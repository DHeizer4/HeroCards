using Cards_Games.Models;
using System.Collections.Generic;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CardResourceEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Players.PlayerUtilities
{
    class PlayerBuff
    {
        public static string ApplyStatusEffect(string actor, IRPGPlayer player, Status status)
        {
            string dialog = "";

            switch (status.StatusType)
            {
                case StatusEnum.Burning:
                    dialog = ApplyBurning(actor, player, status);
                    break;
                default:
                    player.Statuses.Add(status);
                    dialog = ($"{actor} applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration}, int: {status.Interval}) to {player.Name}");
                    break;
            }

            return dialog;
        }

        private static string ApplyBurning(string actor, IRPGPlayer player, Status status)
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
                }
            }

            if (!preexisting)
            {
                status.InternalTracker = status.Interval;
                player.Statuses.Add(status);
                dialog = ($" applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration}, int: {status.Interval}) to {player.Name}");
            }

            return dialog;
        }

        public static void ResolveBurningDebuffs(IRPGPlayer player, List<string> turnLog)
        {

            foreach (Status status in player.Statuses)
            {
                if (status.StatusType == StatusEnum.Burning)
                {
                    if (status.InternalTracker == 0)
                    {
                        DamageEffect damageEffect = new DamageEffect(Target.None, status.Amount, AttackType.Fire, CardResource.Health);
                        int amt = PlayerProperty.DoDamageToPlayer(player, damageEffect, status.Amount);
                        turnLog.Add($"{player.Name} takes {amt} Burning Damage");
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
