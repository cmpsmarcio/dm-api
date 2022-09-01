using dm_api.Domain.Core.Interfaces.Repositories;
using dm_api.Domain.Entities;
using dm_api.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Infraestructure.Data.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly SqlContext context;

        public RepositoryUser(SqlContext context) 
            : base(context)
        {
            this.context = context;
        }
  
        public void Delete(User entity)
        {
            entity.DeletedAt = DateTime.Now;
            Update(entity);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User? GetUser(string username, string password)
        {
            return context
                .Set<User>()
                .Where(x => x.Username == username && x.Userpass == password)
                .FirstOrDefault();
        }
    }
}
