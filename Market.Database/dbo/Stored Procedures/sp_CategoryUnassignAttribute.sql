create procedure sp_CategoryUnassignAttribute
    @CategoryID INT,
    @AttributeID INT
as
begin
    set nocount on;

    if not exists (select 1 from CategoryAttributes where CategoryID = @CategoryID and AttributeID = @AttributeID)
	begin
		raiserror('Category ID %d does not have Attribute ID %d.',16,1,@CategoryID,@AttributeID)
		return 1
	end

    delete from CategoryAttributes
    where CategoryID = @CategoryID and AttributeID = @AttributeID;

    return 0;
end