using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.Category;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Employee;
using PSP_PoS.Components.Item;
using PSP_PoS.Components.Order;
using PSP_PoS.Components.OrderItem;
using PSP_PoS.Components.Reservation;
using PSP_PoS.Components.Service;
using PSP_PoS.Components.Tax;

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
