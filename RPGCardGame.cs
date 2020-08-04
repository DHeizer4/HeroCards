using System;
using System.Collections.Generic;

namespace Cards_Games
{
    class RPGCardGame
    {
        public void StartGame(IRPGPlayer player1)
        {
            List<IRPGPlayer> players = new List<IRPGPlayer>();
            HumanRPG RPG1 = new HumanRPG(player1.Name, 1);
            players.Add(RPG1);
            CompTopRPG comp1 = new CompTopRPG("That guy", 2);
            players.Add(comp1);
            
            PlayGame(players);

        }

        static void PlayGame(List<IRPGPlayer> participants)
        {
            List<RPGAction> actionList = new List<RPGAction>();
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
                ActionCheck(participants, actionList, turnNum);
                //DisplayActions(actionList);
                LoseCheck();
                WinCheck();
                turnNum++;
                win = true;
            }
        }

        public static void ActionCheck(List<IRPGPlayer> participants, List<RPGAction> actionList, int turnNum)
        {
            GetAction(participants, actionList, turnNum);
            ExecuteActions(participants, actionList, turnNum);
        }


        // Rewrite Get Action to convert card to RPGaction item
        // Convert Card to Action should be a function
        // This also means changing player class removing Acton List and making a single Action List
        // Back to the drawing board lets make a list of turns that hold the actions to take plaec on that turn.

        // Jagged List turn action
        // https://www.dotnetperls.com/nested-list#:~:text=A%20List%20can%20have%20elements,developed%20and%20expandable%20data%20structure.

        public static List<RPGAction> GetAction(List<IRPGPlayer> particpants, List<RPGAction> actionList, int turnNum)
        {
            foreach (IRPGPlayer player in particpants)
            {
                int numofaction = 0;
                foreach (RPGAction action in actionList)
                {
                    if(action.Actor == player && action.Original)
                    {
                        numofaction++;
                    } 
                }
                if (numofaction == 0)
                {
                    RPGCard card = player.PlayCard();
                    if (card.Target == Target.Enemy || card.Target == Target.Ally)
                    {
                        IRPGPlayer actedUpon = player.GetTarget(player, particpants, card.Target);
                        int when = card.Speed + turnNum;
                        RPGAction newAction = new RPGAction(player, actedUpon, true, card);
                        actionList.Add(newAction);
                        if (card.Duration > 1)
                        {
                            for (int i = 1; i < card.Duration; i++)
                            {
                                actionList.Add(new RPGAction(player, actedUpon, false, card));
                            }
                        }
                    }
                }
            }
            return actionList;
        } 

        //Need to change to work with RPG Action Class
        public static void ExecuteActions(List<IRPGPlayer> particpants, List<RPGAction> actionList, int turnNum)
        {
            foreach (IRPGPlayer player in particpants)
            {
                foreach(RPGAction action in actionList)
                {
                    if (action.Detonation > turnNum)
                    {
                        ExecuteAction(particpants, action);
                    }
                }
            }
        }

        //Will this be needed still?
        public static void ExecuteAction(List<IRPGPlayer> partcipants, RPGAction action)
        {
            Console.WriteLine($"{action.Actor}, plays {action.Name}");
            Console.WriteLine($"{action.ActedUpon}'s {action.Modify} is lowered by {action.Amount}");
        }

        public static void LoseCheck()
        {
            //is player out of health???
            //Clear actions of dead players
            
        }

        public static void WinCheck()
        {
            // Is only 1 team is left
        }

    }


}
