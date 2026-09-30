create procedure sp_CustomerContactUpdate
@CustomerContactID int,
@CustomerEmail nvarchar(50),
@CustomerID int,
@ContactType tinyint,
@ContactValue nvarchar(100)
as
begin
set nocount on

if not exists(select 1 from CustomerContacts where CustomerContactID = @CustomerContactID )
begin
	raiserror('Customer contact ID %d does not exist or is inactive.',16,1,@CustomerContactID)
	return 1
end

if not exists(select 1 from Customers where CustomerID = @CustomerID)
begin
	raiserror('Customer ID %d does not exist.',16,1,@CustomerID)
	return 1
end

if @ContactType not in (1,2)
begin
	raiserror('Contact type is invalid.',16,1)
	return 1
end

update CustomerContacts
set CustomerEmail = @CustomerEmail,
	CustomerID = @CustomerID,
	ContactType = @ContactType,
	ContactValue = @ContactValue,
	UpdatedDate = getdate()
where CustomerContactID = @CustomerContactID and(
	CustomerEmail != @CustomerEmail or
	CustomerID != @CustomerID or
	ContactType != @ContactType or
	ContactValue != @ContactValue
)

return 0
end