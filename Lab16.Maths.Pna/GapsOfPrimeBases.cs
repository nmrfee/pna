using System.Collections.Generic;
using System.Linq;
using Lab16.Common;
using Lab16.Common.Collections.Generic;
using Lab16.Common.Extensions;

namespace Lab16.Maths.Pna
{
    public sealed class GapsOfPrimeBases
    {
        public GapsOfPrimeBases()
            : this(2, Yield.Parameters<long>(1)) { }

        private GapsOfPrimeBases(long primeDeterminant, IEnumerable<long> modules)
        {
            PrimeDeterminant = primeDeterminant;

            Base = Primorial.Of(primeDeterminant);

            _modules = new Enumerable<long>(modules);
        }

        public Primorial Base { get; }

        public GapsOfPrimeBases ExcludingMultiplesOf(long primeBase)
            => new GapsOfPrimeBases(primeBase, _yieldModules(primeBase));

        public long PrimeDeterminant { get; }

        public IEnumerable<long> YieldGapsInRangeExclusive(long ySublimit, long yLimit)
        {
            var compoundBase = Base.AsLong();

            Extrema.Of(_modules, out var minModule, out var maxModule);

            var xMin = IntegralLinearInverse.MinimumRankWithout(ySublimit, compoundBase, maxModule);

            var xMax = IntegralLinearInverse.MaximumRankWithout(yLimit, compoundBase, minModule);

            return
                YieldOfLong
                .RangeInclusive(xMin, xMax)
                .SelectMany(x => _modules.Where(module => (compoundBase * x + module).IsInRangeExclusive(ySublimit, yLimit)).Select(b => compoundBase * x + b));
        }

        // These are the characteristics=modules in base = #(primeDeterminant)
        public IEnumerable<long> YieldModules()
            => _modules;

        private readonly Enumerable<long> _modules;

        private IEnumerable<long> _yieldModules(long primeBase)
        {
            foreach (var r_i in YieldOfLong.RangeInclusive(0, primeBase - 1))
            {
                foreach (var module in _modules)
                {
                    if (r_i.Equals(Base.GetMagicModuleFor(module, primeBase)))
                    {
                        continue;
                    }

                    yield return Base.AsLong() * r_i + module;
                }
            }
        }
    }
}