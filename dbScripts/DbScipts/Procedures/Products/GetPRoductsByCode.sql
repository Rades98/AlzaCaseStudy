CREATE OR ALTER PROCEDURE [dbo].[GetProductByCode]
@ProductCode varchar(8)
AS
	SELECT ProDet.[Name], ProDet.[ImgUri], ProDet.[Price], ProDet.[Description], ProCat.[Name], ProDetInf.[DetailedDescription], ProDetInf.[Parameters], InStock.[Count] AS 'InStock'
	FROM [dbo].[ProductDetails] ProDet
	INNER JOIN [dbo].[ProductsInStock] InStock ON InStock.[ProductCode]=ProDet.[ProductCode]
	INNER JOIN [dbo].[ProductCategories] ProCat ON ProCat.[Id]=ProDet.[ProductCategoryId]
	LEFT JOIN [dbo].[ProductDetailInfos] ProDetInf ON ProDetInf.ProductDetailId=ProDet.Id
	WHERE ProDet.ProductCode=@ProductCode
GO
