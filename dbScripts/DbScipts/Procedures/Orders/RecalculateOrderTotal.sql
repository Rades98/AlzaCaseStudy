CREATE OR ALTER PROCEDURE [dbo].[RecalculateOrderTotal]
@OrderID int
AS
	UPDATE [dbo].[Orders]
	SET 
	Total = (	
		SELECT COALESCE((SELECT SUM(ProDet.Price) FROM [dbo].[ProductDetails] ProDet
		INNER JOIN [dbo].[Products] Prod ON Prod.ProductDetailId=ProDet.Id
		WHERE Prod.Id IN (SELECT OrderIts.ProductId FROM [dbo].[OrderItems] OrderIts WHERE OrderIts.OrderId=@OrderId)),0)
	),
	Changed = GETDATE()
	WHERE Id=@OrderID
GO