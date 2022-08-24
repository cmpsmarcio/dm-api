using dm_api.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Interfaces
{
    public interface IApplicationServiceClient
    {
        void Add(ClientDto clientDto);
        void Update(ClientDto clientDto);
        void Delete(ClientDto clientDto);
        IEnumerable<ClientDto> GetAll();
        ClientDto Get(Guid id);
    }
}
