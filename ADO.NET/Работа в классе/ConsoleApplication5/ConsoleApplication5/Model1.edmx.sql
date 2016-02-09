
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/09/2016 20:38:44
-- Generated from EDMX file: C:\Users\admin\Documents\Visual Studio 2013\Projects\ConsoleApplication5\ConsoleApplication5\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Autos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CarTable2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Table2Set] DROP CONSTRAINT [FK_CarTable2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarSet];
GO
IF OBJECT_ID(N'[dbo].[Table2Set]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Table2Set];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CarSet'
CREATE TABLE [dbo].[CarSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ComplexProperty1_id] int  NOT NULL,
    [ComplexProperty1_name] nvarchar(max)  NOT NULL,
    [Fuel] bigint  NOT NULL
);
GO

-- Creating table 'Table2Set'
CREATE TABLE [dbo].[Table2Set] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [CarId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [PK_CarSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Table2Set'
ALTER TABLE [dbo].[Table2Set]
ADD CONSTRAINT [PK_Table2Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarId] in table 'Table2Set'
ALTER TABLE [dbo].[Table2Set]
ADD CONSTRAINT [FK_CarTable2]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[CarSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarTable2'
CREATE INDEX [IX_FK_CarTable2]
ON [dbo].[Table2Set]
    ([CarId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------