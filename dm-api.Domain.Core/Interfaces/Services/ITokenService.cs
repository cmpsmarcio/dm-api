using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Domain.Core.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
