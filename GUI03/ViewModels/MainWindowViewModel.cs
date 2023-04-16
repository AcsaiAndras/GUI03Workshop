using GUI03.Logic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI03.ViewModels
{
    
    public class MainWindowViewModel : ObservableRecipient
    {
        public static ObservableCollection<Superhero> Barrack { get; set; }

        IArmyLogic logic;

        public ObservableCollection<Superhero> Army { get; set; }

        public Superhero selectedFromBarracks;

        public Superhero SelectedFromBarracks
        {
            get { return selectedFromBarracks; }
            set
            {
                SetProperty(ref selectedFromBarracks, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (AddSuperHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public Superhero newArmyUnit;

        public Superhero NewArmyUnit
        {
            get { return newArmyUnit; }
            set
            {
                SetProperty(ref newArmyUnit, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (AddSuperHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Superhero selectedFromArmy;

        public Superhero SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand AddSuperHeroCommand { get; set; }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {
        }

        public MainWindowViewModel(IArmyLogic logic)
        {
            this.logic = logic;
            Barrack = new ObservableCollection<Superhero>();
            Army = new ObservableCollection<Superhero>();

            if (File.Exists("superheros.json"))
            {
                var superheros = JsonConvert.DeserializeObject<Superhero[]>(File.ReadAllText("superheros.json"));
                superheros.ToList().ForEach(x => Barrack.Add(x));
            }
            logic.SetupCollections(Barrack, Army);

            AddToArmyCommand = new RelayCommand(
                () => logic.AddToArmy(SelectedFromBarracks),
                () => SelectedFromBarracks != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            AddSuperHeroCommand = new RelayCommand(
                () => logic.AddSuperHero(NewArmyUnit),
                () => NewArmyUnit == null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
        }
    }
}
