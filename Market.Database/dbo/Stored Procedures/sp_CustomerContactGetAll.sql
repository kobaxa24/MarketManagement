create procedure sp_CustomerContactGetAll
as
begin
    set nocount on;

    select
        CustomerContactID,
        CustomerEmail,
        CustomerID,
        ContactType,
        ContactValue,
        IsActive,
        CreatedDate,
        UpdatedDate
    from CustomerContacts;

    return 0;
end