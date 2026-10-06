CREATE PROCEDURE sp_ClearDatabase
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AttributesUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Attributes) THEN 1 ELSE 0 END;

    DECLARE @CategoriesUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Categories) THEN 1 ELSE 0 END;

    DECLARE @CountriesUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Countries) THEN 1 ELSE 0 END;

    DECLARE @CustomersUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Customers) THEN 1 ELSE 0 END;

    DECLARE @CustomerContactsUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM CustomerContacts) THEN 1 ELSE 0 END;

    DECLARE @EmployeeContactsUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM EmployeeContacts) THEN 1 ELSE 0 END;

    DECLARE @EmployeeRolesUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM EmployeeRoles) THEN 1 ELSE 0 END;

    DECLARE @EmployeesUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Employees) THEN 1 ELSE 0 END;

    DECLARE @ProductsUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Products) THEN 1 ELSE 0 END;

    DECLARE @SalesUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Sales) THEN 1 ELSE 0 END;

    DECLARE @SalesItemsUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM SalesItems) THEN 1 ELSE 0 END;

    DECLARE @StockTransactionsUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM StockTransactions) THEN 1 ELSE 0 END;

    DECLARE @SuppliersUsed BIT =
        CASE WHEN EXISTS (SELECT 1 FROM Suppliers) THEN 1 ELSE 0 END;


    DELETE FROM ProductAttributeValues;
    DELETE FROM SalesItems;
    DELETE FROM Sales;
    DELETE FROM StockTransactions;
    DELETE FROM Products;
    DELETE FROM CategoryAttributes;
    DELETE FROM Attributes;
    DELETE FROM UserAccounts;
    DELETE FROM EmployeeContacts;
    DELETE FROM CustomerContacts;
    DELETE FROM Employees;
    DELETE FROM Customers;
    DELETE FROM Categories;
    DELETE FROM EmployeeRoles;
    DELETE FROM Suppliers;
    DELETE FROM Countries;


    IF @AttributesUsed = 1
        DBCC CHECKIDENT ('Attributes', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Attributes', RESEED, 1);

    IF @CategoriesUsed = 1
        DBCC CHECKIDENT ('Categories', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Categories', RESEED, 1);

    IF @CountriesUsed = 1
        DBCC CHECKIDENT ('Countries', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Countries', RESEED, 1);

    IF @CustomersUsed = 1
        DBCC CHECKIDENT ('Customers', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Customers', RESEED, 1);

    IF @CustomerContactsUsed = 1
        DBCC CHECKIDENT ('CustomerContacts', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('CustomerContacts', RESEED, 1);

    IF @EmployeeContactsUsed = 1
        DBCC CHECKIDENT ('EmployeeContacts', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('EmployeeContacts', RESEED, 1);

    IF @EmployeeRolesUsed = 1
        DBCC CHECKIDENT ('EmployeeRoles', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('EmployeeRoles', RESEED, 1);

    IF @EmployeesUsed = 1
        DBCC CHECKIDENT ('Employees', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Employees', RESEED, 1);

    IF @ProductsUsed = 1
        DBCC CHECKIDENT ('Products', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Products', RESEED, 1);

    IF @SalesUsed = 1
        DBCC CHECKIDENT ('Sales', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Sales', RESEED, 1);

    IF @SalesItemsUsed = 1
        DBCC CHECKIDENT ('SalesItems', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('SalesItems', RESEED, 1);

    IF @StockTransactionsUsed = 1
        DBCC CHECKIDENT ('StockTransactions', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('StockTransactions', RESEED, 1);

    IF @SuppliersUsed = 1
        DBCC CHECKIDENT ('Suppliers', RESEED, 0);
    ELSE
        DBCC CHECKIDENT ('Suppliers', RESEED, 1);
END