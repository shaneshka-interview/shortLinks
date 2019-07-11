using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShortLinks.Contracts;
using ShortLinks.Interfaces;
using ShortLinks.Storages;

namespace ShortLinks.Domain
{
   public class ShortLinksDataProvider : IShortLinksDataProvider
    {
        private readonly IShortLinksStorage _shortLinksStorage;
        private readonly IShortLinksShorten _shorten;

        public ShortLinksDataProvider(IShortLinksStorage shortLinksStorage, IShortLinksShorten shorten)
        {
            _shortLinksStorage = shortLinksStorage;
            _shorten = shorten;
        }
        public async Task<ShortLink> GetAsync(string shortLink)
        {
            return await _shortLinksStorage.GetAsync(shortLink);
        }

        public async Task<ShortLink> CreateAsync(string link)
        {
            var shortLink = new ShortLink
            {
                Link = link,
                ShortId = _shorten.Create(link)
            };
            
            var item = await _shortLinksStorage.CreateAsync(shortLink);
            return item;
        }

        public async Task<IEnumerable<ShortLink>> GetAllAsync()
        {
            return await _shortLinksStorage.GetAllAsync();
        }
    }
}
