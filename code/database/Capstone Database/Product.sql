CREATE TABLE [dbo].[Product]
(
	[productId] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NOT NULL, 
    [description] VARCHAR(300) NOT NULL, 
    [type] VARCHAR(50) NOT NULL
)
