CREATE OR ALTER PROCEDURE [dbo].[GetMessageTranslation]
	@LanguageCode varchar(2),
	@MessageCode varchar(50)
AS
	DECLARE @LanguageId int = (SELECT TOP(1) Id FROM [dbo].[Languages] WHERE Code = @LanguageCode)
	
	SELECT TOP(1) TranslatedMessage.[Message] FROM [dbo].[Messages] TranslatedMessage
	INNER JOIN [dbo].[Languages] MessageLanguage ON MessageLanguage.Code = @LanguageCode
	WHERE TranslatedMessage.MessageCode = @MessageCode

GO