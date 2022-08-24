using AutoMapper;
using dm_api.Application.Dtos;
using dm_api.Application.Interfaces;
using dm_api.Domain.Core.Interfaces.Services;
using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application
{
    public class ApplicationServiceClient : IApplicationServiceClient
    {
        public readonly IServiceClient _serviceClient;
        public readonly IMapper _mapper;

        public ApplicationServiceClient(IServiceClient serviceClient, IMapper mapper)
        {
            _serviceClient = serviceClient;
            _mapper = mapper;
        }

        public void Add(ClientDto clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);
            _serviceClient.Add(client);
        }

        public void Delete(ClientDto clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);
            _serviceClient.Delete(client);
        }

        public ClientDto Get(Guid id)
        {
            Client client = _serviceClient.Get(id);
            return _mapper.Map<ClientDto>(client);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            IEnumerable<Client> client = _serviceClient.GetAll();
            return _mapper.Map<IEnumerable<ClientDto>>(client);
        }

        public void Update(ClientDto clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);
            _serviceClient.Update(client);
        }
    }
}
