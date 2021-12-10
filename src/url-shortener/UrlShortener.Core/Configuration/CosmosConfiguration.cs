namespace UrlShortener.Core.Configuration
{
    public static class CosmosConfiguration
    {
        public static string DefaultPartitionKey = "Default";
        public static string DatabaseId = "urlshortener";
        public static CosmosContainers Containers = new CosmosContainers();
    }

    public class CosmosContainers
    {
        public string Urls = "Urls";
    }
}
