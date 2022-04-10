using System.Collections;
using System.Collections.Generic;
using Lab16.Common.Collections.Generic;
using Lab16.Common.Extensions;
using Lab16.Maths.Extensions;

namespace Lab16.Maths.Pna
{
	internal class SetOfFactors : IEnumerable<long>
	{
		internal SetOfFactors(long factor)
		{
			_factors = new Enumerable<long>(factor);
			Maximum = factor;
		}

		internal SetOfFactors(IEnumerable<long> factors)
		{
			_factors = new Enumerable<long>();

			foreach (var factor in factors)
			{
				if (Maximum < factor)
				{
					Maximum = factor;
				}

				_factors.Add(factor);
			}
		}

		internal SetOfFactors(long factor, IEnumerable<long> factors)
			: this(factor.ThenAll(factors)) { }

		public IEnumerator<long> GetEnumerator()
			=> _factors.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> _factors.GetEnumerator();

		internal long GetProduct()
			=> _factors.GetProduct();

		internal bool IsRedundantBefore(long factor)
			=> factor < Maximum;

		internal long Maximum { get; }

		private readonly Enumerable<long> _factors;
	}
}