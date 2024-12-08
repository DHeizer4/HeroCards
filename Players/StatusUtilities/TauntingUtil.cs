using Cards_Games.Logging;
using Cards_Games.Models;
using System;
using System.Collections.Generic;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Players.StatusUtilities
{
    class TauntingUtil
    {
        public static List<IRPGPlayer> ResolveTaunting(List<IRPGPlayer> players)
        {
            List<IRPGPlayer> modifiedList = new List<IRPGPlayer>();

            foreach (IRPGPlayer player in players)
            {
                foreach (Status status in player.Statuses)
                {
                    if (status.Equals(StatusEnum.Taunting))
                    {
                        // percent chance to taunt
                        Random random = new Random();
                        int randomNumber = random.Next(101);
                        TurnLog.AddToLog(LogType.StatusCheck, $"{player.Name} attempts to taunt ({randomNumber})");

                        if (status.Amount < randomNumber)
                        {
                            modifiedList.Add(player);
                            TurnLog.AddToLog(LogType.StatusTrigger, $"{player.Name} Taunted the Attack!!!");
                        }
                    }
                }
            }

            if (modifiedList.Count > 0)
            {
                return modifiedList;
            }

            return players;
        }

    }
}
