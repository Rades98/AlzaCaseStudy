CREATE OR ALTER PROCEDURE [dbo].[InsertProductToOrder](@OrderID int, @ProductCode varchar(8))     
AS
BEGIN 
	INSERT INTO  [dbo].[OrderItems] (OrderId, ProductId, Created)
	VALUES(
		@OrderID,
		(
			SELECT TOP 1 Product.Id
			FROM [dbo].[Products] Product
			INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Product.ProductDetailId AND ProDet.ProductCode=@ProductCode
			INNER JOIN [dbo].[ProductCategories] ProCat ON ProCat.Id=ProDet.ProductCategoryId 
			WHERE Product.Id NOT IN (SELECT OI.ProductId FROM [dbo].[OrderItems] OI )
		),
		GETDATE()
	)

	EXEC [dbo].[RecalculateOrderTotal] @OrderID=@OrderID
END;
GO

