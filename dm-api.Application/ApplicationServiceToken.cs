using dm_api.Application.Models;
using dm_api.Application.Exceptions;
using dm_api.Application.Interfaces;
using dm_api.Domain.Core.Interfaces.Services;
using dm_api.Domain.Entities;

namespace dm_api.Application
{
    public class ApplicationServiceToken: IApplicationServiceToken
    {
        private readonly ITokenService _tokenService;
        private readonly IServiceUser _serviceUser;

        public ApplicationServiceToken(ITokenService tokenService, IServiceUser serviceUser)
        {
            this._tokenService = tokenService;
            this._serviceUser = serviceUser;
        }

        public string GenerateToken(UserRequest userRequest)
        {
            User? user = _serviceUser.GetUser(userRequest.Username, userRequest.Password);

            if (user == null)
                throw new EntityNotFoundException("Invalid User");

            return _tokenService.GenerateToken(user);
        } 
    }
}
