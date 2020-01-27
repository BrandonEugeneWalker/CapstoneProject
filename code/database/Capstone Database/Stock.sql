CREATE TABLE [dbo].[Stock]
(
	[stockId] INT NOT NULL PRIMARY KEY, 
    [productId] INT NOT NULL, 
    CONSTRAINT [FK_Stock_To_Product] FOREIGN KEY ([productId]) REFERENCES [Product]([productId])
)
