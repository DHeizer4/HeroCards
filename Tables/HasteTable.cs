using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Tables
{
    class HasteTable
    {
        public static int GetFactor(int hasteValue)
        {
            int hasteFactor = 0;

            if (hasteValue <= 16)
            {
                hasteFactor = 1;
            }
            else if (hasteValue <= 32)
            {
                hasteFactor = 2;
            }
            else if (hasteValue <= 64)
            {
                hasteFactor = 3;
            }
            else if (hasteValue <= 128)
            {
                hasteFactor = 4;
            }

            return hasteFactor;
        }
    }
}
