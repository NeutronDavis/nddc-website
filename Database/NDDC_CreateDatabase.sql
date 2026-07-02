-- =============================================================================
-- NDDC Website Database Setup Script
-- Generated from EFCore-Lib Models (NDDCWebsiteContext)
-- Compatible with: Microsoft SQL Server 2016+
-- =============================================================================

USE master;
GO

-- -------------------------------------------------------
-- Create Database (skip if it already exists)
-- -------------------------------------------------------
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'NDDCWebsite')
BEGIN
    CREATE DATABASE NDDCWebsite
        COLLATE SQL_Latin1_General_CP1_CI_AS;
    PRINT 'Database NDDCWebsite created.';
END
ELSE
    PRINT 'Database NDDCWebsite already exists -- skipping creation.';
GO

USE NDDCWebsite;
GO

-- =============================================================================
-- SECTION 1: ASP.NET Membership / Providers tables
--   (legacy ASP.NET membership tables, no explicit PKs in the EF model)
-- =============================================================================

-- aspnet_Applications
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_Applications] (
        [ApplicationName]        NVARCHAR(256)    NULL,
        [LoweredApplicationName] NVARCHAR(256)    NULL,
        [ApplicationId]          UNIQUEIDENTIFIER NOT NULL,
        [Description]            NVARCHAR(256)    NULL
    );
    PRINT 'Table aspnet_Applications created.';
END
GO

-- aspnet_Users
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_Users] (
        [ApplicationId]   UNIQUEIDENTIFIER NOT NULL,
        [UserId]          UNIQUEIDENTIFIER NOT NULL,
        [UserName]        NVARCHAR(256)    NOT NULL,
        [LoweredUserName] NVARCHAR(256)    NOT NULL,
        [MobileAlias]     NVARCHAR(16)     NULL,
        [IsAnonymous]     BIT              NOT NULL DEFAULT 0,
        [LastActivityDate] DATETIME        NOT NULL
    );
    PRINT 'Table aspnet_Users created.';
END
GO

-- aspnet_Membership
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_Membership] (
        [ApplicationId]                          UNIQUEIDENTIFIER NOT NULL,
        [UserId]                                 UNIQUEIDENTIFIER NOT NULL,
        [Password]                               NVARCHAR(128)    NOT NULL,
        [PasswordFormat]                         INT              NOT NULL,
        [PasswordSalt]                           NVARCHAR(128)    NOT NULL,
        [MobilePIN]                              NVARCHAR(16)     NULL,
        [Email]                                  NVARCHAR(256)    NULL,
        [LoweredEmail]                           NVARCHAR(256)    NULL,
        [PasswordQuestion]                       NVARCHAR(256)    NULL,
        [PasswordAnswer]                         NVARCHAR(128)    NULL,
        [IsApproved]                             BIT              NOT NULL,
        [IsLockedOut]                            BIT              NOT NULL,
        [CreateDate]                             DATETIME         NOT NULL,
        [LastLoginDate]                          DATETIME         NOT NULL,
        [LastPasswordChangedDate]                DATETIME         NOT NULL,
        [LastLockoutDate]                        DATETIME         NOT NULL,
        [FailedPasswordAttemptCount]             INT              NOT NULL,
        [FailedPasswordAttemptWindowStart]       DATETIME         NOT NULL,
        [FailedPasswordAnswerAttemptCount]       INT              NOT NULL,
        [FailedPasswordAnswerAttemptWindowStart] DATETIME         NOT NULL,
        [Comment]                                NTEXT            NULL
    );
    PRINT 'Table aspnet_Membership created.';
END
GO

-- aspnet_Roles
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_Roles] (
        [ApplicationId]   UNIQUEIDENTIFIER NOT NULL,
        [RoleId]          UNIQUEIDENTIFIER NOT NULL,
        [RoleName]        NVARCHAR(256)    NOT NULL,
        [LoweredRoleName] NVARCHAR(256)    NOT NULL,
        [Description]     NVARCHAR(256)    NULL
    );
    PRINT 'Table aspnet_Roles created.';
END
GO

-- aspnet_UsersInRoles
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_UsersInRoles] (
        [UserId] UNIQUEIDENTIFIER NOT NULL,
        [RoleId] UNIQUEIDENTIFIER NOT NULL
    );
    PRINT 'Table aspnet_UsersInRoles created.';
END
GO

