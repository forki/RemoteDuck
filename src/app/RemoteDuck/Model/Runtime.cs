using System;

namespace RemoteDuck.Model
{
    public class Runtime
    {
        readonly DateTime _startTime;

        public Runtime()
        {
            _startTime = DateTime.Now;
        }

        public TimeSpan ElapsedTime
        {
            get { return DateTime.Now - _startTime; }
        }
    }
}