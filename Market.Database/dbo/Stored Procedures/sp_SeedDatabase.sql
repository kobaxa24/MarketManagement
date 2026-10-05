CREATE PROCEDURE sp_SeedDatabase
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Countries
    INSERT INTO Countries (CountryName) VALUES
        ('Georgia'), ('United States'), ('Germany'), ('France'), ('Italy'),
        ('Spain'), ('Japan'), ('Canada'), ('Brazil'), ('Australia');

    -- 2. EmployeeRoles
    INSERT INTO EmployeeRoles (RoleName) VALUES
        ('Manager'), ('Cashier'), ('Stock Clerk'), ('Sales Associate'), ('Accountant'),
        ('HR Specialist'), ('IT Support'), ('Warehouse Supervisor'), ('Customer Service Rep'), ('Store Director');

    -- 3. Attributes
    INSERT INTO Attributes (AttributeName, AttributeType) VALUES
        ('Color', 1), ('Size', 1), ('Weight', 2), ('Material', 1),
        ('Warranty', 3), ('Voltage', 2), ('Capacity', 2), ('Brand', 1),
        ('IsWaterproof', 4), ('Origin', 1);

    -- 4. Customers
    INSERT INTO Customers (FirstName, LastName, CustomerLoyaltyPoints) VALUES
        ('Liam', 'Anderson', 120), ('Ava', 'Thomas', 45), ('Noah', 'Jackson', 0),
        ('Charlotte', 'White', 300), ('Elijah', 'Harris', 75), ('Amelia', 'Clark', 10),
        ('Lucas', 'Lewis', 200), ('Harper', 'Walker', 5), ('Mason', 'Hall', 150),
        ('Evelyn', 'Allen', 60);

    -- 5. Categories
    INSERT INTO Categories (CategoryName, Description, ParentID) VALUES
        ('Electronics', 'Electronic devices and gadgets', NULL),
        ('Groceries', 'Food and household consumables', NULL),
        ('Clothing', 'Apparel for all ages', NULL),
        ('Home and Garden', 'Home improvement and garden supplies', NULL),
        ('Toys', 'Toys and games', NULL),
        ('Sports', 'Sporting goods and equipment', NULL),
        ('Books', 'Books and magazines', NULL),
        ('Beauty', 'Beauty and personal care', NULL),
        ('Automotive', 'Car parts and accessories', NULL),
        ('Office Supplies', 'Office and stationery supplies', NULL);

    -- 6. Suppliers (CountryID 1-10)
    INSERT INTO Suppliers (CountryID, SupplierName) VALUES
        (1, 'Global Foods Ltd'), (2, 'Tech Supply Co'), (3, 'Fresh Produce Inc'),
        (4, 'BuildRight Materials'), (5, 'AutoParts Direct'), (6, 'HomeGoods Wholesale'),
        (7, 'ElectroSource'), (8, 'FarmFresh Distributors'), (9, 'MedSupply Corp'),
        (10, 'FashionForward Textiles');

    -- 7. Employees (EmployeeRoleID 1-10)
    INSERT INTO Employees (EmployeeRoleID, FirstName, LastName) VALUES
        (1, 'John', 'Smith'), (2, 'Emma', 'Johnson'), (3, 'Michael', 'Williams'),
        (4, 'Olivia', 'Brown'), (5, 'James', 'Jones'), (6, 'Sophia', 'Garcia'),
        (7, 'William', 'Miller'), (8, 'Isabella', 'Davis'), (9, 'Benjamin', 'Rodriguez'),
        (10, 'Mia', 'Martinez'),(1, 'Test', 'Employee1'),(1, 'Test', 'Employee2'),(1, 'Test', 'Employee3'),(1, 'Test', 'Employee4');;

    -- 8. Products (CategoryID/SupplierID 1-10)
    INSERT INTO Products (CategoryID, SupplierID, ProductName, Price) VALUES
        (1, 1, 'Wireless Mouse', 19.99), (1, 2, 'Laptop Stand', 29.99),
        (2, 3, 'Organic Coffee Beans', 12.50), (3, 10, 'Cotton T-Shirt', 9.99),
        (4, 4, 'Garden Hose', 24.99), (6, 5, 'Soccer Ball', 15.00),
        (7, 9, 'Mystery Novel', 8.99), (8, 9, 'Face Moisturizer', 14.99),
        (9, 5, 'Car Air Freshener', 3.99), (10, 6, 'Stapler', 4.50);

    -- 9. CategoryAttributes
    INSERT INTO CategoryAttributes (CategoryID, AttributeID) VALUES
        (1, 1),  -- Electronics - Color
        (1, 2),  -- Electronics - Size
        (2, 1),  -- Groceries - Color
        (3, 3),  -- Clothing - Weight
        (3, 4);  -- Clothing - Material

    -- 10. EmployeeContacts
    INSERT INTO EmployeeContacts (EmployeeID, ContactType, ContactValue) VALUES
        (1, 1, '+1-555-0101'), (2, 2, '+1-555-0102'), (3, 1, '+1-555-0103'),
        (4, 2, '+1-555-0104'), (5, 1, '+1-555-0105'), (6, 2, '+1-555-0106'),
        (7, 1, '+1-555-0107'), (8, 2, '+1-555-0108'), (9, 1, '+1-555-0109'),
        (10, 2, '+1-555-0110');

    -- 11. UserAccounts
    INSERT INTO UserAccounts (EmployeeID, Username, PasswordHash) VALUES
        (1, 'jsmith', HASHBYTES('SHA2_256', N'Password1')),
        (2, 'ejohnson', HASHBYTES('SHA2_256', N'Password2')),
        (3, 'mwilliams', HASHBYTES('SHA2_256', N'Password3')),
        (4, 'obrown', HASHBYTES('SHA2_256', N'Password4')),
        (5, 'jjones', HASHBYTES('SHA2_256', N'Password5')),
        (6, 'sgarcia', HASHBYTES('SHA2_256', N'Password6')),
        (7, 'wmiller', HASHBYTES('SHA2_256', N'Password7')),
        (8, 'idavis', HASHBYTES('SHA2_256', N'Password8')),
        (9, 'brodriguez', HASHBYTES('SHA2_256', N'Password9')),
        (10, 'mmartinez', HASHBYTES('SHA2_256', N'Password10'));

    -- 12. CustomerContacts
    INSERT INTO CustomerContacts (CustomerEmail, CustomerID, ContactType, ContactValue) VALUES
        ('liam.anderson@example.com', 1, 1, '+1-555-0201'),
        ('ava.thomas@example.com', 2, 2, '+1-555-0202'),
        ('noah.jackson@example.com', 3, 1, '+1-555-0203'),
        ('charlotte.white@example.com', 4, 2, '+1-555-0204'),
        ('elijah.harris@example.com', 5, 1, '+1-555-0205'),
        ('amelia.clark@example.com', 6, 2, '+1-555-0206'),
        ('lucas.lewis@example.com', 7, 1, '+1-555-0207'),
        ('harper.walker@example.com', 8, 2, '+1-555-0208'),
        ('mason.hall@example.com', 9, 1, '+1-555-0209'),
        ('evelyn.allen@example.com', 10, 2, '+1-555-0210');

    -- 13. ProductAttributeValues
    INSERT INTO ProductAttributeValues
        (ProductID, AttributeID, TextValue, NumberValue, DateValue, BooleanValue)
    VALUES
        (1, 1, 'Black', NULL, NULL, NULL),
        (2, 2, 'Medium', NULL, NULL, NULL),
        (3, 3, NULL, 250, NULL, NULL),
        (4, 4, 'Cotton', NULL, NULL, NULL),
        (5, 5, NULL, NULL, '2028-01-01', NULL),
        (6, 6, NULL, 0, NULL, NULL),
        (7, 10, 'USA', NULL, NULL, NULL),
        (8, 9, NULL, NULL, NULL, 1),
        (9, 8, 'FreshCo', NULL, NULL, NULL),
        (10, 7, NULL, 20, NULL, NULL);

    -- 14. Sales
    INSERT INTO Sales (CustomerID, EmployeeID, SaleDate) VALUES
        (1, 1, '2026-01-05'), (2, 2, '2026-01-20'), (NULL, 3, '2026-02-02'),
        (4, 4, '2026-02-15'), (5, 5, '2026-03-01'), (NULL, 6, '2026-03-18'),
        (7, 7, '2026-04-10'), (8, 8, '2026-05-05'), (9, 9, '2026-06-01'),
        (10, 10, '2026-06-20');

    -- 15. StockTransactions
    INSERT INTO StockTransactions
        (ProductID, SupplierID, EmployeeID, Quantity, TransactionDate)
    VALUES
        (1, 1, 1, 50, '2026-01-01'),
        (2, 2, 2, 30, '2026-01-10'),
        (3, 3, 3, 100, '2026-01-15'),
        (4, 10, 4, 20, '2026-02-01'),
        (5, 4, 5, 15, '2026-02-10'),
        (6, 5, 6, 40, '2026-03-01'),
        (7, 9, 7, 25, '2026-03-15'),
        (8, 9, 8, 60, '2026-04-01'),
        (9, 5, 9, 80, '2026-05-01'),
        (10, 6, 10, 45, '2026-05-15');

    -- 16. SalesItems
    INSERT INTO SalesItems (SaleID, ProductID, Quantity, UnitPrice, Discount) VALUES
        (1, 1, 2, 19.99, 0),
        (2, 2, 1, 29.99, 0),
        (3, 3, 5, 12.50, 1.00),
        (4, 4, 3, 9.99, 0),
        (5, 5, 1, 24.99, 0),
        (6, 6, 2, 15.00, 0),
        (7, 7, 1, 8.99, 0),
        (8, 8, 4, 14.99, 2.00),
        (9, 9, 6, 3.99, 0),
        (10, 10, 10, 4.50, 0.50);

END