-- aspnet_Paths
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_Paths] (
        [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
        [PathId]        UNIQUEIDENTIFIER NOT NULL,
        [Path]          NVARCHAR(256)    NULL,
        [LoweredPath]   NVARCHAR(256)    NULL
    );
    PRINT 'Table aspnet_Paths created.';
END
GO

-- aspnet_PersonalizationAllUsers
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers] (
        [PathId]          UNIQUEIDENTIFIER NOT NULL,
        [PageSettings]    IMAGE            NULL,
        [LastUpdatedDate] DATETIME         NULL
    );
    PRINT 'Table aspnet_PersonalizationAllUsers created.';
END
GO

-- aspnet_PersonalizationPerUser
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_PersonalizationPerUser] (
        [Id]              UNIQUEIDENTIFIER NOT NULL,
        [PathId]          UNIQUEIDENTIFIER NULL,
        [UserId]          UNIQUEIDENTIFIER NULL,
        [PageSettings]    IMAGE            NULL,
        [LastUpdatedDate] DATETIME         NULL
    );
    PRINT 'Table aspnet_PersonalizationPerUser created.';
END
GO

-- aspnet_Profile
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_Profile] (
        [UserId]               UNIQUEIDENTIFIER NOT NULL,
        [PropertyNames]        NTEXT            NULL,
        [PropertyValuesString] NTEXT            NULL,
        [PropertyValuesBinary] IMAGE            NULL,
        [LastUpdatedDate]      DATETIME         NULL
    );
    PRINT 'Table aspnet_Profile created.';
END
GO

-- aspnet_SchemaVersions
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_SchemaVersions] (
        [Feature]                 NVARCHAR(128) NULL,
        [CompatibleSchemaVersion] NVARCHAR(128) NULL,
        [IsCurrentVersion]        BIT           NULL
    );
    PRINT 'Table aspnet_SchemaVersions created.';
END
GO

-- aspnet_WebEvent_Events
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[aspnet_WebEvent_Events] (
        [EventId]                CHAR(32)        NOT NULL,
        [EventTimeUtc]           DATETIME        NULL,
        [EventTime]              DATETIME        NULL,
        [EventType]              NVARCHAR(256)   NULL,
        [EventSequence]          DECIMAL(19, 0)  NULL,
        [EventOccurrence]        DECIMAL(19, 0)  NULL,
        [EventCode]              INT             NULL,
        [EventDetailCode]        INT             NULL,
        [Message]                NVARCHAR(1024)  NULL,
        [ApplicationPath]        NVARCHAR(256)   NULL,
        [ApplicationVirtualPath] NVARCHAR(256)   NULL,
        [MachineName]            NVARCHAR(256)   NULL,
        [RequestUrl]             NVARCHAR(1024)  NULL,
        [ExceptionType]          NVARCHAR(256)   NULL,
        [Details]                NTEXT           NULL
    );
    PRINT 'Table aspnet_WebEvent_Events created.';
END
GO


-- =============================================================================
-- SECTION 2: NDDC Application Tables
-- =============================================================================

-- Announcements
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Announcements]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Announcements] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Announcements] PRIMARY KEY,
        [Title]     NVARCHAR(350) NULL,
        [StartDate] DATETIME      NULL,
        [EndDate]   DATETIME      NULL,
        [Details]   TEXT          NULL,
        [DateAdded] DATETIME      NULL,
        [AddedBy]   NVARCHAR(100) NULL
    );
    PRINT 'Table Announcements created.';
END
GO

-- Compliants
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Compliants]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Compliants] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Compliants] PRIMARY KEY,
        [Name]      NVARCHAR(100) NULL,
        [Email]     NVARCHAR(100) NULL,
        [Phone]     NVARCHAR(50)  NULL,
        [Location]  NVARCHAR(100) NULL,
        [Title]     NVARCHAR(150) NULL,
        [Message]   TEXT          NULL,
        [DateAdded] DATETIME      NULL
    );
    PRINT 'Table Compliants created.';
END
GO

-- Directors
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Directors]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Directors] (
        [Id]            INT             NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Directors] PRIMARY KEY,
        [DirectorName]  NVARCHAR(150)   NULL,
        [Position]      NVARCHAR(250)   NULL,
        [ImageUrl]      NVARCHAR(150)   NULL,
        [Details]       TEXT            NULL,
        [PositionCount] INT             NULL,
        [DateAdded]     DATETIME        NULL,
        [AddedBy]       NVARCHAR(100)   NULL
    );
    PRINT 'Table Directors created.';
END
GO

