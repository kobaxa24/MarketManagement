CREATE  PROCEDURE sp_EnableDisableUser
    @EmployeeID INT,
    @IsEnabled BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM UserAccounts WHERE EmployeeID = @EmployeeID AND IsActive = 1)
    BEGIN
        RAISERROR('User account does not exist.', 16, 1);
        RETURN 1;
    END

    UPDATE UserAccounts
    SET
        IsEnabled = @IsEnabled,
        UpdatedDate = GETDATE()
    WHERE EmployeeID = @EmployeeID;

    RETURN 0;
END