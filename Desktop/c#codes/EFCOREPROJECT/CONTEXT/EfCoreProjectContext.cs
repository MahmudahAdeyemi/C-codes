using Microsoft.EntityFrameworkCore;

public class EfCoreProjectContext : DbContext
{
   protected readonly IConfiguration Configuration;

    publicRevContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<Department> Departments {get; set;}
    public DbSet<DepartmentCourse> DepartmentCourses {get; set;}
}