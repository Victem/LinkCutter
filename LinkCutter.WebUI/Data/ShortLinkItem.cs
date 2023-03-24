using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.WebUI.Data
{
    public class ShortLinkItem
    {
        public long Id { get; set; }
        public string OriginalUrl { get; set; }
        public string? Token { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expired { get; set; } = DateTime.Now.AddDays(3);
    }

    public class ShortLinkItemConfiguration : IEntityTypeConfiguration<ShortLinkItem>
    {
        public void Configure(EntityTypeBuilder<ShortLinkItem> builder)
        {
            builder.HasIndex(x => x.Token).IsUnique();
        }
    }
}
