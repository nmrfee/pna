using Lab16.Common;

namespace Lab16.Maths
{
	public class GreatestCommonDivisor
	{
		public static GreatestCommonDivisorInt Of(int subject)
			  => new GreatestCommonDivisorInt(subject);

		public static GreatestCommonDivisorLong Of(long subject)
			  => new GreatestCommonDivisorLong(subject);
	}

	public class GreatestCommonDivisorInt 
	{
		internal GreatestCommonDivisorInt(int subject)
			=> _subject = subject;

		public int And(int reference)
		{
			Extrema.Of(Yield.Parameters(_subject, reference), out var lesser, out var greater);

			while (greater != 0)
			{
				var mod = lesser % greater;

				lesser = greater;

				greater = mod;
			}

			return lesser;
		}

		private readonly int _subject;
	}

	public class GreatestCommonDivisorLong : GreatestCommonDivisor
	{
		internal GreatestCommonDivisorLong(long subject)
			=> _subject = subject;

		public long And(long reference)
		{
			Extrema.Of(Yield.Parameters(_subject, reference), out var lesser, out var greater);

			while (greater != 0)
			{
				var mod = lesser % greater;

				lesser = greater;

				greater = mod;
			}

			return lesser;
		}

		private readonly long _subject;
	}
}