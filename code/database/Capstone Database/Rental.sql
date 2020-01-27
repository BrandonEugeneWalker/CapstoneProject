CREATE TABLE [dbo].[Rental]
(
	[rentalId] INT NOT NULL PRIMARY KEY, 
    [stockId] INT NOT NULL, 
    [memberId] INT NOT NULL, 
    CONSTRAINT [FK_Rental_Stock] FOREIGN KEY ([stockId]) REFERENCES [Stock]([stockId]), 
    CONSTRAINT [FK_Rental_Member] FOREIGN KEY ([memberId]) REFERENCES [Member]([memberId])
)
