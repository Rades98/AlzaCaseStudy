CREATE OR ALTER PROCEDURE [dbo].[RemoveProductFromOrder]
@OrderID int,
@ProductCode varchar(8)
AS
	DELETE 
	FROM [dbo].[OrderItems]
	WHERE Id = (
		SELECT TOP 1 OrdIt.Id
		FROM [dbo].[OrderItems] OrdIt
		INNER JOIN [dbo].[Products] Prod ON Prod.Id=OrdIt.ProductId
		INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prod.ProductDetailId
		WHERE ProDet.ProductCode=@ProductCode 
		AND OrdIt.OrderId=@OrderID
	)

	EXEC [dbo].[RecalculateOrderTotal] @OrderID=@OrderID