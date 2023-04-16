using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI03.ViewModels
{
    public class ArmyUnitEditorWindowViewModel
    {
        public Superhero Actual { get; set; }

        public void Setup(Superhero armyunit)
        {
            this.Actual = armyunit;
        }

        public ArmyUnitEditorWindowViewModel()
        {
        }
    }
}
