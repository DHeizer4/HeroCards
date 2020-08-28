using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
