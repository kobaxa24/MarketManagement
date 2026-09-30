create procedure sp_EmployeeRoleInsert
@EmployeeRoleID int output,
@RoleName nvarchar(50)
as
begin
set nocount on

insert into EmployeeRoles(RoleName)
values(@RoleName)

set @EmployeeRoleID = scope_identity()

return 0
end