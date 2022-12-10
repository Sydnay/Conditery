using Conditery.Models;
using Conditery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddOrder(Order order)
        {
            await _orderRepository.AddOrder(order);
        }

        public async Task<Order> GetIncompleteOrder(long userId)
        {
            return await _orderRepository.GetIncompleteOrder(userId);
        }

        public async Task UpdateOrder(Order order)
        {
            await _orderRepository.UpdateOrder(order);
        }
        public async Task DeleteIncompleteOrder(long userId)
        {
            var order = await _orderRepository.GetIncompleteOrder(userId);

            if (order is not null)
                await _orderRepository.DeleteOrder(order);
        }

        public async Task<Order> GetOrder(long orderId)
        {
            return await _orderRepository.GetOrder(orderId);
        }

    }
}
