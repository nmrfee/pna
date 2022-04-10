using System;
using System.Linq;
using Lab16.Common.Collections.Generic;
using Lab16.Common.Extensions;
using Lab16.Common.Testing;

namespace Lab16.Maths.Pna.Tests
{
    internal class PrimeNumberAlgorithmTestContainer : ITestContainer
    {
        [Demo]
        public string YieldThruOneThousand()
        {
            _yieldThru(1_000);

            return "Success (but didnt check for duplicates)";
        }

        [Demo]
        public string YieldThruOneHundredThousand()
        {
            _yieldThru(100_000);

            return "Success (but didnt check for duplicates)";
        }

        //[Demo]
        //public string YieldThruOneMillion()
        //{
        //    _yieldThru(1_000_000);

        //    return "Success (but didnt check for duplicates)";
        //}

        private void _yieldThru(long maximum)
        {
            var generatedPrimes = PrimeNumberAlgorithm.YieldThru(maximum).CacheOrEmpty();

            var expectedPrimes = Primes.Thru(maximum).CacheOrEmpty();

            var incorrectResults = new Enumerable<long>();

            generatedPrimes
                .Where(candidate => !expectedPrimes.Contains(candidate)) // candidate.NotIn(expectedPrimes)
                .AddTo(incorrectResults);

            var missingResults = new Enumerable<long>();

            expectedPrimes
                .Where(prime => !generatedPrimes.Contains(prime))
                .AddTo(missingResults);

            if (incorrectResults.Any() || missingResults.Any())
            {
                var message = $"Incorrect: {incorrectResults.ToAggregateString()}\r\n\r\nMissing: {missingResults.ToAggregateString()}";

                throw new Exception(message);
            }
        }
    }
}