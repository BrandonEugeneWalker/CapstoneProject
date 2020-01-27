CREATE TABLE [dbo].[Member]
(
	[memberId] INT NOT NULL PRIMARY KEY, 
    [username] VARCHAR(50) NOT NULL, 
    [name] VARCHAR(50) NOT NULL, 
    [password] VARCHAR(50) NOT NULL, 
    [isLibrarian] BIT NOT NULL DEFAULT 0, 
    [isBanned] BIT NOT NULL DEFAULT 0
)
