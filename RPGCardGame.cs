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
        public void StartGame(Player player1)
        {
            RPGCard.MakeLibrary();
            HumanRPG RPG1 = new HumanRPG(player1.Name);
            CompTopRPG comp1 = new CompTopRPG("That guy");
            RPG1.OpeningHand();
            //RPG1.DisplayHand();
            bool win = false;
            while (!win)
            {
                int turnNum = 1;
                Console.WriteLine($"Turn {turnNum}");
                ActionCheck();
                LoseCheck();
                WinCheck();
                if (RPG1.Action.Count < 1)
                {
                    RPG1.Action.Add(RPG1.PlayCard());
                }
                if (comp1.Action.Count < 1)
                {
                    comp1.Action.Add(comp1.PlayCard());
                }
            }

        }
         
        public static void ActionCheck()
        {
            GetActions();
            ActionReady();
            ExecuteActions();
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
