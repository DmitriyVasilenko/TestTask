using Application.Stratrgy.Interface;

namespace Application.Stratrgy;

/// <summary>
/// Расчёт для первого банка ВТБ
/// </summary>
public class VTBTotalStrategy : ITotalStrategy
{
    public decimal CalculateTotal(decimal total)
    {
        return decimal.Round(total * 3, 2);
    }
}
