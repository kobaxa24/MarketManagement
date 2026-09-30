create procedure sp_UserAccountGetAll
as
begin
    set nocount on;

    select
        EmployeeID,
        Username,
        PasswordHash,
        IsEnabled,
        IsActive,
        CreatedDate,
        UpdatedDate
    from UserAccounts
    where IsActive = 1;

    return 0;
end