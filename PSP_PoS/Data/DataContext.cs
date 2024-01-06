using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.CategoryComponent;
using PSP_PoS.Components.CustomerComponent;
using PSP_PoS.Components.DiscountComponent;
using PSP_PoS.Components.EmployeeComponent;
using PSP_PoS.Components.ItemComponent;
using PSP_PoS.Components.ItemOrderComponent;
using PSP_PoS.Components.OrderComponent;
using PSP_PoS.Components.OrderService;
using PSP_PoS.Components.ServiceComponent;
using PSP_PoS.Components.TaxComponent;

namespace PSP_PoS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<OrderServices> OrderServices { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItems>()
                .HasKey(oi => new { oi.OrderId, oi.ItemId });

            modelBuilder.Entity<OrderServices>()
                .HasKey(os => new { os.OrderId, os.ServiceId });


            base.OnModelCreating(modelBuilder);
        }

    }
}
