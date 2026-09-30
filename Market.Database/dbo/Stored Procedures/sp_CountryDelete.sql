create procedure sp_CountryDelete
@CountryID int
as
begin
set nocount on

if not exists(select 1 from Countries where CountryID = @CountryID and IsActive = 1)
begin
	raiserror('Country ID %d does not exist or is inactive.',16,1,@CountryID)
	return 1;
end

update Countries
set IsActive = 0,
UpdatedDate = getdate()
where CountryID = @CountryID

return 0
end