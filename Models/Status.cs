using Cards_Games.Enumerations;
using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.StatusEnumeration;

namespace Cards_Games.Models
{
    public class Status
    {
        public StatusEnum StatusType { get; set; }
        public int Amount { get; set; }
        public int Duration { get; set; }
        public int Interval { get; set; }
        public AttackType AttackType { get; set; }
        public bool IsStackable { get; set; }
        public bool IsPercent { get; set; }
    }
}
