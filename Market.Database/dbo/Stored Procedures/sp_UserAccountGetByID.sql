create procedure sp_UserAccountGetByID
    @EmployeeID int
as
begin
    set nocount on;

    if not exists(select 1
        from UserAccounts
        where EmployeeID = @EmployeeID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @EmployeeID);
        return -1;
    end

    select EmployeeID, Username, PasswordHash, IsEnabled, IsActive, CreatedDate, UpdatedDate
    from UserAccounts
    where EmployeeID = @EmployeeID

    return 0;
end