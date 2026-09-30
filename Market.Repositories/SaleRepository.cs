using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    public SaleRepository(DbConnection connection) : base(connection)
    {
    }

}
