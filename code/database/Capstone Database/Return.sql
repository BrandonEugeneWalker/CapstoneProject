CREATE TABLE [dbo].[Return]
(
	[returnId] INT NOT NULL PRIMARY KEY, 
    [memberId] INT NOT NULL, 
    [stockId] INT NOT NULL, 
    [condition] VARCHAR(50) NOT NULL, 
    [description] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Return_Member] FOREIGN KEY ([memberId]) REFERENCES [Member]([memberId]), 
    CONSTRAINT [FK_Return_Stock] FOREIGN KEY ([stockId]) REFERENCES [Stock]([stockId])
)
