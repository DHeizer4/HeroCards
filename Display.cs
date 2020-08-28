using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class Display
    {
        public static void ActionHappens(List<RPGAction> actions, int xCoord, int yCoord)
        {
            int y = 0;
            foreach (RPGAction action in actions)
            {
                Console.SetCursorPosition(xCoord, yCoord + y);
                Console.WriteLine($"{action.Actor.Name} {action.Card.Phrase} {action.ActedUpon.Name}");
                y++;
            }
            
        }

        public static void BattleActionGrid(List<RPGAction> battleActions, int xCoord, int yCoord)
        {
            int turnIncrement = 0;
            int yIncrement = 0;
            int xSpacing = 25;
            int turnAmount = 6;

            Display.BattleBox(xCoord, yCoord, xSpacing, turnAmount);
            xCoord = xCoord + 1;
            for (turnIncrement = 1; turnIncrement <= turnAmount; turnIncrement++)
            {
                yIncrement = 0;
                Console.SetCursorPosition(xCoord + (turnIncrement - 1)*xSpacing, yCoord - 1);
                Display.BattleTurn(turnIncrement);
                foreach (RPGAction action in battleActions)
                {
                    if (action.When == turnIncrement)
                    {
                        Console.SetCursorPosition(xCoord + (turnIncrement - 1)*xSpacing, yCoord + yIncrement);
                        Console.WriteLine($"{action.Actor.Name} {action.Card.Name} {action.ActedUpon.Name}");
                        yIncrement++;
                    }
                }
            }
        }

        public static void BattleBox(int xCoord, int yCoord, int xSpacing, int turns)
        {
            //Top Line
            Console.SetCursorPosition(xCoord, yCoord-2);
            for (int x = 0; x< turns * xSpacing; x++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(xCoord, yCoord - 2 + 12);
            for (int x = 0; x < turns * xSpacing; x++)
            {
                Console.Write("-");
            }
            for (int x = 0; x<turns; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    Console.SetCursorPosition(xCoord + x*xSpacing, yCoord - 1 + y);
                    Console.Write("|");
                }
            }

        }

        public static void BattleTurn(int turnNumber)
        {
            Console.WriteLine($"{turnNumber} turns from now");
        } 

        public static void Delay(int xCoord, int yCoord)
        {
            Console.SetCursorPosition(xCoord, yCoord);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void InvalidChoice()
        {
            Console.CursorLeft = 20;
            Console.WriteLine("That was not a valid option");
        }

        public static void Players(List<IRPGPlayer> players)
        {
            Console.SetCursorPosition(0, 0);
            foreach(IRPGPlayer player in players)
            {
                Console.WriteLine($"Name: {player.Name}\nHealth: {player.Health}\nMana: {player.Mana}\nTime: {player.Time}\n");
            }
        }

        public static void PlayerList(List<IRPGPlayer> players, string header)
        {
            int i = 1;
            Console.CursorLeft = 20;
            Console.WriteLine(header);
            foreach (IRPGPlayer player in players)
            {
                Console.CursorLeft = 20;
                Console.WriteLine($"{i}: {player.Name}");
                i++;
            }
        }

        

    }
}
