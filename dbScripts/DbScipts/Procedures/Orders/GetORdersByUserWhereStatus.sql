CREATE OR ALTER PROCEDURE [dbo].[GetOrdersByUserWhereStatus]
@UserId int,
@StatusId int
AS
	SELECT UserOrder.OrderCode, UserOrder.Total, OrderStatus.[Name], ProductDetails.[Name], ProductDetails.[Price], COUNT(ProductDetails.ProductCode) AS 'Count', ProductDetails.ProductCode
	FROM [dbo].[Orders] UserOrder
	INNER JOIN [dbo].[OrderItems] OrderItems ON OrderItems.OrderId = UserOrder.Id  AND 
												UserOrder.UserId=@UserId
	INNER JOIN [dbo].[Products] OrderProducts ON OrderProducts.Id = OrderItems.ProductId
	INNER JOIN [dbo].[ProductDetails] ProductDetails ON ProductDetails.Id = OrderProducts.ProductDetailId
	INNER JOIN [dbo].[OrderStatuses] OrderStatus ON OrderStatus.Id = UserOrder.OrderStatusId AND
													OrderStatus.Id = @StatusId

	GROUP BY ProductDetails.ProductCode, ProductDetails.[Name], ProductDetails.[Price], UserOrder.OrderCode, UserOrder.Total, OrderStatus.[Name]
	ORDER BY UserOrder.OrderCode