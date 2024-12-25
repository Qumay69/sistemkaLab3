using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Lab3.Models
{
    public static class SeedData
{
    public static void SeedDatabase(DataContext context)
    {
        context.Database.Migrate();

        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product { Name = "Дрель", Price = 75 },
                new Product { Name = "Молоток", Price = 45 },
                new Product { Name = "Лопата", Price = 100 },
                new Product { Name = "Шуруп", Price = 1 },
                new Product { Name = "Кусачки", Price = 150 },
                new Product { Name = "Отвертка", Price = 20 },
                new Product { Name = "Линейка", Price = 10 }
            );
            context.SaveChanges();
        }

        if (!context.Orders.Any())
        {
            var products = context.Products.ToList();
            var customers = new[] { "Фирма А", "Фирма Б", "Фирма В", "Фирма Г", "Фирма Д" };

            context.Orders.AddRange(
                new Order { Customer = "Фирма А", ProductId = products[0].Id, Quantity = 3, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 3 * products[0].Price, IsCompleted = true },
                new Order { Customer = "Фирма Б", ProductId = products[1].Id, Quantity = 10, OrderDate = DateTime.Now.AddDays(-4), TotalAmount = 10 * products[1].Price, IsCompleted = true },
                new Order { Customer = "Фирма В", ProductId = products[2].Id, Quantity = 5, OrderDate = DateTime.Now.AddDays(-3), TotalAmount = 5 * products[2].Price, IsCompleted = false },
                new Order { Customer = "Фирма Г", ProductId = products[3].Id, Quantity = 7, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 7 * products[3].Price, IsCompleted = false },
                new Order { Customer = "Фирма Д", ProductId = products[4].Id, Quantity = 2, OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 2 * products[4].Price, IsCompleted = true },
                new Order { Customer = "Фирма А", ProductId = products[5].Id, Quantity = 15, OrderDate = DateTime.Now.AddDays(-6), TotalAmount = 15 * products[5].Price, IsCompleted = false },
                new Order { Customer = "Фирма Б", ProductId = products[6].Id, Quantity = 8, OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 8 * products[6].Price, IsCompleted = true }
            );
            context.SaveChanges();
        }
    }
}
}
