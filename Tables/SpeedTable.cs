using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Tables
{
    class SpeedTable
    {
        public static int GetFactor(int speedValue)
        {
            int speedFactor = 0;

            if (speedValue <= 16)
            {
                speedFactor = 1;
            }
            else if (speedValue <= 32)
            {
                speedFactor = 2;
            }
            else if (speedValue <= 64)
            {
                speedFactor = 3;
            }
            else if (speedValue <= 128)
            {
                speedFactor = 4;
            }

            return speedFactor;
        }
    }
}
