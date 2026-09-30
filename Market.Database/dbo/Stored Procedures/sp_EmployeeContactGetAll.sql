create procedure sp_EmployeeContactGetAll
as
begin
    set nocount on;

    select
        EmployeeContactID,
        EmployeeID,
        ContactType,
        ContactValue,
        IsActive,
        CreatedDate,
        UpdatedDate
    from EmployeeContacts
    where IsActive = 1;

    return 0;
end