using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Cards_Games
{
   
    public enum Stat {Time, Health, Mana, Weapon, Concentrate, Armor, Block, MagicShield }
    
    class RPGAction
    {
        public IRPGPlayer Actor { get; set; }
        public IRPGPlayer ActedUpon { get; set; }
        public bool Original { get; set; }
        public RPGCard Card { get; set; }

        public RPGAction(IRPGPlayer aActor, IRPGPlayer aTarget, bool orgin, RPGCard aCard)
        {
            Actor = aActor;
            ActedUpon = aTarget;
            Original = orgin;
            Card = aCard;
        }
    }


}
