create procedure sp_EmployeeRoleGetAll
as
begin
    set nocount on;

    select
        EmployeeRoleID,
        RoleName,
        IsActive,
        CreatedDate,
        UpdatedDate
    from EmployeeRoles
    where IsActive = 1;

    return 0;
end