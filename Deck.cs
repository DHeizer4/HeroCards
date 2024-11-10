using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class Deck
    {
        private List<RPGCard> _cards;
        private string _name;

        public Deck(string deckname, List<RPGCard> cards)
        {
            _name = deckname;
            _cards = cards;
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
            for(int i = 0; i< deckindex; i++)
            {
                templist.Add(_cards[i]);
            }
            templist.Add(card);
            for (int i = deckindex; i < count; i++)
            {
                templist.Add(_cards[i]);
            }
            _cards.Clear();
            for(int i = 0; i <= count; i++)
            {
                _cards.Add(templist[i]);
            }
        }

    }

}
