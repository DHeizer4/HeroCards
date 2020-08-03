using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
   
    public enum Stat {Time, Health, Mana, Weapon, Concentrate, Armor, Block, MagicShield }
    
    class RPGAction
    {
        public IRPGPlayer Actor { get; set; }
        public IRPGPlayer Target { get; set; }
        public int Detonation { get; set; }
        public int Amount { get; set; }
        public Stat Modify { get; set; }
        public AttackType Discipline { get; set; }

        public RPGAction(IRPGPlayer aActor, IRPGPlayer aTarget, int aAmount, Stat aModify, AttackType aDiscipline)
        {
            Actor = aActor;
            Target = aTarget;
            Amount = aAmount;
            Modify = aModify;
            Discipline = aDiscipline;
        }
    }


}
