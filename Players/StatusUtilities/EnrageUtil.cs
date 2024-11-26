using Cards_Games.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Cards_Games.Enumerations.StatusEnumeration;

namespace Cards_Games.Players.StatusUtilities
{
    class EnrageUtil
    {
        public static double ResolveEnrageBuff(IRPGPlayer player, double modifiedDamage)
        {
            foreach (Status status in player.Statuses)
            {
                if (status.StatusType == StatusEnum.Enraged)
                {
                    double enragePercent = 1 + (status.Amount / 100);
                    modifiedDamage = modifiedDamage * enragePercent;
                }
            }

            return modifiedDamage;
        }
    }
}
