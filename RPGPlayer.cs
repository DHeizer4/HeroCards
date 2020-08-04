using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cards_Games
{
    interface IRPGPlayer
    {
        string Name { get; set; }
        int Team { get; set; }
        int Time { get; set; }
        int Health { get; set; }
        int Mana { get; set; }
        int Weapon { get; set; }
        int Concentrate { get; set; }
        int Armor { get; set; }
        int Block { get; set; }
        int MagicShield { get; set; }
        List<RPGCard> Action { get; set; }
        Deck Decklist { get; set; }
        List<RPGCard> Hand { get; set; }


        void OpeningHand();
        void DisplayPlayer();
        RPGCard PlayCard();
        IRPGPlayer GetTarget( IRPGPlayer self, List<IRPGPlayer> participants, Target targetType);

    }

    class HumanRPG : IRPGPlayer
    {
        public string Name { get; set; }
        public int Team { get; set; }
        public int Time { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Weapon { get; set; }
        public int Concentrate { get; set; }
        public int Armor { get; set; }
        public int Block { get; set; }
        public int MagicShield { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }

        public HumanRPG(string aName, int aTeam)
        {
            Name = aName;
            Team = aTeam;
            Health = 10;
            Decklist = new Deck("Starter Deck", RPGCard.StartList());
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
        }

        public void DisplayPlayer()
        {
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Health: {Health}   Mana: {Mana}   Time: {Time}");
        }

        public IRPGPlayer GetTarget(IRPGPlayer self, List<IRPGPlayer> participants, Target targetType)
        {
            for (int i = 0; i < participants.Count; i++)
            {
                if (participants[i].Team == self.Team && targetType == Target.Ally)
                {
                    Console.WriteLine($"{i}: Ally  {participants[i].Name}");
                }
                else
                {
                    Console.WriteLine($"{i}: Enemy {participants[i].Name}");
                }
            }
            bool isValid = false;
            int number = -1;
            while (!isValid)
            {
                Console.Write("Please choose a target: ");
                isValid = int.TryParse(Console.ReadLine(), out number);
                if (number < 0 || number > participants.Count - 1)
                {
                    isValid = false;
                }
            }
            return participants[number];
        }

        public RPGCard PlayCard()
        {
            int input;
            bool isValid = false;
            DisplayHand();
            while (true)
            {
                Console.Write("What card would you like to play: ");
                isValid = int.TryParse(Console.ReadLine(), out input);

                if (isValid && input > 0 && input < Hand.Count)
                {
                    RPGCard played = Hand[input];
                    Hand.RemoveAt(input);
                    Console.WriteLine($"{Name} will be playing {played}");
                    return played;
                }
                else
                {
                    Console.WriteLine("That was not a Valid choice");
                    continue;
                }
            }
        }

        public void OpeningHand()
        {
            for (int i = 0; i < 5; i++)
            {
                Hand.Add((RPGCard)Decklist.DealCard());
            }
        }


        public void DisplayHand()
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.WriteLine($"{i}: {Hand[i]}");
            }
        }

    }

    class CompTopRPG : IRPGPlayer
    {
        public string Name { get; set; }
        public int Team { get; set; }
        public int Time { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Weapon { get; set; }
        public int Concentrate { get; set; }
        public int Armor { get; set; }
        public int Block { get; set; }
        public int MagicShield { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }
        
        public CompTopRPG(string aName, int aTeam)
        {
            Name = aName;
            Team = aTeam;
            Health = 10;
            Decklist = new Deck("Starter Deck", RPGCard.StartList());
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
        }

        public IRPGPlayer GetTarget(IRPGPlayer self, List<IRPGPlayer> participants, Target targetType)
        {
            for (int i = 0; i < participants.Count; i++)
            {
                if (participants[i].Team != self.Team && targetType == Target.Enemy)
                {
                    return participants[i];
                }
                else if (participants[i].Team == self.Team && targetType == Target.Ally)
                {
                    return participants[i];
                }
                else
                {
                    return self;
                }
            }
            return self;
        }

        public void OpeningHand()
        {
            for (int i = 0; i < 5; i++)
            {
                Hand.Add((RPGCard)Decklist.DealCard());
            }
        }

        public void DisplayPlayer()
        {
            Console.WriteLine($"Name = {Name}");
            Console.WriteLine($"Health: {Health}   Mana: {Mana}   Time: {Time}");
        }

        public RPGCard PlayCard()
        {
            RPGCard played = Decklist.DealCard();
            Console.WriteLine($"The computer will be playing {played}");
            return played;
        }

    }

}
