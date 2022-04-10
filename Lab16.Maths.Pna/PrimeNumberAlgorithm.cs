using System.Collections.Generic;
using System.Linq;
using Lab16.Common;
using Lab16.Common.Collections.Generic;
using Lab16.Common.Extensions;

namespace Lab16.Maths.Pna
{
	//23# -> int  (n <= 9699689 )
	//29# -> long (n <= 6469693229)
	//47# -> long (n <= 6.1489...E+17)
	//53# -> bigInt
	public class PrimeNumberAlgorithm
	{
		public static IEnumerable<long> YieldThru(long maximum)
		{
			if (maximum.IsLessThan(2))
			{
				return Yield.EmptySetOf<long>();
			}

			if (maximum.Equals(2))
			{
				return Yield.Parameters<long>(2);
			}

			if (maximum.Equals(3))
			{
				return Yield.Parameters<long>(2, 3);
			}

			_primes = new QueueDerivative<long>(Yield.Parameters<long>(2, 3));

			var gapsOfPrimeBases = new GapsOfPrimeBases();

			var prime_i = _primes.Dequeue();

			var prime_iPlusOne = _primes.Dequeue();

			gapsOfPrimeBases
				.YieldGapsInRangeExclusive(prime_i.Squared(), prime_iPlusOne.Squared())
				.Where(gap => gap.IsLessOrEqual(maximum))
				.AddTo(_primes);

			while (Primorial.Of(prime_i).IsLessThan(maximum))
			{
				prime_i = prime_iPlusOne;

				prime_iPlusOne = _primes.Dequeue();

				gapsOfPrimeBases = gapsOfPrimeBases.ExcludingMultiplesOf(prime_i);

				gapsOfPrimeBases
					.YieldGapsInRangeExclusive(prime_i.Squared(), prime_iPlusOne.Squared())
					.Where(gap => gap.IsLessOrEqual(maximum))
					.AddTo(_primes);
			}

			gapsOfPrimeBases
				.YieldModules() // dont need to yield gaps cuz theyre the same as the modules after like 7 or 11...
				.Where(module => module.IsGreaterThan(prime_iPlusOne.Squared()) && module.IsLessOrEqual(maximum))
				.Minus(CompositeModules.FilteredFrom(gapsOfPrimeBases))
				.AddTo(_primes);

			return _primes.YieldEnqueuings();
		}

		private static QueueDerivative<long> _primes;
	}
}