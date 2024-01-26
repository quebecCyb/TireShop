using Microsoft.EntityFrameworkCore;

namespace TireShop.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApiUser> ApiUser { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tire and Brand relationship
            modelBuilder.Entity<Tire>()
                .HasOne(t => t.Brand)
                .WithMany(b => b.Tires)
                .HasForeignKey(t => t.BrandId);

            // Order and User relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // Order and Warehouse relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Warehouse)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.WarehouseId);

            // Availability, Tire, and Warehouse relationship
            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Tire)
                .WithMany(t => t.Availabilities)
                .HasForeignKey(a => a.TireId);

            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Warehouse)
                .WithMany(w => w.Availabilities)
                .HasForeignKey(a => a.WarehouseId);
        }
    }
}
