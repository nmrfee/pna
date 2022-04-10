using System;
using System.Collections.Generic;

namespace Lab16.Maths
{
    public class YieldOfLong
    {
        public static IEnumerable<long> RangeInclusive(long minimum, long maximum)
        {
            if (maximum < minimum)
            {
                throw new InvalidOperationException($"The {nameof(maximum)} ({maximum}) cant be less than {nameof(minimum)} ({minimum}");
            }

            for (var integer_i = minimum; integer_i <= maximum; integer_i++)
            {
                yield return integer_i;
            }
        }
    }
}