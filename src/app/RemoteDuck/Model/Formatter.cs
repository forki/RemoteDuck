using System;

namespace RemoteDuck.Model
{
    public class Formatter
    {
        public static string GetElapsedTimeText(TimeSpan elapsedTime)
        {
            return string.Format("Runtime: {0}s", Math.Round(elapsedTime.TotalSeconds));
        }

        public static string GetIdleTimeText(TimeSpan idleTime)
        {
            return string.Format("Idle: {0}s", Math.Round(idleTime.TotalSeconds));
        }
    }
}