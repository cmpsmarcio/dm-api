using dm_api.Application.Models;

namespace dm_api.Application.Interfaces
{
    public interface IApplicationServiceToken
    {
        string GenerateToken(UserRequest userRequest);
    }
}
