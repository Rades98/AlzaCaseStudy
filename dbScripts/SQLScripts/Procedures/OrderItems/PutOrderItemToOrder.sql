CREATE OR ALTER PROCEDURE [dbo].[PutOrderItemToOrder]
@ProductCode varchar(8),
@OrderCode varchar(10),
@UserId uniqueidentifier
AS
BEGIN

	DECLARE @OrderId uniqueidentifier
	DECLARE @ProductId uniqueidentifier
	SET @OrderId = (
		SELECT USerOrder.Id FROM [dbo].[Orders] UserOrder 
		INNER JOIN [dbo].[OrderStatuses] UserOrderStatus ON UserOrderStatus.Id = UserOrder.OrderStatusId AND
															UserOrderStatus.IsOrderEditable = 1
	)

	IF @OrderId IS NOT NULL
		BEGIN
			SET @ProductId = (
				SELECT TOP(1) AvailableProducts.Id FROM [dbo].[Products] AvailableProducts
				INNER JOIN [dbo].[ProductDetails] AvailableProductDetails ON AvailableProductDetails.Id = AvailableProducts.ProductDetailId AND
																			 AvailableProductDetails.ProductCode = @ProductCode
				WHERE AvailableProducts.Id NOT IN (SELECT ProductId FROM [dbo].[OrderItems])	
			)

			IF @ProductId IS NOT NULL
				BEGIN
					INSERT INTO [dbo].[OrderItems] (Id, OrderId, ProductId, Created)
					VALUES (NEWID(),@OrderId, @ProductId, GETDATE())
					EXEC [dbo].[RecalculateOrderTotal] @OrderID=@OrderId
				END
			ELSE
				BEGIN
					THROW 51000, 'There is no product in stock', 1;  
				END
		END
	ELSE
		BEGIN
			THROW 51000, 'There is no running order for user', 1;   
		END
END