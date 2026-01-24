IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Articles] (
    [ArticleId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [Tags] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260123035228_V0', N'8.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tags] DROP CONSTRAINT [PK_Tags];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tags]') AND [c].[name] = N'TagId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tags] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tags] DROP COLUMN [TagId];
GO

ALTER TABLE [Tags] ADD [TagIDNew] int NOT NULL IDENTITY;
GO

ALTER TABLE [Tags] ADD CONSTRAINT [PK_Tags] PRIMARY KEY ([TagIDNew]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260123042337_V1-remove-TagId-field', N'8.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Tags].[TagIDNew]', N'TagID', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260123042511_V2-rename-TagID-field', N'8.0.23');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ArticleTags] (
    [ArticleTagID] int NOT NULL IDENTITY,
    [TagID] int NOT NULL,
    [ArticleID] int NOT NULL,
    CONSTRAINT [PK_ArticleTags] PRIMARY KEY ([ArticleTagID]),
    CONSTRAINT [FK_ArticleTags_Articles_ArticleID] FOREIGN KEY ([ArticleID]) REFERENCES [Articles] ([ArticleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArticleTags_Tags_TagID] FOREIGN KEY ([TagID]) REFERENCES [Tags] ([TagID]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_ArticleTags_ArticleID_TagID] ON [ArticleTags] ([ArticleID], [TagID]);
GO

CREATE INDEX [IX_ArticleTags_TagID] ON [ArticleTags] ([TagID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260124022506_V3', N'8.0.23');
GO

COMMIT;
GO

