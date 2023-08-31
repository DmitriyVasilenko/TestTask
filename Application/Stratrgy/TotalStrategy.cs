using Application.Stratrgy.Interface;

namespace Application.Stratrgy;

/// <summary>
/// Стандартная логика расчёта
/// </summary>
public class TotalStrategy : ITotalStrategy
{
    public decimal CalculateTotal(decimal total)
    {
        return decimal.Round(total, 2);
    }
}
