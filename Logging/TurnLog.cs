using System;
using System.Collections.Generic;
using System.Text;

namespace Cards_Games.Logging
{
    class TurnLog
    {
        private static List<string> _TurnLog { get; set; } = new List<string>();

        public static void Erase()
        {
            _TurnLog.Clear();
        }

        public static List<string> GetLog()
        {
            return _TurnLog;
        }

        public static void AddToLog(List<string> logEntries)
        {
            foreach (var logEntry in logEntries)
            {
                _TurnLog.Add(logEntry);
            }
        }

        public static void AddToLog(string logEntry)
        {

                _TurnLog.Add(logEntry);
         }
    }
}
