using Cards_Games.Cards;
using Cards_Games.Enumerations;
using Cards_Games.Logging;
using Cards_Games.Models;
using Cards_Games.Players;
using Cards_Games.Players.PlayerUtilities;
using Cards_Games.Players.StatusUtilities;
using Cards_Games.Tables;
using System.Collections.Generic;
using System.Linq;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games
{
    class BattleOrchestrator
    {
        private static List<RPGAction> _TimeLine = new List<RPGAction>();
        private static int _Turn = 0;
        private static string _Version = "0.0.3";

        public static void Start(List<IRPGPlayer> players)
        {
            // Preperation For Battle
            _TimeLine.Clear();

            ResetPlayers(players);
            players = BattleOrchestrator.SpeedSort(players);
            BattleOrchestrator.SetDisplayPositions(players);
            GetOpeningHands(players);
            Display.BattleActionGrid(_TimeLine, _Turn);
            TurnLog.Delete();

            do
            {
                TurnLog.SetTurn(_Turn);
                Display.GameInfo(_Turn, _Version);

                Display.Players(players);
                players = BattleOrchestrator.SpeedSort(players);
                ActionOrchestrator.ExecuteActions(_TimeLine, players, _Turn);

                Display.Players(players);
                BattleOrchestrator.GetNextActions(players);

                Display.Players(players);             // this is sorting the players every time need to set teams once and then handle as teams.  Also need to set display positions.  Also limitation currently here to only have 2 teams
                Display.BattleActionGrid(_TimeLine, _Turn);
                
                EndOfTurn(players);
                Display.Players(players);
                TurnLog.DisplayTurnLog();
                
                _Turn++;
            } while (CheckForWin(players) == -1);

            List<string> winMessage = new List<string>();
            int winningTeam = CheckForWin(players);
            
            if(winningTeam != -2)
            {
                winMessage.Add($"Team {winningTeam} has won");
            }
            else
            {
                winMessage.Add("All participants have died");
            }
            
            Display.SimpleDialogBox(winMessage);

        }

        public static void ResetPlayers(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.Health = player.MaxHealth;
                player.Mana = player.MaxMana;
                player.Statuses = new List<Status>();
                player.Decklist.RandomShuffle(7);
            }
        }

        public static void SetDisplayPositions(List<IRPGPlayer> players)
        {
            int team1DisplayPosition = 1;
            int team2DisplayPosition = 1;

            foreach(IRPGPlayer player in players)
            {
                if (player.Team == 1)
                {
                    player.DisplayPosition = team1DisplayPosition;
                    team1DisplayPosition++;
                }
                
                if (player.Team == 2)
                {
                    player.DisplayPosition = team2DisplayPosition;
                    team2DisplayPosition++;
                }
            }
        }

        public static void EndOfTurn(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                BurningUtil.ResolveBurningDebuffs(player);
                AddTime(player);
                RemoveDurationFromBuffs(player);
                CheckForDeath(player);
            }

            //  CreateLogEntry(); // This needs to say everything that took place on a given turn
        }


        public static void CheckForDeath(IRPGPlayer player)
        {
            if (player.Health <= 0)
            {
                DeathUtil.ApplyDeath(player);
            }
        }

        public static void RemoveDurationFromBuffs(IRPGPlayer player)
        {
            List<Status> statusesToRemove = new List<Status>();

            foreach(Status status in player.Statuses)
            {
                if (!DeathUtil.IsPlayerDead(player))
                {
                    status.Duration -= 1;
                    if (status.Duration <= 0)
                    {
                        statusesToRemove.Add(status);
                    }
                }
            }

            foreach (Status status in statusesToRemove)
            {
                if(status.StatusType == StatusEnumeration.StatusEnum.Shielded)
                {
                    ShieldedUtil.RemoveShield(player, status);
                }
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
                if (DeathUtil.IsPlayerDead(player))
                {
                    continue;
                }

                if (player.NextMove == 0)
                {
                    //Stun check
                    if(player.Statuses.Any(s => s.StatusType == StatusEnum.Stunned))
                    {   
                        Status status = player.Statuses.FirstOrDefault(s => s.StatusType == StatusEnum.Stunned);
                        status.Amount -= 1;
                        TurnLog.AddToLog(LogType.StatusTrigger, $"{player.Name} is stunned and cannot take action this round");

                        if (status.Amount <= 0)
                        {
                            player.Statuses.Remove(status);
                        }

                        continue;
                    }

                    RPGCard playerCard = player.PlayCard(players);
                    List<RPGAction> playerActions = new List<RPGAction>();
                    string actedUpon = RPGAction.GetTarget(playerCard, player, players, _Turn, ref playerActions);
                    
                    if (player.Hand.Count < 5)
                    {
                        player.DrawCard();
                    }

                    for (int i = 0; i < playerActions.Count; i++)
                    {
                        _TimeLine.Add(playerActions[i]);

                        int hasteFactor = HasteTable.GetFactor(player.Haste);
                        int hasteValue = playerCard.Speed - hasteFactor;

                        player.NextMove = hasteValue > 0 ? hasteValue : 0;
                    }

                    string playerEvent = $"{player.Name} plays {playerActions[0].Card.Name} targeting {actedUpon}will happen on turn: {playerActions[0].When}";
                    TurnLog.AddToLog(LogType.CardPlayed, playerEvent);

                }
                else
                {
                    int speedFactor = SpeedTable.GetFactor(player.Speed);
                    player.NextMove -= 1 + speedFactor;

                    if (player.NextMove < 0)
                    {
                        player.NextMove = 0;
                    }
                }
            }
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

            if (teamNumbersWithLivingPlayers.Count == 0)
            {
                return -2;
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
