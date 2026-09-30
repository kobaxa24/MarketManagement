create procedure sp_ProductAttributeValueGetAll
as
begin
    set nocount on;

    select
        ProductID,
        AttributeID,
        TextValue,
        NumberValue,
        DateValue,
        BooleanValue
    from ProductAttributeValues;

    return 0;
end