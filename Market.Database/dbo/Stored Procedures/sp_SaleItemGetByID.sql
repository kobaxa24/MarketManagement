create procedure sp_SalesItemGetByID
    @SalesItemID int
as
begin
    set nocount on;

    if not exists(select 1
        from SalesItems
        where SalesItemID = @SalesItemID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @SalesItemID);
        return -1;
    end

    select SalesItemID, SaleID, ProductID, Quantity, UnitPrice, Discount
    from SalesItems
    where SalesItemID = @SalesItemID;

    return 0;
end