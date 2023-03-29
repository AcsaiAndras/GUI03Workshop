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
        ObservableCollection<ArmyUnit> units;

        public MainWindow()
        {
            InitializeComponent();
            
            units = new ObservableCollection<ArmyUnit>()
            {
                new ArmyUnit(){Name = "mariner", Strength=8, Vitality=7, Value=7 },
                new ArmyUnit(){Name = "sniper", Strength=8, Vitality=5, Value=7  },
                new ArmyUnit(){Name = "pilot", Strength=4, Vitality=3, Value=4  },
                new ArmyUnit(){Name = "engineer", Strength=5, Vitality=6, Value=8  },
                new ArmyUnit(){Name = "infantry", Strength=6, Vitality=8, Value=10  }
            };

            lbox.ItemsSource = units;
            
        }
    }
}
