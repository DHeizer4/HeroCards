using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Cards.Healing
{
    class HealingCards
    {
        public static void MakeHealingCards()
        {
            RPGCard heal = new RPGCard("Cleric", 0, "Heal", 5, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 2)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.Ally, -7, AttackType.Heal, CardResource.Health)
                },
                new List<StatusEffect>(),
                "uses the power of light to heal ",
                new List<string> { "Heals a single ally for 7" },
                "none");

            CardLibrary.Library.Add("Heal", heal);

            RPGCard groupHeal = new RPGCard("Cleric", 0, "Group Heal", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 6)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.Party, -20, AttackType.Heal, CardResource.Health)
                },
                new List<StatusEffect>(),
                "causes light to shine on his allies healing ",
                new List<string> { "Heals you and all your allies for 20" },
                "none");

            CardLibrary.Library.Add("Group Heal", groupHeal);

            RPGCard healingStorm = new RPGCard("Healing", 0, "Healing Storm", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 6)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.RandomAlly, -4, AttackType.Heal, CardResource.Health),
                    new DamageEffect(Target.RandomAlly, -4, AttackType.Heal, CardResource.Health),
                    new DamageEffect(Target.RandomAlly, -4, AttackType.Heal, CardResource.Health),
                    new DamageEffect(Target.RandomAlly, -4, AttackType.Heal, CardResource.Health)
                },
                new List<StatusEffect>(),
                "calls down bolts of holy energy healing ",
                new List<string> { "Call down 4 bolts of holy energy",
                                    "Healing 4 random allies for 4 health"},
                "none");

            CardLibrary.Library.Add("Healing Storm", healingStorm);

            RPGCard holyShield = new RPGCard("Healing", 0, "Holy Shield", 2, 1,
            new List<Cost>(),
            new List<DamageEffect>(),
            new List<StatusEffect>
            {
                    new StatusEffect(Target.Ally, StatusEnum.Shielded, 25, 5, 1, AttackType.StatModify, true, true, true)
            },
            "Creates a Holy shield around ",
            new List<string> { "Create a Magical shield around an ally",
                                    "that blocks 25 dmg" },
            "none");

            CardLibrary.Library.Add("Holy Shield", holyShield);
        }
    }
}
