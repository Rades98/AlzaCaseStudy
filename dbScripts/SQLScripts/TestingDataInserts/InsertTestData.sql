DELETE FROM [dbo].[OrderItems]
DELETE FROM [dbo].[Orders]
DELETE FROM [dbo].[Products]
DELETE FROM [dbo].[ProductDetails]

DECLARE @ProductDetailId uniqueidentifier = NEWID()

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(@ProductDetailId, GETDATE(), 'Mobile phone FUKUME dah dah dah', 'http://www.alza.cdn.cz/product', 'FUKUME 8 - BLACK', 8000.00, 'CE94AE71-1DD0-40F4-A89B-CF70BA3D9E3B', 'AAAA0000')

INSERT INTO [dbo].[ProductDetailInfos]([Id], [ProductDetailId], [DetailedDescription], [Parameters], [Created])
VALUES(NEWID(), @ProductDetailId, 'FUKUME mobile phone lol. Its cool, we all like it, you need it!', '{"Creator": "Fukume","Construction": "Touchscreen","OperatingSystem": "Android","OSversion": 42,"Weight": 174,"Display": {"DisplaySize": 6.1,"Resolution": "2532 x 1170","DisplayType": "Super Trooper Rootin Pootin OLED","PPI": 460},"Dimensions":{"Height": 146.7,"Width": 71.5,"Depth": 7.7},"Camera":{"Resolution": 15,"AutoFocus": true,"Flash": true,"HDVid": true,"Stabilization": true}}',GETDATE())

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'Mobile phone FUKUME dah dah dah', 'http://www.alza.cdn.cz/product', 'FUKUME 8 - GREEN', 8500.00, 'CE94AE71-1DD0-40F4-A89B-CF70BA3D9E3B', 'AAAA0001')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'Mobile phone FUKUME dah dah dah', 'http://www.alza.cdn.cz/product', 'FUKUME 8 - BLACK (64 GB)', 12000.00, 'CE94AE71-1DD0-40F4-A89B-CF70BA3D9E3B', 'AAAA0002')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'X-Protect mobile case protector for FUKUME phones (7+)', 'http://www.alza.cdn.cz/product', 'X-Protect StrongAF - TIGER', 120.00, 'A6312A0B-30C2-40B5-A55A-39C2203F301A', 'AAAA0003')
INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'X-Protect mobile case protector for FUKUME phones (7+)', 'http://www.alza.cdn.cz/product', 'X-Protect StrongAF - PINK', 200.00, 'A6312A0B-30C2-40B5-A55A-39C2203F301A', 'AAAA0004')
INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'X-Protect mobile case protector for FUKUME phones (7+)', 'http://www.alza.cdn.cz/product', 'X-Protect StrongAF - AVENGERS', 500.00, 'A6312A0B-30C2-40B5-A55A-39C2203F301A', 'AAAA0005')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), '2A/5V adapter with USB C cord', 'http://www.alza.cdn.cz/product', 'AdXp Type C', 400.00, '8B1DB412-7D98-4CD0-BAD6-4A7C70B235B1', 'AAAA0006')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'SSD disk M.2 (PCIe 3.0 4x NVMe), TLC (Triple-Level Cell), reading 3500MB/s', 'http://www.alza.cdn.cz/product', 'Blue SN570 1TB', 2500.00, 'CC99E4B0-AF43-4E5E-8BF6-EC3C0A6AF943', 'AAAA0007')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'HDD 3.5", SATA III, reading 220MB/s', 'http://www.alza.cdn.cz/product', 'BarraCuda 2TB', 1500.00, 'FEA68386-0816-492F-9D1A-15AEDC8C38CE', 'AAAA0008')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'SSD disk 2.5", SATA III, TLC (Triple-Level Cell), reading 560MB/s,', 'http://www.alza.cdn.cz/product', 'BarraCuda 2TB', 1500.00, 'CC99E4B0-AF43-4E5E-8BF6-EC3C0A6AF943', 'AAAA0009')

INSERT INTO [dbo].[ProductDetails] (Id, Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(NEWID(), GETDATE(), 'Graphic card 8GB DDR6 (14000MHz)', 'http://www.alza.cdn.cz/product', 'GAINWARD GeForce RTX 3060 Ti Ghost LHR', 15900.00, '3F91A56D-57E5-4079-9E23-E6064502E447', 'AAAA0010')


select * from Products

DECLARE @cnt INT = 0;
DECLARE @pcnt INT = 0

WHILE @pcnt < 10
BEGIN
	SET @cnt = 0;
	WHILE @cnt < 10 AND @pcnt < 10
	BEGIN
		INSERT INTO [dbo].[Products] (Id, Created, ProductDetailId)
		VALUES(NEWID(), GETDATE(), (SELECT PD.Id FROM [dbo].[ProductDetails] PD WHERE ProductCode=(SELECT CONCAT('AAAA000', @pcnt))))
		SET @cnt = @cnt + 1;
	END;

	SET @pcnt = @pcnt +1;
END;

SET @cnt = 0;
	WHILE @cnt < 10
	BEGIN
		INSERT INTO [dbo].[Products] (Id, Created, ProductDetailId)
		VALUES(NEWID(), GETDATE(), (SELECT PD.Id FROM [dbo].[ProductDetails] PD WHERE ProductCode=(SELECT CONCAT('AAAA00', @pcnt))))
		SET @cnt = @cnt + 1;
	END;



DECLARE @OrderID uniqueidentifier = NEWID() 
DECLARE @UserId uniqueidentifier = (SELECT TOP 1 Id FROM [dbo].[Users])

INSERT INTO [dbo].[Orders] (Id, OrderCode, Total, UserId, OrderStatusId, Created)
VALUES (@OrderID, 'AAAAA00000', 0, @UserId, (SELECT TOP 1 Id FROM [dbo].OrderStatuses), GETDATE())

EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0000'     
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0001'     
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0001'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0008'     
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0009'     

SET @OrderID = NEWID() 

INSERT INTO [dbo].[Orders] (Id, OrderCode, Total, UserId, OrderStatusId, Created)
VALUES (@OrderID, 'AAAAA00001', 0, @UserId, (SELECT TOP 1 Id FROM [dbo].OrderStatuses), GETDATE())

EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0010'     
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0010'    
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0008'

SET @OrderID = NEWID() 
INSERT INTO [dbo].[Orders] (Id, OrderCode, Total, UserId, OrderStatusId, Created)
VALUES (@OrderID, 'AAAAA00002', 0, @UserId, (SELECT TOP 1 Id FROM [dbo].OrderStatuses), GETDATE())

EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0010'     
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0009'    
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0008'

INSERT INTO [dbo].[Orders] (Id, OrderCode, Total, UserId, OrderStatusId, Created)
VALUES (NEWID(), 'AAAAA00003', 0, (SELECT TOP 1 Id FROM [dbo].[Users]), '27F83608-434A-4F4B-8315-FF711A97BFF4', GETDATE())