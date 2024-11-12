using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Enumerations
{
    public class StatusEnumeration
    {
        public enum StatusEnum { Taunting,       // cards being played aka limits the targeting
                            Redirecting,         // actions already played to be redirected to this charater
                            Burning,             // Stackable debuff that does Fire (Magical) dmg at the end of a round
                            Stunned,             // Cannot play a card when stunned 1 round = 1 stunned gone
                            Enraged,             // % Dmg increase
                            Bezerk,              // Chooses Target at random for cards that target
                            Strengthen,          // Increases strength
                            Weakened,            // Decreases strength
                            Enlightened,         // Increases Intellect
                            Perplexed,           // Decreases Intellect
                            Quickened,           // Increases Speed for a player
                            Slowed,              // Decreases Speed for a player
                            Poisoned,            // Debuff that does (Physical) dmg at end of turn
                            Death
        }   


    }
}
