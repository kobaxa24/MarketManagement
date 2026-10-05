using System.Data.Common;
using Market.Services.Interfaces.Repositories;

namespace Market.Repositories;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbConnection _connection;
    private DbTransaction? _transaction;

    private readonly Lazy<IAttributeRepository> _attributeRepository;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<ICountryRepository> _countryRepository;
    private readonly Lazy<ICustomerRepository> _customerRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;
    private readonly Lazy<IEmployeeRoleRepository> _employeeRoleRepository;
    private readonly Lazy<IProductAttributeValueRepository> _productAttributeValueRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ISaleItemRepository> _saleItemRepository;
    private readonly Lazy<ISaleRepository> _saleRepository;
    private readonly Lazy<IStockTransactionRepository> _stockTransactionRepository;
    private readonly Lazy<ISupplierRepository> _supplierRepository;
    private readonly Lazy<IUserAccountRepository> _userAccountRepository;
    private readonly Lazy<ICustomerContactRepository> _customerContactRepository;
    private readonly Lazy<IEmployeeContactsRepository> _employeeContactsRepository;

    public UnitOfWork(DbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));

        _attributeRepository = new Lazy<IAttributeRepository>(() => new AttributeRepository(_connection));
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_connection));
        _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(_connection));
        _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_connection));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_connection));
        _employeeRoleRepository = new Lazy<IEmployeeRoleRepository>(() => new EmployeeRoleRepository(_connection));
        _productAttributeValueRepository =
            new Lazy<IProductAttributeValueRepository>(() => new ProductAttributeValueRepository(_connection));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_connection));
        _saleItemRepository = new Lazy<ISaleItemRepository>(() => new SaleItemRepository(_connection));
        _saleRepository = new Lazy<ISaleRepository>(() => new SaleRepository(_connection));
        _stockTransactionRepository =
            new Lazy<IStockTransactionRepository>(() => new StockTransactionRepository(_connection));
        _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(_connection));
        _userAccountRepository = new Lazy<IUserAccountRepository>(() => new UserAccountRepository(_connection));
        _customerContactRepository = new Lazy<ICustomerContactRepository>(() => new CustomerContactRepository(_connection));
        _employeeContactsRepository = new Lazy<IEmployeeContactsRepository>(() => new EmployeeContactsRepository(_connection));

    }

    public IAttributeRepository AttributeRepository => _attributeRepository.Value;
    public ICategoryRepository CategoryRepository => _categoryRepository.Value;
    public ICountryRepository CountryRepository => _countryRepository.Value;
    public ICustomerRepository CustomerRepository => _customerRepository.Value;
    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
    public IEmployeeRoleRepository EmployeeRoleRepository => _employeeRoleRepository.Value;
    public IProductAttributeValueRepository ProductAttributeValueRepository => _productAttributeValueRepository.Value;
    public IProductRepository ProductRepository => _productRepository.Value;
    public ISaleItemRepository SaleItemRepository => _saleItemRepository.Value;
    public ISaleRepository SaleRepository => _saleRepository.Value;
    public IStockTransactionRepository StockTransactionRepository => _stockTransactionRepository.Value;
    public ISupplierRepository SupplierRepository => _supplierRepository.Value;
    public IUserAccountRepository UserAccountRepository => _userAccountRepository.Value;
    public ICustomerContactRepository CustomerContactRepository => _customerContactRepository.Value;
    public IEmployeeContactsRepository EmployeeContactsRepository => _employeeContactsRepository.Value;

    public void BeginTransaction()
    {
        if (_transaction != null)
            throw new InvalidOperationException("A transaction is already in progress.");
        _transaction = _connection.BeginTransaction();
    }

    public void CommitTransaction() => HandleTransaction(() => _transaction?.Commit());

    public void RollbackTransaction() => HandleTransaction(() => _transaction?.Rollback());

    private void HandleTransaction(Action transactionAction)
    {
        if (_transaction == null)
            throw new InvalidOperationException("No transaction in progress.");
        transactionAction();
        _transaction.Dispose();
        _transaction = null;
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
}