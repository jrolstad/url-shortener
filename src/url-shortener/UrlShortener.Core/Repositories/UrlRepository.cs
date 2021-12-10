using System;
using System.Threading.Tasks;
using UrlShortener.Core.Configuration.Cosmos;
using UrlShortener.Core.Mappers;
using UrlShortener.Core.Models;
using UrlShortener.Core.Services;

namespace UrlShortener.Core.Repositories
{
    public class UrlRepository
    {
        private readonly CosmosDbService _cosmosDbService;
        private readonly ShortUrlMapper _mapper;

        public UrlRepository(CosmosDbService cosmosDbService, ShortUrlMapper mapper)
        {
            _cosmosDbService = cosmosDbService;
            _mapper = mapper;
        }

        public async Task<ShortUrl> Add(ShortUrl toAdd)
        {
            var data = _mapper.Map(toAdd);

            var responseData = await _cosmosDbService.Save(data, CosmosConfiguration.Containers.Urls);
            var response = _mapper.Map(responseData);

            return response;
        }
    }
}
