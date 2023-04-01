using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<ArmyUnit> barrack = new ObservableCollection<ArmyUnit>()
        {
                new ArmyUnit() { Name = "mariner", Strength = 8, Vitality = 7, Value = 7 },
                new ArmyUnit() { Name = "sniper", Strength = 8, Vitality = 5, Value = 7  },
                new ArmyUnit() { Name = "pilot", Strength = 4, Vitality = 3, Value = 4  },
                new ArmyUnit() { Name = "engineer", Strength = 5, Vitality = 6, Value = 8  },
                new ArmyUnit() { Name = "infantry", Strength = 6, Vitality = 8, Value = 10  }

        };

        public ArmyUnit SelectedUnitBarrack { get; set; }

        public ArmyUnit SelectedUnitArmy { get; set; }

        public ObservableCollection<ArmyUnit> Barracks { get => barrack; set => barrack = value; }

        public ObservableCollection<ArmyUnit> army = new ObservableCollection<ArmyUnit>();


        public ObservableCollection<ArmyUnit> Army { get => army; set => army = value; }
        
            
            

        private int money { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;





        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            army.Add(SelectedUnitBarrack);
            //money += SelectedUnitArmy.value;
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            army.Remove(SelectedUnitArmy);
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            new EditWindow(SelectedUnitArmy).ShowDialog();
        }
    }
}
