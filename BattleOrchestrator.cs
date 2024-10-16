using Cards_Games.Players;
using System.Collections.Generic;
using static Cards_Games.Enumerations.CardResourceEnum;

namespace Cards_Games
{
    class BattleOrchestrator
    {
        private static List<RPGAction> battleActions = new List<RPGAction>();
        private static int Turn = 0;

        public static void Start(List<IRPGPlayer> players)
        {
            // Preperation For Battle
            battleActions.Clear();

            GetOpeningHands(players);
            Display.BattleActionGrid(battleActions, Turn);

            // Console.SetWindowSize(175, 50);

            // Get battle doll list once implemented
            // OpeningActions(players);

            // need to display players up here 

            // Battle happens here should be in a loop
            // For testing doing 10 rounds of battle
            //for (int x=0; x<10; x++)

            do
            {
                Display.GameInfo(Turn);
                Display.Players(players);

                players = BattleOrchestrator.SpeedSort(players);
                BattleOrchestrator.GetNextActions(players);
                Display.Players(players);             // this is sorting the players every time need to set teams once and then handle as teams.  Also need to set display positions.  Also limitation currently here to only have 2 teams

                players = BattleOrchestrator.CheckForAction(players, Turn);


                Display.BattleActionGrid(battleActions, Turn);
                Display.Players(players);
                AddTime(players);
                Turn++;
            } while (CheckForWin(players) == -1);

            List<string> winMessage = new List<string>();
            winMessage.Add($"Team {CheckForWin(players).ToString()} has won");

            Display.SimpleDialogBox(winMessage);

        }

        public static void BattleMovesOn()
        {
            foreach (RPGAction action in battleActions)
            {
                action.When = action.When - 1;
            }
        }

        public static void AddTime(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.Time = player.Time + 1;
            }

        }

        public static List<IRPGPlayer> CheckForAction(List<IRPGPlayer> players, int turnNumber)
        {
            List<RPGAction> currentAction = new List<RPGAction>();
            foreach (RPGAction action in battleActions)
            {
                if (action.When == turnNumber)
                {
                    currentAction.Add(action);
                }
            }

            ExecuteActions(currentAction, players);
            return players;
        }

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
                        battleActions.Add(new RPGAction(action.Actor, action.ActedUpon, false, durationCard, x, Turn));
                    }
                }
            }

            Display.SimpleDialogBox(linesOfDialog);

            return players;
        }

        public static void GetAction(IRPGPlayer player, List<IRPGPlayer> players)
        {
            RPGCard playerCard = player.PlayCard();
            List<RPGAction> playerAction = RPGAction.ConvertCardToAction(playerCard, player, players, Turn);
            for (int i = 0; i < playerAction.Count; i++)
            {
                battleActions.Add(playerAction[i]);
            }
        }

        public static void GetOpeningHands(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.OpeningHand();
            }
        }

        public static void GetPlayerActions(List<IRPGPlayer> players)
        {
            bool anyaction = false;
            foreach (IRPGPlayer player in players)
            {
                anyaction = BattleOrchestrator.PlayerActionCheck(player);
                if (!anyaction)
                {
                    BattleOrchestrator.GetAction(player, players);
                }
            }
        }

        public static void GetNextActions(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                if (player.NextMove == 0)
                {
                    RPGCard playerCard = player.PlayCard();
                    List<RPGAction> playerAction = RPGAction.ConvertCardToAction(playerCard, player, players, Turn);
                    player.DrawCard();
                    for (int i = 0; i < playerAction.Count; i++)
                    {
                        battleActions.Add(playerAction[i]);
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
            foreach (RPGAction action in battleActions)
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
