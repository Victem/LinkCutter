using Microsoft.EntityFrameworkCore;

namespace LinkCutter.WebUI.Data
{
    public class ShortLinkDbContext : DbContext
    {
        public ShortLinkDbContext(DbContextOptions<ShortLinkDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShortLinkItem> ShortLinkItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ShortLinkItemConfiguration());
        }
    }
}
