using Microsoft.EntityFrameworkCore;

namespace MVCProject;

public class MVCProjectContext : DbContext
{
    public MVCProjectContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    // public DbSet<Stock>Stocks{get; set;}
    //  public DbSet<SalesRep>SalesReps{get; set;}
    //  public DbSet<StoreItems>StoreItems{get; set;}
    // public DbSet<Admin>Admins{get; set;}
    // public DbSet<Categories>Categories{get; set;}
    // public DbSet<StockSold>StockSolds{get; set;}
    // public DbSet<OpeningStock>OpeningStocks{get; set;}
    // public DbSet<ClosingStock>ClosingStocks{get; set;}
}