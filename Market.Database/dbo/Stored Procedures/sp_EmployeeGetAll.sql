create procedure sp_EmployeeGetAll
as
begin
    set nocount on;

    select
        EmployeeID,
        EmployeeRoleID,
        FirstName,
        LastName,
        IsActive,
        CreatedDate,
        UpdatedDate
    from Employees
    where IsActive = 1;

    return 0;
end