using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortLinks.Interfaces;

namespace ShortLinks.Site.Controllers
{
    [Route("r")]
    [ApiController]
    public class RedirectController : ControllerBase
    {
        private readonly IShortLinksDataProvider _shortLinksDataProvider;

        public RedirectController(IShortLinksDataProvider shortLinksDataProvider)
        {
            _shortLinksDataProvider = shortLinksDataProvider;
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
        }
    }
}