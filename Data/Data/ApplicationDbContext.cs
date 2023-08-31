using Domain.Entity;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<BanksTotal> BanksTotals { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //преобразуем перечисление в string формат
        modelBuilder.Entity<BanksTotal>()
            .Property(p => p.Bank)
            .HasConversion<string>();
        //заносим первичные данные
        modelBuilder.Seed();

        
    }

}