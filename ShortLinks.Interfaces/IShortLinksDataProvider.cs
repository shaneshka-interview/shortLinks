using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShortLinks.Contracts;

namespace ShortLinks.Interfaces
{
    public interface IShortLinksDataProvider
    {
        Task<ShortLink> GetAsync(string shortLink);
        Task<ShortLink> CreateAsync(string link);
        Task<IEnumerable<ShortLink>> GetAllAsync();
    }

}
