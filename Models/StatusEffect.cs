using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.StatusEnumeration;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Models
{
    public class StatusEffect
    {
        public Target Target { get; set; }
        public StatusEnum StatusType { get; set; }
        public int Amount { get; set; }
        public int Duration { get; set; }
        public int Interval { get; set; }
        public AttackType AttackType { get; set; }
        public bool IsPercent { get; set; }
        public bool IsStackable { get; set; }
        public bool IsBeneficial { get; set; }

        public StatusEffect(Target target, StatusEnum statusType, int amount, int duration, int interval, AttackType attackType, bool isPercent, bool isStackable, bool isBeneficial)
        {
            Target = target;
            StatusType = statusType;
            Amount = amount;
            Duration = duration;
            Interval = interval;
            AttackType = attackType;
            IsPercent = isPercent;
            IsStackable = isStackable;
            IsBeneficial = isBeneficial;
        }
    }
}
