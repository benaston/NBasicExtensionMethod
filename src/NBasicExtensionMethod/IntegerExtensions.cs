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

	public static class IntegerExtensions
	{
		public static TimeSpan Millisecond(this int i) {
			if (i != 1) {
				throw new ArgumentOutOfRangeException();
			}

			return TimeSpan.FromMilliseconds(1);
		}

		public static TimeSpan Milliseconds(this int i) {
			return TimeSpan.FromMilliseconds(i);
		}

		public static TimeSpan Second(this int i) {
			if (i != 1) {
				throw new ArgumentOutOfRangeException();
			}

			return TimeSpan.FromSeconds(1);
		}

		public static TimeSpan Seconds(this int i) {
			return TimeSpan.FromSeconds(i);
		}

		public static TimeSpan Minute(this int i) {
			if (i != 1) {
				throw new ArgumentOutOfRangeException();
			}

			return TimeSpan.FromMinutes(1);
		}

		public static TimeSpan Minutes(this int i) {
			return TimeSpan.FromMinutes(i);
		}

		public static TimeSpan Hour(this int i) {
			if (i != 1) {
				throw new ArgumentOutOfRangeException();
			}

			return TimeSpan.FromHours(1);
		}

		public static TimeSpan Hours(this int i) {
			return TimeSpan.FromHours(i);
		}

		public static TimeSpan Day(this int i) {
			if (i != 1) {
				throw new ArgumentOutOfRangeException();
			}

			return TimeSpan.FromDays(i);
		}

		public static TimeSpan Days(this int i) {
			return TimeSpan.FromDays(i);
		}

		/// <remarks>
		/// 	See http://en.wikipedia.org/wiki/Leap_year for avg days in yr.
		/// </remarks>
		public static TimeSpan Years(this int i) {
			return TimeSpan.FromDays(i*365.2425d); //see remarks
		}

		public static bool IsBetween(this int i, int lowerBound, int upperBound) {
			return (i > lowerBound) && (i < upperBound);
		}

		public static bool IsBetweenInclusive(this int i, int lowerBound, int upperBound) {
			return (i >= lowerBound) && (i <= upperBound);
		}

		public static bool IsGreaterThan(this int i, int bound) {
			return i > bound;
		}

		public static bool IsPositive(this int i) {
			return i >= 0;
		}

		public static bool IsLessThan(this int i, int bound) {
			return i < bound;
		}
	}
}