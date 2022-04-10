using System.Collections.Generic;

namespace Lab16.Common.Extensions
{
    public static class CharsExtensions
    {
        public static string AsString(this IEnumerable<char> subject)
            => new string(subject.CacheOrEmpty());
    }
}