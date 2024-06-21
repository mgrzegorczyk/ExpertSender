IF DB_ID(N'ExpSendDB') IS NULL
BEGIN
    CREATE DATABASE [ExpSendDB];
END;
GO

USE [ExpSendDB];
GO

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

CREATE TABLE [People] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Emails] (
    [Id] int NOT NULL IDENTITY,
    [EmailAddress] nvarchar(max) NOT NULL,
    [PersonId] int NOT NULL,
    CONSTRAINT [PK_Emails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Emails_People_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [People] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Emails_PersonId] ON [Emails] ([PersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240621093940_InitialCreate', N'8.0.6');
GO

COMMIT;
GO
