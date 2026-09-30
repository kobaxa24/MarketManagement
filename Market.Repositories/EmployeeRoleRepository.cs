using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class EmployeeRoleRepository : BaseRepository<EmployeeRole>, IEmployeeRoleRepository
{
    public EmployeeRoleRepository(DbConnection connection) : base(connection) 
    {
    }

}
