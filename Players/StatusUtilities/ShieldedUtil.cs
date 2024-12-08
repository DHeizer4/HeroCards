using Cards_Games.Logging;
using Cards_Games.Models;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Players.StatusUtilities
{
    class ShieldedUtil
    {
        public static void ApplyShield(IRPGPlayer actor, IRPGPlayer player, Status status)
        {
            string dialog = string.Empty;
            double shieldAmt = 0;

            if (status.IsPercent)
            {
                if (status.Interval == 1)

                {
                    shieldAmt = actor.Health * status.Amount;
                    shieldAmt = shieldAmt / 100;
                }
                else
                {
                    shieldAmt = player.Health * status.Amount;
                    shieldAmt = shieldAmt / 100;
                }
            }

            player.Shield += (int)shieldAmt;
            status.Amount = (int)shieldAmt;

            player.Statuses.Add(status);

            dialog = $"{player.Name} shielded {player.Name} for {status.Amount} lasting {status.Duration} rounds";

            TurnLog.AddToLog(LogType.StatusApplied, dialog);
        }

        public static int ResolveShield(IRPGPlayer player, int damageAmount)
        {
            int postShieldDamage = damageAmount - player.Shield;

            if (postShieldDamage >= 0)
            {
                player.Shield = 0;
            }
            else if (postShieldDamage < 0)
            {
                player.Shield = -1 * postShieldDamage;
                postShieldDamage = 0;
            }

            return postShieldDamage;
        }

        public static void RemoveShield(IRPGPlayer player, Status status)
        {
            int remainingShield = player.Shield;
            int totalShieldValue = 0;

            foreach (Status playerStatus in player.Statuses)
            {
                if (playerStatus.StatusType == StatusEnum.Shielded)
                {
                    totalShieldValue += playerStatus.Amount;
                }
            }

            int damagedabsorbed = totalShieldValue - remainingShield;

            if (status.Amount - damagedabsorbed < status.Amount)
            {
                player.Shield = player.Shield - (status.Amount - damagedabsorbed);
            }

        }

    }
}
