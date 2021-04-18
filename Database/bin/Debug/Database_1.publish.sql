﻿/*
Deployment script for CaseLaw

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "CaseLaw"
:setvar DefaultFilePrefix "CaseLaw"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Dropping [dbo].[FK_JudmentDocument_Report]...';


GO
ALTER TABLE [dbo].[JudmentDocument] DROP CONSTRAINT [FK_JudmentDocument_Report];


GO
PRINT N'Dropping [dbo].[FK_JudmentDocument_Minister]...';


GO
ALTER TABLE [dbo].[JudmentDocument] DROP CONSTRAINT [FK_JudmentDocument_Minister];


GO
PRINT N'Dropping [dbo].[FK_Report_Minister]...';


GO
ALTER TABLE [dbo].[Report] DROP CONSTRAINT [FK_Report_Minister];


GO
PRINT N'Starting rebuilding table [dbo].[JudmentDocument]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_JudmentDocument] (
    [ID]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [ProcessNumber] BIGINT         NULL,
    [JudmentText]   NVARCHAR (MAX) NULL,
    [DecisionText]  NVARCHAR (MAX) NULL,
    [Report]        BIGINT         NULL,
    [Minister]      BIGINT         NULL,
    [MinisterName]  NVARCHAR (MAX) NULL,
    [RawText]       NVARCHAR (MAX) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_JudmentDocument1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[JudmentDocument])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_JudmentDocument] ON;
        INSERT INTO [dbo].[tmp_ms_xx_JudmentDocument] ([ID], [ProcessNumber], [JudmentText], [DecisionText], [Report], [Minister], [MinisterName], [RawText])
        SELECT   [ID],
                 [ProcessNumber],
                 [JudmentText],
                 [DecisionText],
                 [Report],
                 [Minister],
                 [MinisterName],
                 [RawText]
        FROM     [dbo].[JudmentDocument]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_JudmentDocument] OFF;
    END

DROP TABLE [dbo].[JudmentDocument];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_JudmentDocument]', N'JudmentDocument';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_JudmentDocument1]', N'PK_JudmentDocument', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Minister]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Minister] (
    [ID]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Minister1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Minister])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Minister] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Minister] ([ID], [Name])
        SELECT   [ID],
                 [Name]
        FROM     [dbo].[Minister]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Minister] OFF;
    END

DROP TABLE [dbo].[Minister];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Minister]', N'Minister';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Minister1]', N'PK_Minister', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Party]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Party] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [Type]            NVARCHAR (MAX) NULL,
    [JudmentDocument] BIGINT         NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Party1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Party])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Party] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Party] ([ID], [Name], [Type])
        SELECT   [ID],
                 [Name],
                 [Type]
        FROM     [dbo].[Party]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Party] OFF;
    END

DROP TABLE [dbo].[Party];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Party]', N'Party';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Party1]', N'PK_Party', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Report]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Report] (
    [ID]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [Text]     NVARCHAR (MAX) NULL,
    [Reporter] NVARCHAR (MAX) NULL,
    [Minister] BIGINT         NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Report1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Report])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Report] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Report] ([ID], [Text], [Minister])
        SELECT   [ID],
                 [Text],
                 [Minister]
        FROM     [dbo].[Report]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Report] OFF;
    END

DROP TABLE [dbo].[Report];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Report]', N'Report';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Report1]', N'PK_Report', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Vote]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Vote] (
    [ID]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [Text]            NVARCHAR (MAX) NULL,
    [JudmentDocument] BIGINT         NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Vote1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Vote])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Vote] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Vote] ([ID], [Text])
        SELECT   [ID],
                 [Text]
        FROM     [dbo].[Vote]
        ORDER BY [ID] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Vote] OFF;
    END

DROP TABLE [dbo].[Vote];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Vote]', N'Vote';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Vote1]', N'PK_Vote', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[FK_JudmentDocument_Report]...';


GO
ALTER TABLE [dbo].[JudmentDocument] WITH NOCHECK
    ADD CONSTRAINT [FK_JudmentDocument_Report] FOREIGN KEY ([Report]) REFERENCES [dbo].[Report] ([ID]);


GO
PRINT N'Creating [dbo].[FK_JudmentDocument_Minister]...';


GO
ALTER TABLE [dbo].[JudmentDocument] WITH NOCHECK
    ADD CONSTRAINT [FK_JudmentDocument_Minister] FOREIGN KEY ([Minister]) REFERENCES [dbo].[Minister] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Party_JudmentDocument]...';


GO
ALTER TABLE [dbo].[Party] WITH NOCHECK
    ADD CONSTRAINT [FK_Party_JudmentDocument] FOREIGN KEY ([JudmentDocument]) REFERENCES [dbo].[JudmentDocument] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Report_Minister]...';


GO
ALTER TABLE [dbo].[Report] WITH NOCHECK
    ADD CONSTRAINT [FK_Report_Minister] FOREIGN KEY ([Minister]) REFERENCES [dbo].[Report] ([ID]);


GO
PRINT N'Creating [dbo].[FK_Vote_JudmentDocument]...';


GO
ALTER TABLE [dbo].[Vote] WITH NOCHECK
    ADD CONSTRAINT [FK_Vote_JudmentDocument] FOREIGN KEY ([JudmentDocument]) REFERENCES [dbo].[JudmentDocument] ([ID]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[JudmentDocument] WITH CHECK CHECK CONSTRAINT [FK_JudmentDocument_Report];

ALTER TABLE [dbo].[JudmentDocument] WITH CHECK CHECK CONSTRAINT [FK_JudmentDocument_Minister];

ALTER TABLE [dbo].[Party] WITH CHECK CHECK CONSTRAINT [FK_Party_JudmentDocument];

ALTER TABLE [dbo].[Report] WITH CHECK CHECK CONSTRAINT [FK_Report_Minister];

ALTER TABLE [dbo].[Vote] WITH CHECK CHECK CONSTRAINT [FK_Vote_JudmentDocument];


GO
PRINT N'Update complete.';


GO