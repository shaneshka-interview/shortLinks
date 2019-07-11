using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortLinks.Contracts;
using ShortLinks.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShortLinks.Site.Controllers
{
    [Route("api/[controller]")]
    public class ShortsController : Controller
    {
        private readonly IShortLinksDataProvider _shortLinksDataProvider;

        public ShortsController(IShortLinksDataProvider shortLinksDataProvider)
        {
            _shortLinksDataProvider = shortLinksDataProvider;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IEnumerable<ShortLink>> GetShorts()
        {
            var item = await _shortLinksDataProvider.GetAllAsync();
            return item;
        }

        [HttpGet("{shortLink}")]
        public async Task<IActionResult> GetShorts(string shortLink)
        {
            var item = await _shortLinksDataProvider.GetAsync(shortLink);
            if (item == null)
            {
                return BadRequest();
            }

            return Redirect(item.Link);
            //return item;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShort([FromBody] string link)
        {
            if (!IsValidUri(link))
            {
                return BadRequest();
            }

            var item = await _shortLinksDataProvider.CreateAsync(link);
            return Ok(item);
        }

        public bool IsValidUri(string uri)
        {
            return Uri.TryCreate(uri, UriKind.Absolute, out var validatedUri);
        }
    }
}
