USE Example;

BEGIN TRANSACTION
BEGIN TRY

INSERT INTO [dbo].[RadioStations](Name,CountryID) VALUES('BBC Radio 1', (SELECT TOP 1 ID from [dbo].[Countries] WHERE [Name] = 'United Kindgom'));

INSERT INTO [dbo].[RadioStations](Name,CountryID) VALUES('NRJ', (SELECT TOP 1 ID from [dbo].[Countries] WHERE [Name] = 'France'));

INSERT INTO [dbo].[RadioStations](Name,CountryID) VALUES('Radio Plus', (SELECT TOP 1 ID from [dbo].[Countries] WHERE [Name] = 'Poland'));

COMMIT TRANSACTION

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
