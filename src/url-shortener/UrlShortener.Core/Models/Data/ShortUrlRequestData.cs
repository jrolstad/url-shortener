using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core.Models.Data
{
    public class ShortUrlData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Value { get; set; }
        public string SourceUrl { get; set; }
        public string Partition { get; set; }
    }
}
