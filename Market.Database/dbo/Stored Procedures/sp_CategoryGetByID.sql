create procedure sp_CategoryGetByID
    @CategoryID int
as
begin
    set nocount on;

    if not exists(select 1
        from Categories
        where CategoryID = @CategoryID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CategoryID);
        return -1;
    end

    select CategoryID, ParentID, CategoryName, Description, IsActive, CreatedDate, UpdatedDate
    from Categories
    where CategoryID = @CategoryID;

    return 0;
end