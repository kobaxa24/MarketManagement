CREATE  PROCEDURE sp_GetProductsByCategory
    @CategoryID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryID = @CategoryID AND IsActive = 1)
    BEGIN
        RAISERROR('Category with ID %d does not exist.', 16, 1, @CategoryID);
        RETURN 1;
    END

    SELECT
        ProductID,
        CategoryID,
        SupplierID,
        ProductName,
        Price,
        IsActive,
        CreatedDate,
        UpdatedDate
    FROM Products
    WHERE CategoryID = @CategoryID
    AND IsActive = 1;

    RETURN 0;
END