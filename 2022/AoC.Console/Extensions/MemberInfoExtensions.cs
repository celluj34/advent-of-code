using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AoC.Console.Extensions
{
    public static class MemberInfoExtensions
    {
        public static string GetDisplayName(this MemberInfo member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            var attribute = member.GetCustomAttributes<DisplayAttribute>(false).SingleOrDefault();

            return attribute?.GetName() ?? member.Name;
        }

        public static T? GetDefaultValue<T>(this MemberInfo member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            var attribute = member.GetCustomAttributes<DefaultValueAttribute>(false).SingleOrDefault();

            return (T?)attribute?.Value;
        }
    }
}