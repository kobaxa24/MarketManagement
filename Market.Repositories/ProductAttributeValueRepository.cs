using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class ProductAttributeValueRepository : BaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
{
    public ProductAttributeValueRepository(DbConnection connection) : base(connection) 
    {
    }
}
