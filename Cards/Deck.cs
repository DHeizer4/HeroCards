using System;
using System.Collections.Generic;

namespace Cards_Games.Cards
{
    class Deck
    {
        private List<RPGCard> _cards;
        private List<RPGCard> _discard;
        private string _name;

        public Deck(string deckname, List<RPGCard> cards)
        {
            _name = deckname;
            _cards = cards;
            _discard = new List<RPGCard>();
        }

        public string GetDeckName()
        {
            return _name;
        }

        public void DisplayDeck()
        {
            foreach (RPGCard thiscard in _cards)
            {
                Console.WriteLine(thiscard);
            }
        }

        public void RandomShuffle(int times)
        {
            for (int timeIndex = 0; timeIndex < times; timeIndex++)
            {
                Random rand = new Random();
                Queue<RPGCard> Shuffled = new Queue<RPGCard>();
                int movement = rand.Next(2, 7);
                for (int currentCardIndex = movement; _cards.Count > 0; currentCardIndex = currentCardIndex + movement)
                {
                    while (currentCardIndex >= _cards.Count)
                    {
                        currentCardIndex = currentCardIndex % _cards.Count;
                    }
                    Shuffled.Enqueue(_cards[currentCardIndex]);
                    _cards.RemoveAt(currentCardIndex);
                }
                foreach (RPGCard nextcard in Shuffled)
                {
                    _cards.Add(nextcard);
                }
            }
        }

        public RPGCard DealCard()
        {

            RPGCard top = _cards[0];
            _cards.RemoveAt(0);
            return top;
        }

        public void Discard(RPGCard card)
        {
            _discard.Add(card);
        }

        public void ShuffleDiscardIntoDeck()
        {
            foreach (RPGCard card in _discard) 
            {
                _cards.Add(card);
            }

        }

        public int Count()
        {
            return _cards.Count;
        }
        public void AddCard(RPGCard card)
        {
            _cards.Add(card);
        }

        public void PutCardinDeck(RPGCard card, int deckindex)
        {
            List<RPGCard> templist = new List<RPGCard>();
            int count = _cards.Count;
            for (int i = 0; i < deckindex; i++)
            {
                templist.Add(_cards[i]);
            }
            templist.Add(card);
            for (int i = deckindex; i < count; i++)
            {
                templist.Add(_cards[i]);
            }
            _cards.Clear();
            for (int i = 0; i <= count; i++)
            {
                _cards.Add(templist[i]);
            }
        }

        public static List<Deck> GetStarterDecks()
        {
            List<Deck> starterDecks = new List<Deck>();

            starterDecks.Add(AgilityDeck());
            starterDecks.Add(StrengthDeck());
            starterDecks.Add(FireMageDeck());

            return starterDecks;
        }

        public static Deck FireMageDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();

            decklist.Add(CardLibrary.Library["Fire Breath"]);
            decklist.Add(CardLibrary.Library["Burning Thought"]);
            decklist.Add(CardLibrary.Library["FireBall"]);
            decklist.Add(CardLibrary.Library["Blazing Speed"]);
            decklist.Add(CardLibrary.Library["Cataclysm"]);
            decklist.Add(CardLibrary.Library["Fire Blade"]);
            decklist.Add(CardLibrary.Library["Mana Potion"]);
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(CardLibrary.Library["Burn"]);
            }
            return new Deck("Fire Magic based starter", decklist);
        }

        public static Deck AgilityDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();

            decklist.Add(CardLibrary.Library["Lightning Dance"]);
            decklist.Add(CardLibrary.Library["Harden"]);
            decklist.Add(CardLibrary.Library["Empowering Roar"]);
            decklist.Add(CardLibrary.Library["Agile Strike"]);
            decklist.Add(CardLibrary.Library["Double Strike"]);
            decklist.Add(CardLibrary.Library["Sap"]);
            decklist.Add(CardLibrary.Library["Health Potion"]);
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(CardLibrary.Library["Slash"]);
            }
            return new Deck("Agility based starter", decklist);
        }

        public static Deck StrengthDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();

            decklist.Add(CardLibrary.Library["Slam"]);
            decklist.Add(CardLibrary.Library["Harden"]);
            decklist.Add(CardLibrary.Library["Empowering Roar"]);
            decklist.Add(CardLibrary.Library["War Stomp"]);
            decklist.Add(CardLibrary.Library["Cleave"]);
            decklist.Add(CardLibrary.Library["Empowering Strike"]);
            decklist.Add(CardLibrary.Library["Greater Health Potion"]);
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(CardLibrary.Library["Punch"]);
            }

            return new Deck("Strength based Starter", decklist);
        }

        public static Deck GoblinBruiserDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(CardLibrary.Library["Empowering Roar"]);
                decklist.Add(CardLibrary.Library["Slam"]);
                decklist.Add(CardLibrary.Library["Slam"]);
            }

            return new Deck("GoblinBruiser", decklist);
        }

        public static Deck GoblinScoutDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();
            for (int i = 0; i < 12; i++)
            {
                decklist.Add(CardLibrary.Library["Empowering Roar"]);
                decklist.Add(CardLibrary.Library["Cleave"]);
                decklist.Add(CardLibrary.Library["Cleave"]);
            }

            return new Deck("GoblinScout", decklist);
        }

        public static Deck FireDragonDeck()
        {
            List<RPGCard> decklist = new List<RPGCard>();
            for (int i = 0; i < 5; i++)
            {
                decklist.Add(CardLibrary.Library["Empowering Roar"]);
                decklist.Add(CardLibrary.Library["Wing Buffet"]);
                decklist.Add(CardLibrary.Library["Decimating Claw"]);
                decklist.Add(CardLibrary.Library["Fire Breath"]);
                decklist.Add(CardLibrary.Library["Claw Swipe"]);
                decklist.Add(CardLibrary.Library["Burn"]);
            }

            decklist.Add(CardLibrary.Library["Mana Potion"]);
            decklist.Add(CardLibrary.Library["Mana Potion"]);

            return new Deck("FireDragon", decklist);
        }

    }

}
