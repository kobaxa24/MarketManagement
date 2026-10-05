create procedure sp_SalesItemInsert
    @SalesItemID int output,
    @SaleID int,
    @ProductID int,
    @Quantity float,
    @UnitPrice money,
    @Discount float = 0
as
begin
    set nocount on

    if not exists(select 1 from Sales where SaleID = @SaleID)
    begin
        raiserror('Sale ID %d does not exist.', 16, 1, @SaleID)
        return 1
    end

    if not exists(select 1 from Products where ProductID = @ProductID and IsActive = 1)
    begin
        raiserror('Product ID %d does not exist or is inactive.', 16, 1, @ProductID)
        return 1
    end

    if @Quantity <= 0
    begin
        raiserror('Quantity must be greater than 0.', 16, 1)
        return 1
    end

    if @UnitPrice < 0
    begin
        raiserror('Unit price cannot be negative.', 16, 1)
        return 1
    end

    if @Discount < 0
    begin
        raiserror('Discount cannot be negative.', 16, 1)
        return 1
    end

    insert into SalesItems(SaleID, ProductID, Quantity, UnitPrice, Discount)
    values(@SaleID, @ProductID, @Quantity, @UnitPrice, @Discount)

    set @SalesItemID = scope_identity()

    return 0
end