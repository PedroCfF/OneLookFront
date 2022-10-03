using OneLookWA.Models;

namespace OneLookWA.Services.Users
{
    public interface IUsersService
    {
        public Task<User> GetUser(Request request);
        public Task<bool> CreateUser(Request request);
    }
}
