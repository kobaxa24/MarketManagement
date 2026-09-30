using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class StockTransactionRepository : BaseRepository<StockTransaction>, IStockTransactionRepository
{
    public StockTransactionRepository(DbConnection connection) : base(connection)
    {
    }
}
