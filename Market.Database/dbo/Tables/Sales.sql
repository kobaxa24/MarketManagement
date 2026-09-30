CREATE TABLE Sales(
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NULL,
    EmployeeID INT NOT NULL,
    SaleDate DATETIME NOT NULL,
    FOREIGN KEY (EmployeeID) REFERENCES  Employees(EmployeeID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)