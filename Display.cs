using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games
{
    class Display
    {
        public static void BattleTurn(int turnnumber)
        {
            Console.WriteLine($"Turn \u001b[031{turnnumber}\u001b[");
        } 

        public static void InvalidChoice()
        {
            Console.WriteLine("That was not a valid option");
        }

        public static void PlayerList(List<IRPGPlayer> players, string header)
        {
            int i = 1;
            Console.WriteLine(header);
            foreach (IRPGPlayer player in players)
            {
                Console.WriteLine($"{i}: {player}");
            }
        }



    }
}
