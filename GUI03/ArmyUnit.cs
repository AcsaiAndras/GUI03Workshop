using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace GUI03
{
    public class ArmyUnit : INotifyPropertyChanged
    {
        public int strength { get; set; }

        public int vitality { get; set; }

        public int value { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                OnPropertyChanged();
            }
        }

        public int Vitality
        {
            get { return vitality; }
            set { vitality = value; OnPropertyChanged(); }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; OnPropertyChanged(); }
        }
    }
}
