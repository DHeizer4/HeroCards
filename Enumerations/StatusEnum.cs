using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Enumerations
{
    public class StatusEnumeration
    {
        public enum StatusEnum { Taunting, // cards being played aka limits the targeting
                            Redirecting,  // actions already played to be redirected to this charater
                            Burning, 
                            Stunned, 
                            Enraged, 
                            Bezerk, 
                            Strengthen, 
                            SuperSpeed, // Time ticks faster for player 
                            Slow,    // Slow down time for a player 
                            Poisoned,
                            Death}   


    }
}
