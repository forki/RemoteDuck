using System;
using System.Globalization;
using System.Text;

namespace RemoteDuck.Model
{
    public static class Formatter
    {
        public static string GetIdleTimeText(TimeSpan idleTime)
        {
            return string.Format("Idle for {0}", FriendlyTimeDescription.Describe(idleTime));
        }
    }
}