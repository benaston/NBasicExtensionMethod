namespace NBasicExtensionMethod
{
    using System;

    public static class DateTimeExtension
    {
        private static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        private static readonly DateTime MaxDate = new DateTime(2100, 12, 31, 23, 59, 59, 999);

        public static bool IsValid(this DateTime target)
        {
            return (target >= MinDate) && (target <= MaxDate);
        }

        public static bool IsInFuture(this DateTime source)
        {
            return DateTime.Compare(source, DateTime.Now) > 0;
        }

        public static bool IsOlderThan(this DateTime t1, DateTime t2)
        {
            return t1 < t2;
        }

        public static bool IsLaterThan(this DateTime t1, DateTime t2)
        {
            return t1 > t2;
        }
    }
}