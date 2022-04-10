using System.Collections.Generic;

namespace Lab16.Common.Extensions
{
    public static class QueueExtensions
	{
		public static void EnqueueRange<TObject>(this Queue<TObject> subject, IEnumerable<TObject> @object)
		{
			foreach (var item in @object)
			{
				subject.Enqueue(item);
			}
		}

		public static bool NotEmpty<TObject>(this Queue<TObject> subject)
			=> subject.Count > 0;
	}
}