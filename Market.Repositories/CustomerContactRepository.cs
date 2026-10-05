using Market.DTO;
using Market.Services.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Repositories
{
    public sealed class CustomerContactRepository : BaseRepository<CustomerContact>, ICustomerContactRepository
    {
        public CustomerContactRepository(DbConnection connection) : base(connection)
        {
        }
    }
}
