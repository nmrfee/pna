using System.Collections.Generic;

namespace Lab16.Common
{
    public sealed class Yield
	{
		public static TObject[] EmptyArrayOf<TObject>()
			=> new TObject[0];

		public static IEnumerable<TObject> EmptySetOf<TObject>()
			=> new TObject[0];

        public static IEnumerable<TObject> Parameters<TObject>()
            => new TObject[0];

        public static IEnumerable<TObject> Parameters<TObject>(params TObject[] parameters)
            => parameters;

        public static Repetitions<TObject> RepetitionsOf<TObject>(TObject subject)
            => new Repetitions<TObject>(subject);
    }
}