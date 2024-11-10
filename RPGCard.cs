using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games
{
    public class RPGCard
    {
        public string CardType { get; set; }
        public string Name { get; set; }
        public List<Cost> Costs { get; set; }
        public List<StatusEffect> Effects { get; set; }
        public List<DamageEffect> DamageEffects { get; set; }
        public int Durability { get; set; }  // item can be used x times
        public int Speed { get; set; }
        public int Level { get; set; }
        public string Phrase { get; set; }
        public string Description { get; set; }
        public int ChanceToHit { get; set; }
        public int When { get; set; }


        public static Dictionary<string, RPGCard> Library = new Dictionary<string, RPGCard>();

        public RPGCard(string cardtype, int alevel, string name, int speed, int durability, List<Cost> costs, List<DamageEffect> damageEffects, List<StatusEffect> statusEffects, string aphrase)
        {
            CardType = cardtype;
            Level = alevel;
            Name = name;
            Speed = speed;
            Durability = durability;
            Costs = costs;
            DamageEffects = damageEffects;
            Effects = statusEffects;
            Phrase = aphrase;
        }

        public static List<RPGCard> StartList()
        {
            List<RPGCard> start = new List<RPGCard>();
            start.Add(RPGCard.Library["Heal"]);
            start.Add(RPGCard.Library["Burn"]);
            start.Add(RPGCard.Library["Group Heal"]);
            start.Add(RPGCard.Library["Cleave"]);
            start.Add(RPGCard.Library["Mana Potion"]);
            for (int i = 0; i < 12; i++)
            {
                start.Add(RPGCard.Library["Punch"]);
            }
            return start;
        }

        public static string GetDescription(RPGCard card)
        {
            return "";
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public static void MakeLibrary()
        {
            RPGCard punch = new RPGCard("Generic", 0, "Punch", 1, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 1, AttackType.Bludgedeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "punches");

            RPGCard heal = new RPGCard("Cleric", 0, "Heal", 5, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 2)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.Ally, -7, AttackType.Heal, CardResource.Health)
                },
                new List<StatusEffect>(),
                "uses the power of light to heal ");

            RPGCard cataclysm = new RPGCard("Warlock", 0, "Cataclysm", 10, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 10)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.All, 10, AttackType.Fire, CardResource.Health)
                },
                new List<StatusEffect>(),
                "splits the earth and lava erupts burning ");

            RPGCard groupHeal = new RPGCard("Cleric", 0, "Group Heal", 4, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 6)
                },
                new List<DamageEffect> {
                    new DamageEffect(Target.Party, -20, AttackType.Heal, CardResource.Health)
                },
                new List<StatusEffect>(),
                "causes light to shine on his allies healing ");

            RPGCard cleave = new RPGCard("Warrior", 0, "Cleave", 5, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.AllEnemys, 3, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>(),
                "swings his weapon cleaving ");

            RPGCard manaPotion = new RPGCard("Generic", 0, "Mana Potion", 1, 4,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -10, AttackType.StatModify, CardResource.Mana)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains mana");

            RPGCard burn = new RPGCard("Mage", 0, "Burn", 2, 1,
                new List<Cost>
                {
                    new Cost(CardResource.Mana, 2)
                },
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Enemy, StatusEnum.Burning, 1, 3, 1, AttackType.Fire, false, true)
                },
                "burns ");

            RPGCard fireBall = new RPGCard("Mage", 0, "Burn", 4, 1,
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
                    new StatusEffect(Target.AllEnemys, StatusEnum.Burning, 2, 4, 2, AttackType.Fire, false, true)
                },
                "casts fireball at ");

            Library.Add("Punch", punch);
            Library.Add("Heal", heal);
            Library.Add("Group Heal", groupHeal);
            Library.Add("Cataclysm", cataclysm);
            Library.Add("Cleave", cleave);
            Library.Add("Mana Potion", manaPotion);
            Library.Add("Burn", burn);
            Library.Add("FireBall", fireBall);
        }




    }
}
