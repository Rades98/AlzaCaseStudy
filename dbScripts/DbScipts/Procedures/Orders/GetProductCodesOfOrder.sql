CREATE OR ALTER PROCEDURE [dbo].[GetProductCodesOfOrder]
@OrderID int
AS
	SELECT ProDet.ProductCode
	FROM [dbo].[OrderItems] OrdIts
	INNER JOIN [dbo].[Orders] Ord ON Ord.Id=OrdIts.OrderId AND Ord.Id=@OrderID
	INNER JOIN [dbo].[Products] Prod ON Prod.Id=OrdIts.ProductId
	INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prod.ProductDetailId