using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public interface IUserRepository
    {
        User GetUser(long userId);
        List<User> GetAllUsers();
        void AddUser(User users);
        void SetCurrentEvent(long userId, EventType currEvent);
        Task ABOBA();
    }
}
