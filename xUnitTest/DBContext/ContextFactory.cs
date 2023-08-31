using Domain.Entity;
using Domain.Enum;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace xUnitTest.DBContext;

public class ContextFactory
{
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new ApplicationDbContext(options);
        context.Database.EnsureCreated();
        context.BanksTotals.AddRange(
            new BanksTotal() { Id = Guid.Parse("cc3d49a1-690e-4c06-a748-59a7cf763eb9"), Bank = Bank.VTB, Total = 0 },
            new BanksTotal() { Id = Guid.Parse("5c10a962-c64f-4a52-b496-727354455031"), Bank = Bank.Sberbank, Total = 0 },
            new BanksTotal() { Id = Guid.Parse("83593977-56a9-4d2c-b2c0-23f773746e4a"), Bank = Bank.Tinkoff, Total = 0 },
            new BanksTotal() { Id = Guid.Parse("6cf17591-c526-4bad-9051-c46eda7fd131"), Bank = Bank.AlfaBank, Total = 0 },
            new BanksTotal() { Id = Guid.Parse("7359f308-36d7-41ab-97ea-a813dfe38832"), Bank = Bank.Promsvyazbank, Total = 0 }
            );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }

}
