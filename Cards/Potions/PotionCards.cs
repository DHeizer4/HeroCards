using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Cards.Potions
{
    class PotionCards
    {
        public static void MakePotionCards()
        {
            RPGCard manaPotion = new RPGCard("Potion", 0, "Mana Potion", 1, 4,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -10, AttackType.StatModify, CardResource.Mana)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains mana",
                new List<string> { "restores 10 mana" },
                "none");

            CardLibrary.Library.Add("Mana Potion", manaPotion);

            RPGCard healthPotion = new RPGCard("Potion", 0, "Health Potion", 1, 4,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -10, AttackType.StatModify, CardResource.Health)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains Health",
                new List<string> { "restores 10 Health" },
                "none");

            CardLibrary.Library.Add("Health Potion", healthPotion);

            RPGCard greaterHealthPotion = new RPGCard("Potion", 0, "Greater Health Potion", 1, 2,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -20, AttackType.StatModify, CardResource.Health)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains Health",
                new List<string> { "restores 20 Health" },
                "none");

            CardLibrary.Library.Add("Greater Health Potion", greaterHealthPotion);

        }



    }
}
