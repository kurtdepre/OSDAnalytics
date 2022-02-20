Use Master

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OSDAnalytics')
BEGIN
    CREATE DATABASE OSDAnalytics
    END;
Go
Use OSDAnalytics
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
CREATE TABLE [MonitoringEntries] (
    [EntryID] nvarchar(450) NOT NULL,
    [Data] nvarchar(max) NULL,
    [StartTime] datetime2 NOT NULL,
    [CompleteTime] datetime2  NULL,
    [isCompleted] bit NOT NULL,
    [isFailed] bit NOT NULL,
    [FailurePoint] nvarchar(max) NULL,
    CONSTRAINT [PK_MonitoringEntries] PRIMARY KEY ([EntryID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220220210446_InitialCreate', N'6.0.2');
GO

COMMIT;
GO

