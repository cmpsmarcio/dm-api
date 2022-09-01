using dm_api.Application.Dtos;

namespace dm_api.Application.Interfaces
{
    public interface IApplicationServiceToken
    {
        string GenerateToken(UserRequest userRequest);
    }
}
