CREATE DATABASE Example;

GO

CREATE LOGIN ExampleUser WITH PASSWORD = 'Example123!';

GO

USE Example;

GO

CREATE USER ExampleUser FOR LOGIN ExampleUser

GO

EXEC sp_addrolemember N'db_owner', N'ExampleUser'

GO

GRANT EXEC TO ExampleUser;

GO

CREATE DATABASE ExampleDatabaseTests;

GO

USE ExampleDatabaseTests;

GO

CREATE USER ExampleUser FOR LOGIN ExampleUser;

GO

EXEC sp_addrolemember N'db_owner', N'ExampleUser'

GO

GRANT EXEC TO ExampleUser;

GO