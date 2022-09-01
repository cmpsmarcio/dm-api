using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Domain.Entities
{
    public class User: Base
    {
        public string Username { get; set; }
        public string Userpass { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
