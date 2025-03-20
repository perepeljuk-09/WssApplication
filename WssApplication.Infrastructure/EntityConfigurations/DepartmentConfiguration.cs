using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WssApplication.Domain.Entities;

namespace WssApplication.Infrastructure.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("departments", "main");
            builder.HasKey(x => x.Id);

            // Настраиваем связь у одного департамента может быть несколько отделов по ключу DepartmentId
            builder.HasMany(x => x.Divisions).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
        }
    }
}
