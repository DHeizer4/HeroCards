using Cards_Games.Logging;
using Cards_Games.Models;
using Cards_Games.Players.StatusUtilities;
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
        public static string ApplyStatusEffect(IRPGPlayer actor, IRPGPlayer player, Status status)
        {
            string dialog = "";

            if (status.StatusType == StatusEnum.Burning)
            {
                status.Display = true;
                BurningUtil.ApplyBurning(actor.Name, player, status);
            }
            else if (IsCharacterPropertyStatus(status))
            {
                status.Display = false;
                player.Statuses.Add(status);
                dialog = ($"{actor} applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration} to {player.Name}");
                TurnLog.AddToLog(dialog);
            }
            else if (status.StatusType == StatusEnum.Shielded)
            {
                ShieldedUtil.ApplyShield(actor, player, status);
            }
            else
            {
                status.Display = true;
                player.Statuses.Add(status);
                dialog = ($"{actor} applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration}, int: {status.Interval}) to {player.Name}");
                TurnLog.AddToLog(dialog);
            }

            return dialog;
        }




        public static bool IsCharacterPropertyStatus(Status status)
        {
            bool isCharacterProperty = false;

            List<StatusEnum> charaterPropertyAffectingStasus = new List<StatusEnum>()
            {
                StatusEnum.StrengthAdj,
                StatusEnum.IntellectAdj,
                StatusEnum.AgilityAdj,
                StatusEnum.DexterityAdj,
                StatusEnum.SpeedAdj,
                StatusEnum.HasteAdj
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
                foreach(IRPGPlayer player in possibleTargets)
                {
                    foreach(Status status in player.Statuses)
                    {
                        if (status.StatusType == StatusEnum.Redirecting && player != action.ActedUpon)
                        {
                            action.ActedUpon = player;
                            status.Amount -= 1;

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
