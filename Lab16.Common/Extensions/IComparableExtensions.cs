using System;

namespace Lab16.Common.Extensions
{
    public static class IComparableExtensions
    {
        public static bool IsAtLeast<TComparable>(this TComparable subject, TComparable reference)
            where TComparable : IComparable
            => subject.IsGreaterOrEqual(reference);

        public static bool IsAtMost<TComparable>(this TComparable subject, TComparable reference)
            where TComparable : IComparable
            => subject.IsLessOrEqual(reference);

        public static bool IsGreaterOrEqual<TObject>(this IComparable<TObject> subject, TObject reference)
            => subject.CompareTo(reference) >= 0;

        public static bool IsGreaterOrEqual<TComparable>(this TComparable subject, TComparable reference)
            where TComparable : IComparable
            => subject.CompareTo(reference) >= 0;

        public static bool IsGreaterThan<TComparable>(this TComparable subject, TComparable reference)
            where TComparable : IComparable
            => subject.CompareTo(reference) > 0;

        public static bool IsGreaterThan<TObject>(this IComparable<TObject> subject, TObject reference)
            => subject.CompareTo(reference) > 0;

        public static bool IsLessOrEqual<TObject>(this IComparable<TObject> subject, TObject reference)
            => subject.CompareTo(reference) <= 0;

        public static bool IsLessOrEqual<TComparable>(this TComparable subject, TComparable reference)
            where TComparable : IComparable
            => subject.CompareTo(reference) <= 0;

        public static bool IsLessThan<TComparable>(this TComparable subject, TComparable reference)
            where TComparable : IComparable
            => subject.CompareTo(reference) < 0;

        public static bool IsLessThan<TObject>(this IComparable<TObject> subject, TObject reference)
            => subject.CompareTo(reference) < 0;
    }
}