CREATE OR ALTER PROCEDURE [dbo].[InsertProductToOrder](@OrderID uniqueidentifier, @ProductCode varchar(8))     
AS
BEGIN 
	INSERT INTO  [dbo].[OrderItems] (Id, OrderId, ProductId, Created)
	VALUES(
		NEWID(),
		@OrderID,
		(SELECT TOP 1  Prod.Id FROM [dbo].[Products] Prod WHERE Prod.Id NOT IN (SELECT orderItem.ProductId FROM [dbo].[OrderItems] orderItem) AND Prod.ProductCode=@ProductCode),
		GETDATE()
	)

	UPDATE [dbo].[Orders]
	SET 
	Total = (SELECT SUM(Prod.Price) from [dbo].[Products] Prod WHERE Prod.Id IN (SELECT OrderIts.ProductId FROM [dbo].[OrderItems] OrderIts WHERE OrderIts.OrderId=@OrderID)),
	Changed = GETDATE()
	WHERE Id=@OrderID
END;
GO