using System.Collections.Generic;

namespace Lab16.Common
{
    public sealed class Repetitions<TObject>
	{
		internal Repetitions(TObject subject)
			=> _subject = subject;

		public IEnumerable<TObject> Times(int count)
		{
			for (var i = 0; i < count; i++)
			{
				yield return _subject;
			}
		}

		private readonly TObject _subject;
	}
}