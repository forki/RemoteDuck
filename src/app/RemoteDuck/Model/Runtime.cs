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

        public double ElapsedTime
        {
            get { return (DateTime.Now - _startTime).TotalSeconds; }
        }

        public string GetElapsedTimeText()
        {
            return string.Format("Runtime: {0}s", Math.Round(ElapsedTime));
        }
    }
}