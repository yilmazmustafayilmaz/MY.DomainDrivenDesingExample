using Domain.Abstraction;
using Domain.Categories;
using Domain.Orders;
using Domain.Products;
using Domain.Shared;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=YILMAZ\\SQLEXPRESS;Initial Catalog=DomainDrivenDesignDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(x => x.Name).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<User>().Property(x => x.Email).HasConversion(email => email.Value, value => new(value));
        modelBuilder.Entity<User>().Property(x => x.Password).HasConversion(password => password.Value, value => new(value));
        modelBuilder.Entity<User>().OwnsOne(x => x.Address);

        modelBuilder.Entity<Category>().Property(x => x.Name).HasConversion(name => name.Value, value => new(value));

        modelBuilder.Entity<Product>().Property(x => x.Name).HasConversion(name => name.Value, value => new(value));
        modelBuilder.Entity<Product>()
            .OwnsOne(x => x.Price, priceBuilder =>
            {
                priceBuilder
                .Property(x => x.Currency)
                .HasConversion(currency => currency.CurrencyCode, code => Currency.FromCode(code));

                priceBuilder
                .Property(x => x.Amount)
                .HasColumnType("money");
            });

        modelBuilder.Entity<OrderLine>()
            .OwnsOne(x => x.Price, priceBuilder =>
            {
                priceBuilder
                .Property(x => x.Currency)
                .HasConversion(currency => currency.CurrencyCode, code => Currency.FromCode(code));

                priceBuilder
                .Property(x => x.Amount)
                .HasColumnType("money");
            });

        base.OnModelCreating(modelBuilder);
    }
}
