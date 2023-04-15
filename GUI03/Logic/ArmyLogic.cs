using GUI03.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI03.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<ArmyUnit> barracks;
        IList<ArmyUnit> army;
        IMessenger messenger;
        IArmyEditorViaWindow editorService;

        public ArmyLogic(IMessenger messenger, IArmyEditorViaWindow editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public int AllCost
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(t => t.Value);
            }
        }

        public double AVGPower
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Strength), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Vitality), 2);
            }
        }

        public void SetupCollections(IList<ArmyUnit> barracks, IList<ArmyUnit> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddToArmy(ArmyUnit trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper added", "TrooperInfo");
        }

        public void RemoveFromArmy(ArmyUnit trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper removed", "TrooperInfo");
        }

        public void AddSuperHero(ArmyUnit trooper)
        {
            editorService.Edit(trooper);
        }


    }
}

