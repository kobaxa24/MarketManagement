create procedure sp_CustomerGetByID
    @CustomerID int
as
begin
    set nocount on;

    if not exists(select 1
        from Customers
        where CustomerID = @CustomerID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CustomerID);
        return -1;
    end

    select CustomerID, FirstName, LastName, CustomerLoyaltyPoints, CreatedDate, UpdatedDate
    from Customers
    where CustomerID = @CustomerID;

    return 0;
end