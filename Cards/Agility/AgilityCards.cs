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

namespace Cards_Games.Cards.Agility
{
    class AgilityCards
    {
        public static void MakeAgilityCards()
        {

            RPGCard sap = new RPGCard("Assassin", 0, "Sap", 3, 1,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Enemy, 5, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Enemy, StatusEnum.StrengthAdj, -15, 10, 1, AttackType.StatModify, false, false, true),
                    new StatusEffect(Target.Enemy, StatusEnum.AgilityAdj, -15, 10, 1, AttackType.StatModify, false, false, true)
                },
                "strikes at a weak spot on ",
                new List<string> { "Stomp your hooves on the ground",
                                    "stunning them for 1 attack in the next 5 rounds" },
                "wings");

            CardLibrary.Library.Add("Sap", sap);

            RPGCard slash = new RPGCard("Generic", 0, "Slash", 4, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 4, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>(),
                "Slashes at ",
                new List<string> { "Hit a single enemy for 4 slashing dmg" },
                "none");

            CardLibrary.Library.Add("Slash", slash);

            RPGCard doubleStrike = new RPGCard("Generic", 0, "Double Strike", 4, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 4, AttackType.Slashing, CardResource.Health),
                    new DamageEffect(Target.Enemy, 4, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>(),
                "Slashes twice at ",
                new List<string> { "Strike an enemy twice for 4 slashing dmg" },
                "none");

            CardLibrary.Library.Add("Double Strike", doubleStrike);

            RPGCard agileStrike = new RPGCard("Assassin", 0, "Agile Strike", 5, 1,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Enemy, 7, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Self, StatusEnum.AgilityAdj, 15, 10, 1, AttackType.StatModify, false, false, true)
                },
                "strikes ",
                new List<string> { "Focus yourself increases your agility by 15 for 10 rounds",
                                    "and striking your enemy for 7 slashing damage" },
                "wings");

            CardLibrary.Library.Add("Agile Strike", agileStrike);
        }
    }
}
