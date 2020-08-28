using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class Validate
    {
        public static bool ValidateIntInRange(int number, int lower, int upper)
        {
            bool confirm = false;
            if (number >= lower && number <= upper)
            {
                confirm = true;
            }
            return confirm;
        }


    }
}
