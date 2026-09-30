create procedure sp_AttributeDelete
@AttributeID int
as
begin
set nocount on

if not exists (select 1 from Attributes where AttributeID = @AttributeID and IsActive = 1)
begin
	raiserror('Attribute with ID %d does not exist or is inactive.', 16, 1, @AttributeID);
	return 1;
end

update Attributes
set IsActive = 0,
UpdatedDate = getdate()
where AttributeID=@AttributeID

return 0
end