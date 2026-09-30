create procedure sp_ProductGetByID
    @ProductID int
as
begin
    set nocount on;

    if not exists(select 1
        from Products
        where ProductID = @ProductID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @ProductID);
        return -1;
    end

    select ProductID, CategoryID, SupplierID, ProductName, Price, IsActive, CreatedDate, UpdatedDate
    from Products
    where ProductID = @ProductID

    return 0;
end