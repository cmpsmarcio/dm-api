using AutoMapper;
using dm_api.Application.Dtos;
using dm_api.Application.Exceptions;
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

        public void Add(ClientRequest clientRequest)
        {
            Client client = _mapper.Map<Client>(clientRequest);
            _serviceClient.Add(client);
        }

        public void Delete(Guid id)
        {
            Client client = _serviceClient.Get(id);

            if (client == null)
                throw new EntityNotFoundException("Client not found");    

            _serviceClient.Delete(client);
        }

        public ClientResponse Get(Guid id)
        {
            Client client = _serviceClient.Get(id);
            return _mapper.Map<ClientResponse>(client);
        }

        public IEnumerable<ClientResponse> GetAll()
        {
            IEnumerable<Client> client = _serviceClient.GetAll();
            return _mapper.Map<IEnumerable<ClientResponse>>(client);
        }

        public void Update(Guid id, ClientRequest client)
        {
            Client modelClient = _serviceClient.Get(id);

            if (modelClient == null)
                throw new EntityNotFoundException("Client not found!");

            modelClient.FullName = client.FullName;
            modelClient.BirthDate = client.BirthDate;
            modelClient.Email = client.Email;
            modelClient.MobilePhone = client.MobilePhone;
            
            _serviceClient.Update(modelClient);
        }
    }
}
