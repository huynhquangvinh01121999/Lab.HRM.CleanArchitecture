using Domain.Configurations;
using Domain.Entities;
using Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence.Contexts
{
    public class LabContext : IdentityDbContext<AppUsers, AppRoles, Guid>
    {
        public LabContext(DbContextOptions<LabContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new ModeConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new TitleNameConfiguration());
            builder.ApplyConfiguration(new NotityConfiguration());
            builder.ApplyConfiguration(new UserNotityConfiguration());

            builder.Seed();
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<TitleName> TitleNames { get; set; }

        public DbSet<Mode> Modes { get; set; }

        public DbSet<RoleModes> RoleModes { get; set; }

        public DbSet<Notify> Notifies { get; set; }

        public DbSet<UserNotify> UserNotifies { get; set; }
    }
}
