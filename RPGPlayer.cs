using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cards_Games
{
    abstract class RPGplayer : Player
    {
        public int Time { get; set; }
        public int Health { get; set; }
        public List<RPGCard> Action;
        public Deck decklist;

        public RPGplayer(string aName) : base(aName)
        {

        }

        public override void DisplayPlayer()
        {
            base.DisplayPlayer();
        }

        public abstract RPGCard PlayCard();

    }

    class HumanRPG : RPGplayer
    {
        public List<RPGCard> _hand;
        
        public HumanRPG(string aName) : base(aName)
        {
            decklist = new Deck("Starter Deck", RPGCard.StartList());
            _hand = new List<RPGCard>();
            Action = new List<RPGCard>();
        }

        public void OpeningHand()
        {
            for(int i = 0; i<5; i++)
            {
                _hand.Add((RPGCard)decklist.DealCard());
            }
        }

        public override RPGCard PlayCard()
        {
            int input;
            bool isValid = false;
            DisplayHand();
            while (true)
            {
                Console.Write("What card would you like to play: ");
                isValid = int.TryParse(Console.ReadLine(), out input);

                if (isValid && input > 0 && input < _hand.Count)
                {
                    RPGCard played = _hand[input];
                    _hand.RemoveAt(input);
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

        public void DisplayHand()
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                Console.WriteLine($"{i}: {_hand[i]}");
            }
        }

    }

    class CompTopRPG : RPGplayer
    {
        public List<RPGCard> _hand;
        public CompTopRPG(string aName) : base(aName)
        {
            decklist = new Deck("Starter Deck", RPGCard.StartList());
            _hand = new List<RPGCard>();
            Action = new List<RPGCard>();
        }

        public override RPGCard PlayCard()
        {
            RPGCard played = decklist.DealCard();
            Console.WriteLine($"The computer will be playing {played}");
            return played;
        }

    }

}
