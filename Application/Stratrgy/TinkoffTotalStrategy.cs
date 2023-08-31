using Application.Stratrgy.Interface;

namespace Application.Stratrgy;

/// <summary>
/// Расчёт для третьего банка Тиньков
/// </summary>
public class TinkoffTotalStrategy : ITotalStrategy
{
    public decimal CalculateTotal(decimal total)
    {
        total = decimal.Round(total / 2, 2) - 100;
        if (total <= 0)
            return 0;
        return decimal.Round(total, 2);
    }
}
