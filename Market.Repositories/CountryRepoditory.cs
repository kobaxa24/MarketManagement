using Market.DTO;
using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class CountryRepository : BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(DbConnection connection) : base(connection)
    {

    }
}
