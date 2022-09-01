using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Domain.Core.Interfaces.Config
{
    public interface IConfiguration
    {
        string GetSecret();
    }
}
