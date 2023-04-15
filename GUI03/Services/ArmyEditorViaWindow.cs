using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI03.Services
{
    public class ArmyEditorViaWindow : IArmyEditorViaWindow
    {
        public void Edit(ArmyUnit armyunit)
        {
            new EditWindow(armyunit).ShowDialog();
        }
    }
}
