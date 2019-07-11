using System.Collections.Generic;
using System.Threading.Tasks;
using ShortLinks.Contracts;

namespace ShortLinks.Storages
{
    public interface IShortLinksStorage
    {
        Task<ShortLink> GetAsync(string shortLink);
        Task<ShortLink> CreateAsync(ShortLink link);
        Task<IEnumerable<ShortLink>> GetAllAsync();
    }
}