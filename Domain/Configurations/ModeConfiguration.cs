using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ModeConfiguration : IEntityTypeConfiguration<Mode>
    {
        public void Configure(EntityTypeBuilder<Mode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value).HasMaxLength(10).IsRequired(true);

            builder.Property(x => x.MName).HasMaxLength(100).IsRequired(true);
        }
    }
}
