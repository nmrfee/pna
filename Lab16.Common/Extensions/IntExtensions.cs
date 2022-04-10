using System;

namespace Lab16.Common.Extensions
{
    public static class IntExtensions
    {
		public static long AsLong(this int subject)
			=> (long)subject;

		public static ulong AsPositiveLong(this int subject)
			=> (ulong)subject;

		public static int GetEquivalentModulo(this int subject, int modulus)
			=> subject % modulus;

		public static bool IsDivisibleBy(this int subject, int factor)
			=> subject % factor == 0;

		public static bool IsEven(this int integer)
			=> integer % 2 == 0;

		public static bool IsInRangeInclusive(this int subject, int minimum, int maximum)
			=> minimum <= subject && subject <= maximum;

		public static bool IsNegative(this int subject)
			=> subject < 0;

		public static bool IsOdd(this int integer)
			=> integer % 2 == 1;

		public static bool IsZero(this int subject)
			=> subject == 0;

		public static bool NotDivisibleBy(this int subject, int reference)
			=> !subject.IsDivisibleBy(reference);

		public static bool NotInRangeInclusive(this int subject, int minimum, int maximum)
			=> !subject.IsInRangeInclusive(minimum, maximum);

		public static bool NotNegative(this int subject)
			=> subject >= 0;

		public static bool NotZero(this int subject)
			=> subject != 0;

		public static int Squared(this int subject)
			=> subject * subject;

		public static int ToThe(this int subject, int exponent)
		{
			if (exponent < 0)
			{
				throw new System.NotImplementedException($"{subject}^{exponent} (Negative exponent)");
			}

			if (exponent == 0)
			{
				return 1;
			}

			// TODO handle any overflow
			return (int)Math.Pow(subject, exponent);
		}
	}
}