CREATE   PROCEDURE sp_SaleInsert
    @CustomerID INT = NULL,
    @EmployeeID INT,
    @SaleID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeID = @EmployeeID AND IsActive = 1)
    BEGIN
        RAISERROR('Employee does not exist.', 16, 1);
        RETURN 1;
    END

    IF @CustomerID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Customers WHERE CustomerID = @CustomerID)
    BEGIN
        RAISERROR('Customer does not exist.', 16, 1);
        RETURN 1;
    END

    INSERT INTO Sales (CustomerID, EmployeeID, SaleDate)
    VALUES (@CustomerID, @EmployeeID, GETDATE());

    SET @SaleID = SCOPE_IDENTITY();

    RETURN 0;
END