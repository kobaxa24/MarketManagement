CREATE TABLE Employees(
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeRoleID INT NOT NULL,
    FirstName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    FOREIGN KEY (EmployeeRoleID) REFERENCES EmployeeRoles(EmployeeRoleID)
)