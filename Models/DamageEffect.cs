using System;
using System.Collections.Generic;
using System.Text;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Models
{
    public class DamageEffect
    {
        public Target Target { get; set; }
        public int Amount { get; set; }
        public AttackType AttackType { get; set; }

        public DamageEffect(Target target, int amount, AttackType attackType)
        {
            Target = target;
            AttackType = attackType;
            Amount = amount;
        }
    }
}
