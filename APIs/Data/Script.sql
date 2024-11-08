USE [master]
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'UserForgeDB')
BEGIN
    CREATE DATABASE [UserForgeDB]
    CONTAINMENT = NONE
    ON PRIMARY 
    ( NAME = N'UserForgeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\UserForgeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
    LOG ON 
    ( NAME = N'UserForgeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\UserForgeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END
GO

USE UserForgeDB
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE [dbo].[Users](
        [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
        [Name] [nvarchar](max) NOT NULL,
        [Email] [nvarchar](max) NOT NULL,
        [Password] [nvarchar](max) NOT NULL,
        [Created] [datetime] NOT NULL,
        [Modified] [datetime] NOT NULL,
        [LastLogin] [datetime] NOT NULL,
        [Token] [nvarchar](max) NOT NULL,
        [IsActive] [bit] NOT NULL
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Phones')
BEGIN
    CREATE TABLE [dbo].[Phones](
        [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Number] [nvarchar](max) NOT NULL,
        [CityCode] [nvarchar](max) NOT NULL,
        [CountryCode] [nvarchar](max) NOT NULL,
        [UserId] [uniqueidentifier] NULL,
        CONSTRAINT [FK_Phones_Users_UserId] FOREIGN KEY([UserId])
        REFERENCES [dbo].[Users] ([Id])
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