-- EventSpeakers
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventSpeakers]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[EventSpeakers] (
        [Id]               INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_EventSpeakers] PRIMARY KEY,
        [Title]            NVARCHAR(50)  NULL,
        [FirstName]        NVARCHAR(50)  NULL,
        [LastName]         NVARCHAR(50)  NULL,
        [OtherNames]       NVARCHAR(100) NULL,
        [Occupation]       NVARCHAR(150) NULL,
        [Email]            NVARCHAR(150) NULL,
        [Phone]            NVARCHAR(50)  NULL,
        [TwitterHandle]    NVARCHAR(150) NULL,
        [EventDesignation] NVARCHAR(50)  NULL,
        [SpeakerPhoto]     NVARCHAR(50)  NULL,
        [EventId]          INT           NULL,
        [CreatedBy]        NVARCHAR(100) NULL
    );
    PRINT 'Table EventSpeakers created.';
END
GO

-- ExecMngt
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExecMngt]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[ExecMngt] (
        [EMID]          INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_ExecMngt] PRIMARY KEY,
        [ExecName]      NVARCHAR(450) NULL,
        [Position]      NVARCHAR(450) NULL,
        [Details]       TEXT          NULL,
        [ImageUrl]      NVARCHAR(750) NULL,
        [Facebook]      NVARCHAR(750) NULL,
        [Twitter]       NVARCHAR(750) NULL,
        [Instagram]     NVARCHAR(750) NULL,
        [PositionCount] INT           NULL,
        [SortOrder]     INT           NULL
    );
    PRINT 'Table ExecMngt created.';
END
GO

-- Inquiry
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inquiry]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Inquiry] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Inquiry] PRIMARY KEY,
        [Name]      NVARCHAR(100) NULL,
        [Email]     NVARCHAR(100) NULL,
        [Phone]     NVARCHAR(50)  NULL,
        [Location]  NVARCHAR(100) NULL,
        [Type]      NVARCHAR(150) NULL,
        [Message]   TEXT          NULL,
        [DateAdded] DATETIME      NULL
    );
    PRINT 'Table Inquiry created.';
END
GO

-- IReports
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IReports]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[IReports] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_IReports] PRIMARY KEY,
        [Type]      NVARCHAR(100) NULL,
        [Title]     NVARCHAR(150) NULL,
        [Name]      NVARCHAR(150) NULL,
        [Email]     NVARCHAR(100) NULL,
        [Phone]     NVARCHAR(50)  NULL,
        [State]     NVARCHAR(50)  NULL,
        [Location]  NVARCHAR(150) NULL,
        [VideoUrl]  NVARCHAR(150) NULL,
        [DateAdded] DATETIME      NULL,
        [Comment]   TEXT          NULL,
        [ImageUrl1] NVARCHAR(100) NULL,
        [ImageUrl2] NVARCHAR(100) NULL,
        [ImageUrl3] NVARCHAR(100) NULL,
        [ImageUrl4] NVARCHAR(100) NULL
    );
    PRINT 'Table IReports created.';
END
GO

-- IReportImages
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IReportImages]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[IReportImages] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_IReportImages] PRIMARY KEY,
        [IReportId] INT           NULL,
        [ImageUrl]  NVARCHAR(150) NULL
    );
    PRINT 'Table IReportImages created.';
END
GO

-- LiveEvents
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LiveEvents]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[LiveEvents] (
        [Id]             INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_LiveEvents] PRIMARY KEY,
        [Title]          NVARCHAR(350) NULL,
        [Theme]          NVARCHAR(450) NULL,
        [Summary]        NVARCHAR(550) NULL,
        [Details]        TEXT          NULL,
        [BannerImage]    NVARCHAR(50)  NULL,
        [TrailerVideo]   NVARCHAR(250) NULL,
        [LiveEventLink]  TEXT          NULL,
        [StartDate]      DATETIME      NULL,
        [StartTime]      DATETIME      NULL,
        [EndDate]        DATETIME      NULL,
        [EndTime]        DATETIME      NULL,
        [ShowOnHomePage] BIT           NULL,
        [IsLive]         BIT           NULL,
        [CreatedBy]      NVARCHAR(100) NULL,
        [DateCreated]    DATETIME      NULL
    );
    PRINT 'Table LiveEvents created.';
END
GO

-- MngtStaff
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MngtStaff]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[MngtStaff] (
        [MSID]      INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_MngtStaff] PRIMARY KEY,
        [StaffName] NVARCHAR(450) NULL,
        [Position]  NVARCHAR(750) NULL,
        [ImageUrl]  NVARCHAR(750) NULL,
        [SortOrder] INT           NULL
    );
    PRINT 'Table MngtStaff created.';
END
GO

-- MyFile
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyFile]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[MyFile] (
        [FileID]      INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_MyFile] PRIMARY KEY,
        [FileName]    NVARCHAR(450) NULL,
        [FileNo]      NVARCHAR(150) NULL,
        [Figure]      MONEY         NULL,
        [DateCreated] DATETIME      NULL,
        [CreatedBy]   NVARCHAR(50)  NULL
    );
    PRINT 'Table MyFile created.';
