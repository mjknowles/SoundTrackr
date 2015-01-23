CREATE TABLE [dbo].[SongCoord] (
    [songCoordId] INT               IDENTITY (1, 1) NOT NULL,
    [songId]      INT               NULL,
    [coord]       [sys].[geography] NULL,
    PRIMARY KEY CLUSTERED ([songCoordId] ASC)
);

