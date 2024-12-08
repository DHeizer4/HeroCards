using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Enumerations
{
    public class TargetEnum
    {
        public enum Target { Self, 
                            Party, 
                            Ally, 
                            Enemy, 
                            AllEnemys, 
                            All,
                            RandomEnemy,
                            RandomAlly,
                            Random,
                            None}
    }
}
