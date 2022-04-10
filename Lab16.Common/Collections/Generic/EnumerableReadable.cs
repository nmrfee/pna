using System.Collections.Generic;
using Lab16.Common.Collections.Generic;
using Lab16.Common.Extensions;

namespace Lab16.Common.Collections.Generic
{
    internal class EnumerableReadable<TElement> : IReadable<TElement>
    {
        public EnumerableReadable() { }

        public EnumerableReadable(TElement element)
            : this(element.Singly()) { }

        public EnumerableReadable(IEnumerable<TElement> elements)
            => _enumerator = elements.GetEnumerator();
        
        public bool IsEmpty()
            => _isEmpty;

        public TElement Peek()
            => _enumerator.Current;

        object IReadable.Peek()
            => Peek();

        public TElement Read()
        {
            var result = _enumerator.Current;

            _isEmpty = !_enumerator.MoveNext();

            return result;
        }

        object IReadable.Read()
            => Read();

        private IEnumerator<TElement> _enumerator;

        private bool _isEmpty;
    }
}