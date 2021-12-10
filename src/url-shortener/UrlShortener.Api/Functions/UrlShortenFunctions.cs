using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using UrlShortener.Api.Extensions;
using UrlShortener.Core.Models;
using UrlShortener.Core.Orchestrators;

namespace UrlShortener.Api
{
    public class UrlShortenFunctions
    {
        private readonly UrlShorteningOrchestrator _orchestrator;

        public UrlShortenFunctions(UrlShorteningOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        [Function("url-shorten-post")]
        public async Task<HttpResponseData> Post([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "url/short")] HttpRequestData req)
        {
            var response = await _orchestrator.Create(req.GetRequestingUser(), req.GetBody<ShortUrlRequest>());
            return await req.OkResponseAsync(response);
        }

        [Function("url-shorten-get")]
        public async Task<HttpResponseData> Get([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route ="url/short/{id}")] HttpRequestData req,
            string id)
        {
            var response = await _orchestrator.Get(req.GetRequestingUser(), id);
            return await req.OkResponseAsync(response);
        }
    }
}
