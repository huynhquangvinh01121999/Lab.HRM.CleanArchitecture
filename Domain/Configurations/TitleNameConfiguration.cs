using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class TitleNameConfiguration : IEntityTypeConfiguration<TitleName>
    {
        public void Configure(EntityTypeBuilder<TitleName> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TName).HasMaxLength(10).IsRequired(true);
        }
    }
}
