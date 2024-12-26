using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public static class ReportGenerator
    {
        public static List<OrderReport> GetCompletedOrdersReport(DataContext context)
        {
            var completedOrders = context.Orders
                .Where(o => o.IsCompleted && o.OrderDate.Month == DateTime.Now.Month)
                .GroupBy(o => o.Product.Name)
                .Select(g => new OrderReport
                {
                    ProductName = g.Key,
                    TotalQuantity = g.Sum(o => o.Quantity),
                    TotalRevenue = g.Sum(o => o.TotalAmount)
                })
                .ToList();

            return completedOrders;
        }

        public static List<OrderReport> GetPendingOrdersReport(DataContext context)
        {
            var pendingOrders = context.Orders
                .Where(o => !o.IsCompleted && o.OrderDate.Month == DateTime.Now.Month)
                .GroupBy(o => o.Product.Name)
                .Select(g => new OrderReport
                {
                    ProductName = g.Key,
                    TotalQuantity = g.Sum(o => o.Quantity),
                    TotalRevenue = g.Sum(o => o.TotalAmount)
                })
                .ToList();

            return pendingOrders;
        }
    }
}
