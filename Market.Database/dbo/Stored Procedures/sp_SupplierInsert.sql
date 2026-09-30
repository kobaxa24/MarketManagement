create procedure sp_SupplierInsert
@SupplierID int output,
@CountryID int,
@SupplierName nvarchar(100)
as
begin
set nocount on

if not exists(select 1 from Countries where CountryID = @CountryID and IsActive = 1)
begin
	raiserror('Country ID %d does not exist or is inactive.',16,1,@CountryID)
	return 1
end

insert into Suppliers(CountryID,SupplierName)
values(@CountryID,@SupplierName)

set @SupplierID = scope_identity()

return 0
end