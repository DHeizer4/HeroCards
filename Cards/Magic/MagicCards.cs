using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Cards.Magic
{
    class MagicCards
    {
        public static void MakeMagicCards()
        {

            RPGCard fireBreath = new RPGCard("Dragon", 0, "Fire Breath", 7, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 10)
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.AllEnemys, StatusEnum.Burning, 5, 20, 5, AttackType.Fire, false, true, false)
                },
                "opens his mouth blowing fire at all his enemies ",
                new List<string> { "sets all enemies on fire for 20 turns", "doing 5 fire damage to them every 5 turns" },
                "Dragon");

            CardLibrary.Library.Add("Fire Breath", fireBreath);

            RPGCard burn = new RPGCard("Mage", 0, "Burn", 2, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 2)
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Enemy, StatusEnum.Burning, 1, 3, 1, AttackType.Fire, false, true, false)
                },
                "burns ",
                new List<string> { "sets an enemy on fire" },
                "none");

            CardLibrary.Library.Add("Burn", burn);

            RPGCard fireBall = new RPGCard("Mage", 0, "Fireball", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 4)
                },
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Enemy, 5, AttackType.Fire, CardResource.Health)
                },
                new List<StatusEffect>
                {
                    new StatusEffect(Target.AllEnemys, StatusEnum.Burning, 2, 4, 2, AttackType.Fire, false, true, false)
                },
                "casts fireball at ",
                new List<string> { "A fire balls hits one enemy",
                                    "and sets all enemies on fire" },
                "none");

            CardLibrary.Library.Add("FireBall", fireBall);

            RPGCard cataclysm = new RPGCard("Warlock", 0, "Cataclysm", 10, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 10)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.All, 25, AttackType.Fire, CardResource.Health)
                },
                new List<StatusEffect>(),
                "splits the earth and lava erupts burning ",
                new List<string> { "A Fire Attack that deals damage to everyone for 25" },
                "none");

            CardLibrary.Library.Add("Cataclysm", cataclysm);

            RPGCard fireBlade = new RPGCard("Mage", 0, "Fire Blade", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 2)
                },
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Enemy, 4, AttackType.Fire, CardResource.Health),
                    new DamageEffect(Target.All, 4, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>(),
                "conjures a sword of fire and strikes ",
                new List<string> { "you create a sword of fire", "and deal 4 fire damage and", "4 slashing damage to enemy target" },
                "none");

            CardLibrary.Library.Add("Fire Blade", fireBlade);

            RPGCard blazingSpeed = new RPGCard("Mage", 0, "Blazing Speed", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 5)
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.All, StatusEnum.Burning, 1, 3, 1, AttackType.Fire, false, true, false),
                    new StatusEffect(Target.Self, StatusEnum.SpeedAdj, 10, 15, 1, AttackType.None, false, true, true)
                },
                "runs around setting everyone on fire ",
                new List<string> { "you run around applying burning to everyone", "also increeases your speed by 10" },
                "none");

            CardLibrary.Library.Add("Blazing Speed", blazingSpeed);

            RPGCard burningThought = new RPGCard("Mage", 0, "Burning Thought", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 4)
                },
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Enemy, 5, AttackType.Fire, CardResource.Health)
                },
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Enemy, StatusEnum.Burning, 2, 4, 2, AttackType.Fire, false, true, false),
                    new StatusEffect(Target.Self, StatusEnum.IntellectAdj, 10, 20, 1, AttackType.Fire, false, true, true)
                },
                "sears ",
                new List<string> { "Do 5 fire damage to target enemy",
                                    "and sets him on fre for 4 damage over 4 rounds",
                                    "and raise your intyellect by 10"},
                "none");

            CardLibrary.Library.Add("Burning Thought", burningThought);

        }
    }
}
