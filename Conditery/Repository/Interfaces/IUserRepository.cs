using Conditery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public interface IUserRepository : IBaseRepository
    {
        Task<User> GetUser(long userId);
        Task<List<User>> GetAllUsers();
        Task AddUser(User users);
        Task ABOBA();
    }
}
