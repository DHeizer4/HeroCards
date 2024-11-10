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
                    ApplyBurning(player, status);

                    break;
                default:
                    player.Statuses.Add(status);
                    dialog = ($"{actor} applies {status.StatusType.ToString()} to {player.Name}");
                    break;
            }

            return dialog;
        }

        private static void ApplyBurning(IRPGPlayer player, Status status)
        {
            bool preexisting = false;

            foreach (Status existing in player.Statuses)
            {
                if (existing.StatusType == StatusEnum.Burning)
                {
                    existing.Duration += status.Duration;
                    existing.Amount += status.Amount;
                    existing.Interval = status.Interval;

                    preexisting = true;
                }
            }

            if (!preexisting)
            {
                status.InternalTracker = status.Interval;
                player.Statuses.Add(status);
            }
        }

        public static List<string> ResolveBurningDebuffs(IRPGPlayer player)
        {
            List<string> linesOFDialog = new List<string>();

            foreach (Status status in player.Statuses)
            {
                if (status.StatusType == StatusEnum.Burning)
                {
                    if (status.InternalTracker == 0)
                    {
                        DamageEffect damageEffect = new DamageEffect(Target.None, status.Amount, AttackType.Fire, CardResource.Health);
                        int amt = PlayerProperty.DoDamageToPlayer(player, damageEffect, status.Amount);
                        linesOFDialog.Add($"{player.Name} takes {amt} Burning Damage");
                        status.InternalTracker = status.Interval - 1;
                    }
                    else
                    {
                        status.InternalTracker -= 1;
                    }
                }
            }

            return linesOFDialog;
        }

    }
}
