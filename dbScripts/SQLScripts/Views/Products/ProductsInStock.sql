CREATE OR ALTER VIEW [dbo].[ProductsInStock]
AS
SELECT COUNT(P.[ProductCode]) AS 'Count', P.[ProductCode]  
FROM Products P 
WHERE P.Id NOT IN (SELECT ProductId FROM OrderItems) 
GROUP BY P.[ProductCode]