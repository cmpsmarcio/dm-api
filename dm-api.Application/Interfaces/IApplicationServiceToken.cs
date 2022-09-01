using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Interfaces
{
    public interface IApplicationServiceToken
    {
        string GenerateToken(User user);
    }
}