END
GO

-- MyManifest
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyManifest]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[MyManifest] (
        [Man_ID]       INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_MyManifest] PRIMARY KEY,
        [Man_Desc]     NVARCHAR(450) NULL,
        [FileType]     NVARCHAR(150) NULL,
        [Flow]         NVARCHAR(50)  NULL,
        [ItemID]       INT           NULL,
        [DateReceived] DATETIME      NULL,
        [ReceivedBy]   NVARCHAR(50)  NULL
    );
    PRINT 'Table MyManifest created.';
END
GO

-- NewsDepartment
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsDepartment]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[NewsDepartment] (
        [NDID]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_NewsDepartment] PRIMARY KEY,
        [DeptName]    NVARCHAR(350) NULL,
        [DateCreated] DATETIME      NULL,
        [CreatedBy]   NVARCHAR(150) NULL
    );
    PRINT 'Table NewsDepartment created.';
END
GO

-- News
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[News]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[News] (
        [NID]           INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_News] PRIMARY KEY,
        [Subject]       NVARCHAR(350) NULL,
        [Summary]       TEXT          NULL,
        [Details]       TEXT          NULL,
        [NewsID]        NVARCHAR(50)  NULL,
        [ImageUrl]      NVARCHAR(350) NULL,
        [PublishDate]   DATETIME      NULL,
        [ExpiryDate]    DATETIME      NULL,
        [TimeStamp]     BIT           NULL,
        [Enabled]       BIT           NULL,
        [Type]          NVARCHAR(50)  NULL,
        [SetAsSlide]    BIT           NULL,
        [Tags]          NVARCHAR(450) NULL,
        [Archive]       BIT           NULL,
        [Views]         INT           NULL,
        [Clicks]        INT           NULL,
        [NDID]          INT           NULL,
        [CMID]          INT           NULL,
        [DateCreated]   DATETIME      NULL,
        [CreatedBy]     NVARCHAR(150) NULL,
        [DisplayFormat] NVARCHAR(50)  NULL
    );
    PRINT 'Table News created.';
END
GO

-- NewsPhotoGallery
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsPhotoGallery]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[NewsPhotoGallery] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_NewsPhotoGallery] PRIMARY KEY,
        [NewsId]    INT           NULL,
        [ImageUrl]  NVARCHAR(150) NULL,
        [DateAdded] DATETIME      NULL,
        [AddedBy]   NVARCHAR(100) NULL
    );
    PRINT 'Table NewsPhotoGallery created.';
END
GO

-- Offices
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Offices] (
        [OffID]      INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Offices] PRIMARY KEY,
        [OfficeName] NVARCHAR(450) NULL,
        [Location]   NVARCHAR(250) NULL,
        [Address]    NVARCHAR(750) NULL,
        [Phone]      NVARCHAR(50)  NULL,
        [Email]      NVARCHAR(250) NULL,
        [ImageUrl]   NVARCHAR(750) NULL
    );
    PRINT 'Table Offices created.';
END
GO

-- Organization  (HasNoKey in EF -- no PK enforced)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organization]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Organization] (
        [OID]                       INT           NULL,
        [Mission]                   TEXT          NULL,
        [Vision]                    TEXT          NULL,
        [Creed]                     TEXT          NULL,
        [Email]                     NVARCHAR(450) NULL,
        [Phone]                     NVARCHAR(50)  NULL,
        [Address]                   NVARCHAR(750) NULL,
        [LogoUrl]                   NVARCHAR(750) NULL,
        [Facebook]                  NVARCHAR(750) NULL,
        [Twitter]                   NVARCHAR(750) NULL,
        [Linkdin]                   NVARCHAR(750) NULL,
        [Instagram]                 NVARCHAR(750) NULL,
        [MasterPlan]                TEXT          NULL,
        [OfficeGPSCordinates]       NVARCHAR(350) NULL,
        [RiversStateOfficeAdd]      TEXT          NULL,
        [RiversStateOfficeGPS]      NVARCHAR(50)  NULL,
        [DeltaStateOfficeAdd]       TEXT          NULL,
        [DeltaStateOfficeGPS]       NVARCHAR(50)  NULL,
        [AkwaIbomStateOfficeAdd]    TEXT          NULL,
        [AkwaIbomStateOfficeGPS]    NVARCHAR(50)  NULL,
        [CrossRiversStateIfficeAdd] TEXT          NULL,
        [CrossRIversStateOfficeGPS] NVARCHAR(50)  NULL,
        [AbiaStateOfficeAdd]        TEXT          NULL,
        [AbiaStateOfficeGPS]        NVARCHAR(50)  NULL,
        [BayelsaStateOfficeAdd]     TEXT          NULL,
        [BayelsaStateOfficeGPS]     NVARCHAR(50)  NULL,
        [OndoStateOfficeAdd]        TEXT          NULL,
        [OndoStateOfficeGPS]        NVARCHAR(50)  NULL,
        [EdoStateOfficeAdd]         TEXT          NULL,
        [EdoStateOfficeGPS]         NVARCHAR(50)  NULL,
        [ImoStateOfficeAdd]         TEXT          NULL,
        [ImoStateOfficeGPS]         NVARCHAR(50)  NULL
    );
    PRINT 'Table Organization created.';
