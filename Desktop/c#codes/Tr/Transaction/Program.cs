using Microsoft.EntityFrameworkCore;
using Transaction;
using Transaction.Implementation.Repositories;
using Transaction.Implementation.Services;
using Transaction.Interfaces.Repositories;
using Transaction.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TransactionContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<ICashRepository,CashRepository>();
builder.Services.AddScoped<IGoodRealesdRepository,GoodRealesdRepository>();
builder.Services.AddScoped<IGoodReturnedRepository,GoodReturnedRepository>();
builder.Services.AddScoped<IManagerRepository,ManagerRepository>();
builder.Services.AddScoped<IOpeningStockRepository,OpeningStockRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IPurchaseRepository,PurchaseRepository>();
builder.Services.AddScoped<ISalesRepository,SalesRepository>();
builder.Services.AddScoped<ISalesRepRepository,SalesRepRepository>();
builder.Services.AddScoped<IShopItemsRepository,ShopItemsRepository>();
builder.Services.AddScoped<IStoreItemsRepository,StoreItemsRepository>();
builder.Services.AddScoped<IValidClosingStockRepository,ValidClosingStockRepository>();
builder.Services.AddScoped<IManagerService,ManagerService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ISalesService,SalesService>();
builder.Services.AddScoped<ISalesRepService,SalesRepService>();
builder.Services.AddScoped<IShopItemService,ShopItemService>();
builder.Services.AddScoped<IStoreKeepingService,StoreKeepingService>();
builder.Services.AddScoped<IPurchaseService,PurchaseService>();
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
