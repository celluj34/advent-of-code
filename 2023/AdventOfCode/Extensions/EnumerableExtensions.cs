namespace AdventOfCode.Extensions;

public static class EnumerableExtensions
{
    public static ulong Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> summer)
    {
        return source.Aggregate(0UL, (current, item) => current + summer(item));
    }

    public static IEnumerable<T> TakeUntilInclusive<T>(this IEnumerable<T> collection, Predicate<T> endCondition)
    {
        foreach (var item in collection)
        {
            yield return item;

            if (endCondition(item))
            {
                break;
            }
        }
    }
}