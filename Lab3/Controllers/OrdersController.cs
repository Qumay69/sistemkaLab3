using Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    public class OrdersController
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
            public IAsyncEnumerable<Order> GetProducts()
            {
                return db.Orders.AsAsyncEnumerable();
            }
            [HttpGet]
            public async Task<ActionResult<Order>> GetIncompleteOrdersReport(int year, int month)
            {
                var incompleteOrders = await (from o in db.Orders
                                              join p in db.Products on o.ProductId equals p.Id
                                              where o.IsCompleted == false
                                                    && o.OrderDate.Year == year
                                                    && o.OrderDate.Month == month
                                              group new { o, p } by new { p.Name } into g
                                              select new
                                              {
                                                  ProductName = g.Key.Name,
                                                  TotalQuantity = g.Sum(x => x.o.Quantity),
                                                  TotalRevenue = g.Sum(x => x.o.TotalAmount)
                                              })
                                      .OrderBy(x => x.ProductName)
                                      .ToListAsync();
                return Ok(incompleteOrders);
            }
        }
    }
}