END
GO

-- Pages
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pages]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Pages] (
        [PageID]      INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Pages] PRIMARY KEY,
        [PageName]    NVARCHAR(250) NULL,
        [PageContent] TEXT          NULL,
        [RedirectUrl] NVARCHAR(250) NULL,
        [DateCreated] DATE          NULL,
        [CreatedBy]   NVARCHAR(50)  NULL
    );
    PRINT 'Table Pages created.';
END
GO

-- PhotoSpeak
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhotoSpeak]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[PhotoSpeak] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_PhotoSpeak] PRIMARY KEY,
        [Title]     NVARCHAR(250) NULL,
        [ImageUrl]  NVARCHAR(250) NULL,
        [Location]  NVARCHAR(250) NULL,
        [DateAdded] DATETIME      NULL,
        [AddedBy]   NVARCHAR(150) NULL
    );
    PRINT 'Table PhotoSpeak created.';
END
GO

-- Positions
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Positions]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Positions] (
        [PosID]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Positions] PRIMARY KEY,
        [PositionName] NVARCHAR(350) NULL,
        [Category]     NVARCHAR(150) NULL
    );
    PRINT 'Table Positions created.';
END
GO

-- Programs  (separate entity from News, same structure)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Programs]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Programs] (
        [NID]         INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Programs] PRIMARY KEY,
        [Subject]     NVARCHAR(350) NULL,
        [Summary]     NVARCHAR(650) NULL,
        [Details]     TEXT          NULL,
        [NewsID]      NVARCHAR(50)  NULL,
        [ImageUrl]    NVARCHAR(350) NULL,
        [PublishDate] DATETIME      NULL,
        [ExpiryDate]  DATETIME      NULL,
        [TimeStamp]   BIT           NULL,
        [Enabled]     BIT           NULL,
        [Type]        NVARCHAR(50)  NULL,
        [SetAsSlide]  BIT           NULL,
        [Tags]        NVARCHAR(450) NULL,
        [Archive]     BIT           NULL,
        [Views]       INT           NULL,
        [Clicks]      INT           NULL,
        [NDID]        INT           NULL,
        [CMID]        INT           NULL,
        [DateCreated] DATETIME      NULL,
        [CreatedBy]   NVARCHAR(150) NULL
    );
    PRINT 'Table Programs created.';
END
GO

-- ProjectList
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectList]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[ProjectList] (
        [PID]         INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_ProjectList] PRIMARY KEY,
        [Description] NVARCHAR(550) NULL,
        [Type]        NVARCHAR(150) NULL,
        [State]       NVARCHAR(150) NULL,
        [LGA]         NVARCHAR(250) NULL,
        [Location]    NVARCHAR(450) NULL,
        [Contractor]  NVARCHAR(250) NULL,
        [ContractSum] MONEY         NULL,
        [DateOfAward] NVARCHAR(50)  NULL,
        [Status]      NVARCHAR(50)  NULL
    );
    PRINT 'Table ProjectList created.';
END
GO

-- State  (created before ProjectLocation / SkillsApplications which reference SID)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[State] (
        [SID]       INT           NOT NULL CONSTRAINT [PK_State] PRIMARY KEY,  -- ValueGeneratedNever
        [StateName] NVARCHAR(100) NULL,
        [StateType] NVARCHAR(50)  NULL
    );
    PRINT 'Table State created.';
END
GO

-- ProjectLocation
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectLocation]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[ProjectLocation] (
        [PLID]       INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_ProjectLocation] PRIMARY KEY,
        [Location]   NVARCHAR(100) NULL,
        [StrField1]  NVARCHAR(400) NULL,
        [strField2]  NVARCHAR(400) NULL,
        [strField3]  NVARCHAR(400) NULL,
        [strField4]  NVARCHAR(400) NULL,
        [strField5]  NVARCHAR(400) NULL,
        [txtField1]  TEXT          NULL,
        [txtField2]  TEXT          NULL,
        [txtField3]  TEXT          NULL,
        [intField1]  INT           NULL,
        [intField2]  INT           NULL,
        [intField3]  INT           NULL,
        [intField4]  INT           NULL,
        [intField5]  INT           NULL,
        [dateField1] DATE          NULL,
        [dateField2] DATE          NULL,
        [dateField3] DATE          NULL,
        [SID]        INT           NULL
    );
    PRINT 'Table ProjectLocation created.';
