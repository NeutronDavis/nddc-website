-- =============================================================================
-- NDDC Website -- Hotfix Patch 001
-- Adds columns missing from the initial CREATE TABLE script.
-- Safe to run against an existing NDDCWebsite database (idempotent).
-- =============================================================================

USE NDDCWebsite;
GO

-- -------------------------------------------------------
-- LiveEvents: add missing event scheduling / display cols
-- -------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[LiveEvents]') AND name = 'StartDate')
BEGIN
    ALTER TABLE [dbo].[LiveEvents] ADD [StartDate] DATETIME NULL;
    PRINT 'LiveEvents.StartDate added.';
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[LiveEvents]') AND name = 'StartTime')
BEGIN
    ALTER TABLE [dbo].[LiveEvents] ADD [StartTime] DATETIME NULL;
    PRINT 'LiveEvents.StartTime added.';
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[LiveEvents]') AND name = 'EndDate')
BEGIN
    ALTER TABLE [dbo].[LiveEvents] ADD [EndDate] DATETIME NULL;
    PRINT 'LiveEvents.EndDate added.';
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[LiveEvents]') AND name = 'EndTime')
BEGIN
    ALTER TABLE [dbo].[LiveEvents] ADD [EndTime] DATETIME NULL;
    PRINT 'LiveEvents.EndTime added.';
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[LiveEvents]') AND name = 'ShowOnHomePage')
BEGIN
    ALTER TABLE [dbo].[LiveEvents] ADD [ShowOnHomePage] BIT NULL;
    PRINT 'LiveEvents.ShowOnHomePage added.';
END
GO

-- -------------------------------------------------------
-- ExecMngt: add PositionCount used for board member sort
-- -------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[ExecMngt]') AND name = 'PositionCount')
BEGIN
    ALTER TABLE [dbo].[ExecMngt] ADD [PositionCount] INT NULL;
    PRINT 'ExecMngt.PositionCount added.';
END
GO

-- -------------------------------------------------------
-- Directors: add PositionCount and DateAdded columns
-- -------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Directors]') AND name = 'PositionCount')
BEGIN
    ALTER TABLE [dbo].[Directors] ADD [PositionCount] INT NULL;
    PRINT 'Directors.PositionCount added.';
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Directors]') AND name = 'DateAdded')
BEGIN
    ALTER TABLE [dbo].[Directors] ADD [DateAdded] DATETIME NULL;
    PRINT 'Directors.DateAdded added.';
END
GO

PRINT '========================================';
PRINT 'Hotfix Patch 001 applied successfully.';
PRINT '========================================';
GO
