create procedure sp_EmployeeRoleDelete
@EmployeeRoleID int
as
begin
set nocount on

if not exists(select 1 from EmployeeRoles where EmployeeRoleID = @EmployeeRoleID and IsActive = 1)
begin
	raiserror('Employee role ID %d does not exist or is inactive.',16,1,@EmployeeRoleID)
	return 1
end

update EmployeeRoles
set IsActive = 0,
	UpdatedDate = getdate()
where EmployeeRoleID = @EmployeeRoleID

return 0
end