using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Components.EmployeeComponent;
using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.OrderComponent;
using PSP_PoS.Components.OrderItemComponent;
using PSP_PoS.Components.ReservationComponent;
using PSP_PoS.Components.ServiceComponent;
using PSP_PoS.Components.TaxComponent;

namespace PSP_PoS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){
        
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Discount> Discounts => Set<Discount>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Reservation> Reservations => Set<Reservation>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<Tax> Taxes => Set<Tax>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(o => new { o.OrderId, o.ItemId });

            modelBuilder.Entity<Reservation>()
                .HasKey(o => new { o.OrderId, o.ServiceId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
