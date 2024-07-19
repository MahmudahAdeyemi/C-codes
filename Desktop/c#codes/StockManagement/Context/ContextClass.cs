using Microsoft.EntityFrameworkCore;
using StockManagement.Entities;
using StockManagement.Implementations.Services;
namespace StockManagement.Context
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options)
        {
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 23, Name = "admin" },
                new Role { Id = 3, Name = "salesperson" },
                new Role { Id = 4, Name = "customer" });


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id =564,
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    HashedPassword = PasswordUtil.HashPassword("pass"),
                    RoleId  = 23
                });

            // modelBuilder.Entity<Role>().HasComment("comment");
            // new UserRole { Id = 465, UserId =564,RoleId = 23 });

        }
        public DbSet<Admin>Admin{get; set;}
        public DbSet<Customer>Customer{get; set;}
        public DbSet<Expenses>Expenses{get; set;}
        public DbSet<Product>Product{get; set;}
        public DbSet<Role>Role{get; set;}
        public DbSet<SalesRep>SalesRep{get; set;}
        public DbSet<Stock>Stock{get; set;}
        public DbSet<User>User{get; set;}

    }
}