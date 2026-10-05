create procedure sp_SalesItemGetAll
as
begin
    set nocount on;

    select
        SalesItemID,
        SaleID,
        ProductID,
        Quantity,
        UnitPrice,
        Discount
    from SalesItems;

    return 0;
end