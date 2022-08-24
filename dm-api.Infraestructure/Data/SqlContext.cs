using dm_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dm_api.Infrastructure.Data
{
    public class SqlContext: DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options): base(options)
        {

        }

        DbSet<Client> Clients { get; set; }
    }
}