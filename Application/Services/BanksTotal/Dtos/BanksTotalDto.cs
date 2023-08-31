using Application.Dtos;
using Domain;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.Services.Dtos;

public class BanksTotalDto : EntityDtoBase
{
    /// <summary>
    /// Наименование банка
    /// </summary>
    [Required]
    public Bank Bank { get; set; }
    /// <summary>
    /// Cумма активов
    /// </summary>
    [Required]
    [CustomValidation(typeof(ValidationMethods), "ValidateGreaterOrEqualToZero")]
    public decimal Total { get; set; }

    public BanksTotalDto() : base()
    {
    }
}
