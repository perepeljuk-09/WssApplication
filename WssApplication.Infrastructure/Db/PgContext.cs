using Microsoft.EntityFrameworkCore;
using WssApplication.Domain.Entities;
using WssApplication.Infrastructure.EntityConfigurations;

namespace WssApplication.Infrastructure.Db
{
    public class PgContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }

        public PgContext()
        {
        }

        public PgContext(DbContextOptions<PgContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применяем все конфигурации находящиеся в этой сборке
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(CompanyConfiguration).Assembly
                );
        }
    }
}
