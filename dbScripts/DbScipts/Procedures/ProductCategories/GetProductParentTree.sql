﻿CREATE OR ALTER PROCEDURE [dbo].[GetProductParentCategoryTree]
@CatID int
AS     
	WITH RECUR AS 
	(
		SELECT Id, ParentProductCategoryId, [Name]
		FROM dbo.ProductCategories
		WHERE Id = @CatID
		UNION ALL
		SELECT a.Id, a.ParentProductCategoryId, a.[Name]
		FROM dbo.ProductCategories A
		INNER JOIN RECUR B ON B.ParentProductCategoryId = A.Id
	)

	SELECT CONVERT(NVARCHAR(max),RECUR.[Name]) FROM RECUR
