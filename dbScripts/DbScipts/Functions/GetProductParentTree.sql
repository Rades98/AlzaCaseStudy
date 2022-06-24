CREATE OR ALTER FUNCTION [dbo].[GetProductParentTree](@CatID int)  
RETURNS nvarchar(500)   
AS     
BEGIN 
	DECLARE @Result nvarchar(500);
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

	SELECT @Result = (SELECT STRING_AGG (CONVERT(NVARCHAR(max),RECUR.[Name]), ',') 
	FROM RECUR)
	RETURN @Result
END
GO