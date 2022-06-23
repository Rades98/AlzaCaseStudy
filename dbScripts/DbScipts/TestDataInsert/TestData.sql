DELETE FROM [dbo].[OrderItems]
DBCC CHECKIDENT ('[OrderItems]', RESEED, 0)
GO
DELETE FROM [dbo].[Orders]
DBCC CHECKIDENT ('[Orders]', RESEED, 0)
GO
DELETE FROM [dbo].[ProductDetailInfosLocalized]
DBCC CHECKIDENT ('[ProductDetailInfosLocalized]', RESEED, 0)
GO
DELETE FROM [dbo].[ProductDetailInfos]
DBCC CHECKIDENT ('[ProductDetailInfos]', RESEED, 0)
GO
DELETE FROM [dbo].[ProductDetailInfosLocalized]
DBCC CHECKIDENT ('[ProductDetailsLocalized]', RESEED, 0)
GO
DELETE FROM [dbo].[ProductDetails]
DBCC CHECKIDENT ('[ProductDetails]', RESEED, 0)
GO
DELETE FROM [dbo].[Products]
DBCC CHECKIDENT ('[Products]', RESEED, 0)
GO
DELETE FROM [dbo].[Messages]
DBCC CHECKIDENT ('[Messages]', RESEED, 0)
GO

INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'Mobile phone FUKUME dah dah dah', 'http://www.alza.cdn.cz/product', 'FUKUME 8 - BLACK', 8000.00, 1001, 'AAAA0000')

INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('Mobilní telefon FUKUME dá dá dá', 'FUKUME 8 - ČERNÝ', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')

INSERT INTO [dbo].[ProductDetailInfos]([ProductDetailId], [DetailedDescription], [Parameters], [Created])
VALUES((SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'FUKUME mobile phone lol. Its cool, we all like it, you need it!', '{"Creator": "Fukume","Construction": "Touchscreen","OperatingSystem": "Android","OSversion": 42,"Weight": 174,"Display": {"DisplaySize": 6.1,"Resolution": "2532 x 1170","DisplayType": "Super Trooper Rootin Pootin OLED","PPI": 460},"Dimensions":{"Height": 146.7,"Width": 71.5,"Depth": 7.7},"Camera":{"Resolution": 15,"AutoFocus": true,"Flash": true,"HDVid": true,"Stabilization": true}}',GETDATE())

INSERT INTO [dbo].[ProductDetailInfosLocalized]([ProductDetailInfoId], [DetailedDescription], [Parameters], [Created], [LanguageId])
VALUES((SELECT IDENT_CURRENT('[dbo].[ProductDetailInfos]')),'FUKUME mobilní telefon lol. Je fakt cool, všichni ho chceme, ty ho musíš mít!', '{"Výrobce": "Fukume","Konstrukce": "Dotykový","Operační systém": "Android","Verze OS": 42,"Hmotnost": 174,"Display": {"Velikost Displaye": 6.1,"Rozlišení": "2532 x 1170","Typ displaye": "Super Trooper Rootin Pootin OLED","PPI": 460},"Rozměry":{"Výška": 146.7,"Šířka": 71.5,"Hloubka": 7.7},"Fotoaparát":{"Rozlišení ": 15,"AutoFocus": true,"Blesk": true,"HDVid": true,"Stabilizátor": true}}',GETDATE(), 1)

INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'Mobile phone FUKUME dah dah dah', 'http://www.alza.cdn.cz/product', 'FUKUME 8 - GREEN', 8500.00, 1001, 'AAAA0001')

INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('Mobilní telefon FUKUME dá dá dá', 'FUKUME 8 - ZELENÝ', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')

INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'Mobile phone FUKUME dah dah dah', 'http://www.alza.cdn.cz/product', 'FUKUME 8 - BLACK (64 GB)', 12000.00, 1001, 'AAAA0002')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('Mobilní telefon FUKUME dá dá dá', 'FUKUME 8 - ČERNÝ (64 GB)', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')

INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'X-Protect mobile case protector for FUKUME phones (7+)', 'http://www.alza.cdn.cz/product', 'X-Protect StrongAF - TIGER', 120.00, 1002, 'AAAA0003')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('X-Protect StrongAF - TIGR', 'X-Protect kryt na telefon pro FUKUME (7+)', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')

INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'X-Protect mobile case protector for FUKUME phones (7+)', 'http://www.alza.cdn.cz/product', 'X-Protect StrongAF - PINK', 200.00, 1002, 'AAAA0004')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('X-Protect StrongAF - RŮŽOVÝ', 'X-Protect kryt na telefon pro FUKUME (7+)', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')


INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'X-Protect mobile case protector for FUKUME phones (7+)', 'http://www.alza.cdn.cz/product', 'X-Protect StrongAF - AVENGERS', 500.00, 1002, 'AAAA0005')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('X-Protect StrongAF - AVENGERS', 'X-Protect kryt na telefon pro FUKUME (7+)', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')),'http://www.alza.cdn.cz/product')

INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), '2A/5V adapter with USB C cord', 'http://www.alza.cdn.cz/product', 'AdXp Type C', 400.00, 1003, 'AAAA0006')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('AdXp USB Typ C', '2A/5V adaptér s USB C kabelem', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')


INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'SSD disk M.2 (PCIe 3.0 4x NVMe), TLC (Triple-Level Cell), reading 3500MB/s', 'http://www.alza.cdn.cz/product', 'Blue SN570 1TB', 2500.00, 2003, 'AAAA0007')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('Blue SN570 1TB', 'SSD disk M.2 (PCIe 3.0 4x NVMe), TLC (Triple-Level Cell), rychlost čtení 3500MB/s', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')


INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'HDD 3.5", SATA III, reading 220MB/s', 'http://www.alza.cdn.cz/product', 'BarraCuda 2TB', 1500.00, 2004, 'AAAA0008')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('BarraCuda 2TB', 'HDD 3.5", SATA III, rychlost čtení 220MB/s', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')


INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'SSD disk 2.5", SATA III, TLC (Triple-Level Cell), reading 560MB/s,', 'http://www.alza.cdn.cz/product', 'BarraCuda 2TB SX', 1500.00, 2003, 'AAAA0009')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('BarraCuda 2TB SX', 'SSD disk 2.5", SATA III, TLC (Triple-Level Cell), rychlost čtení 560MB/s', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')


INSERT INTO [dbo].[ProductDetails] (Created, [Description], ImgUri, [Name], Price, ProductCategoryId, ProductCode)
VALUES(GETDATE(), 'Graphic card 8GB DDR6 (14000MHz)', 'http://www.alza.cdn.cz/product', 'GAINWARD GeForce RTX 3060 Ti Ghost LHR', 15900.00, 2001, 'AAAA0010')
INSERT INTO [dbo].[ProductDetailsLocalized]([Name], [Description], [LanguageId], [Created], [ProductDetailId], ImgUri)
VALUES('GAINWARD GeForce RTX 3060 Ti Ghost LHR', 'Grafická karta 8GB DDR6 (14000MHz)', 1, GETDATE(), (SELECT IDENT_CURRENT('[dbo].[ProductDetails]')), 'http://www.alza.cdn.cz/product')

DECLARE @cnt INT = 0;
DECLARE @pcnt INT = 0

WHILE @pcnt < 10
BEGIN
	SET @cnt = 0;
	WHILE @cnt < 10 AND @pcnt < 10
	BEGIN
		INSERT INTO [dbo].[Products] (Created, ProductDetailId)
		VALUES(GETDATE(), (SELECT PD.Id FROM [dbo].[ProductDetails] PD WHERE ProductCode=(SELECT CONCAT('AAAA000', @pcnt))))
		SET @cnt = @cnt + 1;
	END;

	SET @pcnt = @pcnt +1;
END;

SET @cnt = 0;
	WHILE @cnt < 10
	BEGIN
		INSERT INTO [dbo].[Products] (Created, ProductDetailId)
		VALUES(GETDATE(), (SELECT PD.Id FROM [dbo].[ProductDetails] PD WHERE ProductCode=(SELECT CONCAT('AAAA00', @pcnt))))
		SET @cnt = @cnt + 1;
	END;



DECLARE @OrderID INT = 1 
DECLARE @UserId INT = (SELECT TOP 1 Id FROM [dbo].[Users])

INSERT INTO [dbo].[Orders] (OrderCode, Total, UserId, OrderStatusId, Created)
VALUES ('AAAAA00000', 0, @UserId, 5, GETDATE())

EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0000'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0001'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0001'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0008'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0009'

SET @OrderID = 2 

INSERT INTO [dbo].[Orders] (OrderCode, Total, UserId, OrderStatusId, Created)
VALUES ('AAAAA00001', 0, @UserId, 5, GETDATE())

EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0010'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0010'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0008'

SET @OrderID = 3
INSERT INTO [dbo].[Orders] (OrderCode, Total, UserId, OrderStatusId, Created)
VALUES ('AAAAA00002', 0, @UserId, 5, GETDATE())

EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0010'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0009'
EXEC [dbo].[InsertProductToOrder] @OrderID=@OrderID, @ProductCode='AAAA0008'

INSERT INTO [dbo].[Orders] (OrderCode, Total, UserId, OrderStatusId, Created)
VALUES ('AAAAA00003', 0, 1, 1, GETDATE())



