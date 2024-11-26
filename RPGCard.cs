using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games
{
    class RPGCard
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
        public List<string> Description { get; set; }
        public int ChanceToHit { get; set; }
        public int When { get; set; }
        public string Limitation { get; set; }


        public static Dictionary<string, RPGCard> Library = new Dictionary<string, RPGCard>();

        public RPGCard(string cardtype, int alevel, string name, int speed, int durability, List<Cost> costs, List<DamageEffect> damageEffects, List<StatusEffect> statusEffects, string aphrase, List<string> description, string limitation)
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
            Description = description;
            Limitation = limitation;
        }

        public static List<RPGCard> StartList()
        {
            List<RPGCard> start = new List<RPGCard>();
            start.Add(RPGCard.Library["Bulwark"]);
            start.Add(RPGCard.Library["Heal"]);
            start.Add(RPGCard.Library["Empowering Roar"]);
            start.Add(RPGCard.Library["Burn"]);
            start.Add(RPGCard.Library["FireBall"]);
            start.Add(RPGCard.Library["Cleave"]);
            start.Add(RPGCard.Library["Mana Potion"]);
            for (int i = 0; i < 12; i++)
            {
                start.Add(RPGCard.Library["Punch"]);
            }
            return start;
        }

        public static Deck GoblinScoutDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(RPGCard.Library["Empowering Roar"]);
                decklist.Add(RPGCard.Library["Cleave"]);
                decklist.Add(RPGCard.Library["Cleave"]);
            }

            return new Deck("GoblinScout", decklist);
        }

        public static Deck GoblinBruiserDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(RPGCard.Library["Empowering Roar"]);
                decklist.Add(RPGCard.Library["Slam"]);
                decklist.Add(RPGCard.Library["Slam"]);
            }

            return new Deck("GoblinBruiser", decklist);
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
                    new DamageEffect(Target.Enemy, 2, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "punches ",
                new List<string> { "punch an emeny for 2 bludgeoning dmg" },
                "none");

            RPGCard slam = new RPGCard("Generic", 0, "Slam", 6, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 6, AttackType.Bludgeon, CardResource.Health)
                },
                new List<StatusEffect>(),
                "Slams his fist into ",
                new List<string> { "Hit a single enemy for 6 bludgeoning dmg" },
                "none");

            RPGCard slash = new RPGCard("Generic", 0, "Slash", 4, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.Enemy, 4, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>(),
                "Slashes at ",
                new List<string> { "Hit a single enemy for 4 slashing dmg" },
                "none");


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

            RPGCard cleave = new RPGCard("Warrior", 0, "Cleave", 5, 1,
                new List<Cost>(),
                new List<DamageEffect> {
                    new DamageEffect(Target.AllEnemys, 3, AttackType.Slashing, CardResource.Health)
                },
                new List<StatusEffect>(),
                "swings his weapon cleaving ",
                new List<string> { "attack that hits all enemies for 3 slashing dmg" },
                "none");

            RPGCard manaPotion = new RPGCard("Generic", 0, "Mana Potion", 1, 4,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -10, AttackType.StatModify, CardResource.Mana)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains mana",
                new List<string> { "restores 10 mana" },
                "none");

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
                new List<string> { "A fire balls hits one enemy and sets all enemies on fire" },
                "none");

            RPGCard empoweringRoar = new RPGCard("Warrior", 0, "Empowering Roar", 1, 1,
                new List<Cost>(),
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Party, StatusEnum.StrengthAdj, 10, 10, 1, AttackType.StatModify, false, false, true),
                    new StatusEffect(Target.Party, StatusEnum.AgilityAdj, 10, 10, 1, AttackType.StatModify, false, false, true)
                },
                "roars strengthening ",
                new List<string> { "Increases Strength and Agility by 10 for you and all your allies" },
                "none");

            RPGCard bulwark = new RPGCard("Tank", 0, "Bulwark", 2, 1,
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
                new List<string> { "Shield you and your allies for 20% of your health for 5 turns" },
                "Minotaur");

            RPGCard insultingShout = new RPGCard("Tank", 0, "Insulting Shout", 1, 1,
                new List<Cost>(),
                new List<DamageEffect>(),
                new List<StatusEffect>
                {
                    new StatusEffect(Target.Self, StatusEnum.Taunting, 50, 10, 1, AttackType.StatModify, true, true, true),
                    new StatusEffect(Target.Self, StatusEnum.Redirecting, 2, 10, 1, AttackType.StatModify, false, true, true)
                },
                "Shouts loudly drawing the enemies attention ",
                new List<string> { "For the next 10 rounds new cards that only target 1 enemy targets you", 
                                    "and the next 2 cards that do not target are redirected to you " },
                "none");





            Library.Add("Punch", punch);
            Library.Add("Heal", heal);
            Library.Add("Group Heal", groupHeal);
            Library.Add("Cataclysm", cataclysm);
            Library.Add("Cleave", cleave);
            Library.Add("Mana Potion", manaPotion);
            Library.Add("Burn", burn);
            Library.Add("FireBall", fireBall);
            Library.Add("Empowering Roar", empoweringRoar);
            Library.Add("Bulwark", bulwark);
            Library.Add("Slam", slam);
            Library.Add("Slash", slash);
            Library.Add("Insulting Shout", insultingShout);
        }




    }
}
