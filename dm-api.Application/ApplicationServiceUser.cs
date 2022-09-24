using AutoMapper;
using dm_api.Application.Models;
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
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapper _mapper;

        public ApplicationServiceUser(IServiceUser serviceUser, IMapper mapper)
        {
            this._serviceUser = serviceUser;
            this._mapper = mapper;
        }
        public void Add(UserRequest userRequest)
        {
            User user = _mapper.Map<User>(userRequest);
            _serviceUser.Add(user);
        }

        public void Delete(Guid id)
        {
            User user = _serviceUser.Get(id);

            if (user == null)
                throw new EntityNotFoundException("Invalid User");

            _serviceUser.Delete(user);
        }

        public User GetUser(string username, string password)
        {
            User? user = _serviceUser.GetUser(username, password);

            if (user == null)
                throw new EntityNotFoundException("Invalid User");

            user.Userpass = String.Empty;

            return user;
        }
    }
}
