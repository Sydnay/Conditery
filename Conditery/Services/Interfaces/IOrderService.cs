using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Services
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        Task<Order> GetOrder(long userId);
        Task<Order> GetIncompleteOrder(long userId);
        Task UpdateOrder(Order order);
        Task DeleteIncompleteOrder(long userId);
    }
}
