create procedure sp_ProductInsert
@ProductID int output,
@CategoryID int,
@SupplierID int,
@ProductName nvarchar(100),
@Price decimal(18,2)
as
begin
set nocount on

if not exists(select 1 from Categories where CategoryID = @CategoryID and IsActive = 1)
begin
	raiserror('Category ID %d does not exist or is inactive.',16,1,@CategoryID)
	return 1
end

if not exists(select 1 from Suppliers where SupplierID = @SupplierID and IsActive = 1)
begin
	raiserror('Supplier ID %d does not exist or is inactive.',16,1,@SupplierID)
	return 1
end

if @Price < 0
begin
	raiserror('Price can not be negative',16,1)
	return 1
end

insert into Products(CategoryID,SupplierID,ProductName,Price)
values(@CategoryID,@SupplierID,@ProductName,@Price)

set @ProductID = scope_identity()

return 0
end