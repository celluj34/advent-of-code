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

    public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
        var i = 0;

        foreach (var element in source)
        {
            if (!predicate(element, i))
            {
                return false;
            }

            ++i;
        }

        return true;
    }

    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int count)
    {
        var enumerable = source.ToList();

        for (var i = 0; i < count; i++)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }
    }
}