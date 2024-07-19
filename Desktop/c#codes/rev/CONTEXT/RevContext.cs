using Microsoft.EntityFrameworkCore;
using rev.ENTITIES;

public class RevContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public RevContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql("server=localhost; database=dotnet-5-crud-api; user=root; password= m@hmud@h2009", ServerVersion.AutoDetect("server=localhost; database=dotnet-5-crud-api; user=root; password= m@hmud@h2009"));
    }

    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<Grade> Grades {get; set;}
    public DbSet<Studentcourse> Studentcourses {get; set;}
}