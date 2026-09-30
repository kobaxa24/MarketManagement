CREATE TABLE EmployeeRoles (
    EmployeeRoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName Nvarchar(50),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL
)