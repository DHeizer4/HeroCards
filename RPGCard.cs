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
    public enum Target { Self, Party, Enemy, AllEnemys, All}

    class RPGCard : Card
    {
        public string CardType { get; set; }
        public string Name { get; set; }
        private CardResource Resource { get; set; }
        private int _cost;
        private int _attack;
        public int Speed { get; set; }
        private AttackType _attacktype;
        private Target _target;
        private int _level;
        private string _phrase;
        public static Dictionary<string, RPGCard> Library = new Dictionary<string, RPGCard>();

        public RPGCard(bool faceup, string cardtype, int alevel, string name, CardResource resource, int cost,  int attack, int speed, AttackType Atype, Target target, string aphrase)
        {
            FaceUp = faceup;
            CardType = cardtype;
            _level = alevel;
            Name = name;
            _attack = attack;
            Speed = speed;
            _attacktype = Atype;
            _target = target;
            _cost = cost;
            Resource = resource;
            _phrase = aphrase;
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
            Library.Add("0 Punch", new RPGCard(true, "Generic", 0, "Punch",  CardResource.Time, 0, 2, 2, AttackType.Bludgedeon, Target.Enemy,"hits the opponet with thier fist"));
        }




    }
}
