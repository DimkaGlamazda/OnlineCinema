CREATE TABLE [dbo].[Schedule]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATE NOT NULL, 
    [MovieId] INT NOT NULL, 
    [SessionId] INT NOT NULL 
)
