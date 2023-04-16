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
        IList<Superhero> barracks;
        IList<Superhero> army;
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

        public void SetupCollections(IList<Superhero> barracks, IList<Superhero> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddToArmy(Superhero trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper added", "TrooperInfo");
        }

        public void RemoveFromArmy(Superhero trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper removed", "TrooperInfo");
        }

        public void AddSuperHero(Superhero trooper)
        {
            editorService.Edit(trooper);
        }
    }
}

