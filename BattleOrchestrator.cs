using Cards_Games.Models;
using Cards_Games.Players;
using Cards_Games.Players.PlayerUtilities;
using System.Collections.Generic;

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

            ResetPlayerStartingHealth(players);
            GetOpeningHands(players);
            Display.BattleActionGrid(_TimeLine, _Turn);

            // Console.SetWindowSize(175, 50);

            do
            {
                Display.GameInfo(_Turn);
                Display.Players(players);

                players = BattleOrchestrator.SpeedSort(players);
                ActionOrchestrator.ExecuteActions(_TimeLine, players, _Turn);
                BattleOrchestrator.GetNextActions(players);


                Display.Players(players);             // this is sorting the players every time need to set teams once and then handle as teams.  Also need to set display positions.  Also limitation currently here to only have 2 teams

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

        public static void ResetPlayerStartingHealth(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.Health = player.MaxHealth;
            }
        }

        public static void EndOfTurn(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                PlayerBuff.ResolveBurningDebuffs(player);
                AddTime(player);
                RemoveDurationFromBuffs(player);
            }

            //  CreateLogEntry(); // This needs to say everything that took place on a given turn
        }


        public static void RemoveDurationFromBuffs(IRPGPlayer player)
        {
            List<Status> statusesToRemove = new List<Status>();

            foreach(Status status in player.Statuses)
            {
                status.Duration -= 1;
                if (status.Duration <= 0)
                {
                    statusesToRemove.Add(status);
                }
            }

            foreach (Status status in statusesToRemove)
            {
                player.Statuses.Remove(status);
            }
        }

        public static void AddTime(IRPGPlayer player)
        {
            player.Time = player.Time + 1;
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
                        player.NextMove = playerCard.Speed;
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
