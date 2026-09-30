create procedure sp_CountryUpdate
@CountryID int,
@CountryName nvarchar(50)
as
begin
set nocount on

if not exists(select 1 from Countries where CountryID = @CountryID and IsActive = 1)
begin
	raiserror('Country ID %d does not exist or is inactive.',16,1,@CountryID)
	return 1;
end

update Countries
set CountryName = @CountryName,
UpdatedDate = getdate()
where CountryID = @CountryID and(
	CountryName != @CountryName
)

return 0
end