

DECLARE @cnt INT;
DECLARE @ProcOrderID INT;
DECLARE @UserId INT;
DECLARE @RandomOrderCode varchar(10);
DECLARE @pcnt INT = 0;
DECLARE @cntMax INT = 0;

WHILE @pcnt < 100
BEGIN
	SET @cnt = 0;
	SET @cntMax = (SELECT ABS(CHECKSUM(NEWID()) % 10) + 1)
	SET @UserId = (SELECT ABS(CHECKSUM(NEWID()) % (SELECT COUNT(Id) FROM [dbo].[Users])) + 1)

	INSERT INTO [dbo].[Orders] (OrderCode, Total, UserId, OrderStatusId, Created)
	VALUES ((SELECT CONCAT('AAAAA000', @pcnt)), 0, @UserId, (SELECT ABS(CHECKSUM(NEWID()) % 4) + 3), GETDATE())

	WHILE @cnt < @cntMax AND @pcnt < 100
	BEGIN
		SET @RandomOrderCode = (SELECT TOP(1) ProductCode FROM ProductDetails WHERE Id = (SELECT ABS(CHECKSUM(NEWID()) % (SELECT COUNT(Id) FROM [dbo].[ProductDetails])) + 1))
		SET @ProcOrderID = (SELECT MAX(Id) FROM [dbo].[Orders])
		EXEC [dbo].[InsertProductToOrder] @OrderID=@ProcOrderID, @ProductCode=@RandomOrderCode
		SET @cnt = @cnt + 1;
	END;

	SET @pcnt = @pcnt +1;
END;

SET @pcnt = 100
WHILE @pcnt < 299
BEGIN
	SET @cnt = 0;
	SET @cntMax = (SELECT ABS(CHECKSUM(NEWID()) % 10) + 1)
	SET @UserId = (SELECT ABS(CHECKSUM(NEWID()) % (SELECT COUNT(Id) FROM [dbo].[Users])) + 1)

	INSERT INTO [dbo].[Orders] (OrderCode, Total, UserId, OrderStatusId, Created)
	VALUES ((SELECT CONCAT('AAAAA00', @pcnt)), 0, @UserId, (SELECT ABS(CHECKSUM(NEWID()) % 4) + 3), GETDATE())

	WHILE @cnt < @cntMax AND @pcnt < 299
	BEGIN
		SET @RandomOrderCode = (SELECT TOP(1) ProductCode FROM ProductDetails WHERE Id = (SELECT ABS(CHECKSUM(NEWID()) % (SELECT COUNT(Id) FROM [dbo].[ProductDetails])) + 1))
		SET @ProcOrderID = (SELECT COUNT(Id) FROM [dbo].[Orders])
		EXEC [dbo].[InsertProductToOrder] @OrderID=@ProcOrderID, @ProductCode=@RandomOrderCode
		SET @cnt = @cnt + 1;
	END;

	SET @pcnt = @pcnt +1;
END;

select * from Orders
