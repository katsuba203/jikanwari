CREATE TABLE [dbo].[Jyugyou] (
    [Id]           INT          NOT NULL IDENTITY,
    [jyugyouName]  VARCHAR (50) NULL,
    [kyousitu]     VARCHAR (50) NULL,
    [kousi]        VARCHAR (50) NULL,
    [NGyoubi]      VARCHAR (50) NULL,
    [jyugyouClass] VARCHAR (50) NULL,
    [kousiID]      INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Jyugyou_kousi] FOREIGN KEY ([kousiID]) REFERENCES [dbo].[Kousi] ([kousiID])
);

