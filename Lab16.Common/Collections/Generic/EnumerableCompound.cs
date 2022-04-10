using System.Collections.Generic;
using Lab16.Common.Extensions;

namespace Lab16.Common.Collections.Generic
{
    internal class EnumerableCompound<TElement> : Enumerable<TElement>
    {
        public EnumerableCompound(IEnumerable<TElement> subject, IEnumerable<TElement> reference)
        {
            _subject = subject;

            _reference = reference;
        }

        public EnumerableCompound(IEnumerable<TElement> subject, TElement reference)
            : this(subject, reference.Singly()) { }

        public override void Add(TElement element)
            => _elementsAdded.Add(element);

        public override IEnumerator<TElement> GetEnumerator()
            => _yieldElements().GetEnumerator();

        private readonly Enumerable<TElement> _elementsAdded
            = new Enumerable<TElement>();

        private readonly IEnumerable<TElement> _reference;

        private readonly IEnumerable<TElement> _subject;

        private IEnumerable<TElement> _yieldElements()
        {
            foreach (var element in _subject)
            {
                yield return element;
            }

            foreach (var element in _reference)
            {
                yield return element;
            }

            foreach (var element in _elementsAdded)
            {
                yield return element;
            }
        }
    }
}