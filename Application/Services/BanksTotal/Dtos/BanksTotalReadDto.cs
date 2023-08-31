using Application.Dtos;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Services.Dtos;

public class BanksTotalReadDto : EntityDtoBase
{
    /// <summary>
    /// Наименование банка
    /// </summary>
    [Required]
    [CustomValidation(typeof(ValidationMethods), "ValidateCorrectEnum")]
    public string? Bank { get; set; }
    /// <summary>
    /// Cумма активов
    /// </summary>
    [Required]
    [CustomValidation(typeof(ValidationMethods), "ValidateGreaterOrEqualToZero")]
    public decimal Total { get; set; }
}
