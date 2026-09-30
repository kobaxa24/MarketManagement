create procedure sp_EmployeeContactGetByID
    @EmployeeContactID int
as
begin
    set nocount on;

    if not exists(select 1
        from EmployeeContacts
        where EmployeeContactID = @EmployeeContactID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @EmployeeContactID);
        return -1;
    end

    select EmployeeContactID, EmployeeID, ContactType, ContactValue, IsActive, CreatedDate, UpdatedDate
    from EmployeeContacts
    where EmployeeContactID = @EmployeeContactID

    return 0;
end