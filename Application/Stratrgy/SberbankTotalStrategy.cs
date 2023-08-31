using Application.Stratrgy.Interface;

namespace Application.Stratrgy;

/// <summary>
/// Расчёт для второго банка Сбербанк
/// </summary>
public class SberbankTotalStrategy : ITotalStrategy
{
    public decimal CalculateTotal(decimal total)
    {
        return decimal.Round(total / 2, 2);
    }
}
