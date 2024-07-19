using Microsoft.EntityFrameworkCore;
using Transaction.Entities;

namespace Transaction;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public DbSet<Cash>Cashes{get; set;}
    public DbSet<OpeningStockProduct>OpeningStockProducts{get; set;}
    public DbSet<OpeningStock>OpeningStocks{get; set;}
    public DbSet<ValidClosingStockProduct>ValidClosingStockProducts{get; set;}
    public DbSet<ValidClosingStock>ValidClosingStocks{get; set;}
    public DbSet<Product>Products{get; set;}
    public DbSet<GoodReleased>GoodReleaseds{get; set;}
    public DbSet<GoodReleasedProduct>GoodReleasedProducts{get; set;}
    public DbSet<Manager>Managers{get; set;}
    public DbSet<ProductPurchace>ProductPurchaces{get; set;}
    public DbSet<Purchace>Purchaces{get; set;}
    public DbSet<Sales>Sales{get; set;}
    public DbSet<SalesRep>SalesReps{get; set;}
    public DbSet<ShopItems>ShopItems{get; set;}
    public DbSet<StoreItems>StoreItems{get; set;}
    public DbSet<GoodsReturned>GoodsReturneds{get; set;}
    public DbSet<GoodsReturnedProduct>GoodsReturnedProducts{get; set;}
    public DbSet<SalesProduct>SalesProducts{get; set;}
}