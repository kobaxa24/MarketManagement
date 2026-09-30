create procedure sp_EmployeeContactInsert
@EmployeeContactID int output,
@EmployeeID int,
@ContactType tinyint,
@ContactValue nvarchar(100)
as
begin
set nocount on

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

insert into EmployeeContacts(EmployeeID,ContactType,ContactValue)
values(@EmployeeID,@ContactType,@ContactValue)

set @EmployeeContactID = scope_identity()

return 0
end