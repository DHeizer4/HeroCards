using Cards_Games.Players;
using System.Collections.Generic;
using static Cards_Games.Enumerations.CardResourceEnum;

namespace Cards_Games
{
    class BattleOrchestrator
    {
        private static List<RPGAction> _TimeLine = new List<RPGAction>();
        private static int _Turn = 0;

        public static void Start(List<IRPGPlayer> players)
        {
            // Preperation For Battle
            _TimeLine.Clear();

            GetOpeningHands(players);
            Display.BattleActionGrid(_TimeLine, _Turn);

            // Console.SetWindowSize(175, 50);

            // Get battle doll list once implemented
            // OpeningActions(players);

            // need to display players up here 

            // Battle happens here should be in a loop
            // For testing doing 10 rounds of battle
            //for (int x=0; x<10; x++)

            do
            {
                Display.GameInfo(_Turn);
                Display.Players(players);

                players = BattleOrchestrator.SpeedSort(players);
                ExecuteActions();
                BattleOrchestrator.GetNextActions(players);
                
                
                Display.Players(players);             // this is sorting the players every time need to set teams once and then handle as teams.  Also need to set display positions.  Also limitation currently here to only have 2 teams


                // Are any actions happening this round / turn
                // This also executes those actions
                //players = BattleOrchestrator.CheckForAction(players, _Turn);


                Display.BattleActionGrid(_TimeLine, _Turn);
                Display.Players(players);

                EndOfTurn(players);
                _Turn++;
            } while (CheckForWin(players) == -1);

            List<string> winMessage = new List<string>();
            winMessage.Add($"Team {CheckForWin(players).ToString()} has won");

            Display.SimpleDialogBox(winMessage);

        }

        public static void BattleMovesOn()
        {
            foreach (RPGAction action in _TimeLine)
            {
                action.When = action.When - 1;
            }
        }

        public static void EndOfTurn(List<IRPGPlayer> players)
        {
            AddTime(players);
          //  CreateLogEntry(); // This needs to say everything that took place on a given turn
        }


        public static void AddTime(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.Time = player.Time + 1;
            }
        }

        //public static List<IRPGPlayer> CheckForAction(List<IRPGPlayer> players, int turnNumber)
        //{
        //    List<RPGAction> currentAction = new List<RPGAction>();
        //    foreach (RPGAction action in _TimeLine)
        //    {
        //        if (action.When == turnNumber)
        //        {
        //            currentAction.Add(action);
        //        }
        //    }

        //    ExecuteActions(currentAction, players);
        //    return players;
        //}

        //This whole function needs to be rewritten for new card structure
        public static List<IRPGPlayer> ExecuteActions(List<RPGAction> actions, List<IRPGPlayer> players)
        {
            List<string> linesOfDialog = new List<string>();

            foreach (RPGAction action in actions)
            {
                string dialog = $"{action.Actor.Name} {action.Card.Phrase} {action.ActedUpon.Name}";
                linesOfDialog.Add(dialog);

                action.ActedUpon.Health = action.ActedUpon.Health - action.Card.Attack;
                if (action.Card.Duration > 1)
                {
                    for (int x = 1; x <= action.Card.Duration; x++)
                    {
                        RPGCard durationCard = new RPGCard(action.Card.CardType, action.Card.Level, action.Card.Name + " effect", CardResource.Time, 0, action.Card.Attack, 0, 0, action.Card.AttackType, action.Card.Target, action.Card.Phrase + " continues on ");
                        _TimeLine.Add(new RPGAction(action.Actor, action.ActedUpon, false, durationCard, x, _Turn));
                    }
                }
            }

            Display.SimpleDialogBox(linesOfDialog);

            return players;
        }

        public static void GetOpeningHands(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.OpeningHand();
            }
        }

        public static void GetNextActions(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                if (player.NextMove == 0)
                {
                    RPGCard playerCard = player.PlayCard();
                    List<RPGAction> playerAction = RPGAction.GetTarget(playerCard, player, players, _Turn);
                    player.DrawCard();
                    for (int i = 0; i < playerAction.Count; i++)
                    {
                        _TimeLine.Add(playerAction[i]);
                        player.NextMove = playerCard.Speed + 1;
                    }
                }
                else
                {
                    player.NextMove -= 1;
                }
            }
        }

        public static bool PlayerActionCheck(IRPGPlayer player)
        {
            foreach (RPGAction action in _TimeLine)
            {
                if (action.Actor == player)
                {
                    return true;
                }
            }
            return false;
        }

        public static List<IRPGPlayer> SpeedSort(List<IRPGPlayer> players)
        {
            players.Sort((x, y) => x.Speed.CompareTo(y.Speed));
            return players;
        }

        // Returns -1 if no winner is found 
        // Returns team number of winning team if there is a winner
        public static int CheckForWin(List<IRPGPlayer> players)
        {
            List<int> teamNumbersWithLivingPlayers = new List<int>();
            foreach (IRPGPlayer player in players)
            {
                if (player.Health > 0)
                {
                    teamNumbersWithLivingPlayers.Add(player.Team);
                }
            }

            int compare = -1;

            for (int i = 0; i < teamNumbersWithLivingPlayers.Count; i++)
            {


                if (compare == -1)
                {
                    compare = teamNumbersWithLivingPlayers[i];
                }
                else if (compare != teamNumbersWithLivingPlayers[i])
                {
                    return -1;
                }
            }

            return compare;
        }


    }
}
