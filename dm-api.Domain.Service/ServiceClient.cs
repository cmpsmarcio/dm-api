using dm_api.Domain.Core.Interfaces.Repositories;
using dm_api.Domain.Core.Interfaces.Services;
using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Domain.Service
{
    public class ServiceClient : ServiceBase<Client>, IServiceClient
    {
        private readonly IRepositoryClient _repositoryClient;
        public ServiceClient(IRepositoryClient repositoryClient) : base(repositoryClient)
        {
            _repositoryClient = repositoryClient;
        }
    }
}
