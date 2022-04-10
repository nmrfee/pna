using Lab16.Common.Extensions;

namespace Lab16.Maths.Pna
{
	public class Primorial
	{
        private Primorial(long primeDeterminant) 
			=> _characteristic = PrimorialCharacteristic.Of(primeDeterminant);

        public long AsLong() 
			=> _characteristic.AsLong();

		public ulong AsPositiveLong()
			=> _characteristic.AsPositiveLong();

		public long GetMagicModuleFor(long module, long @base)
		{
			// the bases should be coprime

			var aModBase = GetEquivalentModulo(@base);
			var mod = aModBase;

			for (var exponent = 1; exponent < @base - 2; exponent++)
			{
				mod *= aModBase;
				mod %= @base;
			}

			var rt = @base - module;
			rt %= @base;
			rt *= mod;
			rt %= @base;

			return Given.That(rt.IsNegative())
						.ThenReturn(rt + @base)
						.Otherwise(rt);
		}

		public long GetEquivalentModulo(long modulus)
			=> _characteristic.GetEquivalentModulo(modulus);

		public bool IsGreaterOrEqual(long reference)
			=> _characteristic.AsLong() >= reference;

        public bool IsGreaterThan(long reference)
			=> _characteristic.AsLong() > reference;

        public bool IsLargerThanLong() 
			=> _characteristic.IsLargerThanLong();

        public bool IsLargerThanPositiveLong() 
			=> _characteristic.IsLargerThanPositiveLong();

        public bool IsLessOrEqual(long reference)
			=> _characteristic.AsLong() <= reference;

		public bool IsLessThan(long reference)
			=> _characteristic.AsLong() < reference;

		public static Primorial Of(long primeDeterminant) 
			=> new Primorial(primeDeterminant);

        public override string ToString() 
			=> _characteristic.Name;

        private readonly PrimorialCharacteristic _characteristic;
	}
}