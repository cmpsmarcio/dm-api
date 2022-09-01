using dm_api.Application.Interfaces;
using dm_api.Domain.Core.Interfaces.Services;
using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application
{
    public class ApplicationServiceToken: IApplicationServiceToken
    {
        private readonly ITokenService _tokenService;

        public ApplicationServiceToken(ITokenService tokenService)
        {
            this._tokenService = tokenService;
        }

        public string GenerateToken(User user) => _tokenService.GenerateToken(user);
    }
}
