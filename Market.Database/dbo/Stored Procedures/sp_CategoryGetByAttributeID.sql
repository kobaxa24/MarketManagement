create procedure sp_CategoryGetByAttributeID
	@AttributeID int
as
begin
	set nocount on

	if not exists (select 1 from Attributes where AttributeID = @AttributeID and IsActive = 1)
	begin
		raiserror('Attribute with ID %d does not exist or is inactive.', 16, 1, @AttributeID);
		return 1;
	end

	select c.CategoryID, c.ParentID, c.CategoryName, c.Description, c.IsActive, c.CreatedDate, c.UpdatedDate
	from CategoryAttributes as ca
	join Categories as c on c.CategoryID = ca.CategoryID
	where ca.AttributeID = @AttributeID and c.IsActive = 1

	return 0
end