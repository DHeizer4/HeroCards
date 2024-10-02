using System;
using System.Collections.Generic;
using Cards_Games.Players;

namespace Cards_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> WelcomeMessage = new List<string>();
            WelcomeMessage.Add("Welcome to Hero Cards");

            Display.SimpleDialogBox(WelcomeMessage);

            RPGCard.MakeLibrary();
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            Console.Clear();
            IRPGPlayer player1 = new HumanRPG(name, 1);

            RPGCardGame Game = new RPGCardGame();
            Game.StartGame(player1);
            Console.SetCursorPosition(0, 0);
        }

    }
}
