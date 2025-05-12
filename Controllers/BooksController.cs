using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using MVBooksAppService.Models;

namespace MVBooksAppService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly CosmosClient _cosmosClient;
        private readonly Container _booksContainer;

        public BooksController(ILogger<BooksController> logger, CosmosClient cosmosClient)
        {
            _logger = logger;
            _cosmosClient = cosmosClient;

            Database database = _cosmosClient.CreateDatabaseIfNotExistsAsync("MyDatabaseName").Result;

            _booksContainer = database.CreateContainerIfNotExistsAsync(
                id: "MyContainerName", partitionKeyPath: "/partitionKeyPath", throughput: 400).Result;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> Get()
        {                        
            QueryDefinition query = new QueryDefinition(
                "select * from books b where p.Price > @price")
                .WithParameter("@price", 10m);

            FeedIterator<Book> resultSet = _booksContainer.GetItemQueryIterator<Book>(
                query,
                requestOptions: new QueryRequestOptions()
                {
                    PartitionKey = new PartitionKey("Author"),
                    MaxItemCount = 1
                });

            return Ok(resultSet);            
        }

        [HttpGet(Name = "GetBookById")]
        public async Task<IActionResult> GetById()
        {
            string id = "123";
            string authorName = "Machado";
            
            ItemResponse<Book> response = await _booksContainer.ReadItemAsync<Book>(id, new PartitionKey(authorName));            

            return Ok(response.Resource);
        }

        [HttpPost(Name = "CreateBook")]
        public async Task<IActionResult> Create()
        {
            // Create a new book with hardcoded random values            

            var book = new Book
            {
                Title = $"Book {Random.Shared.Next(1, 1000)}",
                Author = $"Machado",
                ISBN = $"ISBN-{Random.Shared.Next(1000, 9999)}",
                PublishedDate = DateTime.Now.AddDays(-Random.Shared.Next(1, 1000)),
                Genre = $"Genre {Random.Shared.Next(1, 10)}",
                PageCount = Random.Shared.Next(100, 1000),
                Publisher = $"Publisher {Random.Shared.Next(1, 100)}",
                Price = (decimal)(Random.Shared.NextDouble() * 100),
                BlobUrl = $"https://example.com/blob/{Random.Shared.Next(1, 1000)}",
                Enabled = false,
            };

            ItemResponse<Book> response = await _booksContainer.CreateItemAsync(book, new PartitionKey(book.Author));

            return Ok("Succesfully created!");
        }
    }
}
