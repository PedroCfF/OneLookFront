using OneLookWA.Models;
using System.Net.Http.Json;
using System.ComponentModel.DataAnnotations;

namespace OneLookWA.Services.Users
{
    public class UsersService : IUsersService
    {
        HttpClient _httpClient;  
        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> GetUser(Request request)
        {            
            var users = await _httpClient.GetFromJsonAsync<List<User>>("https://localhost:7193/api/Users");
            var user = users.Find(u => u.UserName == request.name);

            return user;        
        }

        public async Task<bool> CreateUser(Request request)
        {
            var validEmail = new EmailAddressAttribute().IsValid(request.email);

            if(request.name.Length>50)
            {
                return false;
            }

            if(request.password!=request.password2)
            {
                return false;
            }

            if(!validEmail)
            {
                return false;
            }

            await _httpClient.PostAsJsonAsync("https://localhost:7193/api/Users", request);
            return true;
        }
    }
}
