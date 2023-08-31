using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class DataSeed
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanksTotal>().HasData(
            new BanksTotal() { Id = Guid.NewGuid(), Bank = Bank.VTB, Total = 100.00m },
            new BanksTotal() { Id = Guid.NewGuid(), Bank = Bank.Sberbank, Total = 100.00m },
            new BanksTotal() { Id = Guid.NewGuid(), Bank = Bank.Tinkoff, Total = 100.00m },
            new BanksTotal() { Id = Guid.NewGuid(), Bank = Bank.AlfaBank, Total = 100.00m },
            new BanksTotal() { Id = Guid.NewGuid(), Bank = Bank.Promsvyazbank, Total = 100.00m }
            );
    }
}