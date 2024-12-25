using Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private DataContext db;
        public ProductController(DataContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        public IAsyncEnumerable<Product> GetProducts()
        {
            return db.Products.AsAsyncEnumerable();
        }

    }
}
