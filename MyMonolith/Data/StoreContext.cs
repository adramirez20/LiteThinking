using Microsoft.EntityFrameworkCore;

public class StoreContext : DbContext

{

public DbSet<Product> Products {get; set;}

public DbSet<User> Users {get; set;}

public DbSet<Order> Orders {get; set;}

public DbSet<OrderItem> OrderItems{get; set;}

public StoreContext(DbContextOptions<StoreContext> options): base(options) {}

protected override void OnModelCreating(ModelBuilder modelBuilder)

 {

//Configuracion de relaciones

modelBuilder.Entity<Order>()

.HasOne(o => o.User)

.WithMany()

.HasForeignKey(o => o.UserId);

modelBuilder.Entity<OrderItem>()

.HasOne(oi => oi.Product)

.WithMany()

.HasForeignKey(oi => oi.ProductId);

 }

}