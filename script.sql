Create database [MyCoreAdminDB]
go
USE [MyCoreAdminDB]
GO
/****** Object:  Table [dbo].[ATTRIBUTE]    Script Date: 30/01/2019 5:19:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ATTRIBUTE](
	[AttributeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NULL,
	[AttributeName] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_ATTRIBUTE] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BRANCH]    Script Date: 30/01/2019 5:19:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BRANCH](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_BRANCH] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT]    Script Date: 30/01/2019 5:19:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[EstablishedDate] [date] NULL,
	[TypeId] [int] NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCT_ATTRIBUTE]    Script Date: 30/01/2019 5:19:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCT_ATTRIBUTE](
	[ProductId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[AttributeValue] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__PRODUCT___081454530E839143] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TYPE]    Script Date: 30/01/2019 5:19:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPE](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[TypeName] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_TYPE] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ATTRIBUTE] ON 

INSERT [dbo].[ATTRIBUTE] ([AttributeId], [TypeId], [AttributeName]) VALUES (1, 2, N'Model')
INSERT [dbo].[ATTRIBUTE] ([AttributeId], [TypeId], [AttributeName]) VALUES (2, 2, N'Series')
INSERT [dbo].[ATTRIBUTE] ([AttributeId], [TypeId], [AttributeName]) VALUES (3, 2, N'Memory Type')
INSERT [dbo].[ATTRIBUTE] ([AttributeId], [TypeId], [AttributeName]) VALUES (4, 2, N'Capacity')
INSERT [dbo].[ATTRIBUTE] ([AttributeId], [TypeId], [AttributeName]) VALUES (5, 2, N'Bus')
INSERT [dbo].[ATTRIBUTE] ([AttributeId], [TypeId], [AttributeName]) VALUES (6, 2, N'Voltage')
SET IDENTITY_INSERT [dbo].[ATTRIBUTE] OFF
SET IDENTITY_INSERT [dbo].[BRANCH] ON 

INSERT [dbo].[BRANCH] ([BranchId], [BranchName]) VALUES (1, N'
Computer Components')
SET IDENTITY_INSERT [dbo].[BRANCH] OFF
SET IDENTITY_INSERT [dbo].[PRODUCT] ON 

INSERT [dbo].[PRODUCT] ([ProductId], [ProductName], [AddedDate], [EstablishedDate], [TypeId], [Price], [Quantity]) VALUES (1, N'G.SKILL Trident Z RGB DDR4  16GB (8GBx2) 4600MHz', CAST(N'2019-01-23T00:00:00.000' AS DateTime), NULL, 2, NULL, 10)
INSERT [dbo].[PRODUCT] ([ProductId], [ProductName], [AddedDate], [EstablishedDate], [TypeId], [Price], [Quantity]) VALUES (2, N'CORSAIR Vegeance RGB DDR4  Pro 32GB (4 x 8GB) 3733MHz ', CAST(N'2019-01-23T00:00:00.000' AS DateTime), NULL, 2, NULL, 10)
SET IDENTITY_INSERT [dbo].[PRODUCT] OFF
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 1, N'F4-4600C18D-16GTZR')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 2, N'Trident Z RGB')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 3, N'DDR4')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 4, N'16GB (8GBx2)')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 5, N'4600MHz')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (1, 6, N'1.20v')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 1, N'CMW32GX4M4K3733C17')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 2, N'Vengeance')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 3, N'DDR4')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 4, N'32GB (4x8GB)')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 5, N'3733MHz ')
INSERT [dbo].[PRODUCT_ATTRIBUTE] ([ProductId], [AttributeId], [AttributeValue]) VALUES (2, 6, N'1.20v')
SET IDENTITY_INSERT [dbo].[TYPE] ON 

INSERT [dbo].[TYPE] ([TypeId], [BranchId], [TypeName]) VALUES (1, 1, N'CPU')
INSERT [dbo].[TYPE] ([TypeId], [BranchId], [TypeName]) VALUES (2, 1, N'Ram')
INSERT [dbo].[TYPE] ([TypeId], [BranchId], [TypeName]) VALUES (3, 1, N'Nguồn')
INSERT [dbo].[TYPE] ([TypeId], [BranchId], [TypeName]) VALUES (4, 1, N'Mainboard')
INSERT [dbo].[TYPE] ([TypeId], [BranchId], [TypeName]) VALUES (5, 1, N'Case')
SET IDENTITY_INSERT [dbo].[TYPE] OFF
ALTER TABLE [dbo].[ATTRIBUTE]  WITH CHECK ADD  CONSTRAINT [FK_ATTRIBUTE_TYPE] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TYPE] ([TypeId])
GO
ALTER TABLE [dbo].[ATTRIBUTE] CHECK CONSTRAINT [FK_ATTRIBUTE_TYPE]
GO
ALTER TABLE [dbo].[PRODUCT]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_TYPE] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TYPE] ([TypeId])
GO
ALTER TABLE [dbo].[PRODUCT] CHECK CONSTRAINT [FK_PRODUCT_TYPE]
GO
ALTER TABLE [dbo].[PRODUCT_ATTRIBUTE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_ATTRIBUTE_ATTRIBUTE1] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[ATTRIBUTE] ([AttributeId])
GO
ALTER TABLE [dbo].[PRODUCT_ATTRIBUTE] CHECK CONSTRAINT [FK_PRODUCT_ATTRIBUTE_ATTRIBUTE1]
GO
ALTER TABLE [dbo].[PRODUCT_ATTRIBUTE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_ATTRIBUTE_PRODUCT] FOREIGN KEY([ProductId])
REFERENCES [dbo].[PRODUCT] ([ProductId])
GO
ALTER TABLE [dbo].[PRODUCT_ATTRIBUTE] CHECK CONSTRAINT [FK_PRODUCT_ATTRIBUTE_PRODUCT]
GO
ALTER TABLE [dbo].[TYPE]  WITH CHECK ADD  CONSTRAINT [FK_TYPE_BRANCH] FOREIGN KEY([BranchId])
REFERENCES [dbo].[BRANCH] ([BranchId])
GO
ALTER TABLE [dbo].[TYPE] CHECK CONSTRAINT [FK_TYPE_BRANCH]
GO
