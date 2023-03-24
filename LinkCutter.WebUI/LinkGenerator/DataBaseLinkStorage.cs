using LinkCutter.WebUI.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.WebUI.LinkGenerator
{
    public class DataBaseLinkStorage : ILinkStorage
    {
        private readonly ShortLinkDbContext _context;

        public DataBaseLinkStorage(ShortLinkDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetOriginalUrl(string url)
        {
            var linkItem = await _context.ShortLinkItems.FirstOrDefaultAsync(s => s.Token == url && (s.Expired > DateTime.Now));
            if (linkItem is not null)
            {
                return linkItem.OriginalUrl;
            }
            return null;
        }

        public async Task<string> GetToken(string url)
        {
            var linkItem = new ShortLinkItem
            {
                OriginalUrl = url
            };
            _context.ShortLinkItems.Add(linkItem);
            await _context.SaveChangesAsync();
            linkItem.Token = ShortChainGenerator.Encode(linkItem.Id);
            await _context.SaveChangesAsync();

            return linkItem.Token;
        }
    }
}
