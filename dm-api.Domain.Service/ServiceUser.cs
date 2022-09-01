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
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser) 
            : base(repositoryUser)
        {
            this._repositoryUser = repositoryUser;
        }

        public User? GetUser(string username, string password) => _repositoryUser.GetUser(username, password);         
    }
}
