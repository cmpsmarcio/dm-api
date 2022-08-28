using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Application.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException()
        { 
        }

        public EntityNotFoundException(string message): base(message)
        {

        }

        public EntityNotFoundException(string message, Exception exception): base(message, exception)
        {

        }
    }
}
