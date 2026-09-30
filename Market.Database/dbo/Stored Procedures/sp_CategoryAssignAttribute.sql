create procedure sp_CategoryAssignAttribute
    @CategoryID INT,
    @AttributeID INT
as
begin
    set nocount on;

    if not exists (select 1 from Categories where CategoryID = @CategoryID and IsActive = 1)
    begin
        raiserror('Category does not exist.', 16, 1);
        return 1;
    end

    if not exists (select 1 from Attributes where AttributeID = @AttributeID and IsActive = 1)
    begin
        raiserror('Attribute does not exist.', 16, 1);
        return 1;
    end

    if exists (select 1 from CategoryAttributes where CategoryID = @CategoryID and AttributeID = @AttributeID)
    begin
        raiserror('This attribute is already linked to this category.', 16, 1);
        return 1;
    end

    insert into CategoryAttributes (CategoryID, AttributeID)
    values (@CategoryID, @AttributeID);

    return 0;
end