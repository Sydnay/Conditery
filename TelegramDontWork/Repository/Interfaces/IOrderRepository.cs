using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order GetOrder(long userId);
        Order GetIncompleteOrder(long userId);
        void DeleteIncompleteOrder(long userId);
        void SaveChangeAsync();
    }
}
