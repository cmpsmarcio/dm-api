using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using dm_api.Domain.Core.Interfaces.Config;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using dm_api.Domain.Core.Interfaces.Services;

namespace dm_api.Domain.Service
{
    public class TokenService: ITokenService
    {
        private readonly ISettings _config;

        public TokenService(ISettings config)
        {
            this._config = config;
        }
        public string GenerateToken(User user)
        { 
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_config.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("sub", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Username),
                    new Claim(ClaimTypes.Role, "adm")
                }),
                Audience = _config.JwtAudience,
                Issuer = _config.JwtIssuer,
                Claims = new Dictionary<string, object>() { { "job", new { jobName = "name" } } },
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
;