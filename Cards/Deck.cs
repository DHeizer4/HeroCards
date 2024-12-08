using System;
using System.Collections;
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



        public static List<RPGCard> StartList()
        {
            List<RPGCard> start = new List<RPGCard>();
            start.Add(CardLibrary.Library["Lightning Dance"]);
            start.Add(CardLibrary.Library["Harden"]);
            start.Add(CardLibrary.Library["Empowering Roar"]);
            start.Add(CardLibrary.Library["War Stomp"]);
            start.Add(CardLibrary.Library["Double Strike"]);
            start.Add(CardLibrary.Library["Sap"]);
            start.Add(CardLibrary.Library["Greater Health Potion"]);
            for (int i = 0; i < 12; i++)
            {
                start.Add(CardLibrary.Library["Punch"]);
            }
            return start;
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
