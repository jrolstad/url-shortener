using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core.Models
{
    public class ShortUrl
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string SourceUrl { get; set; }
    }
}
