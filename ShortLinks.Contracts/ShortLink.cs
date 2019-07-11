using System;

namespace ShortLinks.Contracts
{
    public class ShortLink
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ShortId { get; set; }
    }
}
