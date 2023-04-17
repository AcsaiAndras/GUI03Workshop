using GUI03.Services;
using GUI03.ViewModels;
using System;
using System.Collections;
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
        public EditWindow(Superhero unit)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Superhero superHero;

            if (tb_name.Text != "" && tb_strength.Text != "" && tb_vitality.Text != "")
            {
                superHero = new Superhero
                {
                    Name = tb_name.Text,

                    Strength = int.Parse(tb_strength.Text),
                    Vitality = int.Parse(tb_vitality.Text),
                };
                if (rb_good.IsChecked == true)
                {
                    superHero.Type = type.Good;
                }
                else if (rb_bad.IsChecked == true)
                {
                    superHero.Type = type.Bad;
                }
                else
                {
                    superHero.Type = type.Neutral;
                }

                MainWindowViewModel.Barrack.Add(superHero);
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Kérem adjon meg minden mezőt");
            }
        }
    }
}
