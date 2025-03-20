using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WssApplication.Domain.Entities;

namespace WssApplication.Infrastructure.EntityConfigurations
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable("divisions", "main");
            builder.HasKey(x => x.Id);
        }
    }
}
