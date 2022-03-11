
using OnlineWallet.Dal.Entities;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace OnlineWallet.Dal
{
    public class WalletContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Finance.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbCustomer>()
                .HasOne(x => x.Wallet)
                .WithOne(x => x.Customer)
                .HasForeignKey<DbWallet>(x => x.CustomerId);

            modelBuilder.Entity<DbTransaction>()
                .HasOne(x => x.Wallet)
                .WithMany()
                .HasForeignKey(x => x.WalletId);

            modelBuilder.Entity<DbCustomer>()
                .HasIndex(x => x.UserName)
                .IsUnique();
        }
    }
}
