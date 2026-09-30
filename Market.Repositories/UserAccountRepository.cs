using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class UserAccountRepository : BaseRepository<UserAccount>, IUserAccountRepository
{
    public UserAccountRepository(DbConnection connection) : base(connection)
    {
    }
}
