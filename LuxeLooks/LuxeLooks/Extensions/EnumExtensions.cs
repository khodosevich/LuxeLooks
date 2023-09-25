using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LuxeLooks.Extensions;

public static class EnumExtensions
{
    public static string DisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            .GetName();
    }
} 