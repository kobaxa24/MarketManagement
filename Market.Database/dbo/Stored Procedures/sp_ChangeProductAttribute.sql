create procedure sp_ChangeProductAttribute
@ProductID int,
@OldAttributeID int,
@NewAttributeID int
as
begin
set nocount on

if not exists(select 1 from Products where ProductID = @ProductID and IsActive = 1)
begin
	raiserror('Product ID %d does not exist or is inactive.',16,1,@ProductID)
	return 1
end

if not exists(select 1 from Attributes where AttributeID = @OldAttributeID and IsActive = 1)
begin
	raiserror('Old Attribute ID %d does not exist or is inactive.',16,1,@OldAttributeID)
	return 1
end

if not exists(select 1 from Attributes where AttributeID = @NewAttributeID and IsActive = 1)
begin
	raiserror('New Attribute ID %d does not exist or is inactive.',16,1,@NewAttributeID)
	return 1
end

if not exists(select 1 from ProductAttributeValues where ProductID = @ProductID and AttributeID = @OldAttributeID)
begin
	raiserror('Product ID %d does not have Attribute ID %d.',16,1,@ProductID,@OldAttributeID)
	return 1
end

if exists(select 1 from ProductAttributeValues where ProductID = @ProductID and AttributeID = @NewAttributeID)
begin
	raiserror('Product ID %d already has Attribute ID %d.',16,1,@ProductID,@NewAttributeID)
	return 1
end

update ProductAttributeValues
set AttributeID = @NewAttributeID
where ProductID = @ProductID and AttributeID = @OldAttributeID

return 0
end