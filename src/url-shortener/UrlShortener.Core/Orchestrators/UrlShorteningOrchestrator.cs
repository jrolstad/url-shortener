using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UrlShortener.Core.Mappers;
using UrlShortener.Core.Models;
using UrlShortener.Core.Repositories;

namespace UrlShortener.Core.Orchestrators
{
    public class UrlShorteningOrchestrator
    {
        private readonly UrlRepository _repository;
        private readonly UrlMapper _urlMapper;
        private readonly ShortUrlMapper _shortUrlMapper;

        public UrlShorteningOrchestrator(UrlRepository repository, 
            UrlMapper urlMapper,
            ShortUrlMapper shortUrlMapper)
        {
            _repository = repository;
            _urlMapper = urlMapper;
            _shortUrlMapper = shortUrlMapper;
        }

        public async Task<ShortUrlResponse> Create(IEnumerable<ClaimsIdentity> user, ShortUrlRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Url)) return new ShortUrlResponse { SourceValue = request?.Url };

            var shortened = _urlMapper.Shorten(request.Url);
            var data = _shortUrlMapper.MapNew(shortened, request.Url);

            var savedData = await _repository.Add(data);
            var response = _shortUrlMapper.MapResponse(savedData);

            return response;
        }

        public async Task<ShortUrlResponse> Get(IEnumerable<ClaimsIdentity> user, string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return new ShortUrlResponse { Id = id };

            var savedData = await _repository.Get(id);
            var response = _shortUrlMapper.MapResponse(savedData);

            return response;
        }
    }
}
