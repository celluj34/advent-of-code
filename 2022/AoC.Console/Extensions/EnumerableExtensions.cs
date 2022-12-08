namespace AoC.Console.Extensions;

public static class EnumerableExtensions
{
    public static ulong Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> summer)
    {
        return source.Aggregate(0UL, (current, item) => current + summer(item));
    }
}