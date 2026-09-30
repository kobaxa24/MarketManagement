create procedure sp_CustomerContactGetByID
    @CustomerContactID int
as
begin
    set nocount on;

    if not exists(select 1
        from CustomerContacts
        where CustomerContactID = @CustomerContactID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CustomerContactID);
        return -1;
    end

    select CustomerContactID, CustomerEmail, CustomerID, ContactType, ContactValue, IsActive, CreatedDate, UpdatedDate
    from CustomerContacts
    where CustomerContactID = @CustomerContactID;

    return 0;
end