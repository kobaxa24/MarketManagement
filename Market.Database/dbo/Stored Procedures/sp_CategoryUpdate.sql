create procedure sp_CategoryUpdate
	@CategoryID int,
	@CategoryName nvarchar(100),
	@Description nvarchar(1000) = null,
	@ParentID int = null
as
begin
	set nocount on;

	if not exists (select 1 from Categories where CategoryID = @CategoryID and IsActive = 1)
	begin
		raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CategoryID);
		return 1; 
	end

	if dbo.fn_DetectCircularReference(@ParentID, @CategoryID) = 1
	begin
		raiserror('Updating ParentID to %d would create a circular reference.', 16, 1, @ParentID);
		return 1; 
	end

	update Categories
	set CategoryName = @CategoryName,
		Description = @Description,
		ParentID = @ParentID,
		UpdatedDate = getdate()
	where CategoryID = @CategoryID and (
		CategoryName != @CategoryName or
		isnull(Description, '') != isnull(@Description, '') or
		isnull(ParentID, -1) != isnull(@ParentID, -1)
	);

	return 0;
end