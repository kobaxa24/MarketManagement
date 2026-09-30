create procedure sp_ProductDelete
@ProductID int
as
begin
set nocount on

if not exists(select 1 from Products where ProductID = @ProductID and IsActive = 1)
begin
	raiserror('Product ID %d does not exist or is inactive.',16,1,@ProductID)
	return 1
end

update Products
set IsActive = 0,
	UpdatedDate = getdate()
where ProductID = @ProductID

return 0
end