using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cards_Games
{
    class RPGCardGame
    {
        public void StartGame(IRPGPlayer player1)
        {
            
            List<IRPGPlayer> players = new List<IRPGPlayer>();
            HumanRPG RPG1 = new HumanRPG(player1.Name);
            players.Add(RPG1);
            CompTopRPG comp1 = new CompTopRPG("That guy");
            players.Add(comp1);
            
            PlayGame(players);

        }

        static void PlayGame(List<IRPGPlayer> participants)
        {
            
            foreach (IRPGPlayer player in participants)
            {
                player.OpeningHand();
                player.DisplayPlayer();
            }
            
            //RPG1.DisplayHand();

            bool win = false;
            while (!win)
            {
                int turnNum = 1;
                Console.WriteLine($"Turn {turnNum}");
                ActionCheck();
                LoseCheck();
                WinCheck();
                win = true;
            }
        }

        public static void ActionCheck()
        {
            //GetActions();
            //ActionReady();
            //ExecuteActions();
        }

        public static void LoseCheck()
        {
            //is player out of health???
            //Clear actions of dead players
        }

        public static void WinCheck()
        {
            // Is only 1 plaer left
        }

    }


}
