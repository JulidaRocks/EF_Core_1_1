using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BBBankContext : DbContext
    {
        public BBBankContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(b =>
            {
                b.HasData(new Account
                {
                    Id = Guid.Parse("37846734-172e-4149-8cec-6f43d1eb3f60"),
                    AccountNumber = "0001-1001",
                    AccountTitle = "Raas Masood",
                    CurrentBalance = 2342.34,
                    Email = "raasmasood@hotmail.com",
                    PhoneNumber = "6096647000",
                    AccountStatus = AccountStatus.Active,
                    UserId = Guid.Parse("24ce7f8a-cbeb-4b33-8a3d-952830b92d04")
                });

                b.HasOne(a => a.User)
                    .WithOne(u => u.Account)
                    .HasForeignKey<Account>(a => a.UserId);
            });

            modelBuilder.Entity<User>(b =>
            {
                b.HasData(new User
                {
                    Id = Guid.Parse("24ce7f8a-cbeb-4b33-8a3d-952830b92d04"),
                    AuthID = Guid.NewGuid().ToString(),
                    Name = "Raas Masood",
                    ProfilePicUrl = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
