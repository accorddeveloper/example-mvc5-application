﻿USE Example;

BEGIN TRANSACTION
BEGIN TRY

IF EXISTS(SELECT * FROM sys.tables WHERE Name = N'RadioStations')
BEGIN
 DROP TABLE [dbo].[RadioStations];
END

CREATE TABLE [dbo].[RadioStations](
	[ID] uniqueidentifier NOT NULL DEFAULT NEWID(),
	[Name] NVARCHAR(200) NOT NULL,
	[Created] datetime2 NOT NULL DEFAULT GETDATE(),
	[CountryID] uniqueidentifier NOT NULL
 CONSTRAINT [PK_RadioStations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[RadioStations]  WITH CHECK ADD  CONSTRAINT [FK_RadioStations_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID]);

ALTER TABLE [dbo].[RadioStations] CHECK CONSTRAINT [FK_RadioStations_Countries];

COMMIT TRANSACTION

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
END CATCH
