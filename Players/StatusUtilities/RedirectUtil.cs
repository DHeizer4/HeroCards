using Cards_Games.Logging;
using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Players.StatusUtilities
{
    class RedirectUtil
    {
        public static void ResolveRedirect(RPGAction action, List<IRPGPlayer> players)
        {
            List<IRPGPlayer> possibleTargets = new List<IRPGPlayer>();

            foreach (IRPGPlayer player in players)
            {
                if (player.Team == action.ActedUpon.Team)
                {
                    possibleTargets.Add(player);
                }
            }

            if (possibleTargets.Count > 1)
            {
                foreach (IRPGPlayer player in possibleTargets)
                {
                    foreach (Status status in player.Statuses)
                    {
                        if (status.StatusType == StatusEnum.Redirecting && player != action.ActedUpon && !DeathUtil.IsPlayerDead(player))
                        {
                            action.ActedUpon = player;
                            status.Amount -= 1;
                            TurnLog.AddToLog(LogType.StatusTrigger, $"{player.Name} redirects ability {action.Card.Name} to himself");

                            if (status.Amount <= 0)
                            {
                                player.Statuses.Remove(status);
                            }
                        }
                    }
                }
            }

        }
    }
}
