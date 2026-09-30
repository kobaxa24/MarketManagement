create procedure sp_AttributeGetAll
as
begin
    set nocount on;

    select
        AttributeID,
        AttributeName,
        AttributeType,
        IsActive,
        CreatedDate,
        UpdatedDate
    from Attributes
    where IsActive = 1;

    return 0;
end