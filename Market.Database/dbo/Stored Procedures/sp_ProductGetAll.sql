create procedure sp_ProductGetAll
as
begin
    set nocount on;

    select
        ProductID,
        CategoryID,
        SupplierID,
        ProductName,
        Price,
        IsActive,
        CreatedDate,
        UpdatedDate
    from Products
    where IsActive = 1;

    return 0;
end