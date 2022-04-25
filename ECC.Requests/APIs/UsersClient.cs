using ECC.Shared.Users.Contracts;

namespace ECC.Requests.APIs
{
    public class UsersClient : IUsersClient
    {
        private readonly HttpClient _httpClient;

        public UsersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<UserResponseDto> GetUserAsync(int id) => 
            await _httpClient.GetFromJsonAsync<UserResponseDto>("api/users/" + id);

    }
}
