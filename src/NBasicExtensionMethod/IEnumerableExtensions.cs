// ReSharper disable InconsistentNaming
namespace NBasicExtensionMethod
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions

    {
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> o)
        {
            return o != null && o.Count() > 0;
        }
    }
}

// ReSharper restore InconsistentNaming