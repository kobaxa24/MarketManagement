namespace Market.Services.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IAttributeRepository AttributeRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICountryRepository CountryRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IEmployeeRoleRepository EmployeeRoleRepository { get; }
    IProductAttributeValueRepository ProductAttributeValueRepository { get; }
    IProductRepository ProductRepository { get; }
    ISaleItemRepository SaleItemRepository { get; }
    ISaleRepository SaleRepository { get; }
    IStockTransactionRepository StockTransactionRepository { get; }
    ISupplierRepository SupplierRepository { get; }
    IUserAccountRepository UserAccountRepository { get; }
    ICustomerContactRepository CustomerContactRepository { get; }
    IEmployeeContactsRepository EmployeeContactsRepository { get; }

}
