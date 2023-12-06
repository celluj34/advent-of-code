namespace AdventOfCode.Extensions;

public static class IEnumerableOfStringExtensions
{
    public static string Join(this IEnumerable<string?> source, string delimiter = ",")
    {
        return string.Join(delimiter, source);
    }
}