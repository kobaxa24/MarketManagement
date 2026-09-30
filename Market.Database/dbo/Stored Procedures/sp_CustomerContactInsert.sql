create procedure sp_CustomerContactInsert
@CustomerContactID int output,
@CustomerEmail nvarchar(50),
@CustomerID int,
@ContactType tinyint,
@ContactValue nvarchar(100)
as
begin
set nocount on

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

insert into CustomerContacts(CustomerEmail,CustomerID,ContactType,ContactValue)
values(@CustomerEmail,@CustomerID,@ContactType,@ContactValue)

set @CustomerContactID = scope_identity()

return 0
end