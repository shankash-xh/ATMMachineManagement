using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataBase;

public class ATMMachineDbContext : DbContext
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<ATMTransactions> Transactions { get; set; }
    public DbSet<ATMCashInventory> Inventory { get; set; }
    public DbSet<SystemSettings> SystemSettings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.DataSeed();
        modelBuilder.DataSeedAccount();
        modelBuilder.DataSeedCash();
        modelBuilder.Entity<Accounts>()
            .HasOne(account => account.User)
            .WithOne(user => user.Account)
            .HasForeignKey<Accounts>(account => account.UserId);
        modelBuilder.Entity<Accounts>().HasIndex(account => account.AccountNumber).IsUnique(true);
        modelBuilder.Entity<ATMTransactions>().HasOne(T => T.Accounts).WithMany(A => A.Transactions).HasForeignKey(k=>k.AccountID);
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=DESKTOP-1J9E9SR;Initial Catalog=EventManagement;Integrated Security=True;Trust Server Certificate=True"
        );
        base.OnConfiguring(optionsBuilder);
    }
}
