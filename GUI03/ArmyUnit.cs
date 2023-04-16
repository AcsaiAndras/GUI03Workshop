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
    public enum type
    {
        Good = 0, Bad = 1, Neutral = 2
    }

    public class Superhero : ObservableObject
    {
        public type Type { get; set; }

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

        public Superhero GetCopy()
        {
            return new Superhero()
            {
                Name = this.Name,
                Strength = this.Strength,
                Vitality = this.Vitality
            };
        }
    }
}
