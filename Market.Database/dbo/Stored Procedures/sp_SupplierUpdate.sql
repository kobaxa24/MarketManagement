create procedure sp_SupplierUpdate
@SupplierID int,
@CountryID int,
@SupplierName nvarchar(100)
as
begin
set nocount on

if not exists(select 1 from Suppliers where SupplierID = @SupplierID and IsActive = 1)
begin
	raiserror('Supplier ID %d does not exist or is inactive.',16,1,@SupplierID)
	return 1
end

if not exists(select 1 from Countries where CountryID = @CountryID and IsActive = 1)
begin
	raiserror('Country ID %d does not exist or is inactive.',16,1,@CountryID)
	return 1
end

update Suppliers
set CountryID = @CountryID,
	SupplierName = @SupplierName,
	UpdatedDate = getdate()
where SupplierID = @SupplierID and(
 CountryID != @CountryID or
 SupplierName != @SupplierName
)

return 0
end