CREATE PROCEDURE sp_ClearDatabase
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ProductAttributeValues
    DELETE FROM SalesItems
    DELETE FROM Sales
    DELETE FROM StockTransactions
    DELETE FROM Products
    DELETE FROM CategoryAttributes
    DELETE FROM Attributes
    DELETE FROM UserAccounts
    DELETE FROM EmployeeContacts
    DELETE FROM CustomerContacts
    DELETE FROM Employees
    DELETE FROM Customers
    DELETE FROM Categories
    DELETE FROM EmployeeRoles
    DELETE FROM Suppliers
    DELETE FROM Countries

    DBCC CHECKIDENT ('Attributes', RESEED, 0)
    DBCC CHECKIDENT ('Categories', RESEED, 0)
    DBCC CHECKIDENT ('Countries', RESEED, 0)
    DBCC CHECKIDENT ('Customers', RESEED, 0)
    DBCC CHECKIDENT ('CustomerContacts', RESEED, 0)
    DBCC CHECKIDENT ('EmployeeContacts', RESEED, 0)
    DBCC CHECKIDENT ('EmployeeRoles', RESEED, 0)
    DBCC CHECKIDENT ('Employees', RESEED, 0)
    DBCC CHECKIDENT ('Products', RESEED, 0)
    DBCC CHECKIDENT ('Sales', RESEED, 0)
    DBCC CHECKIDENT ('SalesItems', RESEED, 0)
    DBCC CHECKIDENT ('StockTransactions', RESEED, 0)
    DBCC CHECKIDENT ('Suppliers', RESEED, 0)
END