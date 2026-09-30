create procedure sp_CountryGetAll
as
begin
    set nocount on;

    select
        CountryID,
        CountryName,
        IsActive,
        CreatedDate,
        UpdatedDate
    from Countries
    where IsActive = 1;

    return 0;
end