create procedure sp_StockTransactionGetAll
as
begin
    set nocount on;

    select
        StocktrancationID,
        ProductID,
        SupplierID,
        EmployeeID,
        Quantity,
        TransactionDate
    from StockTransactions;

    return 0;
end