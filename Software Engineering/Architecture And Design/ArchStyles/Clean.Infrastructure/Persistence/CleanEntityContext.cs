using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Persistence;

public class CleanEntityContext: DbContext
{
    public CleanEntityContext(DbContextOptions<CleanEntityContext> options)
        : base(options)
    {
    }

    public DbSet<DogEntity> Dogs { get; set; }
}