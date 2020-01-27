CREATE TABLE [dbo].[Employee]
(
	[employeId] INT NOT NULL PRIMARY KEY, 
    [password] VARCHAR(50) NOT NULL, 
    [isManager] BIT NOT NULL DEFAULT 0, 
    [name] VARCHAR(50) NOT NULL
)
