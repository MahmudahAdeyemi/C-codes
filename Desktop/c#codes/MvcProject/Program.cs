

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.99
builder.Services.AddControllersWithViews();
// builder.Services.AddScoped<IAdminService,AdminService>();
// builder.Services.AddScoped<IAdminRepository,AdminRepository>();
// builder.Services.AddScoped<ICategoriesService,CategoriesService>();
// builder.Services.AddScoped<ICategoriesRepository,CategoriesRepository>();
// builder.Services.AddDbContext< MVCProjectContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MVCContextConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MVCContextConnection"))));
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
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
