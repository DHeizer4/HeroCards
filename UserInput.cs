using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class UserInput
    {
        public static int GetListOption(string prompt, int listLength, XYLocation location)
        {            
            bool isValid;
            bool inRange;
            int choice = 0;

            while (true)
            {
                Console.SetCursorPosition(location.XLocation, location.YLocation);
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
                        Console.CursorLeft = location.XLocation;
                        Display.InvalidChoice();
                    }
                }
                else
                {
                    Console.CursorLeft = location.XLocation;
                    Display.InvalidChoice();
                }
            }
        }


    }
}
