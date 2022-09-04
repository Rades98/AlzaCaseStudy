CREATE OR ALTER PROCEDURE [dbo].[GetOrdersByUserWhereStatusLocalized]
@UserId int,
@LanguageId int,
@StatusId int
AS
	SELECT UserOrder.OrderCode, UserOrder.Total, COALESCE(OrderStatusLocalized.[Name], OrderStatus.[Name]) AS 'OrderStatus', COALESCE(ProductDetailsLocalized.[Name], ProductDetails.[Name]) AS 'Name', ProductDetails.[Price], COUNT(ProductDetails.ProductCode) AS 'Count', ProductDetails.ProductCode
	FROM [dbo].[Orders] UserOrder
	INNER JOIN [dbo].[OrderItems] OrderItems ON OrderItems.OrderId = UserOrder.Id  AND 
												UserOrder.UserId=@UserId
	INNER JOIN [dbo].[Products] OrderProducts ON OrderProducts.Id = OrderItems.ProductId
	INNER JOIN [dbo].[ProductDetails] ProductDetails ON ProductDetails.Id = OrderProducts.ProductDetailId
	LEFT OUTER JOIN [dbo].[ProductDetailsLocalized] ProductDetailsLocalized ON ProductDetailsLocalized.ProductDetailId = ProductDetails.Id AND
																			   ProductDetailsLocalized.LanguageId = @LanguageId
	INNER JOIN [dbo].[OrderStatuses] OrderStatus ON OrderStatus.Id = UserOrder.OrderStatusId AND
													OrderStatus.Id = @StatusId
	LEFT OUTER JOIN [dbo].[OrderStatusesLocalized] OrderStatusLocalized ON OrderStatusLocalized.OrderStatusId = OrderStatus.Id AND
																	  OrderStatusLocalized.LanguageId = @LanguageId

	GROUP BY ProductDetails.ProductCode, 
			 COALESCE(ProductDetailsLocalized.[Name], ProductDetails.[Name]),
			 ProductDetails.[Price], 
			 UserOrder.OrderCode, 
			 UserOrder.Total, 
			 COALESCE(OrderStatusLocalized.[Name], OrderStatus.[Name])
	ORDER BY UserOrder.OrderCode
