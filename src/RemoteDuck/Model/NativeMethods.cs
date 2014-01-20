using System.Runtime.InteropServices;

namespace RemoteDuck.Model
{
    static class NativeMethods
    {
        // Import SetThreadExecutionState Win32 API and necessary flags

        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;

        [DllImport("kernel32.dll")]
        public static extern uint SetThreadExecutionState(uint esFlags);
    }
}