using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Domain.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            //-------- cấu hình khóa chính - khóa ngoại

            builder.HasKey(x => x.Id);

            // 1 phòng ban có nhiều nhân sự
            builder.HasOne(x => x.Department).WithMany(x => x.Personnels).HasForeignKey(x => x.DepartmentId);

            // 1 chế độ sẽ có 1 hoặc nhiều người su dung
            builder.HasOne(x => x.Mode).WithMany(x => x.Personnels).HasForeignKey(x => x.ModeId);

            builder.HasOne(x => x.TitleName).WithMany(x => x.Personnels).HasForeignKey(x => x.TitleId);


            //-------- cấu hình column type cho các field trong table

            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired(true);

            builder.Property(x => x.DoB).HasMaxLength(50).IsRequired(true);

            builder.Property(x => x.PoB).HasMaxLength(20).IsRequired(false);

            builder.Property(x => x.Email).HasMaxLength(30).IsRequired(true);

            builder.Property(x => x.PhoneNumber).HasMaxLength(13).IsRequired(true);

            builder.Property(x => x.ImagePath).HasMaxLength(50).IsRequired(false);

            builder.Property(x => x.DoB).HasColumnType("datetime");

            builder.Property(x => x.Timestamp).HasColumnType("datetime");


            //-------- cấu hình default value cho field trong table

            builder.Property(x => x.Timestamp).HasDefaultValue(DateTime.Now);
        }
    }
}
