USE [mvcStudy]
GO

/****** Object:  View [dbo].[sv_Orders]    Script Date: 2020/10/3 13:27:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[sv_Orders]
as
SELECT Books.Title, Books.BookCoverUrl, Books.Price,Orders.OrderID, Orders.Num, Orders.Address
FROM Books INNER JOIN
      Orders ON Books.BookId = Orders.BookId
GO


