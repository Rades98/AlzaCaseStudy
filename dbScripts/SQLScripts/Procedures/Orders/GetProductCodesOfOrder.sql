CREATE OR ALTER PROCEDURE [dbo].[GetProductCodesOfOrder]
@OrderID uniqueidentifier
AS
	SELECT ProDet.ProductCode
	FROM [dbo].[OrderItems] OrdIts
	INNER JOIN [dbo].[Orders] Ord ON Ord.Id=OrdIts.OrderId
	INNER JOIN [dbo].[Products] Prod ON Prod.Id=OrdIts.ProductId
	INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prod.ProductDetailId
	WHERE Ord.Id=@OrderID
GO