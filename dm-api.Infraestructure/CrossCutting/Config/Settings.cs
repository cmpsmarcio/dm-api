using dm_api.Domain.Core.Interfaces.Config;
using Microsoft.Extensions.Configuration;

namespace dm_api.Infraestructure.CrossCutting.Config
{
    public class Settings : ISettings
    {
        private readonly IConfiguration _config;

        public Settings(IConfiguration config)
        {
            _config = config;
        }

        public string JwtSecret => _config.GetValue<string>("Jwt:Key");//"dm4&cxnl_a6$#3i5*$0qe=y=a@(-&@fmv2w68w=tbizl1%)$-p2mh";

        public string JwtAudience => _config.GetValue<string>("Jwt:Audience");

        public string JwtIssuer => _config.GetValue<string>("Jwt:Issuer");
    }
}
