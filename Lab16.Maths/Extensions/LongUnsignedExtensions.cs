using System.Linq;

namespace Lab16.Maths.Extensions
{
    public static class LongUnsignedExtensions
    {
        public static long AsLong(this ulong subject)
            => (long)subject;

        //public static ulong GreatestLessorPrime(this ulong subject)
        //    => Primes.YieldThru(subject)Where(p => subject >= p).Min();

        //public static ulong LeastGreaterPrime(this ulong subject)
        //    => Primes.YieldThru(subject).Min();
    }
}