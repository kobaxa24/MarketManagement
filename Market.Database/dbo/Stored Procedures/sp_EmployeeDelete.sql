create procedure sp_EmployeeDelete
@EmployeeID int
as
begin
set nocount on

if not exists(select 1 from Employees where EmployeeID = @EmployeeID and IsActive = 1)
begin
	raiserror('Employee ID %d does not exist or is inactive.',16,1,@EmployeeID)
	return 1
end

update Employees
set IsActive = 0,
	UpdatedDate = getdate()
where EmployeeID = @EmployeeID

return 0
end