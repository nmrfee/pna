namespace Lab16.Common.Extensions
{
    public static class LongExtensions
    {
        public static ulong AsPositiveLong(this long subject)
            => (ulong)subject;

        public static long GetEquivalentModulo(this long subject, long modulus)
            => subject % modulus;

        public static bool IsDivisibleBy(this long subject, long operand)
            => subject % operand == 0;

        public static bool IsEven(this long subject)
            => subject % 2 == 0;

        public static bool IsInRangeExclusive(this long subject, long minimum, long maximum)
            => minimum < subject && subject < maximum;

        public static bool IsInRangeExclusive(this ulong subject, ulong minimum, ulong maximum)
            => minimum < subject && subject < maximum;

        public static bool IsInRangeInclusive(this long subject, long minimum, long maximum)
            => minimum <= subject && subject <= maximum;

        public static bool IsInRangeInclusive(this ulong subject, ulong minimum, ulong maximum)
            => minimum <= subject && subject <= maximum;

        public static bool IsNegative(this long subject)
            => subject < 0;

        public static bool IsOdd(this long subject)
            => subject % 2 == 1;

        public static bool IsPositive(this long subject)
            => subject > 0;

        public static bool IsZero(this long subject)
            => subject == 0;

        public static bool NotDivisibleBy(this long subject, long operand)
            => subject % operand != 0;

        public static bool NotInRangeInclusive(this long subject, long minimum, long maximum)
            => !subject.IsInRangeInclusive(minimum, maximum);

        public static bool NotInRangeInclusive(this ulong subject, ulong minimum, ulong maximum)
            => !subject.IsInRangeInclusive(minimum, maximum);

        public static bool NotNegative(this long subject)
            => subject >= 0;

        public static bool NotPositive(this long subject)
            => subject <= 0;

        public static long Squared(this long subject)
            => subject * subject;
    }
}