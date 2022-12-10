using Conditery.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditery.Repository
{
    public class BaseRepository : IBaseRepository
    {
        protected SemaphoreSlim _semaphore = new SemaphoreSlim(1,1);
        protected ApplicationContext _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _semaphore.WaitAsync();

                await _context.SaveChangesAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
