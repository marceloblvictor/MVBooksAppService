using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVBooksAppService.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MVBooksDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MVBooksDbContext") 
            ?? throw new InvalidOperationException("Connection string 'MVBooksDbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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