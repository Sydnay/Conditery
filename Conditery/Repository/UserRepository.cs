using Conditery.Context;
using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;
        private readonly
        object locker = new object();
        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public User GetUser(long userId)
        {
            lock (locker)
                return context.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public List<User> GetAllUsers()
        {
            lock (locker)
                return context.Users.ToList();
        }

        public void AddUser(User users)
        {
            try
            {
                context.Users.Add(users);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetCurrentEvent(long userId, EventType currEvent)
        {
            var users = GetUser(userId);

            if (users == null)
                throw new ArgumentNullException(nameof(users));

            users.UserEventId = (int)currEvent;
            context.SaveChanges();
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
