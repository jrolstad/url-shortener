namespace UrlShortener.Core.Configuration.Cosmos
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
