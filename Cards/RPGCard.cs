using Cards_Games.Models;
using Cards_Games.Players;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Cards
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

       
    }
}
