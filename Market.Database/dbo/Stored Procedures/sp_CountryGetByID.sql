create procedure sp_CountryGetByID
    @CountryID int
as
begin
    set nocount on;

    if not exists(select 1
        from Countries
        where CountryID = @CountryID and IsActive = 1
    )
    begin
        raiserror('Category with ID %d does not exist or is inactive.', 16, 1, @CountryID);
        return -1;
    end

    select CountryID, CountryName, IsActive, CreatedDate, UpdatedDate
    from Countries
    where CountryID = @CountryID

    return 0;
end