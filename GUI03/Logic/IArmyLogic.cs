using System.Collections.Generic;

namespace GUI03.Logic
{
    public interface IArmyLogic
    {
        int AllCost { get; }
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToArmy(ArmyUnit trooper);
        void AddSuperHero(ArmyUnit trooper);
        void RemoveFromArmy(ArmyUnit trooper);
        void SetupCollections(IList<ArmyUnit> barracks, IList<ArmyUnit> army);
    }
}