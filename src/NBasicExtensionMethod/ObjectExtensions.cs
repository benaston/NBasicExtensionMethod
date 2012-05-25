namespace NBasicExtensionMethod
{
    using System;
    using System.Reflection;

    /// <summary>
    ///   Responsible for providing object extension methods
    ///   to enable assertions to be made.
    /// </summary>
    public static class ObjectExtensions
    {
        public static bool IsNull(this object o)
        {
            return o == null;
        }

        public static bool IsNotNull(this object o)
        {
            return o != null;
        }

        public static bool IsNot<T>(this T o1, T o2) where T : struct
        {
            return !o1.Equals(o2);
        }

        public static T EnsuringThat<T, TException>(this T o, Func<T, bool> assertionAboutO, string message)
            where TException : Exception, new()
        {
            if (assertionAboutO(o))
            {
                return o;
            }

            var e = new TException();
            e.Data.Add("Details", message);
            throw e;
        }

        /// <summary>
        ///   Responsible for providing a fluent method to apply boolean
        ///   logic against a reference type.
        /// </summary>
        public static bool Is<T>(this T o, Func<T, bool> a) where T : class
        {
            return a(o);
        }

        /// <summary>
        ///   Responsible for providing a fluent method to perform a calculation on 
        ///   a reference type.
        /// </summary>
        public static T2 Calculate<T1, T2>(this T1 o, Func<T1, T2> a) where T1 : class
        {
            return a(o);
        }

        /// <summary>
        ///   Responsible for providing a fluent method to apply boolean
        ///   logic against a reference type, *and then invert it*.
        /// </summary>
        public static bool IsNot<T>(this T o, Func<T, bool> a) where T : class
        {
            return !a(o);
        }

        /// <summary>
        ///   Responsible for providing a fluent method to apply boolean
        ///   logic against a reference type.
        /// </summary>
        public static bool Has<T>(this T o, Func<T, bool> a) where T : class
        {
            return a(o);
        }

        /// <summary>
        ///   Responsible for providing a fluent method to apply boolean
        ///   logic against a reference type, *and then invert it*.
        /// </summary>
        public static bool HasNot<T>(this T o, Func<T, bool> a) where T : class
        {
            return !a(o);
        }

        /// <summary>
        ///   Responsible for providing a fluent method to apply boolean
        ///   logic against a reference type.
        /// </summary>
        public static bool Does<T>(this T o, Func<T, bool> a) where T : class
        {
            return a(o);
        }

        /// <summary>
        ///   Responsible for providing a fluent method to apply boolean
        ///   logic against a reference type, *and then invert it*.
        /// </summary>
        public static bool DoesNot<T>(this T o, Func<T, bool> a) where T : class
        {
            return !a(o);
        }

        public static bool HasPublicProperty<T>(this T o, string propertyName) where T : class
        {
            return o.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance) != null;
        }
    }
}