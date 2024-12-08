
namespace Cards_Games.Logging
{
    public class LogTypeEnum
    {
        public enum LogType
        {
            NewTurn,
            DamageEvent,
            ManaEvent,
            TimeEvent,
            EnergyEvent,
            StatusTrigger,
            StatusApplied,
            StatusCheck,
            CardPlayed,
            Nothing,
            Death
        }

    }
}
