using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ShortLinks.Domain
{
    public class ShortLinksShorten : IShortLinksShorten
    {

        private readonly Random random = new Random();
        private const int RandomCharsCount = 3;
        private const string Chars = "abcdefghijklmnopqrstuvwxyz0123456789";

        public string Create(string url)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(url));
                var hashPart = string.Join("", hash.Take(3)
                    .Select(b => b.ToString("x2")));
                var randomPart = new string(Enumerable.Repeat(Chars, RandomCharsCount)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                return hashPart + randomPart;
            }
        }
    }
}
