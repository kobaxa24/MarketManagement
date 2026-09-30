create procedure sp_SaleGetAll
as
begin
    set nocount on;

    select
        SaleID,
        CustomerID,
        EmployeeID,
        SaleDate
    from Sales;

    return 0;
end