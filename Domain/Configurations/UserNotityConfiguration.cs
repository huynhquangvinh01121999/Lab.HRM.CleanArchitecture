using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class UserNotityConfiguration : IEntityTypeConfiguration<UserNotify>
    {
        public void Configure(EntityTypeBuilder<UserNotify> builder)
        {
            builder.HasKey(x => new { x.UserId, x.NotificationId });

            builder
                .HasOne<AppUsers>(sc => sc.AppUsers)
                .WithMany(s => s.UserNotifications)
                .HasForeignKey(sc => sc.UserId);

            builder
                .HasOne<Notify>(sc => sc.Notify)
                .WithMany(s => s.UserNotifications)
                .HasForeignKey(sc => sc.NotificationId);
        }
    }
}
