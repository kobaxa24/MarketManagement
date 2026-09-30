create procedure sp_ProductUpdate
@ProductID int,
@CategoryID int,
@SupplierID int,
@ProductName nvarchar(100),
@Price decimal(18,2)
as
begin
set nocount on

if not exists(select 1 from Products where ProductID = @ProductID and IsActive = 1)
begin
	raiserror('Product ID %d does not exist or is inactive.',16,1,@ProductID)
	return 1
end

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

update Products
set CategoryID = @CategoryID,
	SupplierID = @SupplierID,
	ProductName = @ProductName,
	Price = @Price,
	UpdatedDate = getdate()
where ProductID = @ProductID and (
	CategoryID != @CategoryID or
	SupplierID != @SupplierID or
	ProductName != @ProductName or
	Price != @Price
)

return 0
end