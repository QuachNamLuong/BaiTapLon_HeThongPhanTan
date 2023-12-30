-- Make sure you are using database master
USE master
GO

-- Create database
CREATE DATABASE ProductManagementDB
GO

-- Switch to database ProductManagementDB
USE ProductManagementDB
GO

-- Create table Product
CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(200) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    ManufactureDate DATE NOT NULL,
    IsAvailable BIT NOt NULL
);
GO

-- Create store procedure for insert a record to table Product
CREATE PROCEDURE InsertProduct
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10, 2),
    @ManufactureDate DATE,
    @IsAvailable BIT
AS
BEGIN
    INSERT INTO Product (ProductName, Price, ManufactureDate, IsAvailable)
    VALUES (@ProductName, @Price, @ManufactureDate, @IsAvailable);
END;
GO

-- Create store procedure for update a record to table Product
CREATE PROCEDURE UpdateProduct
    @ProductID INT,
    @ProductName NVARCHAR(100),
    @Price DECIMAL(10, 2),
    @ManufactureDate DATE,
    @IsAvailable BIT
AS
BEGIN
    UPDATE Product
    SET ProductName = @ProductName,
        Price = @Price,
        ManufactureDate = @ManufactureDate,
        IsAvailable = @IsAvailable
    WHERE ProductID = @ProductID;
END;
GO

-- Create store procedure for delete a record to table Product
CREATE PROCEDURE DeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Product
    WHERE ProductID = @ProductID;
END;
GO
