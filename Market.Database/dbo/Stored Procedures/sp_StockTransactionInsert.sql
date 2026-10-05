CREATE PROCEDURE sp_StockTransactionInsert
    @ProductID INT,
    @SupplierID INT,
    @EmployeeID INT,
    @Quantity FLOAT,
    @StockTransactionID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Products WHERE ProductID = @ProductID AND IsActive = 1)
    BEGIN
        RAISERROR('Product does not exist.', 16, 1);
        RETURN 1;
    END

    IF NOT EXISTS (SELECT 1 FROM Suppliers WHERE SupplierID = @SupplierID AND IsActive = 1)
    BEGIN
        RAISERROR('Supplier does not exist.', 16, 1);
        RETURN 1;
    END

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeID = @EmployeeID AND IsActive = 1)
    BEGIN
        RAISERROR('Employee does not exist.', 16, 1);
        RETURN 1;
    END

    IF @Quantity <= 0
    BEGIN
        RAISERROR('Quantity must be greater than zero.', 16, 1);
        RETURN 1;
    END

    INSERT INTO StockTransactions
        (ProductID, SupplierID, EmployeeID, Quantity, TransactionDate)
    VALUES
        (@ProductID, @SupplierID, @EmployeeID, @Quantity, GETDATE());

    SET @StockTransactionID = SCOPE_IDENTITY();

    RETURN 0;
END