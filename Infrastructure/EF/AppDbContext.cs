using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class AppDbContext : IdentityDbContext<UserEntity>
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var adminId = "7fdbd744-81d3-4fa7-a46c-3348520eb328";
            var createAt = new DateTime( 2025, 1, 1);
            var adminUser = new UserEntity()
            {
                Id = adminId,
                Email = "admin@gmail.com",
                NormalizedEmail = "",
                UserName = "admin",
                NormalizedUserName = "admin",
                EmailConfirmed = true,
                ConcurrencyStamp = adminId,
                SecurityStamp = adminId,
                PasswordHash = "AQAAAAIAAYagAAAAECCQAGSQ9zJjhokFh+McPG5SUDwuLoWbYTznBxhuU4SowGDUcR68bJHKtHZQYXtm3g==",
            };
            
            //PasswordHasher<UserEntity> ph = new PasswordHasher<UserEntity>();
            //var hash = ph.HashPassword(adminUser, password: "1234!");
            //Console. WriteLine(hash);
            //adminUser.PasswordHash = hash;
            builder.Entity<UserEntity>()
                .HasData(adminUser);
            
            builder.Entity<UserEntity>()
                .OwnsOne(u => u.Details)
                .HasData(new
                {
                    UserEntityId = adminId,
                    CreatedAt = createAt
                });



    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString:"data source= plik bazy"); //dodac scierzke
    }
}