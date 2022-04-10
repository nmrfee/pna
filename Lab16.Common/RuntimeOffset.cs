using System;

namespace Lab16.Common
{
    // A single tick represents one hundred nanoseconds or one ten-millionth of a second.
    // There are 10,000 ticks in a millisecond 
    public static class RuntimeOffset
    {
        public static void Mark()
            => _beginTime = Ticks;

        public static long MillisecondsSinceMark 
            => (Ticks - _beginTime) / 10_000;

        public static long SecondsSinceMark 
            => (Ticks - _beginTime) / 10_000_000;

        public static long TicksSinceMark
            => Ticks - _beginTime;

        public static TimeSpan TimespanSinceMark
           => new TimeSpan(TicksSinceMark);

        private static long _beginTime;

        public static long Ticks 
            => DateTime.Now.Ticks;
    }
}