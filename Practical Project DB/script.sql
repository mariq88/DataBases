CREATE DATABASE [SupermarketInformation]
GO
USE [SupermarketInformation]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 22.7.2013 г. 18:39:11 ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 22.7.2013 г. 18:39:11 ******/
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
/****** Object:  Table [dbo].[Reports]    Script Date: 22.7.2013 г. 18:39:11 ******/
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
/****** Object:  Table [dbo].[Vendors]    Script Date: 22.7.2013 г. 18:39:11 ******/
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
SET IDENTITY_INSERT [dbo].[Measures] ON 

INSERT [dbo].[Measures] ([ID], [MeasureName]) VALUES (1, N'liters')
INSERT [dbo].[Measures] ([ID], [MeasureName]) VALUES (2, N'peices')
SET IDENTITY_INSERT [dbo].[Measures] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [VendorID], [ProductName], [MeasureID], [BasePrice]) VALUES (1, 2, N'Beer “Zagorka”', 1, 0.8600)
INSERT [dbo].[Products] ([ID], [VendorID], [ProductName], [MeasureID], [BasePrice]) VALUES (2, 3, N'Vodka “Targovishte”', 1, 7.5600)
INSERT [dbo].[Products] ([ID], [VendorID], [ProductName], [MeasureID], [BasePrice]) VALUES (3, 2, N'Beer “Beck’s”', 1, 1.0300)
INSERT [dbo].[Products] ([ID], [VendorID], [ProductName], [MeasureID], [BasePrice]) VALUES (4, 1, N'Chocolate “Milka”', 2, 2.8000)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Reports] ON 

INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (1, 1, 37, 1.0000, 37.0000, N'Supermarket “Bourgas – Plaza”', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (2, 2, 14, 8.5000, 119.0000, N'Supermarket “Bourgas – Plaza”', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (3, 3, 40, 1.2000, 48.0000, N'Supermarket “Kaspichan – Center”', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (4, 1, 65, 0.9200, 59.8000, N'Supermarket “Kaspichan – Center”', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (5, 4, 12, 2.9000, 34.8000, N'Supermarket “Kaspichan – Center”', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (6, 4, 7, 2.8500, 19.9500, N'Supermarket “Bay Ivan” – Zmeyovo', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (7, 2, 4, 7.8000, 31.2000, N'Supermarket “Bay Ivan” – Zmeyovo', CAST(0x5C370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (8, 1, 11, 1.0000, 11.0000, N'Supermarket “Bourgas – Plaza”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (9, 2, 20, 8.5000, 170.0000, N'Supermarket “Bourgas – Plaza”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (10, 3, 43, 1.2000, 51.6000, N'Supermarket “Kaspichan – Center”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (11, 1, 78, 0.9200, 71.7600, N'Supermarket “Kaspichan – Center”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (12, 4, 9, 2.9000, 26.1000, N'Supermarket “Kaspichan – Center”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (13, 3, 75, 1.0500, 78.7500, N'Supermarket “Plovdiv – Stolipinovo”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (14, 1, 146, 0.8800, 128.4800, N'Supermarket “Plovdiv – Stolipinovo”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (15, 2, 67, 7.7000, 515.9000, N'Supermarket “Plovdiv – Stolipinovo”', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (16, 4, 5, 2.8500, 14.2500, N'Supermarket “Bay Ivan” – Zmeyovo', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (17, 2, 3, 7.8000, 23.4000, N'Supermarket “Bay Ivan” – Zmeyovo', CAST(0x5D370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (18, 2, 24, 8.5000, 204.0000, N'Supermarket “Bourgas – Plaza”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (19, 1, 16, 1.0000, 16.0000, N'Supermarket “Bourgas – Plaza”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (20, 1, 90, 0.9200, 82.8000, N'Supermarket “Kaspichan – Center”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (21, 4, 14, 2.9000, 40.6000, N'Supermarket “Kaspichan – Center”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (22, 3, 18, 1.2000, 21.6000, N'Supermarket “Kaspichan – Center”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (23, 2, 12, 7.7000, 92.4000, N'Supermarket “Plovdiv – Stolipinovo”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (24, 3, 60, 1.0500, 63.0000, N'Supermarket “Plovdiv – Stolipinovo”', CAST(0x5E370B00 AS Date))
INSERT [dbo].[Reports] ([ID], [ProductID], [Quantity], [UnitPrice], [Sum], [Supermarket], [ReportDate]) VALUES (25, 1, 230, 0.8800, 202.4000, N'Supermarket “Plovdiv – Stolipinovo”', CAST(0x5E370B00 AS Date))
SET IDENTITY_INSERT [dbo].[Reports] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([ID], [VendorName]) VALUES (1, N'Nestle Sofia Corp.')
INSERT [dbo].[Vendors] ([ID], [VendorName]) VALUES (2, N'Zagorka Corp.')
INSERT [dbo].[Vendors] ([ID], [VendorName]) VALUES (3, N'Targovishte Bottling Company Ltd.')
SET IDENTITY_INSERT [dbo].[Vendors] OFF
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
