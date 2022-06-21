CREATE OR ALTER PROCEDURE [dbo].[DeleteOrderItem]
@OrderCode varchar(10),
@ProductCode varchar(8),
@UserId uniqueidentifier
AS
BEGIN
	DECLARE @Ids TABLE (OrderId uniqueidentifier, UserOrderItemId uniqueidentifier)
	INSERT INTO @Ids
	SELECT TOP(1) UserOrder.Id, UserOrderItems.Id FROM [dbo].[OrderItems] UserOrderItems
	INNER JOIN [dbo].[Orders] UserOrder ON UserOrder.Id = UserOrderItems.OrderId AND 
											UserOrder.OrderCode = @OrderCode
	INNER JOIN [dbo].[Users] OrderUser ON OrderUser.Id = UserOrder.UserId AND
										  OrderUser.Id = @UserId
	INNER JOIN [dbo].[Products] OrderProduct ON OrderProduct.Id = UserOrderItems.ProductId
	INNER JOIN [dbo].[ProductDetails] OrderProductDetail ON OrderProductDetail.Id = OrderProduct.ProductDetailId AND 
															OrderProductDetail.ProductCode = @ProductCode
	INNER JOIN [dbo].[OrderStatuses] UserOrdertatus ON UserOrdertatus.Id = UserOrder.OrderStatusId AND 
													   UserOrdertatus.IsOrderEditable = 1

	DECLARE @OrderId uniqueidentifier 
	SET @OrderId = (SELECT TOP(1) OrderId FROM @Ids)

	DECLARE @OrderItemId uniqueidentifier 
	SET @OrderItemId = (SELECT TOP(1) UserOrderItemId FROM @Ids)

	IF @OrderItemId IS NOT NULL
		BEGIN
			DELETE FROM [dbo].[OrderItems] WHERE Id=@OrderItemId
			EXEC [dbo].[RecalculateOrderTotal] @OrderID=@OrderId
		END
	ELSE
		BEGIN
			THROW 51000, 'There is no item with this code on running order', 1;   
		END
END