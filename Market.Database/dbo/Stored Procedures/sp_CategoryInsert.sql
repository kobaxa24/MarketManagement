create procedure sp_CategoryInsert
    @CategoryName nvarchar(100),
    @Description nvarchar(1000) = null,
    @ParentID int = null,
    @CategoryID int output
as
begin
    set nocount on;

    insert into Categories (CategoryName, Description, ParentID)
    values (@CategoryName, @Description, @ParentID);

    set @CategoryID = scope_identity();

    return 0;
end