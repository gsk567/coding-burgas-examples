using Microsoft.EntityFrameworkCore;

namespace Layered.Data;

public class LayeredEntityContext : DbContext
{
    public LayeredEntityContext(DbContextOptions<LayeredEntityContext> options)
        : base(options)
    {
    }

    public DbSet<Dog> Dogs { get; set; }
}