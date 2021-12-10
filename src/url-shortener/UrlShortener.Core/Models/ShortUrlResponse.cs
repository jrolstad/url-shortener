using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core.Models
{
    public class ShortUrlResponse
    {
        public string Id { get; set; }
        public string ShortValue { get; set; }
        public string SourceValue { get; set; }
    }
}
