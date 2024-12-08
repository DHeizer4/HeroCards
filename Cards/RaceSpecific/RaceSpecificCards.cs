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

namespace Cards_Games.Cards.RaceSpecific
{
    class RaceSpecificCards
    {
        public static void MakeRaceSpecificCards()
        {

            RPGCard bulwark = new RPGCard("RaceSpecific", 0, "Bulwark", 2, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Health, 5),
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Party, StatusEnum.Shielded, 20, 5, 1, AttackType.StatModify, true, true, true)
                },
                "Shields ",
                new List<string> { "Shield you and your allies for 20% of your health",
                                    "for 5 turns" },
                "Minotaur");

            CardLibrary.Library.Add("Bulwark", bulwark);

            RPGCard lightingDance = new RPGCard("RaceSpecific", 0, "Lightning Dance", 2, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Time, 10),
                },
                new List<DamageEffect>
                {
                    new DamageEffect(Target.RandomEnemy, 4, AttackType.Slashing, CardResource.Health),
                    new DamageEffect(Target.RandomEnemy, 4, AttackType.Slashing, CardResource.Health),
                    new DamageEffect(Target.RandomEnemy, 4, AttackType.Slashing, CardResource.Health),
                    new DamageEffect(Target.RandomEnemy, 4, AttackType.Slashing, CardResource.Health),
                    new DamageEffect(Target.AllEnemys, 4, AttackType.Electric, CardResource.Health)
                },
                new List<StatusEffect>
                {
                    new StatusEffect(Target.AllEnemys, StatusEnum.Stunned, 1, 3, 1, AttackType.None, false, false, false)
                },
                "disappears in a flash of light striking ",
                new List<string> { "You disappear and move as fast as lightning",
                                    "striking 4 random enemies for 4 dmg",
                                    "and stunning all enemies with electric damage."},
                "Mausian");

            CardLibrary.Library.Add("Lightning Dance", lightingDance);
        }

    }
}
