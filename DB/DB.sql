/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.1601)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [DBADM]
GO
/****** Object:  Table [dbo].[ADMFollowUp]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMFollowUp](
	[ADMFollowUpIDP] [bigint] IDENTITY(1,1) NOT NULL,
	[ADMIDF] [int] NULL,
	[Remarks] [varchar](max) NULL,
	[StatusIDF] [int] NULL,
	[NextFollowUpDate] [datetime] NULL,
	[FollowUpBy] [int] NULL,
	[FolloUpDate] [datetime] NULL,
 CONSTRAINT [PK_ADMFollowUp] PRIMARY KEY CLUSTERED 
(
	[ADMFollowUpIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ADMHeader]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADMHeader](
	[ADMIDP] [bigint] IDENTITY(1,1) NOT NULL,
	[ICUSNumber] [varchar](50) NULL,
	[ADMNumber] [int] NULL,
	[TicketID] [varchar](50) NULL,
	[OfficeIDF] [int] NULL,
	[OfficeBranchIDF] [int] NULL,
	[TicketIssueBranchID] [int] NULL,
	[TicketAmount] [numeric](18, 2) NULL,
	[ReasonIDF] [int] NULL,
	[Remarks] [varchar](max) NULL,
	[StatusIDF] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_ADMHeader] PRIMARY KEY CLUSTERED 
(
	[ADMIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchMaster]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchMaster](
	[BranchIDP] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_BranchMaster] PRIMARY KEY CLUSTERED 
(
	[BranchIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfficeMaster]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficeMaster](
	[OfficeIDP] [int] IDENTITY(1,1) NOT NULL,
	[OfficeID] [varchar](10) NULL,
	[BranchIDF] [int] NULL,
	[IATANumber] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_OfficeMaster] PRIMARY KEY CLUSTERED 
(
	[OfficeIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReasonMaster]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReasonMaster](
	[ReasonIDP] [int] IDENTITY(1,1) NOT NULL,
	[ReasonName] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_ReasonMaster] PRIMARY KEY CLUSTERED 
(
	[ReasonIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusMaster]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusMaster](
	[StatusIDP] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_StatusMaster] PRIMARY KEY CLUSTERED 
(
	[StatusIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusUpdateLog]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusUpdateLog](
	[LogIDP] [bigint] IDENTITY(1,1) NOT NULL,
	[ADMIDF] [bigint] NULL,
	[TicketID] [varchar](50) NULL,
	[LastStatusIDF] [int] NULL,
	[CurrentStatusIDF] [int] NULL,
	[StatusChangeBy] [int] NULL,
	[StatusChangeDateTime] [datetime] NULL,
 CONSTRAINT [PK_StatusUpdateLog] PRIMARY KEY CLUSTERED 
(
	[LogIDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BranchMaster] ON 

INSERT [dbo].[BranchMaster] ([BranchIDP], [BranchName], [IsActive], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (4, N'demo 1', 1, 0, CAST(N'2020-01-08T08:51:10.783' AS DateTime), 0, CAST(N'2020-01-08T08:51:31.270' AS DateTime))
SET IDENTITY_INSERT [dbo].[BranchMaster] OFF
SET IDENTITY_INSERT [dbo].[OfficeMaster] ON 

INSERT [dbo].[OfficeMaster] ([OfficeIDP], [OfficeID], [BranchIDF], [IATANumber], [IsActive], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (1, N'Demo', 4, N'123456', 1, 0, CAST(N'2020-01-08T09:16:33.943' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[OfficeMaster] OFF
SET IDENTITY_INSERT [dbo].[ReasonMaster] ON 

INSERT [dbo].[ReasonMaster] ([ReasonIDP], [ReasonName], [IsActive], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (2, N'Demo 2', 1, 0, CAST(N'2020-01-08T08:54:15.580' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ReasonMaster] OFF
SET IDENTITY_INSERT [dbo].[StatusMaster] ON 

INSERT [dbo].[StatusMaster] ([StatusIDP], [StatusName], [IsActive], [CreatedBy], [CreatedDateTime], [UpdatedBy], [UpdatedDateTime]) VALUES (1, N'Demo 1', 1, 0, CAST(N'2020-01-08T08:58:30.040' AS DateTime), 0, CAST(N'2020-01-08T08:58:36.157' AS DateTime))
SET IDENTITY_INSERT [dbo].[StatusMaster] OFF
ALTER TABLE [dbo].[ADMFollowUp] ADD  CONSTRAINT [DF_ADMFollowUp_FolloUpDate]  DEFAULT (getdate()) FOR [FolloUpDate]
GO
ALTER TABLE [dbo].[ADMHeader] ADD  CONSTRAINT [DF_ADMHeader_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ADMHeader] ADD  CONSTRAINT [DF_ADMHeader_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[BranchMaster] ADD  CONSTRAINT [DF_BranchMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[BranchMaster] ADD  CONSTRAINT [DF_BranchMaster_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[OfficeMaster] ADD  CONSTRAINT [DF_OfficeMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[OfficeMaster] ADD  CONSTRAINT [DF_OfficeMaster_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[ReasonMaster] ADD  CONSTRAINT [DF_ReasonMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ReasonMaster] ADD  CONSTRAINT [DF_ReasonMaster_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[StatusMaster] ADD  CONSTRAINT [DF_StatusMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[StatusMaster] ADD  CONSTRAINT [DF_StatusMaster_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[StatusUpdateLog] ADD  CONSTRAINT [DF_StatusUpdateLog_StatusChangeDateTime]  DEFAULT (getdate()) FOR [StatusChangeDateTime]
GO
/****** Object:  StoredProcedure [dbo].[ADMFollowUp_GeneralAction]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ADMFollowUp_GeneralAction]
	@ADMFollowUpIDP bigint
	,@ActionType Int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ActionType = 1)
	BEGIN
		DELETE FROM ADMFollowUp WHERE ADMFollowUpIDP = @ADMFollowUpIDP

		SET @OUTVAL = 'Record delete successfully'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ADMFollowUp_Get_GetAll]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ADMFollowUp_Get_GetAll]
	@ADMFollowUpIDP bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY ADMFollowUpIDP DESC) AS SrNo
	,ADMFollowUpIDP
	,ADMIDF
	,Remarks
	,StatusIDF
	,NextFollowUpDate
	,FollowUpBy
	,FolloUpDate
	FROM ADMFollowUp
	WHERE (@ADMFollowUpIDP = 0 OR ADMFollowUpIDP = @ADMFollowUpIDP)
	ORDER BY ADMFollowUpIDP DESC

END

GO
/****** Object:  StoredProcedure [dbo].[ADMFollowUp_Insert_Update]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ADMFollowUp_Insert_Update]
	@ADMFollowUpIDP bigint
	,@ADMIDF int
	,@Remarks varchar(MAX)
	,@StatusIDF int
	,@NextFollowUpDate datetime
	,@FollowUpBy int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ADMFollowUpIDP = 0)
	BEGIN
		INSERT INTO ADMFollowUp (ADMIDF,
		Remarks,
		StatusIDF,
		NextFollowUpDate,
		FollowUpBy)
		VALUES (@ADMIDF,
		@Remarks,
		@StatusIDF,
		@NextFollowUpDate,
		@FollowUpBy)

		SET @OUTVAL = 'Record save successfully.'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[ADMHeader_GeneralAction]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ADMHeader_GeneralAction]
	@ADMIDP bigint
	,@ActionType Int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ActionType = 1)
	BEGIN
		DELETE FROM ADMHeader WHERE ADMIDP = @ADMIDP

		SET @OUTVAL = 'Record delete successfully'
	END
	ELSE IF (@ActionType = 2)
	BEGIN
		UPDATE ADMHeader SET IsActive = (CASE WHEN IsActive = 1 THEN 0 ELSE 1 END) WHERE ADMIDP = @ADMIDP

		SET @OUTVAL = 'Status change successfully'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ADMHeader_Get_GetAll]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ADMHeader_Get_GetAll]
	@ADMIDP bigint
	,@IsActive Bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY ADMIDP DESC) AS SrNo
	,ADMIDP
	,ICUSNumber
	,ADMNumber
	,TicketID
	,OfficeIDF
	,OfficeBranchIDF
	,TicketIssueBranchID
	,TicketAmount
	,ReasonIDF
	,Remarks
	,StatusIDF
	,ADMHeader.IsActive
	,ADMHeader.CreatedBy
	,ADMHeader.CreatedDateTime
	,ADMHeader.UpdatedBy
	,ADMHeader.UpdatedDateTime
	,OfficeMaster.OfficeID
	,OfficeMaster.IATANumber
	,OB.BranchName AS OfficeBranchName
	,TIB.BranchName AS TicketIssueBranchName
	,ReasonMaster.ReasonName
	,StatusMaster.StatusName
	FROM ADMHeader
	LEFT OUTER JOIN OfficeMaster ON OfficeMaster.OfficeIDP = OfficeIDF
	LEFT OUTER JOIN BranchMaster OB ON OB.BranchIDP = OfficeBranchIDF
	LEFT OUTER JOIN BranchMaster TIB ON TIB.BranchIDP = TicketIssueBranchID
	LEFT OUTER JOIN ReasonMaster ON ReasonIDP = ReasonIDF
	LEFT OUTER JOIN StatusMaster ON StatusIDP = StatusIDF
	WHERE (@ADMIDP = 0 OR ADMIDP = @ADMIDP)
	AND (@IsActive IS NULL OR ADMHeader.IsActive = @IsActive)
	ORDER BY ADMIDP DESC

END
GO
/****** Object:  StoredProcedure [dbo].[ADMHeader_Insert_Update]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ADMHeader_Insert_Update]
	@ADMIDP bigint
	,@ICUSNumber varchar(50)
	,@ADMNumber int
	,@TicketID varchar(50)
	,@OfficeIDF int
	,@OfficeBranchIDF int
	,@TicketIssueBranchID int
	,@TicketAmount numeric(18,2) = NULL
	,@ReasonIDF int
	,@Remarks varchar(MAX) = NULL
	,@StatusIDF int
	,@UserID int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ADMIDP = 0)
	BEGIN
		INSERT INTO ADMHeader (ICUSNumber,
		ADMNumber,
		TicketID,
		OfficeIDF,
		OfficeBranchIDF,
		TicketIssueBranchID,
		TicketAmount,
		ReasonIDF,
		Remarks,
		StatusIDF,
		CreatedBy)
		VALUES (@ICUSNumber,
		@ADMNumber,
		@TicketID,
		@OfficeIDF,
		@OfficeBranchIDF,
		@TicketIssueBranchID,
		@TicketAmount,
		@ReasonIDF,
		@Remarks,
		@StatusIDF,
		@UserID)

		SET @OUTVAL = 'Record save successfully.'
	END
	ELSE
	BEGIN
		UPDATE ADMHeader SET ICUSNumber = @ICUSNumber,
		ADMNumber = @ADMNumber,
		TicketID = @TicketID,
		OfficeIDF = @OfficeIDF,
		OfficeBranchIDF = @OfficeBranchIDF,
		TicketIssueBranchID = @TicketIssueBranchID,
		TicketAmount = @TicketAmount,
		ReasonIDF = @ReasonIDF,
		Remarks = @Remarks,
		StatusIDF = @StatusIDF,
		UpdatedBy = @UserID,
		UpdatedDateTime = GETDATE()
		WHERE ADMIDP = @ADMIDP

		SET @OUTVAL = 'Record update successfully.'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[BranchMaster_GeneralAction]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BranchMaster_GeneralAction]
	@BranchIDP int
	,@ActionType Int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ActionType = 1)
	BEGIN
		DELETE FROM BranchMaster WHERE BranchIDP = @BranchIDP

		SET @OUTVAL = 'Record delete successfully'
	END
	ELSE IF (@ActionType = 2)
	BEGIN
		UPDATE BranchMaster SET IsActive = (CASE WHEN IsActive = 1 THEN 0 ELSE 1 END) WHERE BranchIDP = @BranchIDP

		SET @OUTVAL = 'Status change successfully'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[BranchMaster_Get_GetAll]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BranchMaster_Get_GetAll]
	@BranchIDP int
	,@IsActive Bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY BranchIDP DESC) AS SrNo
	,BranchIDP
	,BranchName
	,IsActive
	,CreatedBy
	,CreatedDateTime
	,UpdatedBy
	,UpdatedDateTime
	FROM BranchMaster
	WHERE (@BranchIDP = 0 OR BranchIDP = @BranchIDP)
	AND (@IsActive IS NULL OR IsActive = @IsActive)
	ORDER BY BranchIDP DESC

END
GO
/****** Object:  StoredProcedure [dbo].[BranchMaster_Insert_Update]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BranchMaster_Insert_Update]
	@BranchIDP int
	,@BranchName varchar(50)
	,@UserID int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@BranchIDP = 0)
	BEGIN
		INSERT INTO BranchMaster (BranchName, CreatedBy) VALUES (@BranchName, @UserID)

		SET @OUTVAL = 'Record save successfully.'
	END
	ELSE
	BEGIN
		UPDATE BranchMaster SET BranchName = @BranchName, UpdatedBy = @UserID, UpdatedDateTime = GETDATE() WHERE BranchIDP = @BranchIDP

		SET @OUTVAL = 'Record update successfully.'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[OfficeMaster_GeneralAction]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OfficeMaster_GeneralAction]
	@OfficeIDP int
	,@ActionType Int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ActionType = 1)
	BEGIN
		DELETE FROM OfficeMaster WHERE OfficeIDP = @OfficeIDP

		SET @OUTVAL = 'Record delete successfully'
	END
	ELSE IF (@ActionType = 2)
	BEGIN
		UPDATE OfficeMaster SET IsActive = (CASE WHEN IsActive = 1 THEN 0 ELSE 1 END) WHERE OfficeIDP = @OfficeIDP

		SET @OUTVAL = 'Status change successfully'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[OfficeMaster_Get_GetAll]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OfficeMaster_Get_GetAll]
	@OfficeIDP int
	,@IsActive Bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY OfficeIDP DESC) AS SrNo
	,OfficeIDP
	,OfficeID
	,BranchIDF
	,IATANumber
	,OfficeMaster.IsActive
	,OfficeMaster.CreatedBy
	,OfficeMaster.CreatedDateTime
	,OfficeMaster.UpdatedBy
	,OfficeMaster.UpdatedDateTime
	,BranchMaster.BranchName
	FROM OfficeMaster
	LEFT OUTER JOIN BranchMaster ON BranchMaster.BranchIDP = BranchIDF
	WHERE (@OfficeIDP = 0 OR OfficeIDP = @OfficeIDP)
	AND (@IsActive IS NULL OR OfficeMaster.IsActive = @IsActive)
	ORDER BY OfficeIDP DESC

END
GO
/****** Object:  StoredProcedure [dbo].[OfficeMaster_Insert_Update]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OfficeMaster_Insert_Update]
	@OfficeIDP int
	,@OfficeID varchar(10)
	,@BranchIDF int
	,@IATANumber varchar(50)
	,@UserID int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@OfficeIDP = 0)
	BEGIN
		INSERT INTO OfficeMaster (OfficeID,
		BranchIDF,
		IATANumber,
		CreatedBy)
		VALUES (@OfficeID,
		@BranchIDF,
		@IATANumber,
		@UserID)

		SET @OUTVAL = 'Record save successfully.'
	END
	ELSE
	BEGIN
		UPDATE OfficeMaster SET OfficeID = @OfficeID,
		BranchIDF = @BranchIDF,
		IATANumber = @IATANumber,
		UpdatedBy = @UserID,
		UpdatedDateTime = GETDATE()
		WHERE OfficeIDP = @OfficeIDP

		SET @OUTVAL = 'Record update successfully.'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[ReasonMaster_GeneralAction]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReasonMaster_GeneralAction]
	@ReasonIDP int
	,@ActionType Int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ActionType = 1)
	BEGIN
		DELETE FROM ReasonMaster WHERE ReasonIDP = @ReasonIDP

		SET @OUTVAL = 'Record delete successfully'
	END
	ELSE IF (@ActionType = 2)
	BEGIN
		UPDATE ReasonMaster SET IsActive = (CASE WHEN IsActive = 1 THEN 0 ELSE 1 END) WHERE ReasonIDP = @ReasonIDP

		SET @OUTVAL = 'Status change successfully'
	END

END
GO
/****** Object:  StoredProcedure [dbo].[ReasonMaster_Get_GetAll]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReasonMaster_Get_GetAll]
	@ReasonIDP int
	,@IsActive Bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY ReasonIDP DESC) AS SrNo
	,ReasonIDP
	,ReasonName
	,IsActive
	,CreatedBy
	,CreatedDateTime
	,UpdatedBy
	,UpdatedDateTime
	FROM ReasonMaster
	WHERE (@ReasonIDP = 0 OR ReasonIDP = @ReasonIDP)
	AND (@IsActive IS NULL OR IsActive = @IsActive)
	ORDER BY ReasonIDP DESC

END
GO
/****** Object:  StoredProcedure [dbo].[ReasonMaster_Insert_Update]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReasonMaster_Insert_Update]
	@ReasonIDP int
	,@ReasonName varchar(250)
	,@UserID int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ReasonIDP = 0)
	BEGIN
		INSERT INTO ReasonMaster (ReasonName, CreatedBy) VALUES (@ReasonName, @UserID)

		SET @OUTVAL = 'Record save successfully.'
	END
	ELSE
	BEGIN
		UPDATE ReasonMaster SET ReasonName = @ReasonName, UpdatedBy = @UserID, UpdatedDateTime = GETDATE() WHERE ReasonIDP = @ReasonIDP

		SET @OUTVAL = 'Record update successfully.'
	END
END

GO
/****** Object:  StoredProcedure [dbo].[StatusMaster_GeneralAction]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StatusMaster_GeneralAction]
	@StatusIDP int
	,@ActionType Int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@ActionType = 1)
	BEGIN
		DELETE FROM StatusMaster WHERE StatusIDP = @StatusIDP

		SET @OUTVAL = 'Record delete successfully'
	END
	ELSE IF (@ActionType = 2)
	BEGIN
		UPDATE StatusMaster SET IsActive = (CASE WHEN IsActive = 1 THEN 0 ELSE 1 END) WHERE StatusIDP = @StatusIDP

		SET @OUTVAL = 'Status change successfully'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[StatusMaster_Get_GetAll]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StatusMaster_Get_GetAll]
	@StatusIDP int
	,@IsActive Bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY StatusIDP DESC) AS SrNo
	,StatusIDP
	,StatusName
	,IsActive
	,CreatedBy
	,CreatedDateTime
	,UpdatedBy
	,UpdatedDateTime
	FROM StatusMaster
	WHERE (@StatusIDP = 0 OR StatusIDP = @StatusIDP)
	AND (@IsActive IS NULL OR IsActive = @IsActive)
	ORDER BY StatusIDP DESC

END
GO
/****** Object:  StoredProcedure [dbo].[StatusMaster_Insert_Update]    Script Date: 08/01/2020 09:58:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StatusMaster_Insert_Update]
	@StatusIDP int
	,@StatusName varchar(50)
	,@UserID int
	,@OUTVAL Varchar(100) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	IF (@StatusIDP = 0)
	BEGIN
		INSERT INTO StatusMaster (StatusName, CreatedBy) VALUES (@StatusName, @UserID)

		SET @OUTVAL = 'Record save successfully.'
	END
	ELSE
	BEGIN
		UPDATE StatusMaster SET StatusName = @StatusName, UpdatedBy = @UserID, UpdatedDateTime = GETDATE() WHERE StatusIDP = @StatusIDP

		SET @OUTVAL = 'Record update successfully.'
	END
END

GO
