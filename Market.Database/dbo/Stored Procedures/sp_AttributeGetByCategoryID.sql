create procedure sp_AttributeGetByCategoryID
	@CategoryID int
as
begin
	set nocount on

	if not exists (select 1 from Categories where CategoryID = @CategoryID and IsActive = 1)
	begin
		raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CategoryID);
		return 1;
	end

	select a.AttributeID, a.AttributeName, a.AttributeType, a.IsActive, a.CreatedDate, a.UpdatedDate
	from CategoryAttributes as ca
	join Attributes as a on a.AttributeID = ca.AttributeID
	where ca.CategoryID = @CategoryID and a.IsActive = 1

	return 0
end