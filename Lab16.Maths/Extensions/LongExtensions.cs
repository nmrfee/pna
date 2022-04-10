using System;
using System.Linq;
using Lab16.Common.Extensions;

namespace Lab16.Maths.Extensions
{
    public static class LongExtensions
    {
        public static long GetGreatestLessorPrime(this long subject)
        {
            if (subject < 0)
            {
                throw new ArgumentException($"subject {subject} < 0");
            }

            return Maximum.Of(Primes.Thru(subject));
        }

        public static long GetLeastGreaterPrime(this long subject)
        {
            if (subject < 0)
            {
                throw new ArgumentException($"subject {subject} < 0");
            }

            var maximumFactor = SquareRoot.Of(subject).TruncateToInteger();

            var candidatePrimeFactors = Primes.Thru(maximumFactor).CacheOrEmpty();

            var _subject = subject.IsEven() ? subject + 1 : subject + 2;

            while (candidatePrimeFactors.Any(factor => _subject.IsDivisibleBy(factor)))
            {
                _subject += 2;
            }

            return _subject;
        }

        public static bool IsCoprimeWith(this long subject, long reference)
            => GreatestCommonDivisor.Of(subject).And(reference) == 1;
    }
}