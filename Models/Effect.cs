using static Cards_Games.Enumerations.AttackTypeEnum;
using static Cards_Games.Enumerations.CharacterStatEnum;
using static Cards_Games.Enumerations.TargetEnum;

namespace Cards_Games.Models
{
    public class Effect
    {
        public Target Target { get; set; }
        public CharacterStat CharacterStat { get; set; }
        public int Amount { get; set; }
        public int Duration { get; set; }
        public AttackType AttackType { get; set; }
        public bool Percent { get; set; }
    }
}