END
GO

-- Publications
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Publications]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Publications] (
        [PubId]         INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Publications] PRIMARY KEY,
        [PubTitle]      NVARCHAR(250) NULL,
        [PubSummary]    NVARCHAR(550) NULL,
        [PubThumbImage] NVARCHAR(450) NULL,
        [PubUploadUrl]  NVARCHAR(450) NULL,
        [DateUploaded]  DATETIME      NULL,
        [UploadedBy]    NVARCHAR(150) NULL
    );
    PRINT 'Table Publications created.';
END
GO

-- SightsAndIcons
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SightsAndIcons]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[SightsAndIcons] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_SightsAndIcons] PRIMARY KEY,
        [Title]     NVARCHAR(350) NULL,
        [Summary]   NVARCHAR(500) NULL,
        [Details]   TEXT          NULL,
        [ImageUrl]  NVARCHAR(150) NULL,
        [DateAdded] DATETIME      NULL,
        [AddedBy]   NVARCHAR(100) NULL
    );
    PRINT 'Table SightsAndIcons created.';
END
GO

-- SkillsApplications
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SkillsApplications]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[SkillsApplications] (
        [SDID]              INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_SkillsApplications] PRIMARY KEY,
        [RegNo]             NCHAR(10)     NULL,
        [FirstName]         NVARCHAR(150) NULL,
        [LastName]          NVARCHAR(150) NULL,
        [OtherNames]        NVARCHAR(150) NULL,
        [DateOfBirth]       DATETIME      NULL,
        [MaritalStatus]     NVARCHAR(50)  NULL,
        [Sex]               NVARCHAR(50)  NULL,
        [StateOfOrigin]     NVARCHAR(150) NULL,
        [Address]           NVARCHAR(250) NULL,
        [AddressCity]       NVARCHAR(150) NULL,
        [AddressState]      NVARCHAR(50)  NULL,
        [Phone]             NVARCHAR(50)  NULL,
        [Email]             NVARCHAR(150) NULL,
        [Education]         NVARCHAR(50)  NULL,
        [CurrentSkill]      NVARCHAR(250) NULL,
        [ProgramCategory]   NVARCHAR(50)  NULL,
        [Program]           NVARCHAR(150) NULL,
        [SID]               INT           NULL,
        [PLID]              INT           NULL,
        [LGALetterUpload]   NVARCHAR(250) NULL,
        [InstitutionName]   NVARCHAR(250) NULL,
        [InstitutionDate]   NVARCHAR(50)  NULL,
        [Participated]      BIT           NULL,
        [CertificateUpload] NVARCHAR(250) NULL,
        [DateCreated]       DATETIME      NULL
    );
    PRINT 'Table SkillsApplications created.';
END
GO

-- Slider
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Slider]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Slider] (
        [SLID]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Slider] PRIMARY KEY,
        [Subject]     NVARCHAR(350) NULL,
        [Details]     TEXT          NULL,
        [ImageUrl]    NVARCHAR(450) NULL,
        [SlideID]     NVARCHAR(50)  NULL,
        [PublishDate] DATETIME      NULL,
        [ExpiryDate]  DATETIME      NULL,
        [Enabled]     BIT           NULL
    );
    PRINT 'Table Slider created.';
END
GO

-- Subscription
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subscription]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Subscription] (
        [SubID] INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Subscription] PRIMARY KEY,
        [Email] NVARCHAR(250) NULL
    );
    PRINT 'Table Subscription created.';
END
GO

-- Suggestions
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suggestions]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Suggestions] (
        [Id]        INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Suggestions] PRIMARY KEY,
        [Name]      NVARCHAR(100) NULL,
        [Email]     NVARCHAR(100) NULL,
        [Phone]     NVARCHAR(50)  NULL,
        [Location]  NVARCHAR(100) NULL,
        [Title]     NVARCHAR(150) NULL,
        [Message]   TEXT          NULL,
        [DateAdded] DATETIME      NULL
    );
    PRINT 'Table Suggestions created.';
END
GO

