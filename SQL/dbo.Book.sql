CREATE TABLE [dbo].[Book] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (60)  NOT NULL,
    [Category]    NVARCHAR (30)  NOT NULL,
    [Author]      NVARCHAR (100) NOT NULL,
    [Price]       FLOAT (53)     NOT NULL,
    [Description] NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC)
);

