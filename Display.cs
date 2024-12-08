using Cards_Games.Cards;
using Cards_Games.Models;
using Cards_Games.Players;
using Cards_Games.Players.PlayerUtilities;
using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class Display
    {
        private static XYLocation Team1Display = new XYLocation() { XLocation = 0, YLocation = 0 };
        private static XYLocation Team2Display = new XYLocation() { XLocation = 139, YLocation = 0 };
        private static XYLocation BattleBoxDisplay = new XYLocation() { XLocation = 0, YLocation = 33 };
        private static XYLocation infoBoxDisplay = new XYLocation() { XLocation = 0, YLocation = 44 };
        private static XYLocation DialogBoxLocation = new XYLocation() { XLocation = 40, YLocation = 4 };
        private static XYLocation CardDisplayBox = new XYLocation() { XLocation = 80, YLocation = 4 };

        public static void GameInfo(int turn)
        {
            Console.SetCursorPosition(infoBoxDisplay.XLocation, infoBoxDisplay.YLocation);
            Console.WriteLine($"Turn: {turn}");
            Console.WriteLine("Version 0.0.1");
        }

        public static bool DisplayCard(RPGCard card)
        {
            bool response = false;
            List<string> linesOfDialog = new List<string>();
            List<string> choices = new List<string>();

            choices.Add("Yes");
            choices.Add("No");

            linesOfDialog.Add($"{card.Name}    cooldown {card.Speed}");
            if (card.Durability > 1)
            {
                linesOfDialog.Add($"Can be used {card.Durability} times.");
            }
            linesOfDialog.Add("Costs:");

            foreach (Cost cost in card.Costs)
            {
                linesOfDialog.Add($"  {cost.Amount.ToString()} {cost.Resource.ToString()}");
            }

            linesOfDialog.Add("Effects");

            foreach (DamageEffect damageEffect in card.DamageEffects)
            {
                linesOfDialog.Add($"  Does {damageEffect.Amount} {damageEffect.AttackType.ToString()} to {damageEffect.Target.ToString()}");
            };

            foreach (StatusEffect status in card.Effects)
            {
                linesOfDialog.Add($"  Places {status.StatusType.ToString()} {status.Amount} for {status.Duration} turns");
            }

            linesOfDialog.Add("");
            foreach( string line in card.Description)
            {
                linesOfDialog.Add(line);
            }
            
            linesOfDialog.Add("");
            string prompt = "Would you like to play this card? ";

            int choice = DialogWithInput(linesOfDialog, choices, prompt, "card");

            if (choice == 1)
            {
                response = true;
            };

            return response;
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
                        if (action.ActedUpon == null)
                        {
                            Console.WriteLine($"{action.Actor.Name} {action.Card.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"{action.Actor.Name} {action.Card.Name} {action.ActedUpon.Name}");
                        }
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
                for (int i = 0; i <= 15; i++)
                {
                    Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                    Console.WriteLine($"                              ");
                    offset += 1;
                }
            }

            offset = 0;
            foreach (IRPGPlayer player in players)
            {
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Name: {player.Name}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);

                float health = player.Health;
                float maxHealth = player.MaxHealth;

                CharacterProperties characterProperties = PlayerProperty.GetCharacterProperties(player);

                float healthpercent = (health / maxHealth) * 100;
                if (healthpercent > 79) { Console.Write($"Health: {Green(player.Health.ToString())} / {player.MaxHealth}"); }
                else if (healthpercent > 20) { Console.Write($"Health: {Orange(player.Health.ToString())} / {player.MaxHealth}"); }
                else { Console.Write($"Health: {Red(player.Health.ToString())} / {player.MaxHealth}"); }
                if (player.Shield > 0)
                {
                    Console.WriteLine($" ( {Orange(player.Shield.ToString())} )");
                }
                else { Console.WriteLine(); }
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Mana: {Blue(player.Mana.ToString())} / {player.MaxMana}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                Console.WriteLine($"Time: {player.Time}");
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                if (characterProperties.Strength < player.Strength) { Console.WriteLine($"Strength: {((int)player.Strength).ToString()} {Red($"-{player.Strength - characterProperties.Strength}")}"); }
                else if (characterProperties.Strength > player.Strength) { Console.WriteLine($"Strength: {((int)player.Strength).ToString()} {Green($"+{characterProperties.Strength - player.Strength}")}"); }
                else { Console.WriteLine($"Strength: {(int)player.Strength}"); }
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                if (characterProperties.Intellect < player.Intellect) { Console.WriteLine($"Intellect: {((int)player.Intellect).ToString()} {Red($"-{player.Intellect - characterProperties.Intellect}")}"); }
                else if (characterProperties.Intellect > player.Intellect) { Console.WriteLine($"Intellect: {((int)player.Intellect).ToString()} {Green($"+{characterProperties.Intellect - player.Intellect}")}"); }
                else { Console.WriteLine($"Intellect: {(int)player.Intellect}"); }
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                if (characterProperties.Agility < player.Agility) { Console.WriteLine($"Agility: {((int)player.Agility).ToString()} {Red($"-{player.Agility - characterProperties.Agility}")}"); }
                else if (characterProperties.Agility > player.Agility) { Console.WriteLine($"Agility: {((int)player.Agility).ToString()} {Green($"+{characterProperties.Agility - player.Agility}")}"); }
                else { Console.WriteLine($"Agility: {(int)player.Agility}"); }
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                if (characterProperties.Dexterity < player.Dexterity) { Console.WriteLine($"Dexterity: {((int)player.Dexterity).ToString()} {Red($"-{player.Dexterity - characterProperties.Dexterity}")}"); }
                else if (characterProperties.Dexterity > player.Dexterity) { Console.WriteLine($"Dexterity: {((int)player.Dexterity).ToString()} {Green($"+{characterProperties.Dexterity - player.Dexterity}")}"); }
                else { Console.WriteLine($"Dexterity: {(int)player.Dexterity}"); }
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                if (characterProperties.Speed < player.Speed) { Console.WriteLine($"Speed: {((int)player.Speed).ToString()} {Red($"-{player.Speed - characterProperties.Speed}")}"); }
                else if (characterProperties.Speed > player.Speed) { Console.WriteLine($"Speed: {((int)player.Speed).ToString()} {Green($"+{characterProperties.Speed - player.Speed}")}"); }
                else { Console.WriteLine($"Speed: {(int)player.Speed}"); }
                offset += 1;
                Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                if (characterProperties.Haste < player.Haste) { Console.WriteLine($"Haste: {((int)player.Haste).ToString()} {Red($"-{player.Haste - characterProperties.Haste}")}"); }
                else if (characterProperties.Haste > player.Haste) { Console.WriteLine($"Haste: {((int)player.Haste).ToString()} {Green($"+{characterProperties.Haste - player.Haste}")}"); }
                else { Console.WriteLine($"Haste: {(int)player.Haste}"); }
                offset += 1;
                foreach (Status status in player.Statuses)
                {
                    if (status.Display)
                    {
                        if (status.StatusType == Enumerations.StatusEnumeration.StatusEnum.Death)
                        {
                            Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                            Console.WriteLine($"{status.StatusType.ToString()}");
                        }
                        else
                        {
                            Console.SetCursorPosition(location.XLocation, location.YLocation + offset);
                            Console.WriteLine($"{status.StatusType.ToString()} Duration {status.Duration} Amount {status.Amount}");
                            offset += 1;
                        }
                    }
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

        public static int DialogWithInput(List<string> header, List<String> ListOfChoices, string Prompt, string location)
        {
            int yOffset = 0;
            int i = 1;
            XYLocation xy = new XYLocation();

            if (location == "card")
            {
                xy = CardDisplayBox;
            }
            else
            {
                xy = DialogBoxLocation;
            }

            List<string> FullDialog = new List<string>();
            if (header.Count > 0)
            {
                foreach (var line in header)
                {
                    FullDialog.Add(line);
                }
            }

            foreach (String choice in ListOfChoices)
            {
                FullDialog.Add($"   {choice}");
            }
            FullDialog.Add(Prompt + "  ");
            FullDialog.Add("That was not a valid option");

            ClearDialogBox(FullDialog, location);

            if (header.Count > 0)
            {
                foreach (var line in header)
                {
                    Console.SetCursorPosition(xy.XLocation, xy.YLocation + yOffset);
                    Console.WriteLine(line);
                    yOffset++;
                }
            }

            foreach (String line in ListOfChoices)
            {
                Console.SetCursorPosition(xy.XLocation, xy.YLocation + yOffset);
                Console.WriteLine($"{i}: {line}");
                yOffset++;
                i++;
            }

            XYLocation inputLocation = new XYLocation() { XLocation = xy.XLocation, YLocation = xy.YLocation + yOffset };
            int response = UserInput.GetListOption(Prompt, ListOfChoices.Count, inputLocation);
            ClearDialogBox(FullDialog, location);
            return response;
        }


        private static void ClearDialogBox(List<String> LinesOfDialog, string location = "dialog")
        {
            int yOffset = 0;
            XYLocation xy = new XYLocation();

            if (location == "card")
            {
                xy = CardDisplayBox;
            }
            else { xy = DialogBoxLocation; }

            foreach (String line in LinesOfDialog)
            {
                string blanks = new string(' ', line.Length);
                Console.SetCursorPosition(xy.XLocation, xy.YLocation + yOffset);
                Console.WriteLine(blanks);
                yOffset++;
            }
        }

        public static void ColorTest()
        {
            Console.WriteLine($"Mana: {Red("31")}{Green("32")}{Orange("33")}{Blue("34")}{Purple("35")}{Cyan("36")}");

            Console.ReadLine();
        }

        private static string Cyan(string text)
        {
            text = $"\u001b[36m{text}\u001b[0m";

            return text;
        }

        private static string Purple(string text)
        {
            text = $"\u001b[35m{text}\u001b[0m";

            return text;
        }

        private static string Blue(string text)
        {
            text = $"\u001b[34m{text}\u001b[0m";

            return text;
        }

        private static string Orange(string text)
        {
            text = $"\u001b[33m{text}\u001b[0m";

            return text;
        }
        private static string Green(string text)
        {
            text = $"\u001b[32m{text}\u001b[0m";

            return text;
        }

        private static string Red(string text)
        {
            text = $"\u001b[31m{text}\u001b[0m";

            return text;
        }

    }
}
