create procedure sp_EmployeeRoleGetByID
    @EmployeeRoleID int
as
begin
    set nocount on;

    if not exists(select 1
        from EmployeeRoles
        where EmployeeRoleID = @EmployeeRoleID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @EmployeeRoleID);
        return -1;
    end

    select EmployeeRoleID, RoleName, IsActive, CreatedDate, UpdatedDate
    from EmployeeRoles
    where EmployeeRoleID = @EmployeeRoleID

    return 0;
end