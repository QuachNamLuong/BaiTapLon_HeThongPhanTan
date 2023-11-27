USE master
GO

CREATE DATABASE EmployeeManagement
GO

USE EmployeeManagement
GO

CREATE TABLE Employee(
	EmployeeID CHAR(5),
	FullName NVARCHAR(100) NOT NULL,
	PhoneNo CHAR(15) UNIQUE NOT NULL,
	Birthday DATE NOT NULL,
	Adress NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Employee PRIMARY KEY (EmployeeID)
)
GO

