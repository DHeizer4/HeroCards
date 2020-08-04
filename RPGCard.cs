using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;

namespace Cards_Games
{
    public enum AttackType { Piercing, Slashing, Bludgedeon, Fire, Ice, Electric, Heal}
    public enum CardResource { Health, Time, Mana}
    public enum Target { Self, Party, Ally, Enemy, AllEnemys, All}

    class RPGCard
    {
        public string CardType { get; set; }
        public string Name { get; set; }
        public CardResource Resource { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Duration { get; set; }
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
            Library.Add("0 Punch", new RPGCard("Generic", 0, "Punch",  CardResource.Time, 0, 2, 1, 2, AttackType.Bludgedeon, Target.Enemy,"hits the opponet with thier fist"));
        }




    }
}
