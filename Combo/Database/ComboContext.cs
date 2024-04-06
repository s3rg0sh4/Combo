using Combo.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Combo.Database;

public class ComboContext(DbContextOptions<ComboContext> options) : DbContext(options)
{
    public DbSet<Waybill> Waybill { get; set; }


    public async Task AddImmidiately<T>(T item) where T : class
    {
        Add(item);
        await SaveChangesAsync();
    }
}
