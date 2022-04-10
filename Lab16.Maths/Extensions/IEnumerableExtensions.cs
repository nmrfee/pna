using System.Collections.Generic;
using System.Linq;

namespace Lab16.Maths.Extensions
{
    public static class IEnumerableExtensions
    {
        public static int GetProduct(this IEnumerable<int> numbers)
            => numbers.Aggregate(1, (product, number) => product * number);

        public static uint GetProduct(this IEnumerable<uint> numbers)
          => numbers.Aggregate((uint)1, (product, number) => product * number);

        public static long GetProduct(this IEnumerable<long> numbers)
            => numbers.Aggregate((long)1, (product, number) => product * number);

        public static ulong GetProduct(this IEnumerable<ulong> numbers)
            => numbers.Aggregate((ulong)1, (product, number) => product * number);
    }
}