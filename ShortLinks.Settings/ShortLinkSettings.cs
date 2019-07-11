using System;
using Microsoft.Extensions.Configuration;

namespace ShortLinks.Settings
{
    public class ShortLinkSettings : IShortLinkSettings
    {
        private readonly IConfiguration _configuration;

        public ShortLinkSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetKey => _configuration.GetValue<string>("ShortLinks:key");
    }
}
