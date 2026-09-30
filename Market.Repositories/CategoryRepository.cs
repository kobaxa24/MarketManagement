using Dapper;
using Market.DTO;
using System.Data;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DbConnection connection) : base(connection)
    {

    }

    public void AssignAttribute(int categoryId, int attributeId)
    {
        _connection.Execute(
            "sp_CategoryAssignAttribute",
            new { CategoryID = categoryId, AttributeID = attributeId },
            commandType: CommandType.StoredProcedure);
    }

    public void UnassignAttribute(int categoryId, int attributeId)
    {
        _connection.Execute(
            "sp_CategoryUnassignAttribute",
            new { CategoryID = categoryId, AttributeID = attributeId },
            commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Category> GetCategoriesByAttributeId(int attributeId)
    {
        return _connection.Query<Category>(
            "sp_CategoryGetByAttributeID",
            new { AttributeID = attributeId },
            commandType: CommandType.StoredProcedure);
    }
}