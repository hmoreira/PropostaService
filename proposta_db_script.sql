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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250908201421_InitialCreate'
)
BEGIN
    CREATE TABLE [Propostas] (
        [Id] uniqueidentifier NOT NULL,
        [ClienteId] uniqueidentifier NOT NULL,
        [Valor] decimal(18,2) NOT NULL,
        [Status] smallint NOT NULL,
        CONSTRAINT [PK_Propostas] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250908201421_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250908201421_InitialCreate', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250911175006_RemoverClienteId'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Propostas]') AND [c].[name] = N'ClienteId');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Propostas] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Propostas] DROP COLUMN [ClienteId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250911175006_RemoverClienteId'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250911175006_RemoverClienteId', N'9.0.9');
END;

COMMIT;
GO

