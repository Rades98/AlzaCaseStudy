CREATE OR ALTER PROCEDURE GetCategoriesByProduct
	@ProductCategoryId uniqueidentifier
AS
	SELECT DISTINCT Prods.[Name], Cats.[Name] AS 'Category', Cats.Id AS 'Category Name', CategoryTree 
	FROM dbo.Products Prods
	INNER JOIN dbo.ProductCategories Cats ON Prods.ProductCategoryId=Cats.Id
	CROSS APPLY 
    ( SELECT
          [dbo].[GetProductParentTree](Cats.Id) AS CategoryTree
    ) AS z

GO