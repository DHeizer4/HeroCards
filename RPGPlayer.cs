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
        int Speed { get; set; }
        List<RPGCard> Action { get; set; }
        Deck Decklist { get; set; }
        List<RPGCard> Hand { get; set; }


        void OpeningHand();
        RPGCard PlayCard();
        IRPGPlayer GetTarget(List<IRPGPlayer> participants);

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
        public int Speed { get; set; }
        public List<RPGCard> Action { get; set; }
        public Deck Decklist { get; set; }
        public List<RPGCard> Hand { get; set; }

        // Can a caster cast faster than a fighter and vise versa....

        public HumanRPG(string aName, int aTeam)
        {
            Name = aName;
            Team = aTeam;
            Health = 10;
            Decklist = new Deck("Starter Deck", RPGCard.StartList());
            Hand = new List<RPGCard>();
            Action = new List<RPGCard>();
            Speed = 1;
        }

        public IRPGPlayer GetTarget(List<IRPGPlayer> possibleTargets)
        {
            int choice = 0;
            IRPGPlayer target;
            Display.PlayerList(possibleTargets, "The possible targets are...");
            choice = UserInput.GetListOption("Please choose a target: ", possibleTargets.Count);

            target = possibleTargets[choice - 1];
            Console.Clear();
            return target;
        }

        public RPGCard PlayCard()
        {
            int input;
            bool isValid = false;
            DisplayHand(20);
            while (true)
            {
                Console.SetCursorPosition(20, 0);
                Console.Write("What card would you like to play: ");
                isValid = int.TryParse(Console.ReadLine(), out input);

                if (isValid && input >= 0 && input < Hand.Count)
                {
                    RPGCard played = Hand[input];
                    Hand.RemoveAt(input);
                    Console.CursorLeft = 20;
                    Console.WriteLine($"{Name} will be playing {played}");
                    return played;
                }
                else
                {
                    Display.InvalidChoice();
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

        public void DisplayHand(int xCoord)
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.SetCursorPosition(xCoord , i+1);
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
        public int Speed { get; set; }
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
            Speed = 2;
        }

        public IRPGPlayer GetTarget(List<IRPGPlayer> possibleTargets)
        {
            return possibleTargets[0];
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
            Console.CursorLeft = 20;
            Console.WriteLine($"{Name} will be playing {played}");
            return played;
        }

    }

}
