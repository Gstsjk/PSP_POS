using Microsoft.EntityFrameworkCore;
using PSP_PoS.Components.Product;

namespace PSP_PoS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){
        
        }

        public DbSet<ProductModel> Products => Set<ProductModel>();
    }
}
