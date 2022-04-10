using System.Collections.Generic;
using Lab16.Common.Extensions;

namespace Lab16.Common.Collections.Generic
{
    public class QueueDerivative<TElement>
    {
        public QueueDerivative() { }

        public QueueDerivative(TElement element)
            : this(element.Singly()) { }

        public QueueDerivative(IEnumerable<TElement> elements)
            => EnqueueRange(elements);

        public int Count
            => _queue.Count;

        public TElement Dequeue()
            => _queue.Dequeue();

        public void Enqueue(TElement element)
        {
            _queue.Enqueue(element);

            _enqueuings.Add(element);
        }

        public void EnqueueRange(IEnumerable<TElement> elements)
        {
            foreach (var element in elements)
            {
                Enqueue(element);
            }
        }

        public bool IsEmpty()
            => Count == 0;

        public bool NotEmpty()
            => Count > 0;

        public IEnumerable<TElement> YieldEnqueuings()
            => _enqueuings;

        private Enumerable<TElement> _enqueuings
            = new Enumerable<TElement>();

        private Queue<TElement> _queue
            = new Queue<TElement>();
    }
}