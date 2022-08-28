using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Dtos
{
    public class ClientResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
