using JWTAssignment.Entities;
using JWTAssignment.Implementation.Servives;
using Microsoft.EntityFrameworkCore;
namespace JWTAssignment.Context

{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> opt) : base(opt)
        {

        }
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UsersRoles => Set<UserRole>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Order> Orders => Set<Order>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 23, Name = "admin" },
                new Role { Id = 687, Name = "manager" },
                new Role { Id = 432, Name = "salesperson" },
                new Role { Id = 325, Name = "customer" });


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id =564,
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PasswordHash = PasswordUtil.HashPassword("pass"),
                });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 465, UserId =564,RoleId = 23 });

        }
    }
}