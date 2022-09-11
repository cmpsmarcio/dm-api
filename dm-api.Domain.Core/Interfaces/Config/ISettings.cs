using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Domain.Core.Interfaces.Config
{
    public interface ISettings
    {
        string JwtSecret { get; }
        string JwtAudience { get; }
        string JwtIssuer { get; }
    }
}
