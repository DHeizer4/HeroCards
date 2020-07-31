using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            Player player1 = new Player(name);


            RPGCardGame Game = new RPGCardGame();
            Game.StartGame(player1);

        }

        static int GetInteger(string quest)
        {
            int num;
            bool isValid;

            do
            {
                Console.Write(quest);
                isValid = int.TryParse(Console.ReadLine(), out num);
                if (!isValid)
                {
                    Console.WriteLine("That was not a valid input please enter an integer");
                }
            } while (!isValid);

            return num;
        }

    }
}
