CREATE OR ALTER PROCEDURE GetCategoriesByProduct
AS
	SELECT DISTINCT ProDet.[Name], Cats.[Name] AS 'Category', Cats.Id AS 'Category Id', CategoryTree 
	FROM [dbo].[Products] Prods
	INNER JOIN [dbo].[ProductDetails] ProDet ON ProDet.Id=Prods.ProductDetailId
	INNER JOIN [dbo].[ProductCategories] Cats ON ProDet.ProductCategoryId=Cats.Id
	CROSS APPLY 
    ( SELECT
          [dbo].[GetProductParentTree](Cats.Id) AS CategoryTree
    ) AS z

GO