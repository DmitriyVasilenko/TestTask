using Domain.Entities.Abstracts;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity;

/// <summary>
/// Таблица информации по банку
/// </summary>
[Table("banks_total")]
public class BanksTotal : EntityBase
{
    /// <summary>
    /// Наименование банка
    /// </summary>
    [Column("bank")]
    [Required]
    public Bank Bank { get; set; }
    /// <summary>
    /// Cумма активов
    /// </summary>
    [Required]
    [Column("total", TypeName = "decimal(28,2)")]
    [CustomValidation(typeof(ValidationMethods), "ValidateGreaterOrEqualToZero")]
    public decimal Total { get; set; }
}
