using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class ArmyUnit : ObservableObject
    {
        public string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public int strength;

        public int Strength
        {
            get { return strength; }
            set { SetProperty(ref strength, value); }
        }

        public int vitality;

        public int Vitality
        {
            get { return vitality; }
            set { SetProperty(ref vitality, value); }
        }

        public int value;

        public int Value
        {
            get { return value; }
            set { SetProperty(ref value, value); }
        }

        public int Cost
        {
            get
            {
                return vitality * strength;
            }
        }

        public ArmyUnit GetCopy()
        {
            return new ArmyUnit()
            {
                Name = this.Name,
                Strength = this.Strength,
                Vitality = this.Vitality
            };
        }


    }
}
