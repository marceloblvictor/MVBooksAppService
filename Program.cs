using MVBooksAppService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var cosmosConnectionString = builder.Configuration["CosmosDb:ConnectionString"];
var cosmosKey = builder.Configuration["CosmosDb:Key"];
var cosmosDatabaseName = builder.Configuration["CosmosDb:DatabaseName"];

builder.Services.AddAzureCosmosDb(cosmosConnectionString, cosmosKey, cosmosDatabaseName);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();


// set metadata to blob 

//await blobClient.SetMetadataAsync(new Dictionary<string, string>
//{
//    { "Resolution", "1920x1080" },
//    { "ColorProfile", "sRGB" }
//});