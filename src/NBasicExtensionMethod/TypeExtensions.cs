namespace NBasicExtensionMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///   Responsible for providing extension methods for testing assertions
    ///   against Type instances.
    ///   <![CDATA[    
    /// Example:
    ///   Func<Type, IEnumerable<PropertyInfo>> propertyNamedPageId =
    ///   t => t.GetProperties().Where(p => p.HasOneAttributeWithName<DataMemberAttribute>("pageid", false));
    ///   Assert.That(The.Type<RegisterPageResponse>().HasExactlyOne(propertyNamedPageId));
    /// ]]>
    /// </summary>
    public static class TypeExtensions
    {
        public static bool HasExactlyOne<TType, TCollection>(this TType t, Func<TType, IEnumerable<TCollection>> func)
            where TType : Type
        {
            return Has(t, 1, func);
        }

        public static bool HasNo<TType, TCollection>(this TType t, Func<TType, IEnumerable<TCollection>> func)
            where TType : Type
        {
            return Has(t, 0, func);
        }

        public static bool Has<TType, TCollection>(this TType t, int n, Func<TType, IEnumerable<TCollection>> func)
            where TType : Type
        {
            return func(t).Count() == n;
        }
    }
}