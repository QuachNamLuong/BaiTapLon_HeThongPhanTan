USE master
GO

CREATE DATABASE EmployeeManagement
GO

USE EmployeeManagement
GO

CREATE TABLE Employee(
	EmployeeID CHAR(5),
	FullName NVARCHAR(100),
	PhoneNo CHAR(15) UNIQUE,
	Birthday DATE,
	Adress NVARCHAR(100),
	CONSTRAINT PK_Employee PRIMARY KEY (EmployeeID)
)
GO

CREATE TABLE History(
	EmployeeID CHAR(5),
	UpdateTime DATETIME,
	SiteUpdate NVARCHAR(100),
	ContentUpdate NTEXT,
	CONSTRAINT PK_History PRIMARY KEY (EmployeeID, UpdateTime),
	CONSTRAINT FK_History_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
)
GO

INSERT INTO Employee (EmployeeID, FullName, PhoneNo, Birthday, Adress)
VALUES 
('E001', N'John Doe', '1234567890', '1990-01-15', N'123 Main St'),
('E002', N'Jane Smith', '9876543210', '1985-05-20', N'456 Oak St'),
('E003', N'Michael Johnson', '5551112222', '1992-08-10', N'789 Pine St'),
('E004', N'Susan Williams', '3334445555', '1988-03-25', N'101 Elm St'),
('E005', N'David Lee', '9998887777', '1995-11-03', N'202 Maple St'),
('E006', N'Amy Brown', '7772223333', '1987-09-18', N'303 Cedar St'),
('E007', N'Robert Davis', '6665554444', '1993-04-12', N'404 Birch St'),
('E008', N'Emily Taylor', '1112223333', '1991-07-28', N'505 Walnut St'),
('E009', N'Chris Martin', '4443332222', '1986-12-05', N'606 Pineapple St'),
('E010', N'Jessica White', '2223334444', '1994-06-08', N'707 Orange St');

INSERT INTO History (EmployeeID, UpdateTime, SiteUpdate, ContentUpdate)
VALUES
('E001', '2023-01-10 08:30:00', N'Site A', N'Updated contact information'),
('E002', '2023-02-15 12:45:00', N'Site B', N'Added new project details'),
('E003', '2023-03-20 15:00:00', N'Site C', N'Changed work schedule'),
('E004', '2023-04-25 10:00:00', N'Site D', N'Updated skills and certifications'),
('E005', '2023-05-30 14:15:00', N'Site E', N'Added new achievements'),
('E006', '2023-06-05 09:30:00', N'Site F', N'Updated professional experience'),
('E007', '2023-07-10 11:00:00', N'Site G', N'Added education details'),
('E008', '2023-08-15 13:45:00', N'Site H', N'Changed profile picture'),
('E009', '2023-09-20 16:30:00', N'Site I', N'Updated project contributions'),
('E010', '2023-10-25 10:45:00', N'Site J', N'Added new skills');
