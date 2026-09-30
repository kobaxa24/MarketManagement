create procedure sp_SupplierGetByID
    @SupplierID int
as
begin
    set nocount on;

    if not exists(select 1
        from Suppliers
        where SupplierID = @SupplierID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @SupplierID);
        return -1;
    end

    select SupplierID, CountryID, SupplierName, IsActive, CreatedDate, UpdatedDate
    from Suppliers
    where SupplierID = @SupplierID

    return 0;
end