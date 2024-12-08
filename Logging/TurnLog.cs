using System.Collections.Generic;
using static Cards_Games.Logging.LogTypeEnum;

namespace Cards_Games.Logging
{
    class TurnLog
    {
        private static List<LogEntry> LogEntries = new List<LogEntry>();
        private static int TurnTracker { get; set; }


        public static void Clear()
        {
            foreach (LogEntry logEntry in LogEntries)
            {
                if (logEntry.isActive)
                {
                    logEntry.isActive = false;
                }
            }
        }

        public static void Delete()
        {
            LogEntries.Clear();
        }

        public static List<string> GetLog()
        {
            List<string> log = new List<string>();

            foreach (LogEntry logEntry in LogEntries)
            {
                if (logEntry.isActive)
                {
                    log.Add(logEntry.LogEvent);
                }
            }

            return log;
        }

        public static void SetTurn(int turnNumber)
        {
            TurnTracker = turnNumber;

            LogEntry entry = new LogEntry()
            {
                TurnNumber = TurnTracker,
                LogEvent = $"---- Turn: {turnNumber} ----",
                isActive = true,
                EventType = LogType.NewTurn
            };

            LogEntries.Add(entry);
        }

        public static void AddToLog(LogType logType, string logEntry)
        {
            LogEntry entry = new LogEntry()
            {
                TurnNumber = TurnTracker,
                LogEvent = logEntry,
                isActive = true,
                EventType = logType
            };

            LogEntries.Add(entry);
        }

        public static void DisplayTurnLog()
        {
            int logCount = 0;

            foreach (LogEntry logEntry in LogEntries)
            {
                if (logEntry.EventType != LogType.NewTurn && logEntry.TurnNumber == TurnTracker)
                {
                    logCount++;
                }
            }

            if (logCount > 0)
            {
                Display.SimpleDialogBox(GetLog());
                Clear();
            }
            else
            {
                AddToLog(LogType.Nothing, "Nothing happened");
            }
            
        }
    }
}
