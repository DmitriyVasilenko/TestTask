using Application.Stratrgy.Interface;

namespace Application.Stratrgy;

public class TotalContext : ITotalContext
{
    private ITotalStrategy _strategy;

#pragma warning disable CS8618 
    public TotalContext() 
    {
    }
#pragma warning restore CS8618 

    public TotalContext(ITotalStrategy strategy)
    {
        this._strategy = strategy;
    }

    public void SetStrategy(ITotalStrategy strategy)
    {
        this._strategy = strategy;
    }
    /// <summary>
    /// Определяем по какой стратегии пойдет логика
    /// </summary>
    /// <param name="item">Номер банка в списке</param>
    public void SetStrategy(int item)
    {
        ITotalStrategy strategy;
        switch (item)
        {
            case 0:
                strategy = new VTBTotalStrategy();
                break;
            case 1:
                strategy = new SberbankTotalStrategy();
                break;
            case 2:
                strategy = new TinkoffTotalStrategy();
                break;
            default:
                strategy = new TotalStrategy();
                break;
        }
        this._strategy = strategy;
    }
    /// <summary>
    /// Расчёт значения к применяемой логики
    /// </summary>
    /// <param name="total"></param>
    /// <returns></returns>
    public decimal ExecuteStrategy(decimal total)
    {
        return this._strategy.CalculateTotal(total);
    }
}
