using System;

namespace Lab16.Maths.Extensions
{
	public static class IntExtensions
	{
		public static bool IsPrime(this int subject)
			=> subject != 1 && subject.IsPrimeOrOne();

		// TODO use AKS :)
		public static bool IsPrimeOrOne(this int subject)
		{
			if (subject < 0)
			{
				throw new InvalidOperationException($"{nameof(subject)} cant be negative");
			}

			if (subject == 0)
			{
				return false;
			}

			if (subject == 1)
			{
				return true;
			}

			if (subject % 2 == 0)
			{
				return false;
			}

			if (subject % 3 == 0)
			{
				return false;
			}

			for (var x = 5; x <= Math.Sqrt(subject) + 1; x += 2)
			{
				if (subject % x == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}