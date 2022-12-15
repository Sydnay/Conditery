using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public interface IOrderRepository : IBaseRepository
    {
        Task AddOrder(Order order);
        Task<Order> GetOrder(long orderId);
        Task<List<Order>> GetAllUserOrders(long userId);
        Task<Order> GetIncompleteOrder(long userId);
        Task UpdateOrder(Order order);
        Task DeleteOrder(Order order);
    }
}
