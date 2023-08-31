using Domain.Entity;
using Domain.Enum;
using Infrastructure.Data;

namespace Infrastructure.Repositoies;

public class BanksTotalRepository : BaseRepository<BanksTotal>, IBanksTotalRepository
{
    private readonly ApplicationDbContext _context;
    public BanksTotalRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    /// <summary>
    /// Получения из базы информаию банка
    /// </summary>
    /// <param name="bank">По наименованию</param>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    public async Task<BanksTotal?> GetAsync(Bank bank, bool disableTracking = true)
    {
        var model = await ToListAsync();
        return model.FirstOrDefault(x => x.Bank == bank);
    }
}