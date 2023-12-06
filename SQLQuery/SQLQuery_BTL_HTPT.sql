USE master
GO

CREATE DATABASE EmployeeManagement
GO

USE EmployeeManagement
GO

CREATE TABLE Employee(
	EmployeeID INT,
	FullName NVARCHAR(100) NOT NULL,
	PhoneNo CHAR(15) UNIQUE NOT NULL,
	Birthday DATE NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	CONSTRAINT PK_Employee PRIMARY KEY (EmployeeID)
)
GO

CREATE PROCEDURE SP_DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employee
    WHERE EmployeeID = @EmployeeID;
END
GO

