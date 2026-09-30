using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
{
    public SupplierRepository(DbConnection connection) : base(connection) 
    { }
}
