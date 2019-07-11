using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShortLinks.Contracts;
using ShortLinks.Errors;

namespace ShortLinks.Storages
{
    public class ShortLinksStorage : IShortLinksStorage
    {

        //private ConcurrentDictionary<string, ShortLink> _links = new ConcurrentDictionary<string, ShortLink>();
        private readonly ShortLinksContext _context;

        public ShortLinksStorage(ShortLinksContext context)
        {
            _context = context;
        }

        public async Task<ShortLink> GetAsync(string shortLink)
        {
            return await _context.ShortLinks.FirstOrDefaultAsync(x => x.ShortId == shortLink);

            /*
            if (!_links.TryGetValue(shortLink, out var weatherTown))
            {
                throw new ShortLinksException($"not found {shortLink}");
            }
            
            return link;*/
        }

        public async Task<ShortLink> CreateAsync(ShortLink link)
        {
            var item = await GetAsync(link.ShortId);
            if (item == null)
            {
               var entity = await _context.ShortLinks.AddAsync(link);
               await _context.SaveChangesAsync();

               return entity.Entity;
            }

            return item;

            /*if (!_links.TryGetValue(link.Short, out var shortLink))
            {
                shortLink = link;
                _links.TryAdd(link.Short, shortLink);
            }

            return shortLink;*/
        }

        public async Task<IEnumerable<ShortLink>> GetAllAsync()
        {
            return await _context.ShortLinks.ToArrayAsync();
            //return _links.Values.ToArray();
        }
    }
}
