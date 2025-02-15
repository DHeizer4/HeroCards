using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Cards.Utility
{
    class UtilityCards
    {
        public static void MakeUtilityCards()
        {

            RPGCard empoweringRoar = new RPGCard("Warrior", 0, "Empowering Roar", 1, 1,
                new List<Cost>(),
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Party, StatusEnum.StrengthAdj, 10, 10, 1, AttackType.StatModify, false, false, true),
                    new StatusEffect(Target.Party, StatusEnum.AgilityAdj, 10, 10, 1, AttackType.StatModify, false, false, true)
                },
                "roars strengthening ",
                new List<string> { "Increases Strength and Agility by 10 for you",
                                    "and all your allies" },
                "none");

            CardLibrary.Library.Add("Empowering Roar", empoweringRoar);

            RPGCard warStomp = new RPGCard("Warrior", 0, "War Stomp", 3, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 5)
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.AllEnemys, StatusEnum.Stunned, 1, 5, 1, AttackType.None, false, false, false)
                },
                "Stomp your hooves stunning enemies ",
                new List<string> { "Stomp your hooves on the ground",
                                    "stunning them for 1 attack in the next 5 rounds" },
                "hoofs");

            CardLibrary.Library.Add("War Stomp", warStomp);

            RPGCard harden = new RPGCard("Tank", 0, "Harden", 2, 1,
            new List<Cost>(),
            new List<DamageEffect>(),
            new List<StatusEffect>
            {
                    new StatusEffect(Target.Self, StatusEnum.Shielded, 25, 5, 1, AttackType.StatModify, true, true, true)
            },
            "Concentrates hardening himself from incoming damage ",
            new List<string> { "You concentrate bracing for incoming damage creating a",
                                    "tempoary shield for 25% of your current health" },
            "none");

            CardLibrary.Library.Add("Harden", harden);

            RPGCard wingBuffet = new RPGCard("Warrior", 0, "Wing Buffet", 3, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 5)
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.AllEnemys, StatusEnum.Stunned, 1, 3, 1, AttackType.None, false, false, false)
                },
                "flaps his wings blowing air at ",
                new List<string> { "Uses your wings to blow your enemies back",
                                    "stunning them for 1 attack in the next 3 rounds" },
                "wings");

            CardLibrary.Library.Add("Wing Buffet", wingBuffet);

            RPGCard insultingShout = new RPGCard("Tank", 0, "Insulting Shout", 1, 1,
                new List<Cost>(),
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Self, StatusEnum.Taunting, 50, 10, 1, AttackType.StatModify, true, true, true),
                    new StatusEffect(Target.Self, StatusEnum.Redirecting, 2, 10, 1, AttackType.StatModify, false, true, true)
                },
                "Shouts loudly drawing the enemies attention ",
                new List<string> { "For the next 10 rounds",
                                    "new cards that only target 1 enemy targets you",
                                    "and the next 2 cards that would hit an ally",
                                    "are re-directed to you " },
                "none");

            CardLibrary.Library.Add("Insulting Shout", insultingShout);


        }

    }
}
