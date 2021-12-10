using System;
using UrlShortener.Core.Configuration;

namespace UrlShortener.Core.Mappers
{
    public class ShortUrlMapper
    {
        public Models.ShortUrl MapNew(string shortenedUrl, string sourceUrl)
        {
            return new Models.ShortUrl
            {
                Id = Guid.NewGuid().ToString(),
                SourceUrl = sourceUrl,
                Value = shortenedUrl
            };
        }

        public Models.ShortUrlResponse MapResponse(Models.ShortUrl toMap)
        {
            return new Models.ShortUrlResponse
            {
                Id = toMap?.Id,
                ShortValue = toMap?.Value,
                SourceValue = toMap?.SourceUrl
            };
        }

        public Models.Data.ShortUrlData Map(Models.ShortUrl toMap)
        {
            return new Models.Data.ShortUrlData
            {
                Id = toMap?.Id,
                Value = toMap?.Value,
                SourceUrl = toMap?.SourceUrl,
                Partition = CosmosConfiguration.DefaultPartitionKey
            };
        }

        public Models.ShortUrl Map(Models.Data.ShortUrlData toMap)
        {
            return new Models.ShortUrl
            {
                Id = toMap?.Id,
                Value = toMap?.Value,
                SourceUrl = toMap?.SourceUrl
            };
        }
    }
}
