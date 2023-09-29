using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LuxeLooks.Domain.Extensions;

public static class EnumExtensions
{
    public static string DisplayName(this System.Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            .GetName();
    }
} 