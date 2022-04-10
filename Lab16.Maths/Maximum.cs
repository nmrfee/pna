using System;
using System.Collections.Generic;

namespace Lab16.Maths
{
    public static class Maximum
    {
        public static TComparable Of<TComparable>(IEnumerable<TComparable> subject)
            where TComparable : IComparable
        {
            Extrema.Of(subject, out _, out var maximum);

            return maximum;
        }
    }
}