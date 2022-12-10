using Conditery.Context;
using Conditery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly ApplicationContext context;
        public OrderRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }
        public async Task AddOrder(Order order)
        {
            try
            {
                await _semaphore.WaitAsync();

                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }


        public async Task<Order> GetIncompleteOrder(long userId)
        {
            try
            {
                await _semaphore.WaitAsync();

                return await context.Orders.Where(x => x.UpdateTime == DateTime.MinValue).FirstOrDefaultAsync(o => o.UserId == userId);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<Order> GetOrder(long orderId)
        {
            try
            {
                await _semaphore.WaitAsync();

                return await context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                await _semaphore.WaitAsync();
                context.Orders.Update(order);
                await context.SaveChangesAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task DeleteOrder(Order order)
        {
            try
            {
                await _semaphore.WaitAsync();
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
