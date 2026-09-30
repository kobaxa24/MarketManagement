using Dapper;
using Market.DTO;
using System.Data;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class AttributeRepository : BaseRepository<Market.DTO.Attribute>, IAttributeRepository
{
    public AttributeRepository(DbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Market.DTO.Attribute> GetAttributesByCategoryId(int categoryId)
    {
        return _connection.Query<Market.DTO.Attribute>(
            "sp_AttributeGetByCategoryID",
            new { CategoryID = categoryId },
            commandType: CommandType.StoredProcedure);
    }
}
