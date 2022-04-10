using System.Collections.Generic;
using System.Linq;
using Lab16.Common.Collections.Generic;
using Lab16.Common.Extensions;
using Lab16.Maths.Extensions;

namespace Lab16.Maths.Pna
{
    public partial class CompositeModules
    {
        public static void Filter(GapsOfPrimeBases gapsOfPrimeBases, out IEnumerable<long> composites, out IEnumerable<long> primes)
        {
            var primorial = gapsOfPrimeBases.Base.AsLong() - 1;
            var nextPrime = gapsOfPrimeBases.PrimeDeterminant.GetLeastGreaterPrime();

            _filter(primorial, gapsOfPrimeBases.PrimeDeterminant, nextPrime, gapsOfPrimeBases.YieldModules(), out composites, out primes);
        }

        public static void Filter(
            long primeDeterminant,
            IEnumerable<long> modules,
            out IEnumerable<long> composites,
            out IEnumerable<long> primes)
        {
            var primorial = Primorial.Of(primeDeterminant).AsLong() - 1;
            var nextPrime = primeDeterminant.GetLeastGreaterPrime();

            _filter(primorial, primeDeterminant, nextPrime, modules, out composites, out primes);
        }

        public static IEnumerable<long> FilteredFrom(GapsOfPrimeBases gapsOfPrimeBases) 
            => _filter2(gapsOfPrimeBases.Base.AsLong(), gapsOfPrimeBases.PrimeDeterminant.GetLeastGreaterPrime());

        private static IEnumerable<long> _filter2(
         long primorial, // the actual primorial (the caller should not -1)
                         //   long primeDeterminant,
            long nextPrime
           //   IEnumerable<long> modules,
           //  out IEnumerable<long> composites,
           // out IEnumerable<long> primes
           )
        {
            var result = new Enumerable<long>();

            //       var primeSet = new Enumerable<long>();

            //modules
            //    .Where(module_i => module_i.IsGreaterThan(primeDeterminant.Squared()) && module_i.IsLessThan(nextPrime.Squared()))
            //    .AddTo(primeSet);

            var primeFactors = Primes.InRangeInclusive(nextPrime, SquareRoot.Of(primorial - 1).TruncateToInteger());

            var factors = new QueueDerivative<SetOfFactors>(primeFactors.Select(prime => new SetOfFactors(prime)));

            while (factors.NotEmpty())
            {
                var f_i = factors.Dequeue();

                var productOfF_i = f_i.GetProduct();

                var maximumOperand = (primorial - 1) / productOfF_i;

                if (maximumOperand.IsLessThan(nextPrime))
                {
                    continue;
                }

                var operands = Primes.InRangeInclusive(nextPrime, maximumOperand).Where(prime => prime.IsGreaterOrEqual(f_i.Maximum));

                foreach (var operand in operands)
                {
                    var m_i = productOfF_i * operand;

                    result.Add(m_i);

                    if (((primorial - 1) / m_i).IsGreaterOrEqual(nextPrime))
                    {
                        factors.Enqueue(new SetOfFactors(operand, f_i));
                    }
                }
            }

            return result;
        }

        private static void _filter(
            long primorial,
            long primeDeterminant,
            long nextPrime,
            IEnumerable<long> modules,
            out IEnumerable<long> composites,
            out IEnumerable<long> primes)
        {
            var compositeSet = new Enumerable<long>();

            var primeSet = new Enumerable<long>();
            
            modules
                .Where(module_i => module_i.IsGreaterThan(primeDeterminant.Squared()) && module_i.IsLessThan(nextPrime.Squared()))
                .AddTo(primeSet);

            var factors = new QueueDerivative<SetOfFactors>(primeSet.Select(primeFactor => new SetOfFactors(primeFactor)));

            while (factors.NotEmpty())
            {
                var factorSet = factors.Dequeue();

                var maximumOperand = primorial / factorSet.GetProduct();

                if (maximumOperand.IsLessThan(nextPrime))
                {
                    continue;
                }

                var operands = primeSet.Where(m_i => m_i.IsGreaterOrEqual(nextPrime) && m_i.IsLessOrEqual(maximumOperand));

                foreach (var operand in operands)
                {
                    if (factorSet.IsRedundantBefore(operand))
                    {
                        continue;
                    }

                    var product = factorSet.GetProduct() * operand;

                    if ((primorial / product).IsGreaterOrEqual(nextPrime))
                    {
                        factors.Enqueue(new SetOfFactors(operand, factorSet));
                    }

                    compositeSet.Add(product);

                    if (factorSet.GetProduct().Equals(nextPrime))
                    {
                        foreach (var primeModule in modules.Where(m_i => m_i.IsLessThan(product)).Minus(compositeSet))
                        {
                            if (!primeSet.Contains(primeModule))
                            {
                                primeSet.Add(primeModule);
                            }
                        }
                    }
                }
            }

            composites = compositeSet;

            primes = primeSet;
        }

        internal static IEnumerable<long> Of(long primeDeterminant)
        {
            var primorial = Primorial.Of(primeDeterminant).AsLong() - 1;

            var nextPrime = primeDeterminant.GetLeastGreaterPrime();

            var maximumFactor = primorial / nextPrime;

            var factors =
                new Queue<SetOfFactors>(Primes.InRangeInclusive(nextPrime, maximumFactor)
                    .Select(primeFactor => new SetOfFactors(primeFactor)));

            while (factors.NotEmpty())
            {
                var factorSet = factors.Dequeue();
                var maximumOperand = primorial / factorSet.GetProduct();

                if (maximumOperand.IsLessThan(nextPrime))
                {
                    continue;
                }

                var operands = Primes.InRangeInclusive(nextPrime, maximumOperand);

                foreach (var operand in operands)
                {
                    if (factorSet.IsRedundantBefore(operand))
                    {
                        continue;
                    }

                    var product = factorSet.GetProduct() * operand;

                    if ((primorial / product).IsGreaterOrEqual(nextPrime))
                    {
                        factors.Enqueue(new SetOfFactors(operand, factorSet));
                    }

                    yield return product;
                }
            }
        }
    }
}