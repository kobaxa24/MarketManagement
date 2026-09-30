create procedure sp_AttributeGetByID
    @AttributeID int
as
begin
    set nocount on;

    if not exists(select 1
        from Attributes
        where AttributeID = @AttributeID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @AttributeID);
        return -1;
    end

    select AttributeID, AttributeName, AttributeType, IsActive, CreatedDate, UpdatedDate
    from Attributes
    where AttributeID = @AttributeID

    return 0;
end