using Cards_Games.Logging;
using Cards_Games.Models;
using System.Linq;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Players.StatusUtilities
{
    class DeathUtil
    {
        public static void ApplyDeath(IRPGPlayer player)
        {
            Status deathstatus = new Status() { StatusType = Enumerations.StatusEnumeration.StatusEnum.Death, Display = true };
            
            if (!player.Statuses.Any(s => s.StatusType == StatusEnum.Death))
            {
                player.Health = 0;
                player.Statuses.Clear();
                player.Statuses.Add(deathstatus);

                string logEntry = $"{player.Name} has Died!";

                TurnLog.AddToLog(LogType.Death, logEntry);
            }

        }

        public static bool IsPlayerDead(IRPGPlayer player)
        {
            bool isDead = false;
            foreach (var status in player.Statuses)
            {
                if (status.StatusType == Enumerations.StatusEnumeration.StatusEnum.Death)
                {
                    isDead = true;
                }
            }

            return isDead;
        }

    }
}
