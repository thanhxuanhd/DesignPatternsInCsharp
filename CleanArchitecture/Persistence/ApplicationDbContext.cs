using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new CustomerConfiguration().Configure(builder.Entity<Customer>());
        new EmployeeConfiguration().Configure(builder.Entity<Employee>());
        new ProductConfiguration().Configure(builder.Entity<Product>());
        new SaleConfiguration().Configure(builder.Entity<Sale>());
    }
}