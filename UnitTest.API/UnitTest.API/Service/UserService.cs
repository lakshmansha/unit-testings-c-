using Microsoft.EntityFrameworkCore;
using UnitTest.API.Data;
using UnitTest.API.Models;

namespace UnitTest.API.Service
{
    public class UserService : IUserService
    {
        private readonly UnitTestAPIContext _context;

        public UserService(UnitTestAPIContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

    }
}
