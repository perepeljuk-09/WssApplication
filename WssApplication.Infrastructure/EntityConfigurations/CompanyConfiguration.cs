using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WssApplication.Domain.Entities;

namespace WssApplication.Infrastructure.EntityConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies", "main");
            builder.HasKey(x => x.Id);

            // Настраиваем связь у одной компании может быть несколько департаментов по ключу CompanyId
            builder.HasMany(x => x.Departments).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        }
    }
}
