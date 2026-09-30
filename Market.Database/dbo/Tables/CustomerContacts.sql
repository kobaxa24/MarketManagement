CREATE TABLE CustomerContacts(
    CustomerContactID INT PRIMARY KEY IDENTITY(1,1),
    CustomerEmail NVARCHAR(50) NOT NULL,
    CustomerID INT NOT NULL,
    ContactType TINYINT NOT NULL, --1. WorkPhoneNumber, 2. HomePhoneNumber
    ContactValue NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)