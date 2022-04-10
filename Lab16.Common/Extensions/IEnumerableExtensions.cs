using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab16.Common.Collections.Generic;

namespace Lab16.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TElement> AddTo<TElement>(this IEnumerable<TElement> subject, Enumerable<TElement> enumerable)
        {
            enumerable.AddRange(subject);

            return subject;
        }

        public static IEnumerable<TElement> AddTo<TElement>(this IEnumerable<TElement> subject, Queue<TElement> queue)
        {
            queue.EnqueueRange(subject);

            return subject;
        }

        public static IEnumerable<TElement> AddTo<TElement>(this IEnumerable<TElement> subject, QueueDerivative<TElement> queue)
        {
            queue.EnqueueRange(subject);

            return subject;
        }

        public static IReadable<TElement> AsReadable<TElement>(this IEnumerable<TElement> subject)
            => new EnumerableReadable<TElement>(subject);

        public static TObject[] Cache<TObject>(this IEnumerable<TObject> subject)
        {
            if (subject == null)
            {
                return new TObject[0];
            }

            return subject as TObject[] ?? subject.ToArray();
        }

        public static TObject[] Cache<TObject>(this IEnumerable<TObject> subject, out TObject[] result)
        {
            result = subject.Cache();

            return result;
        }

        public static TObject[] CacheOrDefault<TObject>(this IEnumerable<TObject> subject, out TObject[] result)
        {
            result = subject.Cache();

            return result;
        }

        public static TObject[] CacheOrEmpty<TObject>(this IEnumerable<TObject> subject, out TObject[] result)
            => result = subject.SelectOrEmpty().Cache();

        public static object[] CacheOrEmpty(this IEnumerable subject, out object[] result)
            => result = subject.Cast<object>().SelectOrEmpty().Cache();

        public static object[] CacheOrEmpty(this IEnumerable subject)
            => subject.Cast<object>().SelectOrEmpty().Cache();

        public static TObject[] CacheOrEmpty<TObject>(this IEnumerable<TObject> subject)
            => subject.SelectOrEmpty().Cache();

        public static TObject[] CacheOrDefault<TObject>(this IEnumerable<TObject> subject)
            => subject.SelectOrEmpty().Cache();

        public static void ForEach<TObject>(this IEnumerable<TObject> subject, Action<int, TObject> callFunction)
        {
            if (subject != null)
            {
                var index = 0;
                foreach (var item in subject)
                {
                    callFunction(index++, item);
                }
            }
        }

        public static void ForEach<TObject>(this IEnumerable<TObject> subject, Action<TObject> callFunction)
        {
            if (subject != null)
            {
                foreach (var item in subject)
                {
                    callFunction(item);
                }
            }
        }

        public static void ForEach<TObject>(this IEnumerable<TObject> subject, Action callFunction)
        {
            if (subject != null)
            {
                foreach (var _ in subject)
                {
                    callFunction();
                }
            }
        }

        public static bool IsEmpty<TElement>(this IEnumerable<TElement> subject) 
            => !subject.Any();

        public static bool IsNullOrEmpty<TElement>(this IEnumerable<TElement> subject)
          => subject is null || !subject.Any();

        public static IEnumerable<TObject> Minus<TObject>(this IEnumerable<TObject> subject, IEnumerable<TObject> operand)
            => subject.Where(element => !operand.Contains(element));

        public static bool NotEmpty<TElement>(this IEnumerable<TElement> subject)
            => subject?.Any() ?? false;

        public static IEnumerable<TObject> SelectOrEmpty<TObject>(this IEnumerable<TObject> subject)
            => subject ?? new TObject[0];

        public static IEnumerable<TObject> SelectOrEmpty<TObject>(this IEnumerable<TObject> subject, out IEnumerable<TObject> result)
        {
            result = subject ?? new TObject[0];

            return result;
        }

        public static IEnumerable<TResult> SelectOrEmpty<TElement, TResult>(this IEnumerable<TElement> subject, Func<TElement, TResult> selector)
            => subject.SelectOrEmpty().Select(selector);

        public static IEnumerable<TElement> Then<TElement>(this IEnumerable<TElement> subject, TElement reference)
            => new EnumerableCompound<TElement>(subject, reference);

        public static IEnumerable<TElement> ThenAll<TElement>(this IEnumerable<TElement> subject, IEnumerable<TElement> reference)
            => new EnumerableCompound<TElement>(subject, reference);

        public static string ToAggregateString<TObject>(this IEnumerable<TObject> subject, object separator)
        {
            // todo move cache to common ....?

            var itemsArray = subject?.ToArray() ?? new TObject[0]; // hmmm

            if (itemsArray.Length == 0)
            {
                return "";
            }

            var builder = new StringBuilder(itemsArray[0].ToString());

            for (var i = 1; i < itemsArray.Length; i++)
            {
                builder.Append($"{separator}{itemsArray[i]}");
            }

            return $"{builder}";
        }

        public static string ToAggregateString<TObject>(this IEnumerable<TObject> subject)
        {
            if (subject == null)
            {
                return "Null";
            }

            var subjectCache = subject as TObject[] ?? subject.ToArray();

            return subjectCache.Length == 0
                ? "[ Empty ]"
                : $"{string.Join(", ", subjectCache.Select(item => $"{item}"))}";
        }

        public static string ToAggregateLines<TObject>(this IEnumerable<TObject> subject)
            => string.Join("\r\n", subject.Select(item => $"{item}"));

        public static string ToAggregateString(this IEnumerable subject)
        {
            var builder = new StringBuilder();

            Action<StringBuilder, string> append
                = (sb, s) =>
                {
                    _startStringBuilding(sb, s);
                    append = _continueStringBuilding;
                };

            foreach (var item in subject)
            {
                append(builder, $"{item}");
            }

            return builder.ToString();
        }

        private static void _continueStringBuilding(StringBuilder builder, string @object)
            => builder.Append($", {@object}");

        private static void _startStringBuilding(StringBuilder builder, string @object)
            => builder.Append(@object);
    }
}