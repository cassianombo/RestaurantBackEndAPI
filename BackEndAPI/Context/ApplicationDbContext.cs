using BackEndAPI.Model;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<RestaurantTable> DiningTables { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração para a entidade Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id); // Chave primária
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18,2)");
        });

        // Configuração para a entidade DiningTable
        modelBuilder.Entity<RestaurantTable>(entity =>
        {
            entity.HasKey(e => e.Id); // Chave primária
            entity.Property(e => e.Number)
                  .IsRequired();
            entity.Property(e => e.Capacity)
                  .IsRequired();
            entity.Property(e => e.IsOccupied)
                  .IsRequired();
        });

        // Configuração para a entidade Order
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id); // Chave primária
            entity.Property(e => e.TableId)
                  .IsRequired();
            entity.Property(e => e.OrderDateTime)
                  .IsRequired();

            // Relacionamento 1:N com DiningTable
            entity.HasOne(e => e.Table)
                  .WithMany()
                  .HasForeignKey(e => e.TableId);

            // Relacionamento 1:N com OrderProduct
            entity.HasMany(e => e.Products)
                  .WithOne(e => e.Order)
                  .HasForeignKey(e => e.OrderId);
        });

        // Configuração para a entidade OrderProduct
        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.Id); // Chave primária

            entity.Property(e => e.OrderId)
                  .IsRequired();
            entity.Property(e => e.ProductId)
                  .IsRequired();
            entity.Property(e => e.Quantity)
                  .IsRequired();

            // Relacionamento 1:N com Order
            entity.HasOne(e => e.Order)
                  .WithMany(e => e.Products)
                  .HasForeignKey(e => e.OrderId);

            // Relacionamento 1:N com Product
            entity.HasOne(e => e.Product)
                  .WithMany()
                  .HasForeignKey(e => e.ProductId);
        });

        // Configuração para a entidade Payment
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id); // Chave primária
            entity.Property(e => e.OrderId)
                  .IsRequired();
            entity.Property(e => e.PaymentDateTime)
                  .IsRequired();
            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            // Relacionamento 1:N com Order
            entity.HasOne(e => e.Order)
                  .WithMany()
                  .HasForeignKey(e => e.OrderId);
        });
    }
}

