create procedure sp_CountryInsert
    @CountryID int output,
    @CountryName nvarchar(50)
as
begin
    set nocount on;

    insert into Countries(CountryName)
    values(@CountryName);

    set @CountryID = scope_identity();

    return 0;
end