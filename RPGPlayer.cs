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
        List<RPGCard> Action { get; set; }
        Deck Decklist { get; set; }
        List<RPGCard> Hand { get; set; }


        void OpeningHand();
        void DisplayPlayer();
        RPGCard PlayCard();

    }

    class HumanRPG : IRPGPlayer
    {
        public string Name { get; set; }
        public int Team { get; set; }
        public int Time { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }

        public HumanRPG(string aName)
        {
            Name = aName;
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
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }
        
        public CompTopRPG(string aName)
        {
            Name = aName;
            Health = 10;
            Decklist = new Deck("Starter Deck", RPGCard.StartList());
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
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
