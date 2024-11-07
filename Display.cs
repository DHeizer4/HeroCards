using Cards_Games.Models;
using Cards_Games.Players;
using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class Display
    {
        private static XYLocation Team1Display = new XYLocation() { XLocation = 0, YLocation = 0 };
        private static XYLocation Team2Display = new XYLocation() { XLocation = 139, YLocation = 0 };
        private static XYLocation BattleBoxDisplay = new XYLocation() { XLocation = 0, YLocation = 26 };
        private static XYLocation infoBoxDisplay = new XYLocation() { XLocation = 0, YLocation = 41 };
        private static XYLocation DialogBoxLocation = new XYLocation() { XLocation = 30, YLocation = 6 };

        public static void GameInfo(int turn)
        {
            Console.SetCursorPosition(infoBoxDisplay.XLocation, infoBoxDisplay.YLocation);
            Console.WriteLine($"Turn: {turn}");
        }

        public static void BattleActionGrid(List<RPGAction> battleActions, int currentTurnNumber)
        {
            int xCoord = BattleBoxDisplay.XLocation;
            int yCoord = BattleBoxDisplay.YLocation;
            int turnIncrement = 0;
            int yIncrement = 0;
            int xSpacing = 25;
            int turnAmount = 6;

            Display.ClearBattleBox(xCoord, yCoord, xSpacing, turnAmount);
            Display.BattleBox(xCoord, yCoord, xSpacing, turnAmount);
            xCoord = xCoord + 1;
            for (turnIncrement = 1; turnIncrement <= turnAmount; turnIncrement++)
            {
                yIncrement = 0;
                Console.SetCursorPosition(xCoord + (turnIncrement - 1) * xSpacing, yCoord - 1);
                Display.BattleTurn(currentTurnNumber + turnIncrement);
                foreach (RPGAction action in battleActions)
                {
                    if (action.When == turnIncrement + currentTurnNumber)
                    {
                        Console.SetCursorPosition(xCoord + (turnIncrement - 1) * xSpacing, yCoord + yIncrement);
                        Console.WriteLine($"{action.Actor.Name} {action.Card.Name} {action.ActedUpon.Name}");
                        yIncrement++;
                    }
                }
            }
        }

        public static void ClearBattleBox(int xCoord, int yCoord, int xSpacing, int turns)
        {
            string blanks = string.Empty;
            Console.SetCursorPosition(xCoord, yCoord - 2);

            for (int x = 0; x < turns * xSpacing; x++)
            {
                blanks = blanks + " ";
            }

            for (int y = 0; y < 14; y++)
            {
                Console.WriteLine(blanks);
            }
        }

        public static void BattleBox(int xCoord, int yCoord, int xSpacing, int turns)
        {
            //Top Line
            Console.SetCursorPosition(xCoord, yCoord - 2);
            for (int x = 0; x < turns * xSpacing; x++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(xCoord, yCoord - 2 + 12);
            for (int x = 0; x < turns * xSpacing; x++)
            {
                Console.Write("-");
            }
            for (int x = 0; x < turns; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    Console.SetCursorPosition(xCoord + x * xSpacing, yCoord - 1 + y);
                    Console.Write("|");
                }
            }

        }

        public static void BattleTurn(int turnNumber)
        {
            Console.WriteLine($"Turn: {turnNumber}");
        }

        public static void InvalidChoice()
        {
            Console.WriteLine("That was not a valid option");
        }

        public static void Players(List<IRPGPlayer> players)
        {
            Console.SetCursorPosition(0, 0);
            var team1 = new List<IRPGPlayer>();
            var team2 = new List<IRPGPlayer>();

            foreach (IRPGPlayer player in players)
            {
                if (player.Team == 1)
                {
                    team1.Add(player);
                }
                else if (player.Team == 2)
                {
                    team2.Add(player);
                }
            }

            DisplayTeam(team1, Team1Display);
            DisplayTeam(team2, Team2Display);
        }

        public static void DisplayTeam(List<IRPGPlayer> players, XYLocation location)
        {
            int offset = 0;
            int yHeight = players.Count * 5;

            foreach (IRPGPlayer player in players)
            {
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"                  ");
                offset += 2;
            }

            offset = 0;
            foreach (IRPGPlayer player in players)
            {
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Name: {player.Name}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Health: {player.Health} / {player.MaxHealth}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Mana: {player.Mana} / {player.MaxMana}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Strength: {player.Strength}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Interllect: {player.Intellect}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Armor: {player.Armor}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Time: {player.Time}");
                foreach (Status status in player.Statuses)
                {
                    Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                    Console.WriteLine($"{status.StatusType.ToString()} Duration {status.Duration} Amount {status.Amount}");
                }
                offset += 2;
            }
        }

        public static void SimpleDialogBox(List<String> LinesOfDialog)
        {
            int yOffset = 0;
            LinesOfDialog.Add("");
            LinesOfDialog.Add("Press Enter to continue...");

            ClearDialogBox(LinesOfDialog);
            foreach (String line in LinesOfDialog)
            {
                Console.SetCursorPosition(DialogBoxLocation.XLocation, DialogBoxLocation.YLocation + yOffset);
                Console.WriteLine(line);
                yOffset++;
            }
            Console.ReadLine();
            ClearDialogBox(LinesOfDialog);
        }

        public static int DialogWithInput(string header, List<String> ListOfChoices, string Prompt)
        {
            int yOffset = 0;
            int i = 1;
            List<string> FullDialog = new List<string>();
            if (!string.IsNullOrEmpty(header))
            {
                FullDialog.Add(header);
            }

            foreach (String choice in ListOfChoices)
            {
                FullDialog.Add($"   {choice}");
            }
            FullDialog.Add(Prompt + "  ");
            FullDialog.Add("That was not a valid option");

            ClearDialogBox(FullDialog);

            if (!string.IsNullOrEmpty(header))
            {
                Console.SetCursorPosition(DialogBoxLocation.XLocation, DialogBoxLocation.YLocation + yOffset);
                Console.WriteLine(header);
                yOffset++;
            }

            foreach (String line in ListOfChoices)
            {
                Console.SetCursorPosition(DialogBoxLocation.XLocation, DialogBoxLocation.YLocation + yOffset);
                Console.WriteLine($"{i}: {line}");
                yOffset++;
                i++;
            }

            XYLocation inputLocation = new XYLocation() { XLocation = DialogBoxLocation.XLocation, YLocation = DialogBoxLocation.YLocation + yOffset };
            int response = UserInput.GetListOption(Prompt, ListOfChoices.Count, inputLocation);
            ClearDialogBox(FullDialog);
            return response;
        }


        private static void ClearDialogBox(List<String> LinesOfDialog)
        {
            int yOffset = 0;

            foreach (String line in LinesOfDialog)
            {
                string blanks = new string(' ', line.Length);
                Console.SetCursorPosition(DialogBoxLocation.XLocation, DialogBoxLocation.YLocation + yOffset);
                Console.WriteLine(blanks);
                yOffset++;
            }
        }

    }
}
