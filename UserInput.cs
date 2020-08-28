using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class UserInput
    {
        public static int GetListOption(string prompt, int listLength)
        {
            bool isValid;
            bool inRange;
            int choice = 0;

            while (true)
            {
                Console.CursorLeft = 20;
                Console.Write(prompt);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out choice);
                if (isValid)
                {
                    inRange = Validate.ValidateIntInRange(choice, 1, listLength);
                    if (inRange)
                    {
                        return choice;
                    }
                    else
                    {
                        Display.InvalidChoice();
                    }
                }
                else
                {
                    Display.InvalidChoice();
                }
            }
        }


    }
}
