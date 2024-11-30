using Cards_Games.Models;
using Cards_Games.Players;
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
        public List<IRPGPlayer> Summons { get; set; }
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
        public RPGCard(string cardtype, int alevel, string name, int speed, int durability, List<Cost> costs, List<DamageEffect> damageEffects, List<StatusEffect> statusEffects, List<IRPGPlayer> summons, string aphrase, List<string> description, string limitation)
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
            RPGCard exampleCard = new RPGCard("cardType", 0, "Name", 1, 1,
                new List<Cost>(),
                new List<DamageEffect>(),
                new List<StatusEffect>(),
                "action phrase: a pharse that is said when the card activates",
                new List<string> { "a text a human can read that tells what a card does" },
                "Restrict to a certain race?");

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

            RPGCard healthPotion = new RPGCard("Generic", 0, "Health Potion", 1, 4,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -10, AttackType.StatModify, CardResource.Health)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains Health",
                new List<string> { "restores 10 Health" },
                "none");

            RPGCard greaterHealthPotion = new RPGCard("Generic", 0, "Greater Health Potion", 1, 2,
                new List<Cost>(),
                new List<DamageEffect>
                {
                    new DamageEffect(Target.Self, -20, AttackType.StatModify, CardResource.Health)
                },
                new List<StatusEffect>(),
                "drinks the potion and gains Health",
                new List<string> { "restores 20 Health" },
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
                new List<string> { "A fire balls hits one enemy",
                                    "and sets all enemies on fire" },
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
                new List<string> { "Increases Strength and Agility by 10 for you",
                                    "and all your allies" },
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
                new List<string> { "Shield you and your allies for 20% of your health",
                                    "for 5 turns" },
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
                new List<string> { "For the next 10 rounds",
                                    "new cards that only target 1 enemy targets you",
                                    "and the next 2 cards that would hit an ally",
                                    "are re-directed to you " },
                "none");

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
                "wings");

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
            Library.Add("Health Potion", healthPotion);
            Library.Add("Claw Swipe", clawSwipe);
            Library.Add("Fire Breath", fireBreath);
            Library.Add("Decimating Claw", decimatingClaw);
            Library.Add("Greater Health Potion", greaterHealthPotion);
            Library.Add("Wing Buffet", wingBuffet);

        }




    }
}
