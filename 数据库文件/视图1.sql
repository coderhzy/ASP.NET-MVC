create view sv_Orders
as
SELECT Books.Title, Books.BookCoverUrl, Books.Price, Orders.Num, Orders.Address
FROM Books INNER JOIN
      Orders ON Books.BookId = Orders.BookId