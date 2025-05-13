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
        private readonly Container _booksContainer;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            //_cosmosClient = cosmosClient;

            //Database database = _cosmosClient.CreateDatabaseIfNotExistsAsync("MyDatabaseName").Result;

            //_booksContainer = database.CreateContainerIfNotExistsAsync(
            //    id: "MyContainerName", partitionKeyPath: "/partitionKeyPath", throughput: 400).Result;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> Get()
        {                        
            //QueryDefinition query = new QueryDefinition(
            //    "select * from books b where p.Price > @price")
            //    .WithParameter("@price", 10m);

            //var queryOptions = new QueryRequestOptions
            //{
            //    MaxItemCount = 1,
            //    PartitionKey = new PartitionKey("Author"),
            //    MaxBufferedItemCount = 1,
            //    MaxConcurrency = 1,
            //    ConsistencyLevel = ConsistencyLevel.Strong
            //};
            

            //FeedIterator<Book> resultSet = _booksContainer.GetItemQueryIterator<Book>(
            //    query,
            //    requestOptions: queryOptions);

            return Ok("books succesfull");            
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<IActionResult> GetById(int id)
        {
            //string id = "123";
            //string authorName = "Machado";
            
            //ItemResponse<Book> response = await _booksContainer.ReadItemAsync<Book>(id, new PartitionKey(authorName));            

            return Ok("book succesfull: " + id.ToString());
        }

        [HttpPost(Name = "CreateBook")]
        public async Task<IActionResult> Create()
        {
            // Create a new book with hardcoded random values            

            //var book = new Book
            //{
            //    Title = $"Book {Random.Shared.Next(1, 1000)}",
            //    Author = $"Machado",
            //    ISBN = $"ISBN-{Random.Shared.Next(1000, 9999)}",
            //    PublishedDate = DateTime.Now.AddDays(-Random.Shared.Next(1, 1000)),
            //    Genre = $"Genre {Random.Shared.Next(1, 10)}",
            //    PageCount = Random.Shared.Next(100, 1000),
            //    Publisher = $"Publisher {Random.Shared.Next(1, 100)}",
            //    Price = (decimal)(Random.Shared.NextDouble() * 100),
            //    BlobUrl = $"https://example.com/blob/{Random.Shared.Next(1, 1000)}",
            //    Enabled = false,
            //};

            //ItemResponse<Book> response = await _booksContainer.CreateItemAsync(book, new PartitionKey(book.Author));

            return Ok("Succesfully created!");
        }
    }
}
