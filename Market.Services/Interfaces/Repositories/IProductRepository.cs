using Market.DTO;

namespace Market.Services.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    IEnumerable<Product> GetProductsByCategory(int CategoryID);
}
