using Orders.Domain;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderContext context = new OrderContext();
        public void DeleteOrder(int id)
        {
            var ordersToRemove = context.Orders.Where(o => o.Id == id).ToList();
            context.Orders.RemoveRange(ordersToRemove);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrdersByCustomer(int id)
        {
            var customerOrders = context.Orders.Where(o => o.customer_id == id).ToList();

            return customerOrders;
        }
    }
}
