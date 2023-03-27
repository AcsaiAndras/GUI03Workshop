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
        public string name;

        public int strength;

        public int vitality;

        public int value;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value.ToString();
                OnPropertyChanged();
            }
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
