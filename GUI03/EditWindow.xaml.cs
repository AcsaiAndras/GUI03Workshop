using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GUI03
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ArmyUnit unit { get; set; }

        public EditWindow(ArmyUnit unit)
        {
            InitializeComponent();
            this.unit = unit;
            lb_name.Content = unit.Name;
            lb_strength.Content = unit.Strength;
            lb_vitality.Content = unit.Vitality;
            lb_value.Content = unit.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            unit.Strength = int.Parse(tb_strength.ToString());
            unit.Vitality = int.Parse(tb_vitality.ToString());
            unit.Value = int.Parse(tb_value.ToString());
        }
    }
}
