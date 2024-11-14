using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Enumerations
{
    public class AttackTypeEnum
    {
        public enum AttackType { Piercing,  // Phyiscal ignore armor
                            Slashing,       // Phyiscal modified by Dex
                            Bludgeon,     // Phyiscal modified by Str
                            Fire,           // Magical
                            Ice,            // Magical
                            Electric,       // Magical
                            Shadow,         // Magical
                            Heal,           // Generic
                            StatModify      // Generic
        }
    }
}
