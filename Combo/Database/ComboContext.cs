using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Combo.Database;

public class ComboContext : DbContext
{
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql(options.CurrentValue.Postgres);

    public DbSet<Waybill> Waybill { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=combo;Username=postgres;Password=s3rg0sh4;IncludeErrorDetail=true");

    public async Task AddImmidiately<T>(T item) where T : class
    {
        Add<T>(item);
        await SaveChangesAsync();
    }
}
