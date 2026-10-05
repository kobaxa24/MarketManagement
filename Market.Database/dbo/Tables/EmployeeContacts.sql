CREATE TABLE EmployeeContacts(
    EmployeeContactID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT NOT NULL,
    ContactType TINYINT NOT NULL CHECK(ContactType IN (1,2)), --1. WorkPhoneNumber, 2. HomePhoneNumber
    ContactValue NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
)