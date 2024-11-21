﻿using Cards_Games.Models;
using Cards_Games.Players;
using Cards_Games.Players.PlayerUtilities;
using Cards_Games.Tables;
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

            ResetPlayers(players);
            GetOpeningHands(players);
            Display.BattleActionGrid(_TimeLine, _Turn);

            do
            {
                List<string> turnLog = new List<string>() { $"---- Turn: {_Turn} ----"};
                Display.GameInfo(_Turn);

                Display.Players(players);

                players = BattleOrchestrator.SpeedSort(players);
                ActionOrchestrator.ExecuteActions(_TimeLine, players, _Turn, turnLog);
                BattleOrchestrator.GetNextActions(players, turnLog);

                Display.Players(players);             // this is sorting the players every time need to set teams once and then handle as teams.  Also need to set display positions.  Also limitation currently here to only have 2 teams
                Display.BattleActionGrid(_TimeLine, _Turn);
                Display.Players(players);

                EndOfTurn(players, turnLog);

                Display.SimpleDialogBox(turnLog);
                _Turn++;
            } while (CheckForWin(players) == -1);

            List<string> winMessage = new List<string>();
            winMessage.Add($"Team {CheckForWin(players).ToString()} has won");

            Display.SimpleDialogBox(winMessage);

        }

        public static void ResetPlayers(List<IRPGPlayer> players)
        {
            foreach (IRPGPlayer player in players)
            {
                player.Health = player.MaxHealth;
                player.Mana = player.MaxMana;
                player.Statuses = new List<Status>();
            }
        }

        public static void EndOfTurn(List<IRPGPlayer> players, List<string> turnLog)
        {
            foreach (IRPGPlayer player in players)
            {
                PlayerBuff.ResolveBurningDebuffs(player, turnLog);
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

        public static void GetNextActions(List<IRPGPlayer> players, List<string> turnLog)
        {
            foreach (IRPGPlayer player in players)
            {
                if (player.NextMove == 0)
                {
                    RPGCard playerCard = player.PlayCard();
                    List<RPGAction> playerActions = new List<RPGAction>();
                    string actedUpon = RPGAction.GetTarget(playerCard, player, players, _Turn, ref playerActions);
                    player.DrawCard();
                    for (int i = 0; i < playerActions.Count; i++)
                    {
                        _TimeLine.Add(playerActions[i]);

                        int hasteFactor = HasteTable.GetFactor(player.Haste);
                        int hasteValue = playerCard.Speed - hasteFactor;

                        player.NextMove = hasteValue > 0 ? hasteValue : 0;
                    }

                    string playerEvent = $"{player.Name} plays {playerActions[0].Card.Name} targeting {actedUpon}will happen on turn: {playerActions[0].When}";
                    turnLog.Add(playerEvent);
                }
                else
                {
                    int speedFactor = SpeedTable.GetFactor(player.Speed);
                    player.NextMove -= speedFactor;

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
