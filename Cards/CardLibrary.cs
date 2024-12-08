using Cards_Games.Models;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;
using System.Collections.Generic;
using Cards_Games.Cards.Potions;
using Cards_Games.Cards.Agility;
using Cards_Games.Cards.Healing;
using Cards_Games.Cards.Magic;
using Cards_Games.Cards.RaceSpecific;
using Cards_Games.Cards.Strength;
using Cards_Games.Cards.Utility;

namespace Cards_Games.Cards
{
    class CardLibrary
    {
        public static Dictionary<string, RPGCard> Library = new Dictionary<string, RPGCard>();

        public static void MakeLibrary()
        {
            PotionCards.MakePotionCards();
            AgilityCards.MakeAgilityCards();
            HealingCards.MakeHealingCards();
            MagicCards.MakeMagicCards();
            RaceSpecificCards.MakeRaceSpecificCards();
            StrengthCards.MakeStrengthCards();
            UtilityCards.MakeUtilityCards();

            RPGCard exampleCard = new RPGCard("cardType", 0, "Name", 1, 1,
                new List<Cost>(),
                new List<DamageEffect>(),
                new List<StatusEffect>(),
                "action phrase: a pharse that is said when the card activates",
                new List<string> { "a text a human can read that tells what a card does" },
                "Restriction");



        }
    }
}
