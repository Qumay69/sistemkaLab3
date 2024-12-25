using Lab3.Models;

namespace Lab3
{
    public class TestMiddleware
    {
        private RequestDelegate nextDelegate;
        public TestMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext context,
                DataContext dataContext)
        {
            if (context.Request.Path == "/test")
            {
                await context.Response.WriteAsync($"There are "
                    + dataContext.Products.Count() + " products\n");
                await context.Response.WriteAsync("There are "
                    + dataContext.Orders.Count() + " Orders\n");
            }
            else
            {
                await nextDelegate(context);
            }
        }
    }
}
