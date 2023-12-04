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

