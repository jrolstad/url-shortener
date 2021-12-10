using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Api.Extensions
{
    public static class HttpRequestDataExtensions
    {
        public static IEnumerable<ClaimsIdentity> GetRequestingUser(this HttpRequestData request)
        {
            return request.Identities;
        }

        public static T GetBody<T>(this HttpRequestData request)
        {
            if (request.Body == null) return default(T);

            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body);
            var bodyAsString = reader.ReadToEnd();

            var result = JsonConvert.DeserializeObject<T>(bodyAsString);

            return result;
        }

        public static async Task<HttpResponseData> OkResponseAsync<T>(this HttpRequestData request, T data)
        {
            var response = request.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(data);

            return response;
        }

        public static async Task<HttpResponseData> RedirectResponseAsync(this HttpRequestData request, ShortUrlResponse data)
        {
            var response = request.CreateResponse(HttpStatusCode.Redirect);
            // Add redirect location here

            return response;
        }
    }
}
