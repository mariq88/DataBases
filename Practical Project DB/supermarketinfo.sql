USE [master]
GO
/****** Object:  Database [SupermarketInformation]    Script Date: 22.7.2013 г. 18:36:45 ******/
CREATE DATABASE [SupermarketInformation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SupermarketInformation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SupermarketInformation.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SupermarketInformation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SupermarketInformation_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SupermarketInformation] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupermarketInformation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupermarketInformation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupermarketInformation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupermarketInformation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupermarketInformation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupermarketInformation] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupermarketInformation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SupermarketInformation] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SupermarketInformation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupermarketInformation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupermarketInformation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupermarketInformation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupermarketInformation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupermarketInformation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupermarketInformation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupermarketInformation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupermarketInformation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SupermarketInformation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupermarketInformation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupermarketInformation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupermarketInformation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupermarketInformation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupermarketInformation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupermarketInformation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupermarketInformation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SupermarketInformation] SET  MULTI_USER 
GO
ALTER DATABASE [SupermarketInformation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupermarketInformation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SupermarketInformation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SupermarketInformation] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SupermarketInformation]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 22.7.2013 г. 18:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MeasureName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 22.7.2013 г. 18:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[MeasureID] [int] NOT NULL,
	[BasePrice] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 22.7.2013 г. 18:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Sum] [money] NOT NULL,
	[Supermarket] [nvarchar](100) NOT NULL,
	[ReportDate] [date] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 22.7.2013 г. 18:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Measures] FOREIGN KEY([MeasureID])
REFERENCES [dbo].[Measures] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Measures]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Vendors] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendors] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Vendors]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Products]
GO
USE [master]
GO
ALTER DATABASE [SupermarketInformation] SET  READ_WRITE 
GO
