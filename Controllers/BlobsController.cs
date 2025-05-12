using Microsoft.AspNetCore.Mvc;

namespace MVBooksAppService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlobsController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        public BlobsController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }
        
    }
}
