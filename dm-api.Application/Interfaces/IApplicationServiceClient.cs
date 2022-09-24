using dm_api.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Interfaces
{
    public interface IApplicationServiceClient
    {
        void Add(ClientRequest clientRequest);
        void Update(Guid id, ClientRequest clientDto);
        void Delete(Guid id);
        IEnumerable<ClientResponse> GetAll();
        ClientResponse Get(Guid id);
    }
}
