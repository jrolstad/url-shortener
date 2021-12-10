using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using UrlShortener.Core.Configuration;

namespace UrlShortener.Api
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                 .ConfigureFunctionsWorkerDefaults()
                 .ConfigureServices(DependencyInjectionConfiguration.Configure)
                 .ConfigureAppConfiguration((context, builder) =>
                 {
                     builder.AddEnvironmentVariables();
                 })
                 .Build();

            host.Run();
        }
    }
}