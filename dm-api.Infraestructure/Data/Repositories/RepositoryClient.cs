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
    public class RepositoryClient : RepositoryBase<Client>, IRepositoryClient
    {
        private readonly SqlContext _context;
        public RepositoryClient(SqlContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
