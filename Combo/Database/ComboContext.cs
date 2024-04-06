using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Combo.Database;

public class ComboContext(IOptionsMonitor<ConnectionStrings> options) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(options.CurrentValue.Postgres);

    public async Task AddImmidiately<T>(T item) where T : class
    {
        Add<T>(item);
        await SaveChangesAsync();
    }
}
