using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;
using Dapper;
using System.Data;

namespace Market.Repositories;

public sealed class ProductAttributeValueRepository : BaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
{
    public ProductAttributeValueRepository(DbConnection connection) : base(connection) 
    {
    }
    public override object Insert(ProductAttributeValue entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var parameters = new DynamicParameters();

        parameters.Add(nameof(entity.ProductID), entity.ProductID);
        parameters.Add(nameof(entity.AttributeID), entity.AttributeID);
        parameters.Add(nameof(entity.TextValue), entity.TextValue);
        parameters.Add(nameof(entity.NumberValue), entity.NumberValue);
        parameters.Add(nameof(entity.DateValue), entity.DateValue);
        parameters.Add(nameof(entity.BooleanValue), entity.BooleanValue);

        _connection.Execute(
            "sp_ProductAttributeValueInsert",
            parameters,
            commandType: CommandType.StoredProcedure);

        return entity.ProductID;
    }
    public override ProductAttributeValue GetById(object id)
    {
        var key = ((int ProductID, int AttributeID))id;

        return _connection.QuerySingle<ProductAttributeValue>(
            "sp_ProductAttributeValueGetById",
            new
            {
                key.ProductID,
                key.AttributeID
            },
            commandType: CommandType.StoredProcedure);
    }
}
