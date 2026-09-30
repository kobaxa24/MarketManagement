CREATE TABLE ProductAttributeValues (
    ProductID INT NOT NULL,
    AttributeID INT NOT NULL,
    TextValue NVARCHAR(500) NULL,
    NumberValue DECIMAL(18,2) NULL,
    DateValue DATETIME NULL,
    BooleanValue BIT NULL,
    FOREIGN KEY(AttributeID) REFERENCES Attributes(AttributeID),
    FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
    PRIMARY KEY(ProductID, AttributeID)
);