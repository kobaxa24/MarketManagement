CREATE   PROCEDURE sp_UserAccountInsert
    @EmployeeID INT,
    @Username VARCHAR(50),
    @PasswordHash VARBINARY(255)

AS
BEGIN
    SET NOCOUNT ON;

    IF @Username IS NULL OR LTRIM(RTRIM(@Username)) = ''
    BEGIN
        RAISERROR('Username cannot be empty.', 16, 1);
        RETURN 1;
    END

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeID = @EmployeeID AND IsActive = 1)
    BEGIN
        RAISERROR('Employee does not exist.', 16, 1);
        RETURN 1;
    END

    IF EXISTS (SELECT 1 FROM UserAccounts WHERE Username = @Username)
    BEGIN
        RAISERROR('Username already exists.', 16, 1);
        RETURN 1;
    END

    IF EXISTS (SELECT 1 FROM UserAccounts WHERE EmployeeID = @EmployeeID)
    BEGIN
        RAISERROR('This employee already has a user account.', 16, 1);
        RETURN 1;
    END

    INSERT INTO UserAccounts (EmployeeID, Username, PasswordHash)
    VALUES (@EmployeeID, @Username, @PasswordHash);

    RETURN 0;
END