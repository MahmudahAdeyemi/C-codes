using Microsoft.EntityFrameworkCore;
using MVC;
using MVC.INTERFACE;
using MVC.REPOSITORIES;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepostory>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddDbContext<MVCContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MVCContextConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MVCContextConnection"))));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=Index}");
app.Run();
