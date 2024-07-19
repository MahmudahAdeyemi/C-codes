namespace MVC;
using Microsoft.EntityFrameworkCore;
using MVC.ENTITIES;

public class MVCContext : DbContext
{

    public MVCContext(DbContextOptions<MVCContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    public DbSet<Student> Students{get; set;}
    public DbSet<Department> Departments {get; set;}
}