-- Tenders
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tenders]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Tenders] (
        [Id]           INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Tenders] PRIMARY KEY,
        [Title]        NVARCHAR(450) NULL,
        [Category]     NVARCHAR(100) NULL,
        [Details]      TEXT          NULL,
        [DocumentUrl]  NVARCHAR(350) NULL,
        [AdvertDate]   DATETIME      NULL,
        [DeadlineDate] DATETIME      NULL,
        [AddedBy]      NVARCHAR(100) NULL
    );
    PRINT 'Table Tenders created.';
END
GO

-- Testimonial
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Testimonial]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Testimonial] (
        [Id]            INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Testimonial] PRIMARY KEY,
        [TestimonialBy] NVARCHAR(250) NULL,
        [Occupation]    NVARCHAR(250) NULL,
        [Testimonial]   NVARCHAR(450) NULL,
        [ImageUrl]      NVARCHAR(150) NULL,
        [DateAdded]     DATETIME      NULL,
        [AddedBy]       NVARCHAR(150) NULL
    );
    PRINT 'Table Testimonial created.';
END
GO

-- Updates
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Updates]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Updates] (
        [Id]                 INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Updates] PRIMARY KEY,
        [UpdateType]         NVARCHAR(50)  NULL,
        [UpdateCategory]     NVARCHAR(150) NULL,
        [ProjectProgramType] NVARCHAR(150) NULL,
        [Title]              NVARCHAR(450) NULL,
        [Location]           NVARCHAR(450) NULL,
        [GISCordinates]      NVARCHAR(50)  NULL,
        [Description]        TEXT          NULL,
        [DescriptionImage]   NVARCHAR(250) NULL,
        [Challenges]         TEXT          NULL,
        [ChallengeImage]     NVARCHAR(250) NULL,
        [Impact]             TEXT          NULL,
        [ImpactImage]        NVARCHAR(250) NULL,
        [HomeFeatured]       BIT           NULL,
        [AddedBy]            NVARCHAR(150) NULL,
        [DateAdded]          DATETIME      NULL
    );
    PRINT 'Table Updates created.';
END
GO

-- UsersInAccount  (HasNoKey in EF -- no PK enforced)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsersInAccount]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[UsersInAccount] (
        [UAID]        INT     NULL,
        [AID]         NCHAR(10) NULL,
        [Username]    NVARCHAR(150) NULL,
        [DateCreated] DATE    NULL
    );
    PRINT 'Table UsersInAccount created.';
END
GO

-- Videos
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Videos]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Videos] (
        [Id]         INT           NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Videos] PRIMARY KEY,
        [VideoTitle] NVARCHAR(250) NULL,
        [VideoDesc]  NVARCHAR(450) NULL,
        [YoutubeUrl] NVARCHAR(450) NULL,
        [DateAdded]  DATETIME      NULL,
        [AddedBy]    NVARCHAR(100) NULL
    );
    PRINT 'Table Videos created.';
END
GO


-- =============================================================================
-- SECTION 3: Views (required by EF model mapping)
-- =============================================================================

IF OBJECT_ID(N'[dbo].[vw_aspnet_Applications]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_Applications];
GO
CREATE VIEW [dbo].[vw_aspnet_Applications] AS
SELECT [ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]
FROM   [dbo].[aspnet_Applications];
GO
PRINT 'View vw_aspnet_Applications created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_Users]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_Users];
GO
CREATE VIEW [dbo].[vw_aspnet_Users] AS
SELECT [ApplicationId], [UserId], [UserName], [LoweredUserName],
       [MobileAlias], [IsAnonymous], [LastActivityDate]
FROM   [dbo].[aspnet_Users];
GO
PRINT 'View vw_aspnet_Users created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_Roles]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_Roles];
GO
CREATE VIEW [dbo].[vw_aspnet_Roles] AS
SELECT [ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]
FROM   [dbo].[aspnet_Roles];
GO
PRINT 'View vw_aspnet_Roles created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_UsersInRoles]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_UsersInRoles];
GO
CREATE VIEW [dbo].[vw_aspnet_UsersInRoles] AS
SELECT [UserId], [RoleId]
FROM   [dbo].[aspnet_UsersInRoles];
GO
PRINT 'View vw_aspnet_UsersInRoles created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_Profiles]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_Profiles];
GO
CREATE VIEW [dbo].[vw_aspnet_Profiles] AS
SELECT [UserId], [LastUpdatedDate]
FROM   [dbo].[aspnet_Profile];
GO
PRINT 'View vw_aspnet_Profiles created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_MembershipUsers]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_MembershipUsers];
GO
CREATE VIEW [dbo].[vw_aspnet_MembershipUsers] AS
SELECT
    m.[UserId],
    m.[ApplicationId],
    u.[UserName],
    u.[LoweredUserName],
    u.[MobileAlias],
    u.[IsAnonymous],
    u.[LastActivityDate],
    m.[Email],
    m.[LoweredEmail],
    m.[PasswordQuestion],
    m.[PasswordAnswer],
    m.[IsApproved],
    m.[IsLockedOut],
    m.[CreateDate],
    m.[LastLoginDate],
    m.[LastPasswordChangedDate],
    m.[LastLockoutDate],
    m.[FailedPasswordAttemptCount],
    m.[FailedPasswordAttemptWindowStart],
    m.[FailedPasswordAnswerAttemptCount],
    m.[FailedPasswordAnswerAttemptWindowStart],
    m.[Comment],
    m.[MobilePIN]
FROM [dbo].[aspnet_Membership] m
INNER JOIN [dbo].[aspnet_Users] u ON m.[UserId] = u.[UserId];
GO
PRINT 'View vw_aspnet_MembershipUsers created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_Paths]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_WebPartState_Paths];
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Paths] AS
SELECT [ApplicationId], [PathId], [Path], [LoweredPath]
FROM   [dbo].[aspnet_Paths];
GO
PRINT 'View vw_aspnet_WebPartState_Paths created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_Shared]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_WebPartState_Shared];
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Shared] AS
SELECT [PathId], [LastUpdatedDate]
FROM   [dbo].[aspnet_PersonalizationAllUsers];
GO
PRINT 'View vw_aspnet_WebPartState_Shared created.';
GO

