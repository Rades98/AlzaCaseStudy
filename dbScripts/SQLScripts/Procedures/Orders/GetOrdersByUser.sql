CREATE OR ALTER PROCEDURE [dbo].[GetOrdersByUser]
@UserId uniqueidentifier
AS
	SELECT * 
	FROM [dbo].[Orders] Ord
	WHERE Ord.UserId=@UserId
GO