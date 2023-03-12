using UnitTest.API.Models;

namespace UnitTest.API.Service
{
    public interface IUserService
    {
        Task<List<User>> GetUser();
    }
}