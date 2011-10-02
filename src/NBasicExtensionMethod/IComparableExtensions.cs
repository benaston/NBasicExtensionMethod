// ReSharper disable InconsistentNaming
namespace NBasicExtensionMethod
{
    using System;

    public static class IComparableExtensions
    {
        public static bool IsLessThan<T>(this T c, T o) where T : IComparable
        {
            return c.CompareTo(o) < 0;
        }

        public static bool IsLessThanOrEqualTo<T>(this T c, T o) where T : IComparable
        {
            return c.CompareTo(o) <= 0;
        }

        public static bool IsGreaterThan<T>(this T c, T o) where T : IComparable
        {
            return c.CompareTo(o) > 0;
        }

        public static bool IsGreaterThanOrEqualTo<T>(this T c, T o) where T : IComparable
        {
            return c.CompareTo(o) >= 0;
        }

        public static bool Is<T>(this T c, T o) where T : IComparable
        {
            return c.ValueEquals(o);
        }

        public static bool ValueEquals<T>(this T c, T o) where T : IComparable
        {
            return c.CompareTo(o) == 0;
        }

        public static bool IsBetween<T>(this T value, T lowerBound, T upperBound) where T : IComparable
        {
            return value.CompareTo(lowerBound) > 0 && value.CompareTo(upperBound) < 0;
        }

        public static bool IsBetweenInclusive<T>(this T value, T lowerBound, T upperBound) where T : IComparable
        {
            return value.CompareTo(lowerBound) >= 0 && value.CompareTo(upperBound) <= 0;
        }
    }
}

// ReSharper restore InconsistentNaming