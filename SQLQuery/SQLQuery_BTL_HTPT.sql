USE master
GO

CREATE DATABASE EmployeeManagement
GO

USE EmployeeManagement
GO

CREATE TABLE Employee(
	EmployeeID INT,
	FullName NVARCHAR(100) NOT NULL,
	PhoneNo CHAR(15) UNIQUE NOT NULL CHECK (PhoneNumber LIKE '[0-9]%' AND LEN(PhoneNumber) BETWEEN 10 AND 15),
	Birthday DATE NOT NULL CHECK (Birthday >= '1900-01-01' AND Birthday <= GETDATE()),
	Salary DECIMAL(10, 2) NOT NULL CHECK (Salary > 0),
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

CREATE PROCEDURE SP_UpdateEmployee
    @EmployeeID INT
    @FullName NVARCHAR(100),
    @PhoneNo CHAR(15),
    @Birthday DATE,
    @Salary DECIMAL(10, 2),
AS
BEGIN
    UPDATE Employee
    SET
	FullName = CASE WHEN @FullName IS NOT NULL THEN @FullName ELSE FullName END,
	PhoneNo = CASE WHEN @PhoneNo IS NOT NULL THEN @PhoneNo ELSE PhoneNo END,
	Birthday = CASE WHEN @Birthday IS NOT NULL THEN @Birthday ELSE Birthday END,
	Salary = CASE WHEN @Salary IS NOT NULL THEN @Salary ELSE Salary END,
    WHERE EmployeeID = @EmployeeID;
END
GO

