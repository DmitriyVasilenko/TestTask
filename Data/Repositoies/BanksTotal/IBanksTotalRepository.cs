using Domain.Entity;
using Domain.Enum;

namespace Infrastructure.Repositoies;

public interface IBanksTotalRepository : IBaseRepository<BanksTotal>
{
    /// <summary>
    /// Получения из базы информаию банка
    /// </summary>
    /// <param name="bank">По наименованию</param>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    Task<BanksTotal?> GetAsync(Bank bank, bool disableTracking = true);
}
