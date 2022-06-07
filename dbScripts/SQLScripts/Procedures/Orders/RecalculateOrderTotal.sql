CREATE OR ALTER PROCEDURE [dbo].[RecalculateOrderTotal]
@OrderID uniqueidentifier
AS
	UPDATE [dbo].[Orders]
	SET 
	Total = (
		SELECT SUM(ProDet.Price) FROM [dbo].[ProductDetails] ProDet
		INNER JOIN [dbo].[Products] Prod ON Prod.ProductDetailId=ProDet.Id
		WHERE Prod.Id IN (SELECT OrderIts.ProductId FROM [dbo].[OrderItems] OrderIts WHERE OrderIts.OrderId=@OrderID)
	),
	Changed = GETDATE()
	WHERE Id=@OrderID
GO