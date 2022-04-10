using Lab16.Common.Collections.Generic;

namespace Lab16.Common.Extensions
{
    public static class IReadableExtensions
	{
		public static bool NotEmpty<TElement>(this IReadable<TElement> subject)
			=> !subject.IsEmpty();
	}
}