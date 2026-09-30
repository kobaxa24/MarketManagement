CREATE TABLE CategoryAttributes (
    CategoryID INT NOT NULL,
    AttributeID INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (AttributeID) REFERENCES Attributes(AttributeID),
    PRIMARY KEY(CategoryID, AttributeID)
);