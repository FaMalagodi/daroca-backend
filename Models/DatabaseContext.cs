using Microsoft.EntityFrameworkCore;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public virtual DbSet<Customer> Customer { get; set;} // devo criar isso para cada uma das novas classes DbSet < classe >
    public virtual DbSet<ProductCategory> ProductCategory { get; set;}
    public virtual DbSet<Product> Product { get; set;}
    public virtual DbSet<SalesOrder> SalesOrder { get; set;} 
    public virtual DbSet<SalesOrderItem> SalesOrderItem { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder) // cai na prova
    {
        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Latitude).HasPrecision(11, 3).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Longitude).HasPrecision(11, 3).IsRequired();
        
        modelBuilder.Entity<ProductCategory>().HasKey(e => e.ProductCategoryId);
        modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<ProductCategory>().HasMany<Product>().WithOne().HasForeignKey(e => e.ProductCategoryId); // relacionamento de um-para-muitos entre as entidades ProductCategory e Product. Isso significa que uma categoria de produto pode ter vários produtos associados a ela

        modelBuilder.Entity<Product>().HasKey(e => e.ProductId);
        modelBuilder.Entity<Product>().Property(p => p.ProductCategoryId).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();

        modelBuilder.Entity<SalesOrder>().HasKey(e => e.OrderId);
        modelBuilder.Entity<SalesOrder>().Property(p => p.CustomerId).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.OrderDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EstimatedDeliveryDate);
        modelBuilder.Entity<SalesOrder>().Property(p => p.Status).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<SalesOrder>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(e => e.ProductId);
        modelBuilder.Entity<Customer>().HasMany<SalesOrder>().WithOne().HasForeignKey(e => e.CustomerId);
        
        modelBuilder.Entity<SalesOrderItem>().HasKey(e => new {e.OrderId, e.ProductId});
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<Product>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(e => e.ProductId);       
        //modelBuilder.Entity<Customer>(entity => {entity.HasKey(k => k.CustomerId);}); //add linha igual a essa para a classe que acabei de fzr, mudando a classe que aqui é <Customer> 
        OnModelCreatingPartial(modelBuilder);
    }

//não se esquecam de que sales order possui relação com Customer

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

//criar duas classes, no modelo e suas especificações, na databasecontext

//ProductCategory (productCategoryId int OBRIGATORIO primary key, Name string (50) OBRIGATORIO)

//Product (ProductId int OBRIGATORIO primary key, ProductCategoryId int OBRIGATORIO, Name string (50) OBRIGATORIO, UnitPrice decimal (11,5) OBRIGATORIO)