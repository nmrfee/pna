using System;

namespace Lab16.Maths
{
    public static class SquareRoot
    {
        public static double Of(int subject) 
            => Math.Sqrt(subject);

        public static double Of(long subject)
            => Math.Sqrt(subject);
    }
}