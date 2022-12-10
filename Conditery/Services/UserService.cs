using Conditery.Models;
using Conditery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SetCurrentEvent(long userId, EventType currEvent)
        {
            var users = await _userRepository.GetUser(userId);

            if (users == null)
                return;

            users.UserEventId = (int)currEvent;
            await _userRepository.SaveChangesAsync();
        }
        public async Task<User> GetUser(long userId)
        {
            return await _userRepository.GetUser(userId);
        }

        public async Task AddUser(User users)
        {
            await _userRepository.AddUser(users);
        }
    }
}
