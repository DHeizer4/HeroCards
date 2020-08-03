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
            int turnNum = 1;
            bool win = false;
            while (!win)
            {
                Console.WriteLine($"Turn {turnNum}");
                ActionCheck(participants, turnNum);
                LoseCheck();
                WinCheck();
                turnNum++;
                win = true;
            }
        }

        public static void ActionCheck(List<IRPGPlayer> participants, int turnNum)
        {
            GetAction(participants, turnNum);
            ExecuteActions(participants, turnNum);
        }

        public static void GetAction(List<IRPGPlayer> particpants, int turnNum)
        {
            foreach (IRPGPlayer player in particpants)
            {
                if (player.Action.Count < 1)
                {
                    RPGCard card = player.PlayCard();
                    card.Speed = card.Speed + turnNum;
                    Console.WriteLine($"Card will take place on turn {card.Speed}");
                    player.Action.Add(card);
                }
            }
        } 

        public static void ExecuteActions(List<IRPGPlayer> particpants, int turnNum)
        {
            foreach (IRPGPlayer player in particpants)
            {
                foreach(RPGCard card in player.Action)
                {
                    if (card.Speed < turnNum)
                    {
                        ExecuteCard(player, particpants, card);
                    }
                }
            }
        }

        public static void ExecuteCard(IRPGPlayer activePlayer, List<IRPGPlayer> partcipants, RPGCard card)
        {
            Console.WriteLine($"{activePlayer}, plays {card}");
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
