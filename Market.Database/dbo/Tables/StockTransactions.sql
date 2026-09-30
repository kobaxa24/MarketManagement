CREATE TABLE StockTransactions
(
    StocktrancationID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL,
    SupplierID INT NOT NULL,
    EmployeeID INT NOT NULL,
    Quantity FLOAT NOT NULL,
    TransactionDate DATETIME NOT NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (EmployeeID) REFERENCES  Employees(EmployeeID)
)