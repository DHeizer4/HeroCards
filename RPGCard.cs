using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;

namespace Cards_Games
{
    public enum AttackType { Piercing, Slashing, Bludgedeon, Fire, Ice, Electric, Heal, ManaModify}
    public enum CardResource { Health, Time, Mana}
    public enum Target { Self, Party, Ally, Enemy, AllEnemys, All}

    class RPGCard
    {
        public string CardType { get; set; }
        public string Name { get; set; }
        public CardResource Resource { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Duration { get; set; }  // item lasts for x turns
        public int Durability { get; set; }  // item can be used x times
        public int Speed { get; set; }
        public AttackType AttackType { get; set; }
        public Target Target { get; set; }
        public int Level { get; set; }
        public string Phrase { get; set; }
        public static Dictionary<string, RPGCard> Library = new Dictionary<string, RPGCard>();

        public RPGCard(string cardtype, int alevel, string name, CardResource resource, int cost,  int attack, int aduration ,int speed, AttackType Atype, Target target, string aphrase)
        {
            CardType = cardtype;
            Level = alevel;
            Name = name;
            Attack = attack;
            Duration = aduration;
            Speed = speed;
            AttackType = Atype;
            Target = target;
            Cost = cost;
            Resource = resource;
            Phrase = aphrase;
        }

        public static List<RPGCard> StartList()
        {
            List<RPGCard> start = new List<RPGCard>();
            start.Add(RPGCard.Library["0 Heal"]);
            start.Add(RPGCard.Library["0 Burn"]);
            start.Add(RPGCard.Library["2 Group Heal"]);
            start.Add(RPGCard.Library["1 Cleave"]);
            start.Add(RPGCard.Library["P Mana Potion"]);
            for (int i = 0; i < 12; i++)
            {
                start.Add(RPGCard.Library["0 Punch"]);
            }
            return start;
        }


        public override string ToString()
        {
            return $"{Name}";
        }

        public static void MakeLibrary()
        {
            Library.Add("0 Punch", new RPGCard("Generic", 0, "Punch",  CardResource.Time, 0, 2, 1, 2, AttackType.Bludgedeon, Target.Enemy,"punches "));
            Library.Add("0 Heal", new RPGCard("Cleric", 0, "Heal", CardResource.Mana, 1, -3, 1, 3, AttackType.Heal, Target.Ally, "uses the power of light to heal "));
            Library.Add("4 Cataclysm", new RPGCard("Mage", 0, "Cataclysm", CardResource.Mana, 5, 10, 3, 5, AttackType.Fire, Target.All, "splits the earth and lava erupts burning "));
            Library.Add("2 Group Heal", new RPGCard("Cleric", 0, "Group Heal", CardResource.Mana, 5, -2, 1, 3, AttackType.Heal,Target.Party, "causes light to shine on his allies healing "));
            Library.Add("1 Cleave", new RPGCard("Warrior", 0, "Cleave", CardResource.Time, 2, 3, 1, 2, AttackType.Slashing, Target.AllEnemys, "swings his weapon cleaving "));
            Library.Add("P Mana Potion", new RPGCard("Generic", 0, "Mana Potion", CardResource.Time, 0, 5, 1, 1, AttackType.ManaModify, Target.Self, "drinks the potion and gain mana"));
            Library.Add("0 Burn", new RPGCard("Mage", 0, "Burn", CardResource.Mana, 1, 1, 3, 2, AttackType.Fire, Target.Enemy, "burns"));




        }




    }
}
