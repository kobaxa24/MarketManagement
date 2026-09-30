create procedure sp_EmployeeInsert
@EmployeeID int output,
@EmployeeRoleID int,
@FirstName nvarchar(20),
@LastName nvarchar(30)

as
begin
set nocount on

if not exists(select 1 from EmployeeRoles where EmployeeRoleID = @EmployeeRoleID and IsActive = 1)
begin
	raiserror('Employee role ID %d does not exist or is inactive.',16,1,@EmployeeRoleID)
	return 1
end

insert into Employees(EmployeeRoleID,FirstName,LastName)
values(@EmployeeRoleID,@FirstName,@LastName)

set @EmployeeID = scope_identity()

return 0
end