using Lab16.Common.Extensions;

namespace Lab16.Maths
{
	public static class IntegralLinearInverse
	{
		// returns the *smallest* rank r_0 such that b(r)+m <= y_0, for r <= r_0
		public static long MaximumRankUnder(long y_0, long @base, long module)
		{
			if (@base.IsNegative())
			{
				throw new System.NotImplementedException($"{nameof(@base)} < 0");
			}

			return Given.That( y_0.IsGreaterThan(module) || (y_0 - module).IsDivisibleBy(@base))
			            .ThenReturn((y_0 - module) / @base)
			            .Otherwise(-1 + (y_0 - module) / @base);
		}

		// returns the *smallest* rank r_0 such that b(r)+m < y_0, for r < r_0
		public static long MaximumRankWithout(long y_0, long @base, long module)
		{
			var maximum = MaximumRankUnder(y_0, @base, module);

			return (@base * maximum + module).Equals(y_0) ? maximum - 1 : maximum;
		}

		// returns the *largest* rank r_0 such that b(r)+m >= y_0, for r >= r_0
		public static long MinimumRankOver(long y_0, long @base, long module)
		{
			if (@base.IsNegative())
			{
				throw new System.NotImplementedException($"{nameof(@base)} < 0");
			}

			return Given.That(y_0.IsGreaterThan(module) && (y_0 - module).NotDivisibleBy(@base))
			            .ThenReturn(1 + (y_0 - module) / @base)
			            .Otherwise((y_0 - module) / @base);
		}

		// returns the *largest* rank r_0 such that b(r)+m > y_0, for r > r_0
		public static long MinimumRankWithout(long y_0, long a, long b)
		{
			var minimum = MinimumRankOver(y_0, a, b);

			return Given.That((a * minimum + b).Equals(y_0))
						.ThenReturn(minimum + 1)
						.Otherwise(minimum);
		}

		public static long RankOf(long y_0, long @base, long module)
		{
			if (@base.IsNegative())
			{
				throw new System.NotImplementedException($"{nameof(@base)} < 0");
			}

			if ((y_0 - module).NotDivisibleBy(@base))
			{
				throw new System.InvalidOperationException($"{nameof(y_0)} not = {module} mod {@base}");
			}

			return (y_0 - module) / @base;
		}

		// returns the theoretical rank(y_0), assuming y_0 = m mod b
		// if rank(y_0) is not an integer, the floor(rank) is returned.
		// floor(rank) is the rank y_0 would be in if it were bx+m,
		// because floor(rank) < rank < ceil(rank).
		// theoretical rank is off by at most 1 from rank( bx+(y_0 mod b) )
		public static long TheoreticalRankOf(long y_0, long @base, long module)
		{
			if (@base.IsNegative())
			{
				throw new System.NotImplementedException($"{nameof(@base)} < 0");
			}

			return (y_0 - module) / @base;
		}
	}
}