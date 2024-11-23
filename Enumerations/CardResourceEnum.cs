using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Enumerations
{
    public class CardResourceEnum
    {
        public enum CardResource
        {
            Health,  // When it reaches 0 player loses can be used to pay for cards
            Time,   // Gain on a turn always use all of it to play a card gain a bonus for extra
            Mana,   // Starts full used to play a card can be replenished
            Energy,  // Only granted by using a card used to pay for other cards
            Shield
        }
    }
}
