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
    public sealed class EmployeeContactsRepository : BaseRepository<EmployeeContact>, IEmployeeContactsRepository
    {
        public EmployeeContactsRepository(DbConnection connection) : base(connection)
        {
        }
    }
}
