namespace AoC.Console.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var name = value.ToString();
        var memberInfo = value.GetType().GetMember(name).FirstOrDefault();

        return memberInfo == null ? name : memberInfo.GetDisplayName();
    }

    public static T? GetDefaultValue<T>(this Enum value)
    {
        var name = value.ToString();
        var memberInfo = value.GetType().GetMember(name).FirstOrDefault();

        return memberInfo == null ? default : memberInfo.GetDefaultValue<T>();
    }
}