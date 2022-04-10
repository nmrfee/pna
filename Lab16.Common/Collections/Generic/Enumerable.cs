using System.Collections;
using System.Collections.Generic;

namespace Lab16.Common.Collections.Generic
{
    public class Enumerable<TElement> : IEnumerable<TElement>
    {
        public Enumerable() { }

        public Enumerable(TElement element)
            => Add(element);

        public Enumerable(IEnumerable<TElement> elements)
            => AddRange(elements);

        public virtual void Add(TElement element)
            => _elements.AddLast(element);

        public virtual void AddRange(IEnumerable<TElement> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public virtual IEnumerator<TElement> GetEnumerator()
            => _elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private readonly LinkedList<TElement> _elements
            = new LinkedList<TElement>();
    }
}