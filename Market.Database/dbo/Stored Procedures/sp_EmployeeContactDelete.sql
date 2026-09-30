create procedure sp_EmployeeContactDelete
@EmployeeContactID int
as
begin
set nocount on

if not exists(select 1 from EmployeeContacts where EmployeeContactID = @EmployeeContactID and IsActive = 1)
begin
	raiserror('Employee contact ID %d does not exist or is inactive.',16,1,@EmployeeContactID)
	return 1
end

update EmployeeContacts
set IsActive = 0,
	UpdatedDate = getdate()
where EmployeeContactID = @EmployeeContactID

return 0
end