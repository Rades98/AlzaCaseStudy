CREATE OR ALTER PROCEDURE [dbo].[RecalculateOrderTotal]
@OrderID uniqueidentifier
AS
	UPDATE [dbo].[Orders]
	SET 
	Total = (	
		SELECT COALESCE((SELECT SUM(ProDet.Price) FROM [dbo].[ProductDetails] ProDet
		INNER JOIN [dbo].[Products] Prod ON Prod.ProductDetailId=ProDet.Id
		WHERE Prod.Id IN (SELECT OrderIts.ProductId FROM [dbo].[OrderItems] OrderIts WHERE OrderIts.OrderId='1EBF6D45-4A73-4669-B778-C57C5DE6CB41')),0)
	),
	Changed = GETDATE()
	WHERE Id=@OrderID
GO