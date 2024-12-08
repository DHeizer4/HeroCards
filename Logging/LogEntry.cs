using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Logging
{
    public class LogEntry
    {
        public string LogEvent { get; set; }
        public LogType EventType { get; set; }
        public bool isActive { get; set; }
        public int TurnNumber { get; set; }

    }
}
