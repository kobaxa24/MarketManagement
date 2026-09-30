create procedure sp_SaleGetByID
    @SaleID int
as
begin
    set nocount on;

    if not exists(select 1
        from Sales
        where SaleID = @SaleID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @SaleID);
        return -1;
    end

    select SaleID, CustomerID, EmployeeID, SaleDate
    from Sales
    where SaleID = @SaleID;

    return 0;
end