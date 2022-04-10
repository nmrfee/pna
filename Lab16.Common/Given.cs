namespace Lab16.Common.Extensions
{
    public static class Given
    {
        public static If That(bool subject)
            => new If(subject);
    }
}