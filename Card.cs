using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class Card
    {

        bool faceUp;


        public bool FaceUp
        {
            get
            {
                return faceUp;
            }
            set
            {
                faceUp = value;
            }
        }

        public Card()
        {
            faceUp = false;
        }

        public void FlipCard()
        {
            if (faceUp)
            {
                faceUp = false;
            }
            else
            {
                faceUp = true;
            }
        } 

        public override string ToString()
        {
            return ($"The card is {faceUp}");
        }
    }
}
