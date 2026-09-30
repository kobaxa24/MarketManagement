create procedure sp_ProductAttributeValueGetByID
    @ProductID int,
    @AttributeID int
as
begin
    set nocount on;

    if not exists(select 1
        from ProductAttributeValues
        where ProductID = @ProductID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @ProductID);
        return -1;
    end

    if not exists(select 1
        from ProductAttributeValues
        where AttributeID = @AttributeID
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @AttributeID);
        return -1;
    end

    select ProductID, AttributeID, TextValue, NumberValue, DateValue, BooleanValue
    from ProductAttributeValues
    where ProductID = @ProductID
      and AttributeID = @AttributeID;

    return 0;
end