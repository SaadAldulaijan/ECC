using ECC.Shared.Users.Contracts;

namespace ECC.Requests.APIs
{
    public interface IUsersClient
    {
        Task<UserResponseDto> GetUserAsync(int id);
    }
}
