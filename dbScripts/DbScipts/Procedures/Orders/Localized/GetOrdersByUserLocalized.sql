CREATE OR ALTER PROCEDURE [dbo].[GetOrdersByUserLocalized]
@UserId int,
@LanguageCode varchar(2)
AS
	SELECT UserOrders.OrderCode, UserOrders.Total, COALESCE(OrderStatusLocalized.[Name], OrderStatus.[Name]) AS 'OrderStatus', COALESCE(ProductDetailsLocalized.[Name], ProductDetails.[Name]) AS 'Name', ProductDetails.[Price], COUNT(ProductDetails.ProductCode) AS 'Count', ProductDetails.ProductCode
	FROM [dbo].[Orders] UserOrders
	LEFT OUTER JOIN [dbo].[OrderItems] OrderItems ON OrderItems.OrderId = UserOrders.Id  AND 
												UserOrders.UserId=1
	INNER JOIN [dbo].[Languages] OrderLanguage ON OrderLanguage.Code = 'cs'
	LEFT OUTER JOIN [dbo].[Products] OrderProducts ON OrderProducts.Id = OrderItems.ProductId
	LEFT OUTER JOIN [dbo].[ProductDetails] ProductDetails ON ProductDetails.Id = OrderProducts.ProductDetailId
	LEFT OUTER JOIN [dbo].[ProductDetailsLocalized] ProductDetailsLocalized ON ProductDetailsLocalized.ProductDetailId = ProductDetails.Id AND
																			   ProductDetailsLocalized.LanguageId = OrderLanguage.Id
	INNER JOIN [dbo].[OrderStatuses] OrderStatus ON OrderStatus.Id = UserOrders.OrderStatusId
	LEFT OUTER JOIN [dbo].[OrderStatusesLocalized] OrderStatusLocalized ON OrderStatusLocalized.OrderStatusId = OrderStatus.Id AND
																	  OrderStatusLocalized.LanguageId = OrderLanguage.Id
	
	GROUP BY ProductDetails.ProductCode, 
			 COALESCE(ProductDetailsLocalized.[Name], ProductDetails.[Name]),
			 ProductDetails.[Price], 
			 UserOrders.OrderCode, 
			 UserOrders.Total, 
			 COALESCE(OrderStatusLocalized.[Name], OrderStatus.[Name])
	ORDER BY UserOrders.OrderCode
GO