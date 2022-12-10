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
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<User> GetUser(long userId)
        {
            try
            {
                await _semaphore.WaitAsync();

                return await context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                await _semaphore.WaitAsync();

                return await context.Users.ToListAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task AddUser(User users)
        {
            try
            {
                await _semaphore.WaitAsync();

                await context.Users.AddAsync(users);
                await context.SaveChangesAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task ABOBA()
        {
            if (context.UserEvents.FirstOrDefault() is not null)
                return;

            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleStart,
                Name = EventType.HandleStart.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleCreateOrder,
                Name = EventType.HandleCreateOrder.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderType,
                Name = EventType.HandleOrderType.ToString()
            }); 
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderDate,
                Name = EventType.HandleOrderDate.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderDetails,
                Name = EventType.HandleOrderDetails.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderCity,
                Name = EventType.HandleOrderCity.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderPriceRange,
                Name = EventType.HandleOrderPriceRange.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderAttachments,
                Name = EventType.HandleOrderAttachments.ToString()
            });
            await context.UserEvents.AddAsync(new UserEvent
            {
                Id = (int)EventType.HandleOrderReady,
                Name = EventType.HandleOrderReady.ToString()
            });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
