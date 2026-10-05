using Dapper;
using Market.DTO;
using Market.Repositories;
using Market.Services.Interfaces.Repositories;
using System.Data.Common;
using System.Data;

public sealed class UserAccountRepository
    : BaseRepository<UserAccount>, IUserAccountRepository
{
    public UserAccountRepository(DbConnection connection)
        : base(connection)
    {
    }

    public override object Insert(UserAccount entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        var parameters = new DynamicParameters();

        parameters.Add(nameof(entity.EmployeeID), entity.EmployeeID);
        parameters.Add(nameof(entity.Username), entity.Username);
        parameters.Add(nameof(entity.PasswordHash), entity.PasswordHash);

        _connection.Execute(
            "sp_UserAccountInsert",
            parameters,
            commandType: CommandType.StoredProcedure);
        return entity.EmployeeID;
    }

    public override UserAccount GetById(object id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        return _connection.QuerySingle<UserAccount>(
            "sp_UserAccountGetById",
            new { EmployeeID = id },
            commandType: CommandType.StoredProcedure);
    }
}