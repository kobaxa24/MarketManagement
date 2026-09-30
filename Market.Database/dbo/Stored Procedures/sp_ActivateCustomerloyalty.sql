create procedure sp_ActivateCustomerloyalty
@CustomerContactID int
as
begin
set nocount on

if not exists(select 1 from CustomerContacts where CustomerContactID = @CustomerContactID)
begin
	raiserror('Employee contact ID %d does not exist or is inactive.',16,1,@CustomerContactID)
	return 1
end

update CustomerContacts
set IsActive = 1,
	UpdatedDate = getdate()
where CustomerContactID = @CustomerContactID

return 0
end