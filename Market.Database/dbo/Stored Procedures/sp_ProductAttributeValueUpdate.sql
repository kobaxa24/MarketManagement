create procedure sp_ProductAttributeValueUpdate
@ProductID int,
@AttributeID int,
@TextValue nvarchar(500) = null,
@NumberValue decimal(18,2) = null,
@DateValue datetime = null,
@BooleanValue bit = null
as
begin
set nocount on

if not exists(select 1 from Products where ProductID = @ProductID and IsActive = 1)
begin
	raiserror('Product ID %d does not exist or is inactive.',16,1,@ProductID)
	return 1
end

if not exists(select 1 from Attributes where AttributeID = @AttributeID and IsActive = 1)
begin
	raiserror('Attribute ID %d does not exist or is inactive.',16,1,@AttributeID)
	return 1
end

if not exists(select 1 from ProductAttributeValues where ProductID = @ProductID and AttributeID = @AttributeID)
begin
	raiserror('Product ID %d does not have Attribute ID %d.',16,1,@ProductID,@AttributeID)
	return 1
end

update ProductAttributeValues
set TextValue = @TextValue,
	NumberValue = @NumberValue,
	DateValue = @DateValue,
	BooleanValue = @BooleanValue
where ProductID = @ProductID and AttributeID = @AttributeID and(
	isnull(TextValue, '') != isnull(@TextValue, '') or
	isnull(NumberValue, -1) != isnull(@NumberValue, -1) or
	isnull(DateValue, '1900-01-01') != isnull(@DateValue, '1900-01-01') or 
	isnull(BooleanValue, 2) != isnull(@BooleanValue, 2)	
)

return 0
end