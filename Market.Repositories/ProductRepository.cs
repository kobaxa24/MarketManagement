using Dapper;
using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Product> GetProductsByCategory(int CategoryID) 
    {
        var parameters = new DynamicParameters();
        parameters.Add("CategoryID", CategoryID);

        return _connection.Query<Product>(
            "sp_GetProductsByCategory",
            parameters,
            commandType: System.Data.CommandType.StoredProcedure);

    }
}
