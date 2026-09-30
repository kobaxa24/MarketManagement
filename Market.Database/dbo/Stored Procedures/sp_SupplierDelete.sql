create procedure sp_SupplierDelete
@SupplierID int
as
begin
set nocount on

if not exists(select 1 from Suppliers where SupplierID = @SupplierID and IsActive = 1)
begin
	raiserror('Supplier ID %d does not exist or is inactive.',16,1,@SupplierID)
	return 1
end

update Suppliers
set IsActive = 0,
	UpdatedDate = getdate()
where SupplierID = @SupplierID

return 0
end