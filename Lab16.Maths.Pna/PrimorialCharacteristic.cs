using System.Collections.Generic;
using Lab16.Common.Extensions;

namespace Lab16.Maths.Pna
{
	internal partial class PrimorialCharacteristic
	{
		private PrimorialCharacteristic(long max, string name, Dictionary<long, long> modCache)
		{
			_longMax = max;

			_modCache = modCache;

			Name = name;
		}

		internal long AsLong()
			=> _longMax;

		internal ulong AsPositiveLong()
			=> Given
				.That(_longMax.Equals(long.MaxValue))
				.ThenReturn(ulong.MaxValue)
				.Otherwise(_longMax.AsPositiveLong());

		internal long GetEquivalentModulo(long modulus)
			=> _modCache[modulus];

		// 53# > ulong.maxValue => 53# > long.maxValue
		// 47# < long.maxValue
		internal bool IsLargerThanLong()
			=> _longMax.Equals(long.MaxValue);

		internal bool IsLargerThanPositiveLong()
			=> _longMax.Equals(long.MaxValue);

		internal string Name { get; }

		internal static PrimorialCharacteristic Of(long prime)
			=> _primorialCache[prime];

		private readonly long _longMax;

		private readonly Dictionary<long, long> _modCache;

		private static readonly Dictionary<long, PrimorialCharacteristic> _primorialCache;
	}
}