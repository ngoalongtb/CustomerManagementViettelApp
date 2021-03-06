USE [master]
GO
/****** Object:  Database [CustomerManagementApp]    Script Date: 5/6/2018 1:53:23 PM ******/
CREATE DATABASE [CustomerManagementApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerManagementApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CustomerManagementApp.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CustomerManagementApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CustomerManagementApp_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CustomerManagementApp] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerManagementApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerManagementApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CustomerManagementApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerManagementApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerManagementApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CustomerManagementApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerManagementApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CustomerManagementApp] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerManagementApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerManagementApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerManagementApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerManagementApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CustomerManagementApp] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CustomerManagementApp]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](255) NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](255) NULL,
	[Gia] [float] NULL,
	[KhuyenMai] [float] NULL,
	[MoTa] [nvarchar](255) NULL,
	[MaDanhMuc] [int] NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LichSuDangKy]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LichSuDangKy](
	[MaDichVu] [int] NOT NULL,
	[Gia] [float] NULL,
	[TenTaiKhoan] [varchar](255) NOT NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC,
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiTaiKhoan]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTaiKhoan](
	[MaLoaiTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiTaiKhoan] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTaiKhoan] [varchar](255) NOT NULL,
	[MatKhau] [varchar](255) NULL,
	[TenHienThi] [nvarchar](255) NULL,
	[MaLoaiTaiKhoan] [int] NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoanDichVu]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoanDichVu](
	[MaDichVu] [int] NOT NULL,
	[TenTaiKhoan] [varchar](255) NOT NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC,
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinTaiKhoan]    Script Date: 5/6/2018 1:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinTaiKhoan](
	[TenTaiKhoan] [varchar](255) NOT NULL,
	[HoTen] [nvarchar](255) NULL,
	[NgaySinh] [datetime] NULL,
	[SoDienThoai] [nvarchar](20) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[Email] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[TaiKhoan] ([TenTaiKhoan], [MatKhau], [TenHienThi], [MaLoaiTaiKhoan], [NgayTao]) VALUES (N'admin', N'12345', N'Admin', NULL, NULL)
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LichSuDangKy]  WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LichSuDangKy]  WITH CHECK ADD FOREIGN KEY([TenTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenTaiKhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaLoaiTaiKhoan])
REFERENCES [dbo].[LoaiTaiKhoan] ([MaLoaiTaiKhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoanDichVu]  WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoanDichVu]  WITH CHECK ADD FOREIGN KEY([TenTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenTaiKhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinTaiKhoan]  WITH CHECK ADD FOREIGN KEY([TenTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenTaiKhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [CustomerManagementApp] SET  READ_WRITE 
GO
