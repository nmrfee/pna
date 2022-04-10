namespace Lab16.Common.Collections
{
    public interface IReadable
    {
        bool IsEmpty();

        object Peek();

        object Read();
    }
}