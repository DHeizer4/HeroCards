using Cards_Games.Models;
using System;
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

            if (status.StatusType == StatusEnum.Burning)
            {
                status.Display = true;
                dialog = ApplyBurning(actor, player, status);
            }
            else if (IsCharacterPropertyStatus(status))
            {
                status.Display = false;
                player.Statuses.Add(status);
                dialog = ($"{actor} applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration} to {player.Name}");
            }
            else
            {
                status.Display = true;
                player.Statuses.Add(status);
                dialog = ($"{actor} applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration}, int: {status.Interval}) to {player.Name}");
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

        public static bool IsCharacterPropertyStatus(Status status)
        {
            bool isCharacterProperty = false;

            List<StatusEnum> charaterPropertyAffectingStasus = new List<StatusEnum>()
            {
                StatusEnum.Strengthen,
                StatusEnum.Enlightened,
                StatusEnum.Agile,
                StatusEnum.Nimble,
                StatusEnum.Acclerate,
                StatusEnum.Quickened
            };

            if (charaterPropertyAffectingStasus.Contains(status.StatusType))
            {
                isCharacterProperty = true;
            }

            return isCharacterProperty;
        }

        public static double ResolveEnrageBuff(IRPGPlayer player, double modifiedDamage)
        {
            foreach(Status status in player.Statuses)
            {
                if (status.StatusType == StatusEnum.Enraged)
                {
                    double enragePercent = 1 + (status.Amount / 100);
                    modifiedDamage = modifiedDamage * enragePercent;
                }
            }

            return modifiedDamage;
        }

        public static List<IRPGPlayer> ResolveTaunting(List<IRPGPlayer> players)
        {
            List<IRPGPlayer> modifiedList = new List<IRPGPlayer>();

            foreach(IRPGPlayer player in players)
            {
                foreach (Status status in player.Statuses)
                {
                    if (status.Equals(StatusEnum.Taunting))
                    {
                        // percent chance to taunt
                        Random random = new Random();
                        int randomNumber = random.Next(101);

                        if (status.Amount < randomNumber)
                        {
                            modifiedList.Add(player);
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
