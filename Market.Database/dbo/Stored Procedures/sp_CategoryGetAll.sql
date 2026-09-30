create procedure sp_CategoryGetAll
as
begin
    set nocount on;

    select
        CategoryID,
        ParentID,
        CategoryName,
        Description,
        IsActive,
        CreatedDate,
        UpdatedDate
    from Categories
    where IsActive = 1;

    return 0;
end