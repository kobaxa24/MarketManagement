create procedure sp_CategoryAttributeGetByID
    @CategoryID int,
    @AttributeID int
as
begin
    set nocount on;

    if not exists(select 1
        from CategoryAttributes
        where AttributeID = @AttributeID 
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @AttributeID);
        return -1;
    end

    if not exists(select 1
        from CategoryAttributes
        where CategoryID = @CategoryID 
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CategoryID);
        return -1;
    end

    select CategoryID, AttributeID
    from CategoryAttributes
    where CategoryID = @CategoryID
      and AttributeID = @AttributeID;

    return 0;
end