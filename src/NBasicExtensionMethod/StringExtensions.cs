// Copyright 2012, Ben Aston (ben@bj.ma).
// 
// This file is part of NBasicExtensionMethod.
// 
// NBasicExtensionMethod is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NBasicExtensionMethod is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NBasicExtensionMethod. If not, see <http://www.gnu.org/licenses/>.

namespace NBasicExtensionMethod
{
	using System;
	using System.Configuration;
	using System.Globalization;
	using System.Security.Cryptography;
	using System.Text;
	using System.Text.RegularExpressions;

	public static class StringExtensions
	{
		private static readonly Regex WebUriExpression = new Regex(
			@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Singleline | RegexOptions.Compiled);

		private static readonly Regex EmailAddressExpression =
			new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
			          RegexOptions.Singleline | RegexOptions.Compiled);

		private static readonly Regex StripHtmlExpression = new Regex("<\\S[^><]*>",
		                                                              RegexOptions.IgnoreCase | RegexOptions.Singleline |
		                                                              RegexOptions.Multiline |
		                                                              RegexOptions.CultureInvariant |
		                                                              RegexOptions.Compiled);

		private static readonly char[] IllegalUrlCharacters = new[] {
			';', '/', '\\', '?', ':', '@', '&', '=', '+', '$',
			',', '<', '>', '#', '%', '.', '!', '*', '\'', '"',
			'(', ')', '[', ']', '{', '}', '|', '^', '`', '~',
			'–'
			, '‘', '’', '“', '”', '»', '«'
		};

		/// <summary>
		/// 	Returns the appsetting corresponding to the string value.
		/// </summary>
		public static string AppSetting(this string s) {
			return ConfigurationManager.AppSettings[s];
		}

		/// <summary>
		/// 	Attempts to parse a string based on the type of the default value supplied.
		/// </summary>
		/// <remarks>
		/// 	NOTE: this is an expensive method making use of exception handling to deal with enumerations.
		/// </remarks>
		/// <returns> The converted value if conversion is possible, otherwise the default value. </returns>
		public static T TryParseOrDefault<T>(this string s, T defaultValue)
			where T : IConvertible {
			if (s == null) {
				return defaultValue;
			}

			try {
				var isEnum = false;

				try {
					isEnum = Enum.IsDefined(typeof (T), s);
				} catch (ArgumentException) {}

				if (isEnum) {
					return (T) (Enum.Parse(typeof (T), s));
				}

				return (T) (Convert.ChangeType(s, typeof (T)));
			} catch (Exception) {
				return defaultValue;
			}
		}

		public static bool IsWebUrl(this string target) {
			return !string.IsNullOrEmpty(target) && WebUriExpression.IsMatch(target);
		}

		public static bool IsEmail(this string target) {
			return !string.IsNullOrEmpty(target) && EmailAddressExpression.IsMatch(target);
		}

		public static string NullSafe(this string target) {
			return (target ?? string.Empty).Trim();
		}

		public static string FormatWith(this string target, params object[] args) {
			if (string.IsNullOrWhiteSpace(target)) {
				throw new Exception("Target is empty.");
			}

			return string.Format(CultureInfo.CurrentCulture, target, args);
		}

		public static string Hash(this string target) {
			if (string.IsNullOrWhiteSpace(target)) {
				throw new Exception("Target is empty.");
			}

			using (var md5 = MD5.Create()) {
				var data = Encoding.Unicode.GetBytes(target);
				var hash = md5.ComputeHash(data);

				return Convert.ToBase64String(hash);
			}
		}

		public static string WrapAt(this string target, int index) {
			if (string.IsNullOrWhiteSpace(target)) {
				throw new Exception("Target is empty.");
			}

			if (index <= 0) {
				throw new Exception("Invalid index.");
			}

			const int dotCount = 3;

			return (target.Length <= index)
			       	? target
			       	: string.Concat(target.Substring(0, index - dotCount), new string('.', dotCount));
		}

