CREATE DATABASE Example;

GO

CREATE LOGIN ExampleUser WITH PASSWORD = 'Example123!';

GO

USE Example;

GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'ExampleUser')
BEGIN
    CREATE USER ExampleUser FOR LOGIN ExampleUser
    EXEC sp_addrolemember N'db_owner', N'ExampleUser'
END;

GO

GRANT EXEC TO ExampleUser;

GO
