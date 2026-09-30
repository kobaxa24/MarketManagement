create procedure sp_EmployeeContactUpdate
@EmployeeContactID int,
@EmployeeID int,
@ContactType tinyint,
@ContactValue nvarchar(100)
as
begin
set nocount on

if not exists(select 1 from EmployeeContacts where EmployeeContactID = @EmployeeContactID and IsActive = 1)
begin
	raiserror('Employee contact ID %d does not exist or is inactive.',16,1,@EmployeeContactID)
	return 1
end

if not exists(select 1 from Employees where EmployeeID = @EmployeeID and IsActive = 1)
begin
	raiserror('Employee ID %d does not exist or is inactive.',16,1,@EmployeeID)
	return 1
end

if @ContactType not in (1,2)
begin
	raiserror('Contact type is invalid.',16,1)
	return 1
end

update EmployeeContacts
set EmployeeID = @EmployeeID,
	ContactType = @ContactType,
	ContactValue = @ContactValue,
	UpdatedDate = getdate()
where EmployeeContactID = @EmployeeContactID and(
	EmployeeID != @EmployeeID or
	ContactType != @ContactType or
	ContactValue != @ContactValue
)

return 0
end