using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Services
{
    public interface IUserService
    {
        Task SetCurrentEvent(long userId, EventType currEvent);
        Task<User> GetUser(long userId);
        Task AddUser(User users);
    }
}
