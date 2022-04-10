using System;
using System.Collections.Generic;
using System.Linq;
using Lab16.Common.Extensions;

namespace Lab16.Maths
{
    public static class Extrema
    {
        public static void Of<TComparable>(IEnumerable<TComparable> subject, out TComparable minimum, out TComparable maximum)
            where TComparable : IComparable
        {
            if (subject.IsEmpty())
            {
                throw new InvalidOperationException("The enumerable is empty");
            }

            minimum = subject.First();

            maximum = subject.First();

            foreach (var element in subject)
            {
                if (element.IsGreaterThan(maximum))
                {
                    maximum = element;
                }

                if (element.IsLessThan(minimum))
                {
                    minimum = element;
                }
            }
        }
    }
}