using Microsoft.EntityFrameworkCore;
using ShortLinks.Contracts;

namespace ShortLinks.Storages
{
   public class ShortLinksContext : DbContext
    {
        public ShortLinksContext(DbContextOptions<ShortLinksContext> options)
            : base(options)
        {
        }

        public DbSet<ShortLink> ShortLinks { get; set; }
    }
}