IF OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_User]', 'V') IS NOT NULL
    DROP VIEW [dbo].[vw_aspnet_WebPartState_User];
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_User] AS
SELECT [Id], [PathId], [UserId], [LastUpdatedDate]
FROM   [dbo].[aspnet_PersonalizationPerUser];
GO
PRINT 'View vw_aspnet_WebPartState_User created.';
GO


-- =============================================================================
-- SECTION 4: Recommended Indexes
-- =============================================================================

-- News: date + enabled filter (most common query)
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_News_PublishDate_Enabled' AND object_id = OBJECT_ID('[dbo].[News]'))
    CREATE NONCLUSTERED INDEX [IX_News_PublishDate_Enabled]
        ON [dbo].[News] ([PublishDate] DESC, [Enabled])
        INCLUDE ([NID], [Subject], [ImageUrl], [Type]);
GO

-- News: department filter
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_News_NDID' AND object_id = OBJECT_ID('[dbo].[News]'))
    CREATE NONCLUSTERED INDEX [IX_News_NDID] ON [dbo].[News] ([NDID]);
GO

-- NewsPhotoGallery: gallery lookup per news item
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_NewsPhotoGallery_NewsId' AND object_id = OBJECT_ID('[dbo].[NewsPhotoGallery]'))
    CREATE NONCLUSTERED INDEX [IX_NewsPhotoGallery_NewsId] ON [dbo].[NewsPhotoGallery] ([NewsId]);
GO

-- IReportImages: images per report
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_IReportImages_IReportId' AND object_id = OBJECT_ID('[dbo].[IReportImages]'))
    CREATE NONCLUSTERED INDEX [IX_IReportImages_IReportId] ON [dbo].[IReportImages] ([IReportId]);
GO

-- Slider: active slides
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Slider_PublishDate_Enabled' AND object_id = OBJECT_ID('[dbo].[Slider]'))
    CREATE NONCLUSTERED INDEX [IX_Slider_PublishDate_Enabled]
        ON [dbo].[Slider] ([PublishDate] DESC, [Enabled]);
GO

-- SkillsApplications: registration number lookup
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_SkillsApplications_RegNo' AND object_id = OBJECT_ID('[dbo].[SkillsApplications]'))
    CREATE NONCLUSTERED INDEX [IX_SkillsApplications_RegNo] ON [dbo].[SkillsApplications] ([RegNo]);
GO

-- Subscription: unique email constraint
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'UQ_Subscription_Email' AND object_id = OBJECT_ID('[dbo].[Subscription]'))
    CREATE UNIQUE NONCLUSTERED INDEX [UQ_Subscription_Email]
        ON [dbo].[Subscription] ([Email])
        WHERE [Email] IS NOT NULL;
GO

-- aspnet_Users: fast login lookup
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_aspnet_Users_LoweredUserName' AND object_id = OBJECT_ID('[dbo].[aspnet_Users]'))
    CREATE NONCLUSTERED INDEX [IX_aspnet_Users_LoweredUserName]
        ON [dbo].[aspnet_Users] ([LoweredUserName], [ApplicationId]);
GO

PRINT '========================================';
PRINT 'NDDCWebsite database setup complete.';
-- PRINT 'Run this script against SQL Server using';
-- PRINT 'SSMS or sqlcmd.';
PRINT '========================================';
GO
