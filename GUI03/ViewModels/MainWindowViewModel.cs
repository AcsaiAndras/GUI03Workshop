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
        public static ObservableCollection<ArmyUnit> Barrack { get; set; }


        IArmyLogic logic;

        //public ObservableCollection<ArmyUnit> Barrack { get; set; }

        public ObservableCollection<ArmyUnit> Army { get; set; }

        public ArmyUnit selectedFromBarracks;

        public ArmyUnit SelectedFromBarracks
        {
            get { return selectedFromBarracks; }
            set
            {
                SetProperty(ref selectedFromBarracks, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (AddSuperHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }




        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>


        










        ////////////////////////////////////////////////



        public ArmyUnit newArmyUnit;

        public ArmyUnit NewArmyUnit
        {
            get { return newArmyUnit; }
            set
            {
                //newArmyUnit = new ArmyUnit();
                SetProperty(ref newArmyUnit, value);
                //Barrack.Add(newArmyUnit);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (AddSuperHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }

        private ArmyUnit selectedFromArmy;

        public ArmyUnit SelectedFromArmy
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


        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }

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
            Barrack = new ObservableCollection<ArmyUnit>();
            Army = new ObservableCollection<ArmyUnit>();

            if (File.Exists("superheros.json"))
            {
                var pizzas = JsonConvert.DeserializeObject<ArmyUnit[]>(File.ReadAllText("superheros.json"));
                pizzas.ToList().ForEach(x => Barrack.Add(x));
            }

            //Barrack.Add(new ArmyUnit()
            //{
            //    Name = "marine",
            //    Strength = 8,
            //    Vitality = 6
            //});
            //Barrack.Add(new ArmyUnit()
            //{
            //    Name = "pilot",
            //    Strength = 7,
            //    Vitality = 3
            //});
            //Barrack.Add(new ArmyUnit()
            //{
            //    Name = "infantry",
            //    Strength = 6,
            //    Vitality = 8
            //});
            //Barrack.Add(new ArmyUnit()
            //{
            //    Name = "sniper",
            //    Strength = 3,
            //    Vitality = 3
            //});
            //Barrack.Add(new ArmyUnit()
            //{
            //    Name = "engineer",
            //    Strength = 5,
            //    Vitality = 6
            //});

            //Army.Add(Barrack[2].GetCopy());
            //Army.Add(Barrack[4].GetCopy());

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
