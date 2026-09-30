create procedure sp_CategoryAttributeGetAll
as
begin
    set nocount on;

    select
        CategoryID,
        AttributeID
    from CategoryAttributes;

    return 0;
end