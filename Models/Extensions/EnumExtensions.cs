using System.ComponentModel;

namespace Application.Extensions;

/// <summary>
/// Расширения для перечислений (Enum)
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Преоброзование из наименования в перечесления
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T? ParseEnum<T>(this string? value)        
    {
        if (string.IsNullOrEmpty(value))
            return default(T);
        return (T)Enum.Parse(typeof(T), value, true);
    }
    /// <summary>
    /// Можно ли преоброзовать наименование в перечесление
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParseEnum<T>(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return false;
        return Enum.TryParse(typeof(T), value, true, out object? result);

    }
    /// <summary>
    /// Получаем из перечисления наименование
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public static string GetName<T>(this Enum e)
    {
        if (e == null) 
            return "";
        var result = Enum.GetName(typeof(T), e);
        if (result == null) 
            return "";
        return result;
    }
    /// <summary>
    /// Получаем из перечисления описание 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public static string GetDescription<T>(this T? e)
    {
        if (e == null)
            return "";
        if (!typeof(T).IsEnum)
            return "";
        var description = e.ToString();
        if (description == null) return "";
        var fieldInfo = e.GetType().GetField(description);
        if (fieldInfo != null)
        {
            var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
                description = ((DescriptionAttribute)attrs[0]).Description;
        }
        return description;
    }
    /// <summary>
    /// Преобразуем формат перечисления в список формата (id, name)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static object? ToListEnum<T>() where T : struct
    {
        var t = typeof(T);
        if (!t.IsEnum)
            return null;
        object? values = 
            Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new { Id = e.ToString(), Name = e.GetDescription() })
                .ToList();
        return values;
    }
}
