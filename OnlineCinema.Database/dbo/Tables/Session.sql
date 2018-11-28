CREATE TABLE [dbo].[Session] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (MAX) NOT NULL,
    [TimeFrom] TIME (7)       NOT NULL,
    [TimeTo]   TIME (7)       NOT NULL,
    CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED ([Id] ASC)
);

