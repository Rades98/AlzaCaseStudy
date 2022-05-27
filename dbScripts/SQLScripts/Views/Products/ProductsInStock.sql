CREATE OR ALTER VIEW [dbo].[ProductsInStock]
AS
SELECT COUNT(ProDet.[ProductCode]) AS 'Count', ProDet.[ProductCode]  
FROM Products Prod 
INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prod.ProductDetailId
WHERE Prod.Id NOT IN (SELECT ProductId FROM OrderItems) 
GROUP BY ProDet.[ProductCode]