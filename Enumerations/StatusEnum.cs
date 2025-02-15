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
                            StrengthAdj,          // Increases strength
                            IntellectAdj,         // Increases Intellect
                            AgilityAdj,               // Increases Agility
                            DexterityAdj,              // Increases Dexterity
                            SpeedAdj,           // Increases Speed for a player
                            HasteAdj,           // Increase Haste
                            Poisoned,            // Debuff that does (Physical) dmg at end of turn
                            Cleanse,             // Remove status from player
                            Shielded,
                            DeadlyWound,         // Healing debuff prevents a percentage of healing
                            Vulnerable,          // Debuff that increases the damager a player takes
                            Slowed,             // Debuff that makes someone cards take longer to play
                            Evasion,            // A chance to avoid a attack
                            LifeStealing,       // % of damage done heals the person doing the dmg
                            Death
        }   


    }
}
