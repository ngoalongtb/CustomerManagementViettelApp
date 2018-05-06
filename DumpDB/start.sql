use master

if exists (select * from sys.databases where name='CustomerManagementApp')
drop database CustomerManagementApp

go

create database CustomerManagementApp
go
use CustomerManagementApp
go

CREATE TABLE LoaiTaiKhoan(
	MaLoaiTaiKhoan INT IDENTITY PRIMARY KEY,
	TenLoaiTaiKhoan NVARCHAR(255)
)

CREATE TABLE TaiKhoan(
	TenTaiKhoan varchar(255) primary key,
	MatKhau varchar(255),
	TenHienThi nvarchar(255),
	MaLoaiTaiKhoan int,
	NgayTao DateTIME
)
CREATE TABLE ThongTinTaiKhoan(
	TenTaiKhoan VARCHAR(255) PRIMARY KEY,
	HoTen NVARCHAR(255),
	NgaySinh DATETIME,
	SoDienThoai NVARCHAR(20),
	HinhAnh NVARCHAR(255),
	Email VARCHAR(255)
)
GO
CREATE TABLE DanhMuc(
	MaDanhMuc INT IDENTITY PRIMARY KEY,
	TenDanhMuc NVARCHAR(255),
	NgayTao DateTIME
)
GO
CREATE TABLE DichVu(
	MaDichVu INT PRIMARY KEY IDENTITY,
	TenDichVu NVARCHAR(255),
	Gia FLOAT,
	KhuyenMai FLOAT,
	MoTa NVARCHAR(255),
	MaDanhMuc INT,
	NgayTao DateTIME
)
GO
CREATE TABLE TaiKhoanDichVu(
	MaDichVu INT,
	TenTaiKhoan VARCHAR(255),
	PRIMARY KEY (MaDichVu, TenTaiKhoan),
	NgayTao DateTIME
)
GO
CREATE TABLE LichSuDangKy(
	MaDichVu INT,
	Gia FLOAT,
	TenTaiKhoan VARCHAR(255),
	PRIMARY KEY (MaDichVu, TenTaiKhoan),
	NgayTao DateTIME
)
GO

GO
ALTER TABLE TaiKhoan
ADD FOREIGN KEY(MaLoaiTaiKhoan) REFERENCES LoaiTaiKhoan(MaLoaiTaiKhoan)
on delete cascade 
on update cascade

ALTER TABLE ThongTinTaiKhoan
ADD FOREIGN KEY(TenTaiKhoan) REFERENCES TaiKhoan(TenTaiKhoan)
on delete cascade 
on update cascade

ALTER TABLE DichVu
ADD FOREIGN KEY(MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
on delete cascade 
on update cascade

ALTER TABLE TaiKhoanDichVu
ADD FOREIGN KEY(MaDichVu) REFERENCES DichVu(MaDichVu)
on delete cascade 
on update cascade

ALTER TABLE TaiKhoanDichVu
ADD FOREIGN KEY(TenTaiKhoan) REFERENCES TaiKhoan(TenTaiKhoan)
on delete cascade 
on update cascade


ALTER TABLE LichSuDangKy
ADD FOREIGN KEY(MaDichVu) REFERENCES DichVu(MaDichVu)
on delete cascade 
on update cascade

ALTER TABLE LichSuDangKy
ADD FOREIGN KEY(TenTaiKhoan) REFERENCES TaiKhoan(TenTaiKhoan)
on delete cascade 
on update cascade


select * from TaiKhoan

select * from ThongTinTaiKhoan