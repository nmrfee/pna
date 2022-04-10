namespace Lab16.Common.Extensions
{
    public class If
    {
        internal If(bool condition)
            => _condition = condition;

        public TObject Otherwise<TObject>(TObject secondObject)
            => _condition ? ((TObject)_firstObject) : secondObject;

        public If ThenReturn<TObject>(TObject @object)
        {
            _firstObject = @object;

            return this;
        }

        private readonly bool _condition;

        private object _firstObject;
    }
}