		public static string StripWhitespace(this string s) {
			return Regex.Replace(s, @"\s", String.Empty);
		}

		public static string NormalizeWhitespaceToSingleSpaces(this string s) {
			return Regex.Replace(s, @"\s+", " ");
		}

		public static string StripHtml(this string target) {
			return StripHtmlExpression.Replace(target, string.Empty);
		}

		public static string StripFileExtension(this string target) {
			return target.Substring(0, target.LastIndexOf('.'));
		}

		public static Guid ToGuid(this string target) {
			var result = Guid.Empty;

			if ((!string.IsNullOrEmpty(target)) && (target.Trim().Length == 22)) {
				var encoded = string.Concat(target.Trim().Replace("-", "+").Replace("_", "/"), "==");
				var base64 = Convert.FromBase64String(encoded);

				result = new Guid(base64);
			}

			return result;
		}

		public static T ToEnum<T>(this string target, T defaultValue) where T : IComparable, IFormattable {
			var convertedValue = defaultValue;

			if (!string.IsNullOrEmpty(target)) {
				convertedValue = (T) Enum.Parse(typeof (T), target.Trim(), true);
			}

			return convertedValue;
		}

		public static string ToLegalUrl(this string target) {
			if (string.IsNullOrEmpty(target)) {
				return target;
			}

			target = target.Trim();

			if (target.IndexOfAny(IllegalUrlCharacters) > -1) {
				foreach (var character in IllegalUrlCharacters) {
					target = target.Replace(character.ToString(CultureInfo.CurrentCulture), string.Empty);
				}
			}

			target = target.Replace(" ", "-");

			while (target.Contains("--")) {
				target = target.Replace("--", "-");
			}

			return target;
		}

		public static string Repeat(this string source, int length) {
			if (source.IsNotNullOrWhiteSpace()) {
				throw new Exception("String repeat source is empty.");
			}

			if (length <= 0) {
				throw new ArgumentOutOfRangeException("length");
			}

			var b = new StringBuilder(source.Length*length);
			for (var x = 0; x < length; x++) b.Append(source);
			return b.ToString();
		}

		public static string With(this string format, params object[] args) {
			return string.Format(format, args);
		}

		public static bool IsNullOrWhiteSpace(this string s) {
			return string.IsNullOrWhiteSpace(s);
		}

		public static bool IsNotNullOrWhiteSpace(this string s) {
			return !string.IsNullOrWhiteSpace(s);
		}

		public static bool IsNullOrEmpty(this string s) {
			return string.IsNullOrEmpty(s);
		}

		public static bool IsNotNullOrEmpty(this string s) {
			return !string.IsNullOrEmpty(s);
		}

		/// <summary>
		/// 	A utility method for determining the assembly qualified name for a type of a given name for which we do not know the containing assembly at run time. See <a
		///  	href="http://msdn.microsoft.com/en-us/library/system.type.assemblyqualifiedname.aspx">MSDN</a> .
		/// </summary>
		/// <param name="typeName"> The name of the type to find the assembly qualified name for. This must include the full namespace. </param>
		/// <returns> The assembly qualified name of the type. </returns>
		public static string GetAssemblyQualifiedName(this string typeName) {
			if (typeName.IsNotNullOrWhiteSpace()) {
				throw new Exception("Type name is empty.");
			}

			foreach (var currentassembly in AppDomain.CurrentDomain.GetAssemblies()) {
				var t = currentassembly.GetType(typeName, false, true);
				if (t != null) return t.AssemblyQualifiedName;
			}

			throw new ArgumentException("Unable to find supplied type name: " + typeName);
		}

		public static string WithCapitalizedFirstLetter(this string s) {
			if (s.IsNotNullOrWhiteSpace()) {
				throw new Exception("String to capitalize is empty.");
			}

			return char.ToUpper(s[0]) + s.Substring(1);
		}

		public static byte[] ToUtf8Bytes(this string s) {
			return Encoding.UTF8.GetBytes(s);
		}
	}
}