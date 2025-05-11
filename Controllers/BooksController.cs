using Microsoft.AspNetCore.Mvc;
using MVBooksAppService.Data;
using MVBooksAppService.Models;

namespace MVBooksAppService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly MVBooksDbContext _dbContext;

        public BooksController(ILogger<BooksController> logger, MVBooksDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<IList<Book>> Get()
        {
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new Book
            {
                Id = index,
                Title = $"Book {index}",
                Author = $"Author {index}",
                ISBN = $"ISBN-{index}",
                PublishedDate = DateTime.Now.AddDays(-index * 365),
                Genre = $"Genre {index}",
                PageCount = Random.Shared.Next(100, 1000),
                Publisher = $"Publisher {index}",
                Price = (decimal)(Random.Shared.NextDouble() * 100)
            })
            .ToList());
        }
    }
}
