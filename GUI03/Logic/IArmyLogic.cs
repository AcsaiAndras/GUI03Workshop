using System.Collections.Generic;

namespace GUI03.Logic
{
    public interface IArmyLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToArmy(Superhero trooper);
        void AddSuperHero(Superhero trooper);
        void RemoveFromArmy(Superhero trooper);
        void SetupCollections(IList<Superhero> barracks, IList<Superhero> army);
    }
}