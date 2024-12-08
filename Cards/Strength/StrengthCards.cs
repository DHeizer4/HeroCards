using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Cards.Strength
{
    class StrengthCards
    {
        public static void MakeStrengthCards()
        {
            RPGCard punch = new RPGCard("Strength", 0, "Punch", 1, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 2, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "punches ",
                new List<string> { "punch an emeny for 2 bludgeoning dmg" },
                "none");

            CardLibrary.Library.Add("Punch", punch);

            RPGCard slam = new RPGCard("Strength", 0, "Slam", 6, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 6, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "Slams his fist into ",
                new List<string> { "Hit a single enemy for 6 bludgeoning dmg" },
                "none");

            CardLibrary.Library.Add("Slam", slam);

            RPGCard cleave = new RPGCard("Strength", 0, "Cleave", 5, 1,
                new List<Cost>(),
                    new List<DamageEffect> {
                    new DamageEffect(Target.AllEnemys, 3, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "swings his weapon cleaving ",
                new List<string> { "attack that hits all enemies for 3 slashing dmg" },
                "none");

            CardLibrary.Library.Add("Cleave", cleave);

            RPGCard clawSwipe = new RPGCard("Dragon", 0, "Claw Swipe", 4, 1,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.AllEnemys, 5, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "swipes his claw hiting ",
                new List<string> { "an attack that does 5 base dmg to all enemies" },
                "claws");

            CardLibrary.Library.Add("Claw Swipe", clawSwipe);

            RPGCard decimatingClaw = new RPGCard("Dragon", 0, "Decimating Claw", 10, 1,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Enemy, 25, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "opens his mouth blowing fire at all his enemies ",
                new List<string> { "sets all enemies on fire for 20 turns", "doing 5 fire damage to them every 5 turns" },
                "claws");

            CardLibrary.Library.Add("Decimating Claw", decimatingClaw);
        }

    }
}
