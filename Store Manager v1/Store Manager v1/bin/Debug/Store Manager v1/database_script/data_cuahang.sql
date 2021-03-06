USE [master]
GO
/****** Object:  Database [data_cuahang]    Script Date: 04/07/2017 12:13:52 SA ******/
CREATE DATABASE [data_cuahang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'data_cuahang', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\data_cuahang.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'data_cuahang_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\data_cuahang_log.ldf' , SIZE = 1792KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [data_cuahang] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [data_cuahang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [data_cuahang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [data_cuahang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [data_cuahang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [data_cuahang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [data_cuahang] SET ARITHABORT OFF 
GO
ALTER DATABASE [data_cuahang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [data_cuahang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [data_cuahang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [data_cuahang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [data_cuahang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [data_cuahang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [data_cuahang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [data_cuahang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [data_cuahang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [data_cuahang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [data_cuahang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [data_cuahang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [data_cuahang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [data_cuahang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [data_cuahang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [data_cuahang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [data_cuahang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [data_cuahang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [data_cuahang] SET RECOVERY FULL 
GO
ALTER DATABASE [data_cuahang] SET  MULTI_USER 
GO
ALTER DATABASE [data_cuahang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [data_cuahang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [data_cuahang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [data_cuahang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [data_cuahang]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[idUser] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[roles] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[idMaHD] [numeric](18, 0) NOT NULL,
	[idSp] [numeric](18, 0) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[idMaHD] ASC,
	[idSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietNhap]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNhap](
	[idHoaDon] [numeric](18, 0) NOT NULL,
	[idSp] [numeric](18, 0) NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietNhap] PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC,
	[idSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[idDM] [numeric](18, 0) NOT NULL,
	[TenDM] [nvarchar](50) NULL,
	[IMAGE] [binary](50) NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[idDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DanhThu]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhThu](
	[idDanhthu] [numeric](18, 0) NOT NULL,
	[idnhanvien] [nvarchar](50) NULL,
	[Money] [money] NULL,
	[ngay] [date] NOT NULL,
 CONSTRAINT [PK_DanhThu] PRIMARY KEY CLUSTERED 
(
	[idDanhthu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[idHoaDon] [numeric](18, 0) NOT NULL,
	[idNhanvien] [nvarchar](50) NULL,
	[TenKH] [nvarchar](50) NULL,
	[NgayBan] [date] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[idHoaDon] [numeric](18, 0) NOT NULL,
	[idNhanvien] [nvarchar](50) NULL,
	[TenDT] [nvarchar](50) NULL,
	[NgayMua] [date] NULL,
 CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 04/07/2017 12:13:52 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[idSp] [numeric](18, 0) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Nhasx] [nvarchar](100) NULL,
	[TimeBH] [nvarchar](50) NULL,
	[DonVi] [nvarchar](50) NULL,
	[GiaNhap] [decimal](30, 0) NULL,
	[GiaBan] [decimal](30, 0) NULL,
	[IdDanhMuc] [numeric](18, 0) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[idSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Account] ([idUser], [password], [roles]) VALUES (N'nguyenphong', N'9f48495bb4b98ac37a1a72c7e6490c7a', 1)
INSERT [dbo].[Account] ([idUser], [password], [roles]) VALUES (N'nguyenquoc', N'9f48495bb4b98ac37a1a72c7e6490c7a', NULL)
INSERT [dbo].[Account] ([idUser], [password], [roles]) VALUES (N'nguyentoan', N'9f48495bb4b98ac37a1a72c7e6490c7a', NULL)
INSERT [dbo].[Account] ([idUser], [password], [roles]) VALUES (N'user', N'9f48495bb4b98ac37a1a72c7e6490c7a', 0)
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_DanhMuc] FOREIGN KEY([IdDanhMuc])
REFERENCES [dbo].[DanhMuc] ([idDM])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_DanhMuc]
GO
USE [master]
GO
ALTER DATABASE [data_cuahang] SET  READ_WRITE 
GO
