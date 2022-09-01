using dm_api.Application.Dtos;
using dm_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        void Add(UserRequest userRequest);
        void Delete(Guid id);
        User GetUser(string username, string password);
    }
}
