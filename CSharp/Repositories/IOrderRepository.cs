using System.Collections.Generic;
using Orders.Domain;


namespace CSharp.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrdersByCustomer(int id);
        void DeleteOrder(int id);


    }
}
