namespace NBasicExtensionMethod
{
    using System;

    public static class TimeSpanExtensions
    {
        public static bool IsGreaterThanZero(this TimeSpan t)
        {
            return t > TimeSpan.Zero;
        }

        public static DateTime Ago(this TimeSpan t)
        {
            return DateTime.Now - t;
        }

        public static DateTime Hence(this TimeSpan t)
        {
            return DateTime.Now + t;
        }

        public static DateTime Before(this TimeSpan t, DateTime d)
        {
            return d - t;
        }

        public static DateTime After(this TimeSpan t, DateTime d)
        {
            return d + t;
        }

        public static TimeSpan ShorterThan(this TimeSpan t1, TimeSpan t2)
        {
            return t2 - t1;
        }

        public static TimeSpan LongerThan(this TimeSpan t1, TimeSpan t2)
        {
            return t2 + t1;
        }
    }
}