create procedure sp_AttributeUpdate
@AttributeID int,
@AttributeName nvarchar(100),
@AttributeType tinyint
as
begin
set nocount on

if not exists (select 1 from Attributes where AttributeID = @AttributeID and IsActive = 1)
begin
	raiserror('Attribute with ID %d does not exist or is inactive.', 16, 1, @AttributeID);
	return 1; 
end
if @AttributeType not in (1,2,3,4)
begin
	raiserror('Attribute type is invalid.',16,1)
	return 1
end

update Attributes
set AttributeName = @AttributeName,
AttributeType = @AttributeType,
UpdatedDate = getdate()
where AttributeID = @AttributeID and(
AttributeName != @AttributeName or
AttributeType != @AttributeType
 )

return 0
end