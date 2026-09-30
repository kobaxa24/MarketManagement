create procedure sp_AttributeInsert
@AttributeName nvarchar(100) ,
@AttributeType tinyint,
@AttributeID int output
as
begin
set nocount on;
if @AttributeType not in (1,2,3,4)
begin
raiserror('Attribute type is invalid.',16,1)
return 1
end

insert into Attributes(AttributeName,AttributeType)
values(@AttributeName,@AttributeType)

set @AttributeID = scope_identity();

return 0
end