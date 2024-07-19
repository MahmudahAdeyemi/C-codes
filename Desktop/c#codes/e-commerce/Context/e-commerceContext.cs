using e_commerce.Entities;
using Microsoft.EntityFrameworkCore;


namespace e_commerce.Context
{
    public class e_commerceContext  : DbContext
    {
        public e_commerceContext(DbContextOptions<e_commerceContext> options) : base(options)
        {
        }
       // protected override void onConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
// optioonsBuilder.UseMySQL("server=localhost;user=root;database=e-commerce;port=3306;password=m@hmud@h2009")
//         }
        public DbSet<Admin>Admins{get; set;}
        public DbSet<Brand>Brands{get; set;}
        public DbSet<BrandProduct>BrandProducts{get; set;}
        public DbSet<Customer>Customers{get; set;}
        public DbSet<Product>Products{get; set;}
        public DbSet<Cart>Carts {get; set;}
        public DbSet<Order>Orders{get; set;}
    }
}