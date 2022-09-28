using MetaboCoins.API.Model;
using Microsoft.EntityFrameworkCore;

namespace MetaboCoins.API.Authentication
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<StoreBranchModel> StoreBranches { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ScanHistoryModel> ScanHistories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
