-- =============================================================================
-- NDDC Website -- Hotfix Patch 002
-- Adds the ASP.NET Core Data Protection key store table.
-- Safe to run against an existing NDDCWebsite database (idempotent).
--
-- WHY: the web app runs in a container with an ephemeral filesystem, so the
-- default key ring (~/.aspnet/DataProtection-Keys) is destroyed on every
-- deploy/restart. Program.cs now calls PersistKeysToDbContext, which reads and
-- writes the key ring to this table so it survives redeploys.
--
-- The table is created empty on purpose. Existing antiforgery cookies signed
-- by the old, now-lost key ring are simply discarded -- users receive a fresh
-- cookie on their next page load, so no migration of live data is required.
-- =============================================================================

USE NDDCWebsite;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[DataProtectionKeys]'))
BEGIN
    CREATE TABLE [dbo].[DataProtectionKeys] (
        [Id]         INT IDENTITY (1, 1) NOT NULL,
        [FriendlyName] NVARCHAR (512)   NULL,
        [Xml]        NVARCHAR (MAX)     NOT NULL,
        CONSTRAINT [PK_DataProtectionKeys] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
    PRINT 'DataProtectionKeys table created.';
END
ELSE
BEGIN
    PRINT 'DataProtectionKeys table already exists -- no change.';
END
GO
