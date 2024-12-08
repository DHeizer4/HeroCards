using Cards_Games.Logging;
using Cards_Games.Models;
using Cards_Games.Players.PlayerUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Players.StatusUtilities
{
    class BurningUtil
    {
        public static string ApplyBurning(string actor, IRPGPlayer player, Status status)
        {
            bool preexisting = false;
            string dialog = string.Empty;

            foreach (Status existing in player.Statuses)
            {
                if (existing.StatusType == StatusEnum.Burning)
                {
                    existing.Duration += status.Duration;
                    existing.Amount += status.Amount;
                    existing.Interval = status.Interval;

                    preexisting = true;
                    dialog = ($"{actor} modifies {status.StatusType.ToString()} (Amt: {existing.Amount}, Dur: {existing.Duration}, int: {existing.Interval}) on {player.Name}");
                    TurnLog.AddToLog(LogType.StatusApplied, dialog);
                }
            }

            if (!preexisting)
            {
                status.InternalTracker = status.Interval;
                player.Statuses.Add(status);
                dialog = ($" applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration}, int: {status.Interval}) to {player.Name}");
                TurnLog.AddToLog(LogType.StatusApplied, dialog);
            }

            return dialog;
        }

        public static void ResolveBurningDebuffs(IRPGPlayer player)
        {

            foreach (Status status in player.Statuses)
            {
                if (status.StatusType == StatusEnum.Burning)
                {
                    if (status.InternalTracker == 0)
                    {
                        DamageEffect damageEffect = new DamageEffect(Target.None, status.Amount, AttackType.Fire, CardResource.Health);
                        int amt = PlayerProperty.DoDamageToPlayer(player, damageEffect, status.Amount);
                        string dialog = $"{player.Name} takes {amt} Burning Damage";
                        TurnLog.AddToLog(LogType.DamageEvent, dialog);

                        status.InternalTracker = status.Interval - 1;
                    }
                    else
                    {
                        status.InternalTracker -= 1;
                    }
                }
            }
        }

    }
}
