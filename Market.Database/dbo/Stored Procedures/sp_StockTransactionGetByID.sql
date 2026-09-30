create procedure sp_StockTransactionGetByID
    @StocktrancationID int
as
begin
    set nocount on;

    if not exists(select 1
        from StockTransactions
        where StocktrancationID = @StocktrancationID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @StocktrancationID);
        return -1;
    end

    select StocktrancationID, ProductID, SupplierID, EmployeeID, Quantity, TransactionDate
    from StockTransactions
    where StocktrancationID = @StocktrancationID;

    return 0;
end