using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminId = "0bb08caa-d013-4715-a64f-a7e77ee77b01";
            var createdAt = new DateTime(2025, 04, 08);
            var adimUser = new UserEntity() { 
                Id = adminId,
                Email = "admin@wsei.edu.pl",
                NormalizedEmail = "admin@wsei.edu.pl".ToUpper(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                ConcurrencyStamp = adminId,
                PasswordHash = "AQAAAAIAAYagAAAAEDG3hcj+oftRgbbHiXRBcAa0RVrAfZgCuRMN/l3tSrq9zsP7OGuKKZkZ3SUBzG/3Ng==\r\nAQAAAAIAAYagAAAAEJd6yrzWXiQmyjGsf9llxuG3Va8rUUn6NqAaFD1LNZT8GlzkxNZyWtdnLX6htBSO6g=="

            };

            builder.Entity<UserEntity>().HasData(adimUser);
            builder.Entity<UserEntity>().OwnsOne(u => u.Details)
                .HasData(new
                {
                    UserEntityId = adminId,
                    CreatedAt = createdAt
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"data source=c:\Data\app.db");
        }
    }
}