-- Tạo CSDL và Bảng SinhVien
CREATE DATABASE HTPT;
USE HTPT;

drop database HTPT;
CREATE TABLE SinhVien (
    MaSV INT PRIMARY KEY,
    HoTen NVARCHAR(50),
    NamSinh DATE,
    DiemTB FLOAT,
    GioiTinh BIT
);


select * from SinhVien;

INSERT INTO SinhVien (MaSV, HoTen, NamSinh, DiemTB, GioiTinh)
VALUES 
    (1, N'Nguyen Van A', '2000-01-01', 8.5, 1),
    (2, N'Tran Thi B', '2001-02-02', 7.8, 0);
INSERT INTO SinhVien (MaSV, HoTen, NamSinh, DiemTB, GioiTinh)
VALUES
    ('3', 'Tran Van D', '1993-04-04', 8.7, 1),
    ('4', 'Le Thi E', '1994-05-05', 9.2, 0),
    ('5', 'Pham Van F', '1995-06-06', 7.5, 1);
