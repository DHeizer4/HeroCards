using Cards_Games.Logging;
using Cards_Games.Models;
using Cards_Games.Players.StatusUtilities;
using System.Collections.Generic;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Logging.LogTypeEnum;

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
                dialog = ($"{actor.Name} applies {status.StatusType.ToString()} (Amt: {status.Amount}, Dur: {status.Duration} to {player.Name}");
                TurnLog.AddToLog(LogType.StatusApplied, dialog);
            }
            else if (status.StatusType == StatusEnum.Shielded)
            {
                ShieldedUtil.ApplyShield(actor, player, status);
            }
            else
            {
                status.Display = true;
                player.Statuses.Add(status);
                dialog = ($"{actor.Name} applies {status.StatusType.ToString()} to {player.Name} (Amt: {status.Amount}, Dur: {status.Duration}, int: {status.Interval}) ");
                TurnLog.AddToLog(LogType.StatusApplied, dialog);
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

    }
}
