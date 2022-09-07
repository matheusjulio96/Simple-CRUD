using Microsoft.EntityFrameworkCore;

namespace Simple_CRUD.Data
{
    public class SimpleCrudDbContext : DbContext
    {
        public SimpleCrudDbContext(DbContextOptions<SimpleCrudDbContext> options)
        : base(options)
        {
        }

        public DbSet<PersonEntity> Persons { get; set; } = null!;
    }
}
