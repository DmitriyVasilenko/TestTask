using Application.Extensions;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class ValidationMethods
{
    /// <summary>
    /// Проверка, значение больше или равно нулю
    /// </summary>
    /// <param name="value"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static ValidationResult? ValidateGreaterOrEqualToZero(decimal value, ValidationContext context)
    {
        bool isValid = true;

        if (value < decimal.Zero || value > decimal.MaxValue)
            isValid = false;
        if (isValid)
            return ValidationResult.Success;
        else
        {
            return new ValidationResult(
                string.Format("Поле {0} должно быть больше или равно 0.", context.MemberName),
                new List<string>() { !string.IsNullOrEmpty(context.MemberName) ? context.MemberName : "" });
        }
    }
    /// <summary>
    /// Проверка, значение совпадает с перечислением
    /// </summary>
    /// <param name="value"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static ValidationResult? ValidateCorrectEnum<T>(string value, ValidationContext context)
    {
        bool isValid = true;
        if (!value.TryParseEnum<Bank>())
            isValid = false;
        if (isValid)
            return ValidationResult.Success;
        else
        {
            return new ValidationResult(
            string.Format("Поле {0} должно соответствовать справочнику банков", context.MemberName),
            new List<string>() { !string.IsNullOrEmpty(context.MemberName) ? context.MemberName : "" });
        }
    }
}
