namespace AdventOfCode.Extensions;

public static class StringExtensions
{
    private static T? ToNullableEnum<T>(this string input) where T : struct, Enum
    {
        if (Enum.TryParse(input, true, out T output))
        {
            return output;
        }

        return null;
    }

    private static T? ToNullableEnumFromDisplayName<T>(this string input) where T : struct, Enum
    {
        if (Enum.GetValues<T>().ToDictionary(x => x.GetDisplayName(), y => y).TryGetValue(input, out var value))
        {
            return value;
        }

        return null;
    }

    public static T ToEnum<T>(this string input) where T : struct, Enum
    {
        return input.ToNullableEnum<T>() ??
            input.ToNullableEnumFromDisplayName<T>() ?? throw new ArgumentException($"{input} is not a value for enum {typeof(T).FullName}");
    }
}