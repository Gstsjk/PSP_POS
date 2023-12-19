using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.Account;
using PSP_PoS.Components.Category;
using PSP_PoS.Components.Customer;
using PSP_PoS.Components.Discount;
using PSP_PoS.Components.Loyalty;
using PSP_PoS.Components.Order;
using PSP_PoS.Components.Product;
using PSP_PoS.Components.Reservation;
using PSP_PoS.Components.Service;
using PSP_PoS.Components.Tax;

namespace PSP_PoS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){
        
        }

        public DbSet<CategoryModel> Categories => Set<CategoryModel>();
        public DbSet<CustomerModel> Customers => Set<CustomerModel>();
        public DbSet<DiscountModel> Discounts => Set<DiscountModel>();
        public DbSet<EmployeeModel> Employees => Set<EmployeeModel>();
        public DbSet<LoyaltyModel> Loyalties => Set<LoyaltyModel>();
        public DbSet<OrderModel> Orders => Set<OrderModel>();
        public DbSet<ProductModel> Products => Set<ProductModel>();
        public DbSet<ReservationModel> Reservations => Set<ReservationModel>();
        public DbSet<ServiceModel> Services => Set<ServiceModel>();
        public DbSet<TaxModel> Taxes => Set<TaxModel>();
        
    }
}
