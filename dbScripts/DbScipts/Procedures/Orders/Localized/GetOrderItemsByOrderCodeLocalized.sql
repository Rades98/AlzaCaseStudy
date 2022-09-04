CREATE OR ALTER PROCEDURE [dbo].[GetOrderItemsByOrderCodeLocalized]
@OrderCode varchar(10),
@LanguageId INT 
AS 
SELECT 
	varOrder.OrderCode,
	COALESCE(varProdDetLocalized.[Name], varProdDetail.[Name]) AS [Name],
	varProdDetail.ProductCode,
	varProdDetail.Price,
	ProdCount.[Count],
	InStock.AvailableCount

FROM OrderItems varOrdItem
	INNER JOIN [dbo].[Orders] varOrder ON varOrder.Id = varOrdItem.OrderId AND 
										  varOrder.OrderCode = @OrderCode
	INNER JOIN [dbo].[Products] varProduct ON varProduct.Id = varOrdItem.ProductId
	INNER JOIN [dbo].[ProductDetails] varProdDetail ON varProdDetail.Id = varProduct.ProductDetailId
	LEFT OUTER JOIN [dbo].[ProductDetailsLocalized] varProdDetLocalized ON varProdDetLocalized.ProductDetailId = varProdDetail.Id AND
																	       varProdDetLocalized.LanguageId = @LanguageId

	OUTER APPLY
	(
		SELECT COUNT(ProDet.[ProductCode]) AS 'Count', ProDet.[ProductCode]  
		FROM Products Prod 
		INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prod.ProductDetailId
		INNER JOIN [dbo].[OrderItems] OrdIts ON OrdIts.ProductId = Prod.Id  
		WHERE ProDet.ProductCode = varProdDetail.ProductCode AND
			  OrdIts.OrderId = varOrder.Id
		GROUP BY ProDet.[ProductCode]
	) AS ProdCount

	OUTER APPLY
	(
		SELECT COUNT(ProDet.[ProductCode]) AS 'AvailableCount', ProDet.[ProductCode]  
		FROM Products Prod 
		INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prod.ProductDetailId
		WHERE Prod.Id NOT IN (SELECT ProductId FROM OrderItems) AND ProDet.ProductCode = varProdDetail.ProductCode
		GROUP BY ProDet.[ProductCode]

	) AS InStock

	GROUP BY 
		COALESCE(varProdDetLocalized.[Name], varProdDetail.[Name]),
		varProdDetail.ProductCode,
		varProdDetail.Price,
		ProdCount.[Count],
		InStock.AvailableCount,
		varOrder.OrderCode

	ORDER BY varProdDetail.ProductCode