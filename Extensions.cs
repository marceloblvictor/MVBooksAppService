using Microsoft.Azure.Cosmos;

namespace MVBooksAppService;

public static class Extensions
{
    /// <summary>
    /// Adds Cosmos Client to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add Cosmos Client to.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static void AddAzureCosmosDb(this IServiceCollection services, string connectionString, string key, string databaseName)
    {
        // Add the CosmosClient to the service collection
        services.AddSingleton<CosmosClient>(sp =>
        {
            var options = new CosmosClientOptions
            {
                SerializerOptions = new CosmosSerializationOptions
                {
                    PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                    Indented = false,
                    IgnoreNullValues = false
                },
                ConnectionMode = ConnectionMode.Direct, //Direct is more performant // Gateway only support HTTPS, no TCP
                GatewayModeMaxConnectionLimit = 10,
                RequestTimeout = TimeSpan.FromSeconds(30),
                TokenCredentialBackgroundRefreshInterval = null,               
                CosmosClientTelemetryOptions = new CosmosClientTelemetryOptions()
                {
                    DisableSendingMetricsToService = false,
                    DisableDistributedTracing = false
                },
            };
            return new CosmosClient(connectionString, key, options);
        });
    }       
}
