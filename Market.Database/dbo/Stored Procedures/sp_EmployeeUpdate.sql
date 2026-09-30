create procedure sp_EmployeeUpdate
@EmployeeID int,
@EmployeeRoleID int,
@FirstName nvarchar(20),
@LastName nvarchar(30)
as
begin
set nocount on

if not exists(select 1 from Employees where EmployeeID = @EmployeeID and IsActive = 1)
begin
	raiserror('Employee ID %d does not exist or is inactive.',16,1,@EmployeeID)
	return 1
end

if not exists(select 1 from EmployeeRoles where EmployeeRoleID = @EmployeeRoleID and IsActive = 1)
begin
	raiserror('Employee role ID %d does not exist or is inactive.',16,1,@EmployeeRoleID)
	return 1
end

update Employees
set EmployeeRoleID = @EmployeeRoleID,
	FirstName = @FirstName,
	LastName = @LastName,
	UpdatedDate = getdate()
where EmployeeID = @EmployeeID and(
	EmployeeRoleID != @EmployeeRoleID or
	FirstName != @FirstName or
	LastName != @LastName 
)

return 0
end