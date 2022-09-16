using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleAdminId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleUserId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");

            modelBuilder.Entity<AppRoles>().HasData(
                new AppRoles
                {
                    Id = roleAdminId,
                    Name = "Admin",
                    NormalizedName = "admin"
                },
                new AppRoles
                {
                    Id = roleUserId,
                    Name = "User",
                    NormalizedName = "user"
                });

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    DName = "ICT"
                }, new Department
                {
                    Id = 2,
                    DName = "NS"
                });

            modelBuilder.Entity<Mode>().HasData(
                new Mode
                {
                    Id = 1,
                    Value = "0",
                    MName = "private",
                }, new Mode
                {
                    Id = 2,
                    Value = "1",
                    MName = "public",
                }, new Mode
                {
                    Id = 3,
                    Value = "3",
                    MName = "all",
                });

            modelBuilder.Entity<RoleModes>().HasData(
                new RoleModes {Id = 1, ModeId = 1, RoleId = roleAdminId },
                new RoleModes {Id = 2, ModeId = 2, RoleId = roleAdminId },
                new RoleModes { Id = 3, ModeId = 2, RoleId = roleUserId });

            modelBuilder.Entity<TitleName>().HasData(
                new TitleName { Id = 1, TName = "ICT"},
                new TitleName { Id = 2, TName = "GĐ" },
                new TitleName { Id = 3, TName = "NS" });

            modelBuilder.Entity<Employees>().HasData(
                new Employees { Id = 1, FullName = "Nguyễn Văn A", DoB = DateTime.Now, Email = "nguyenvana@gmail.com", PhoneNumber = "0786542541", TitleId = 1, DepartmentId = 1, ModeId = 1 },
                new Employees { Id = 2, FullName = "Nguyễn Văn B", DoB = DateTime.Now, Email = "nguyenvanb@gmail.com", PhoneNumber = "0786542542", TitleId = 2, DepartmentId = 1, ModeId = 2 },
                new Employees { Id = 3, FullName = "Trần Thị C", DoB = DateTime.Now, Email = "tranthic@gmail.com", PhoneNumber = "0786542543", TitleId = 3, DepartmentId = 2, ModeId = 2 });
        }
    }
}
