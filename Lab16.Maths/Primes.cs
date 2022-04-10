using System;
using System.Collections.Generic;
using System.Linq;
using Lab16.Common.Extensions;
using Lab16.Maths.Extensions;

namespace Lab16.Maths
{
    public static partial class Primes
    {
        internal static long CacheMaximum
            => _cache[_cache.Length - 1];

        internal static int CacheCount
            => _cache.Length;

        public static IEnumerable<long> InRangeInclusive(long minimum, long maximum)
            => Thru(maximum).Where(prime_i => prime_i.IsGreaterOrEqual(minimum));

        public static IEnumerable<long> Thru(long maximum)
        {
            if (maximum.IsNegative())
            {
                throw new ArgumentException($"{nameof(maximum)} is negative");
            }

            if (maximum == 0 || maximum == 1)
            {
                yield break;
            }

            foreach (var cachedPrime_i in _cache)
            {
                if (cachedPrime_i.IsGreaterThan(maximum))
                {
                    yield break;
                }

                yield return cachedPrime_i;
            }

            var prime_i = CacheMaximum.GetLeastGreaterPrime();

            while (maximum.IsGreaterOrEqual(prime_i))
            {
                yield return prime_i;

                prime_i = prime_i.GetLeastGreaterPrime();
            }
        }
    }
}