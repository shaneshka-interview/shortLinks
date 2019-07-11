using System;

namespace ShortLinks.Errors
{
    public class ShortLinksException : Exception
    {
        public ShortLinksException(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
