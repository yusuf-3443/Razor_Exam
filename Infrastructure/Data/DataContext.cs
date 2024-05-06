using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options){}

    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; }= null!;
    public DbSet<Transaction> Transactions { get; set; }= null!;


//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Ignore<Account>();
//         modelBuilder.Entity<Customer>().ToTable("Customer");
//         modelBuilder.Entity<Transaction>().ToTable("Transaction");

//         base.OnModelCreating(modelBuilder);
//     }
}

    //   modelBuilder.Entity<Account>()
    // .Property(x => x.Type)
    // .IsRequired()
    // .HasConversion(
    //     convertToProviderExpression: x => x.AssemblyQualifiedName,
    //     convertFromProviderExpression: x => Type.GetType(x));
    //     base.OnModelCreating(modelBuilder);