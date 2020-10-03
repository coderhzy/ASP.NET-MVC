CREATE DATABASE [mvcStudy]
go
USE [mvcStudy]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 2019/9/8 21:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](50) NULL,
	[Title] [nvarchar](160) NULL,
	[Price] [decimal](10, 2) NULL,
	[BookCoverUrl] [nvarchar](1024) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2019/9/8 21:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](1024) NULL,
	[BookId] [int] NULL,
	[Num] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Books] ON 

GO
INSERT [dbo].[Books] ([BookId], [AuthorName], [Title], [Price], [BookCoverUrl]) VALUES (1, N'Õı÷æ»', N'asp.net MVC', CAST(43.00 AS Decimal(10, 2)), N'/images/book1.jpg')
GO
INSERT [dbo].[Books] ([BookId], [AuthorName], [Title], [Price], [BookCoverUrl]) VALUES (2, N'’≈¡’', N'asp.net Core', CAST(40.00 AS Decimal(10, 2)), N'/images/book2.jpg')
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
