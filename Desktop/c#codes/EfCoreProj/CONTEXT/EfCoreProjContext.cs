using Microsoft.EntityFrameworkCore;

public class EfCoreProjectContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=root;database=EfCoreProject;port=3306;password=m@hmud@h2009";
        optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<Student> Students {get; set;}
    public DbSet<Course> Courses {get; set;}
    public DbSet<Department> Departments {get; set;}
    public DbSet<DepartmentCourse> DepartmentCourses {get; set;}
    public DbSet<Admin>Admins{get;set;}
}