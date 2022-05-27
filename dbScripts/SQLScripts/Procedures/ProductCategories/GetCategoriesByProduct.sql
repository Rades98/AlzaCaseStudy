-- Inserts product to order and calculates final price of order

CREATE OR ALTER PROCEDURE [dbo].[InsertProductToOrder](@OrderID uniqueidentifier, @ProductCode varchar(8))     
AS
BEGIN 
	INSERT INTO  [dbo].[OrderItems] (Id, OrderId, ProductId, Created)
	VALUES(
		NEWID(),
		@OrderID,
		(SELECT TOP 1  Prod.Id FROM [dbo].[Products] Prod WHERE Prod.Id NOT IN (SELECT TOP(1) orderItem.ProductId FROM [dbo].[OrderItems] orderItem) AND Prod.ProductCode=@ProductCode),
		GETDATE()
	)
END;
GO