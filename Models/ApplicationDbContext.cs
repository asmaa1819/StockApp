
namespace StockApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define relationships here
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Store)
                .WithMany(s => s.Items)
                .HasForeignKey(i => i.StoreId);
        }

    }
}
