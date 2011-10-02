namespace NBasicExtensionMethod
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumExtensions
    {
        public static IDictionary ToDictionary<TEnumValueType>(this Enum e)
        {
            if (typeof (TEnumValueType).FullName != Enum.GetUnderlyingType(e.GetType()).FullName)
            {
                throw new ArgumentException("Invalid type specified.");
            }

            return Enum.GetValues(e.GetType())
                .Cast<object>()
                .ToDictionary(key => Enum.GetName(e.GetType(), key),
                              value => (TEnumValueType) value);
        }

        public static IEnumerable<T> All<T>(this T e) where T : struct, IConvertible
        {
            return Enum.GetValues(e.GetType()).Cast<T>();
        }
    }
}