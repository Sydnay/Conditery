using Conditery.Context;
using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext context;
        public OrderRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void AddOrder(Order order)
        {
            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Order GetIncompleteOrder(long userId)=> context.Orders.Where(x=>x.UpdateTime == DateTime.MinValue).FirstOrDefault(o => o.UserId == userId);

        public void DeleteIncompleteOrder(long userId)
        {
            var order = GetIncompleteOrder(userId);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public void SaveChangeAsync()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
