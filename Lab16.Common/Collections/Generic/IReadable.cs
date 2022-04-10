namespace Lab16.Common.Collections.Generic
{
    public interface IReadable<out TElement> : IReadable
    {
        new TElement Read();
        
        new TElement Peek();
    }
}