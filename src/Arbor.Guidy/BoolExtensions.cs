namespace Arbor.Guidy
{
    public static class BoolExtensions
    {
        public static bool IsTrue(this bool? value)
        {
            return value.HasValue && value.Value;
        }
    }
}