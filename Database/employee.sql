CREATE DATABASE EmployeeManagement
USE EmployeeManagement

CREATE TABLE Employee(
	EmployeeID CHAR(5),
	FullName NVARCHAR(100),
	PhoneNo CHAR(15) UNIQUE,
	Birthday DATE,
	Adress NVARCHAR(100),
	CONSTRAINT PK_Employee PRIMARY KEY (EmployeeID)
)

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

--- chạy dòng dưới rồi mới chạy sp
Use EmployeeManagement;
---sp hiển thị danh sach nhân viên
CREATE PROCEDURE SP_HienThiDanhSachNhanVien
AS
BEGIN
    SELECT * FROM Employee;
END

---sp thêm mới nhân viên
CREATE PROCEDURE SP_ThemMoiNhanVien
    @Id NVARCHAR(50),
    @Ten NVARCHAR(100),
    @PhoneNo CHAR(15),
    @Address NVARCHAR(100),
    @Birthday DATE
AS
BEGIN
    INSERT INTO Employee (EmployeeID, FullName, PhoneNo, Adress, Birthday)
    VALUES (@Id, @Ten, @PhoneNo, @Address, @Birthday);
END


---sp xoá nhân viên
CREATE PROCEDURE SP_XoaNhanVien
    @Id NVARCHAR(50)
AS
BEGIN
    DELETE FROM Employee WHERE EmployeeID = @Id;
END

---sp sửa thông tin nhân viên
CREATE PROCEDURE SP_SuaThongTinNhanVien
    @Id NVARCHAR(50),
    @Ten NVARCHAR(100),
    @PhoneNo CHAR(15),
    @Address NVARCHAR(100),
    @Birthday DATE
AS
BEGIN
    UPDATE Employee
    SET FullName = @Ten, PhoneNo = @PhoneNo, Adress = @Address, Birthday = @Birthday
    WHERE EmployeeID = @Id;
END


select * from Employee;
