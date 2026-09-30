CREATE TABLE Suppliers
(
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    CountryID INT NOT NULL,
    SupplierName NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    FOREIGN KEY (CountryID) references  Countries(CountryID)
);