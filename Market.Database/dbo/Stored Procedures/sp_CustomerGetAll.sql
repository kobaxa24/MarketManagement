create procedure sp_CustomerGetAll
as
begin
    set nocount on;

    select
        CustomerID,
        FirstName,
        LastName,
        CustomerLoyaltyPoints,
        CreatedDate,
        UpdatedDate
    from Customers;

    return 0;
end