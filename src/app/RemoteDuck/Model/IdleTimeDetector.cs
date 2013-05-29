using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace RemoteDuck.Model
{
    public class IdleTimeDetector
    {
        readonly Dictionary<DateTime, TimeSpan> _idleTimes;
        readonly TimeSpan _throttleTime;

        public IdleTimeDetector()
        {
            _idleTimes = new Dictionary<DateTime, TimeSpan>();
            _throttleTime = TimeSpan.FromMinutes(1);
        }

        public TimeSpan GetIdleTime()
        {
            _idleTimes.Add(DateTime.Now, GetCurrentIdleTime());

            var time = DateTime.Now.Subtract(_throttleTime);
            foreach (var key in _idleTimes.Keys.Where(x => x < time).ToList())
                _idleTimes.Remove(key);

            if (_idleTimes.Count == 0)
                return TimeSpan.Zero;

            return _idleTimes.Values.Max();
        }

        public static TimeSpan GetCurrentIdleTime()
        {
            var idleTime = 0;
            var lastInputInfo = new LastInputInfo();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            if (GetLastInputInfo(out lastInputInfo))
                idleTime = Environment.TickCount - lastInputInfo.dwTime;

            return TimeSpan.FromMilliseconds(idleTime);
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(out LastInputInfo plii);

        [StructLayout(LayoutKind.Sequential)]
        struct LastInputInfo
        {
            static readonly int SizeOf = Marshal.SizeOf(typeof (LastInputInfo));
            [MarshalAs(UnmanagedType.U4)] public int cbSize;
            [MarshalAs(UnmanagedType.U4)] public int dwTime;
        }
    }
}