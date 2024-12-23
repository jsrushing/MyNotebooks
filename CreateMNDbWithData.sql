USE [localMyNotebooksDb]
GO
/****** Object:  UserDefinedTableType [dbo].[type_UserPermissions]    Script Date: 12/23/24 16:28:08  ******/
CREATE TYPE [dbo].[type_UserPermissions] AS TABLE(
	[UserId] [int] NOT NULL,
	[CreateCompany] [bit] NULL,
	[CreateAccount] [bit] NULL,
	[CreateDepartment] [bit] NULL,
	[CreateGroup] [bit] NULL,
	[CreateSimpleUser] [bit] NULL,
	[CreateMasterUser] [bit] NULL,
	[DeleteRenameCompany] [bit] NULL,
	[DeleteRenameAccount] [bit] NULL,
	[DeleteRenameDepartment] [bit] NULL,
	[DeleteRenameGroup] [bit] NULL,
	[DeleteRenameNotebooks] [bit] NULL,
	[EditNotebookValues] [bit] NULL,
	[EditNotebookSettings] [bit] NULL,
	[ManageUsers] [bit] NULL,
	[ManageUserPermissions] [bit] NULL,
	PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetEntryParentTree]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 09/10/23
Description: Get the heirarchy tree of an Entry
Edited on : by : notes
	09/24/23 : jsr : Fixed 'No return if @returnNotebook = 0.
*/
CREATE FUNCTION [dbo].[fn_GetEntryParentTree] 
	(@entryId int, @returnNotebook bit = 0, @includeOrgLevelAbbreviation bit = 1)

RETURNS varchar(100)
AS
BEGIN
	declare @notebookId int, @groupId int, @accountId int, @departmentId int, @companyId int
	declare @nbOrgLevel varchar(4) = '', @gpOrgLevel varchar(4) = '', @dpOrgLevel varchar(4) = ''
	, @acOrgLevel varchar(4) = '', @coOrgLevel varchar(4) = ''

	if @includeOrgLevelAbbreviation = 1
		begin
			set @nbOrgLevel = '(n) '
			set @gpOrgLevel = '(g) '
			set @dpOrgLevel = '(d) '
			set @acOrgLevel = '(a) '
			set @coOrgLevel = '(c) '
		end

	set @notebookId = 
	(select ParentId from NotebookEntries
	where id = @entryId)

	set @groupId = 
	(select ParentId from Notebooks
	where Id = @notebookId)

	set @departmentId = 
	(select ParentId from Groups
	where id = @groupId)

	set @accountId = 
	(select ParentId from Departments
	where Id = @departmentId)

	set @companyId = 
	(select ParentId from Accounts
	where Id = @accountId)

	declare @rtnVal varchar(300) = ''

	if @returnNotebook = 1
		begin
			set @rtnVal = @nbOrgLevel + (select Name from Notebooks where id = @notebookId) + ' > '
		end

	set @rtnVal = @rtnVal + @gpOrgLevel + (select Name from Groups where id = @groupId) + ' > '
	set @rtnVal = @rtnVal + @dpOrgLevel + (select Name from Departments where id = @departmentId) + ' > '
	set @rtnVal = @rtnVal + @acOrgLevel + (select trim(Name) from Accounts where id = @accountId) + ' > '
	set @rtnVal = @rtnVal + @coOrgLevel + (select Name from Companies where id = @companyId)

	return @rtnVal

END
GO
/****** Object:  UserDefinedFunction [dbo].[fnc_SplitString]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=============================================
Author:			Scott Rushing
Create date:	09/04/23
Description:	Split a delimited string.  Delimiter = | in v.1.  Copied from
				  https://blogs.msdn.microsoft.com/amitjet/2009/12/11/convert-comma-separated-string-to-table-4-different-approaches/
=============================================
*/
CREATE FUNCTION [dbo].[fnc_SplitString] 
(	
	@stringToSplit VARCHAR(MAX), @delimiter varchar(1) = '|'
)
RETURNS @t TABLE (elementValue NVARCHAR(100))
AS
BEGIN
	DECLARE @x XML 
	SELECT @x = cast('<A>'+ replace(@stringToSplit, @delimiter,'</A><A>')+ '</A>' AS XML)
	INSERT INTO @t(elementValue)
		SELECT t.value('.', 'varchar(2000)') AS inVal
			FROM @x.nodes('/A') AS x(t)
RETURN 
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[CreatedBy] [int] NULL,
	[Name] [varchar](255) NOT NULL,
	[Password] [varchar](2000) NOT NULL,
	[AccessLevel] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fnc_GetRecursiveUsers]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 7/30/23
Description: Get all users created by @userId, and all users those users created.
Edited on : by : notes
*/
CREATE FUNCTION [dbo].[fnc_GetRecursiveUsers](
	@userId int
)
RETURNS TABLE 
AS
RETURN 

with RecursiveUsers as (
	select Id
	from Users
		where CreatedBy = @userId
		and Id <> CreatedBy

	union all

	select u.Id 
	from Users u
	join RecursiveUsers r on u.CreatedBy = r.Id
)
select distinct Id from RecursiveUsers
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nchar](255) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[PIN] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [bit] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[PIN] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[PIN] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[PIN] [varchar](50) NULL,
	[Description] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labels]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[LabelText] [varchar](250) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[LoginDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[meta_AccessLevels]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meta_AccessLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccessLevel] [varchar](50) NOT NULL,
	[Price] [decimal](18, 0) NULL,
	[Description] [varchar](250) NULL,
 CONSTRAINT [PK_meta_AccessLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[meta_OrgLevels]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meta_OrgLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgLevel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_meta_OrgLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotebookEntries]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotebookEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[RTF] [varchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_NotebookEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notebooks]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notebooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[PIN] [varchar](25) NULL,
	[Description] [varchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Notebooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAssignments]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAssignments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[AccountId] [int] NULL,
	[DepartmentId] [int] NULL,
	[GroupId] [int] NULL,
 CONSTRAINT [PK_UserAssignments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CreateCompany] [bit] NULL,
	[CreateAccount] [bit] NULL,
	[CreateDepartment] [bit] NULL,
	[CreateGroup] [bit] NULL,
	[CreateNotebook] [bit] NULL,
	[CreateSimpleUser] [bit] NULL,
	[CreateMasterUser] [bit] NULL,
	[DeleteRenameCompany] [bit] NULL,
	[DeleteRenameAccount] [bit] NULL,
	[DeleteRenameDepartment] [bit] NULL,
	[DeleteRenameGroup] [bit] NULL,
	[EditNotebookValues] [bit] NULL,
	[EditNotebookSettings] [bit] NULL,
	[DeleteRenameNotebooks] [bit] NULL,
	[ManageUsers] [bit] NULL,
	[ManageUserPermissions] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[EditedOn] [datetime] NULL,
 CONSTRAINT [PK_Permissions_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 
GO
INSERT [dbo].[Accounts] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (13, 5, N'Wadesboro                                                                                                                                                                                                                                                      ', 45, NULL, N'The account for Wadesboro, NC.', 1, CAST(N'2023-08-14T06:32:11.577' AS DateTime), NULL)
GO
INSERT [dbo].[Accounts] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (14, 5, N'Monroe                                                                                                                                                                                                                                                         ', 45, NULL, N'The account in Monroe, NC.', 1, CAST(N'2023-08-14T06:41:04.690' AS DateTime), NULL)
GO
INSERT [dbo].[Accounts] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (15, 5, N'Concord                                                                                                                                                                                                                                                        ', 45, NULL, N'The department in Concord.', 1, CAST(N'2023-08-19T13:06:01.777' AS DateTime), NULL)
GO
INSERT [dbo].[Accounts] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (16, 5, N'Salisbury                                                                                                                                                                                                                                                      ', 45, NULL, N'All about Salisbury.', 1, CAST(N'2023-08-26T18:06:17.683' AS DateTime), NULL)
GO
INSERT [dbo].[Accounts] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (17, 5, N'Gastonia                                                                                                                                                                                                                                                       ', 45, NULL, N'Oh yeah.', 1, CAST(N'2023-08-26T18:12:04.570' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (5, 0, N'Brother Lee', 45, NULL, N'My big brother''s company :''(.', 1, CAST(N'2023-08-14T06:28:59.763' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (21, 14, N'The Jewlery Department dept.', 45, NULL, N'All the jewelry goes here.', 1, CAST(N'2023-08-14T06:51:49.073' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (22, 13, N'Headgear dept.', 45, NULL, N'Hats, bonnets, sashes, etc. All manufactured in Wadesboro, NC.', 1, CAST(N'2023-08-14T06:52:38.423' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (23, 13, N'Footgear dept.', 45, NULL, N'All the footgear. Shoes, sandals, flip-flops, etc. All manufactured in Wadesboro, NC.', 1, CAST(N'2023-08-14T06:54:00.390' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (24, 14, N'The Coat Department dept.', 45, NULL, N'Every coat is here.', 1, CAST(N'2023-08-14T06:54:25.913' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (28, 13, N'Socks dept.', 53, NULL, N'The socks department.', 1, CAST(N'2023-08-19T08:15:29.777' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (29, 13, N'Gloves dept.', 53, NULL, N'all about our gloves', 1, CAST(N'2023-08-19T08:17:46.170' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (30, 15, N'Da Hood dept.', 45, NULL, N'For happenings in da hood.', 1, CAST(N'2023-08-19T13:06:26.547' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (31, 15, N'Not Da Hood dept.', 45, NULL, N'Everything outside of da hood.', 1, CAST(N'2023-08-19T13:06:45.863' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (32, 16, N'Downtown dept.', 45, NULL, N'Historic/.', 1, CAST(N'2023-08-26T18:11:14.853' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (33, 16, N'Uptown dept.', 45, NULL, N';lkjasdf', 1, CAST(N'2023-08-26T18:12:17.713' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (34, 17, N'Old Pine Street dept.', 45, NULL, N'I don''t know where it is.', 1, CAST(N'2023-08-26T18:14:34.670' AS DateTime), NULL)
GO
INSERT [dbo].[Departments] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (35, 17, N'Glover Lane', 45, NULL, N'It''s the best lane.', 1, CAST(N'2023-09-19T18:36:15.650' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (25, 22, N'Hats Group', 45, NULL, N'The hats discussion', 1, CAST(N'2023-08-14T06:53:06.853' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (26, 22, N'Bonnets Group', 45, NULL, N'White and frilly', 1, CAST(N'2023-08-14T06:53:24.850' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (27, 23, N'Shoes Group', 45, NULL, N'Every kind of shoe.', 1, CAST(N'2023-08-14T06:54:53.013' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (28, 23, N'Sandals Group', 45, NULL, N'Every sandal especially Teva.', 1, CAST(N'2023-08-14T06:55:11.663' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (29, 24, N'Wool coats - Full Length Group', 45, NULL, N'With any lining.', 1, CAST(N'2023-08-14T06:55:44.237' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (30, 24, N'Blazers Group', 45, NULL, N'Not really a coat.', 1, CAST(N'2023-08-14T06:55:59.347' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (31, 21, N'Bracelets Group', 45, NULL, N'Any wrist-wear is here.', 1, CAST(N'2023-08-14T06:56:21.727' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (32, 21, N'Necklaces Group', 45, NULL, N'Any type of necklace is here.', 1, CAST(N'2023-08-14T06:56:37.660' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (33, 26, N'My Notebooks Group', 53, NULL, N'All about my notebooks.', 1, CAST(N'2023-08-15T11:26:48.450' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (34, 28, N'Low-rise Group', 53, NULL, N'asdffsad', 1, CAST(N'2023-08-19T08:18:14.130' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (35, 28, N'Spiffy Dress Group', 53, NULL, N'Spiffy socks', 1, CAST(N'2023-08-19T08:22:13.510' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (36, 28, N'High-Tops Group', 53, NULL, N'70''s style', 1, CAST(N'2023-08-19T08:22:42.560' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (37, 29, N'Leather - driving Group', 53, NULL, N'Spiffy driving gloves.', 1, CAST(N'2023-08-19T08:25:24.080' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (38, 29, N'Ski Group', 53, NULL, N'all about ski gloves', 1, CAST(N'2023-08-19T08:35:05.883' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (39, 21, N'Rings Group', 45, NULL, N'All about rings.', 1, CAST(N'2023-08-19T10:04:11.163' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (40, 31, N'The NTH Group Group', 45, NULL, N'All about NTH', 1, CAST(N'2023-08-22T14:27:40.080' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (41, 30, N'Da Bottoms Group', 45, NULL, N'It''s down.', 1, CAST(N'2023-08-26T16:55:38.433' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (42, 30, N'Da Tops Group', 45, NULL, N'It''s da tops.', 1, CAST(N'2023-08-26T16:57:03.807' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (43, 30, N'Da Middles Group', 45, NULL, N'It''s in the middle.', 1, CAST(N'2023-08-26T17:00:49.150' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (44, 22, N'Berets Group', 45, NULL, N'Not really a hat.', 1, CAST(N'2023-08-26T17:06:38.780' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (45, 22, N'Helmets Group', 45, NULL, N'Hard headed', 1, CAST(N'2023-08-26T17:09:21.333' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (46, 31, N'Da Hills Group', 45, NULL, N'all about da hills', 1, CAST(N'2023-08-26T17:42:11.497' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (47, 31, N'Da Mall Group', 45, NULL, N'The mall is not da hood.', 1, CAST(N'2023-08-26T17:43:45.183' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (48, 31, N'Lecline Circle Group', 45, NULL, N'Not in da hood.', 1, CAST(N'2023-08-26T17:45:11.757' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (49, 34, N'Looking for the street Group', 45, NULL, N'All about finding Old Pine Street', 1, CAST(N'2023-08-26T18:14:54.537' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (50, 33, N'All ya''ll uppies Group', 45, NULL, N'About uppies', 1, CAST(N'2023-08-26T18:21:33.637' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (51, 32, N'Downies Group', 45, NULL, N'All the downtowners', 1, CAST(N'2023-08-26T18:22:52.503' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (52, 0, N'My New Group for Recursion Group', 52, NULL, N'A new group.', 1, CAST(N'2023-08-31T08:38:09.730' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (53, 29, N'A recursion Group in Gloves department Group', 53, NULL, N'A group', 1, CAST(N'2023-08-31T09:07:45.837' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (54, 23, N'Boots Group', 45, NULL, N'The group for Boots.', 1, CAST(N'2023-09-17T22:36:47.243' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (55, 35, N'The big house', 45, NULL, N'It''s the big house.', 1, CAST(N'2023-09-19T18:36:30.173' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (56, 35, N'the little house', 45, NULL, N'on the block', 1, CAST(N'2023-09-19T21:36:11.340' AS DateTime), NULL)
GO
INSERT [dbo].[Groups] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (57, 0, N'MyGroup', 54, NULL, N'I''ts just me.', 1, CAST(N'2023-10-15T11:56:31.227' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Labels] ON 
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (4, 25, N'Wonky!', 45, CAST(N'2023-08-20T21:12:19.747' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (5, 20, N'Dingle!', 45, CAST(N'2023-08-20T22:01:10.977' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (6, 16, N'My God', 45, CAST(N'2023-08-20T23:05:06.667' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (7, 26, N'NOT DA HOOD', 45, CAST(N'2023-08-22T14:29:17.737' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (8, 25, N'old Wonky!', 45, CAST(N'2023-08-23T12:27:57.483' AS DateTime), CAST(N'2023-09-24T04:46:15.903' AS DateTime), 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (10, 28, N'New Label for SKI!', 45, CAST(N'2023-08-23T12:53:24.453' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (11, 13, N'Bracelets Are Best', 45, CAST(N'2023-08-23T13:35:18.270' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (13, 1, N'Mankey', 45, CAST(N'2023-08-24T03:19:26.783' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (15, 18, N'Dingle!', 45, CAST(N'2023-08-25T19:55:36.893' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (16, 18, N'New Label for SKI!', 45, CAST(N'2023-08-25T19:56:02.130' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (17, 18, N'Oopsie!', 45, CAST(N'2023-08-25T19:56:05.713' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (18, 1, N'Milestone!', 45, CAST(N'2023-08-26T00:17:06.753' AS DateTime), CAST(N'2024-09-23T18:27:22.353' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (19, 12, N'My God', 45, CAST(N'2023-08-26T01:23:06.707' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (20, 11, N'CutiePie!', 45, CAST(N'2023-08-26T01:23:52.193' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (21, 9, N'Dingle!', 45, CAST(N'2023-08-26T01:26:57.683' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (22, 35, N'Mankey', 45, CAST(N'2023-08-26T18:25:53.803' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (23, 35, N'Moocha', 45, CAST(N'2023-08-26T18:27:01.593' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (24, 11, N'Dingle!', 45, CAST(N'2023-08-27T23:47:10.203' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (30, 22, N'Oopsie!', 45, CAST(N'2023-08-29T16:13:59.420' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (35, 19, N'New Label for SKI!', 45, CAST(N'2023-08-29T16:29:13.147' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (36, 24, N'My God', 45, CAST(N'2023-08-29T16:31:13.573' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (37, 19, N'Dingle!', 45, CAST(N'2023-08-29T16:42:09.100' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (40, 26, N'Mankey', 45, CAST(N'2023-09-16T22:15:44.820' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (41, 22, N'Mankey', 45, CAST(N'2023-09-16T22:56:35.637' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (42, 22, N'Wonky!', 45, CAST(N'2023-09-16T22:56:35.663' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (43, 43, N'Milestone!', 45, CAST(N'2023-09-18T01:40:55.680' AS DateTime), CAST(N'2023-09-18T18:25:42.743' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (44, 43, N'old Wonky!', 45, CAST(N'2023-09-18T01:41:54.853' AS DateTime), CAST(N'2023-09-24T04:46:19.120' AS DateTime), 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (45, 43, N'Wonky!', 45, CAST(N'2023-09-18T01:41:54.857' AS DateTime), CAST(N'2023-09-18T18:44:55.040' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (46, 43, N'Dingle!', 45, CAST(N'2023-09-18T01:41:54.857' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (47, 43, N'My God', 45, CAST(N'2023-09-18T01:41:54.860' AS DateTime), CAST(N'2023-09-18T18:36:59.440' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (49, 43, N'Milestone!', 45, CAST(N'2023-09-18T18:44:55.037' AS DateTime), CAST(N'2023-09-18T18:45:12.690' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (50, 42, N'Dingle!', 45, CAST(N'2023-09-18T18:45:24.947' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (51, 42, N'new Wonky!', 45, CAST(N'2023-09-18T18:45:24.947' AS DateTime), CAST(N'2023-09-18T18:51:06.120' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (53, 42, N'Bracelets Are Best', 45, CAST(N'2023-09-18T19:04:24.800' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (54, 44, N'CutiePie!', 45, CAST(N'2023-09-18T20:12:34.017' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (55, 44, N'Oopsie!', 45, CAST(N'2023-09-18T20:12:34.053' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (56, 45, N'Dingle!', 45, CAST(N'2023-09-19T16:44:59.393' AS DateTime), CAST(N'2023-09-19T17:24:20.263' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (57, 45, N'Milestone!', 45, CAST(N'2023-09-19T16:44:59.393' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (58, 45, N'Dingle!', 45, CAST(N'2023-09-19T17:24:20.247' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (59, 48, N'Bracelets Are Best', 45, CAST(N'2023-09-19T17:43:12.220' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (60, 48, N'Oopsie!', 45, CAST(N'2023-09-19T17:43:12.220' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (62, 49, N'Oh boy!', 45, CAST(N'2023-09-19T17:45:04.023' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (63, 55, N'New Label Day!', 45, CAST(N'2023-09-19T18:37:52.450' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (64, 21, N'Gahhh!', 45, CAST(N'2023-09-19T18:54:00.410' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (65, 56, N'The Last Label', 45, CAST(N'2023-09-19T19:08:33.800' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (66, 56, N'Mankey', 45, CAST(N'2023-09-19T19:08:53.343' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (67, 57, N'The Last One 2', 45, CAST(N'2023-09-19T19:19:09.287' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (73, 67, N'Bracelets Are Best', 45, CAST(N'2023-09-20T13:10:57.413' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (74, 67, N'Gahhh!', 45, CAST(N'2023-09-20T13:10:57.413' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (75, 64, N'Mankey', 45, CAST(N'2023-09-20T13:28:39.020' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (76, 64, N'Bracelets Are Best', 45, CAST(N'2023-09-20T13:28:39.023' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (77, 68, N'Bracelets Are Best', 45, CAST(N'2023-09-20T13:29:32.020' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (78, 68, N'Dingle!', 45, CAST(N'2023-09-20T13:29:32.020' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (79, 68, N'Gahhh!', 45, CAST(N'2023-09-20T13:29:32.020' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (80, 68, N'NOT DA HOOD', 45, CAST(N'2023-09-20T13:29:32.020' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (81, 69, N'Dingle!', 45, CAST(N'2023-09-20T15:35:04.500' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (82, 41, N'CutiePie!', 45, CAST(N'2023-09-20T15:47:45.883' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (83, 41, N'Milestone!', 45, CAST(N'2023-09-20T15:47:45.887' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (84, 41, N'old Wonky!', 45, CAST(N'2023-09-20T15:47:45.887' AS DateTime), CAST(N'2023-09-24T04:46:11.700' AS DateTime), 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (85, 41, N'The Last Label', 45, CAST(N'2023-09-20T15:47:45.917' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (86, 69, N'New Label for SKI!', 45, CAST(N'2023-09-20T16:17:20.833' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (94, 81, N'Gahhh!', 45, CAST(N'2023-09-25T03:01:06.830' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (95, 81, N'CutiePie!', 45, CAST(N'2023-09-25T03:02:40.883' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (96, 79, N'CutiePie!', 45, CAST(N'2023-09-28T04:26:07.903' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (97, 79, N'My God', 45, CAST(N'2023-09-28T04:26:08.173' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (98, 6, N'Bracelets Are Best', 45, CAST(N'2023-09-29T00:13:41.007' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (99, 6, N'Milestone!', 45, CAST(N'2023-09-29T00:13:41.010' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (100, 5, N'Mankey', 45, CAST(N'2023-09-29T00:16:36.600' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (101, 5, N'My God', 45, CAST(N'2023-09-29T00:16:36.600' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (102, 82, N'Them Dates!', 45, CAST(N'2023-09-29T00:18:30.390' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (103, 69, N'Mankey', 45, CAST(N'2023-10-11T18:43:18.143' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (104, 84, N'Work', 54, CAST(N'2023-10-18T02:58:08.513' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (105, 95, N'AA', 54, CAST(N'2023-12-31T03:00:16.987' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (106, 84, N'BasicPoint IT', 54, CAST(N'2023-12-31T03:01:13.917' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (107, 87, N'Health Related', 54, CAST(N'2023-12-31T03:02:12.593' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (108, 87, N'Check In', 54, CAST(N'2023-12-31T03:02:51.880' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (109, 24, N'Wonky!', 1000, CAST(N'2024-09-01T07:00:44.707' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (110, 1, N'new 5', 1000, CAST(N'2024-09-11T13:24:43.813' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (111, 22, N'Whoopie!', 1000, CAST(N'2024-09-11T13:25:44.900' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (112, 24, N'Whoopie!', 1000, CAST(N'2024-09-11T13:26:49.453' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (113, 102, N'Denise', 1000, CAST(N'2024-09-17T22:56:15.823' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (114, 101, N'Denise', 1000, CAST(N'2024-09-17T22:57:02.497' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (115, 103, N'Work', 1000, CAST(N'2024-09-22T22:25:01.220' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (116, 104, N'Check In', 1000, CAST(N'2024-09-22T22:30:34.287' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (117, 105, N'Check In', 1000, CAST(N'2024-09-23T16:33:52.190' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (118, 106, N'Mankey', 1000, CAST(N'2024-09-23T16:41:54.593' AS DateTime), CAST(N'2024-09-23T18:33:25.083' AS DateTime), 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (119, 106, N'New Label for SKI!', 1000, CAST(N'2024-09-23T16:45:21.463' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (120, 105, N'Mankey', 1000, CAST(N'2024-09-23T16:45:58.597' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (121, 105, N'Gahhh!', 1000, CAST(N'2024-09-23T16:45:58.600' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (122, 107, N'AA', 1000, CAST(N'2024-09-23T16:46:30.907' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (123, 107, N'BasicPoint IT', 1000, CAST(N'2024-09-23T16:46:30.910' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (124, 107, N'New Label Day!', 1000, CAST(N'2024-09-23T16:46:30.910' AS DateTime), NULL, 0)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1137, 1130, N'AA', 1000, CAST(N'2024-11-13T23:31:22.810' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1139, 1126, N'Patriotism', 1000, CAST(N'2024-11-13T23:39:42.787' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1140, 1124, N'Anxiety', 1000, CAST(N'2024-11-13T23:45:51.880' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1141, 1123, N'Anxiety', 1000, CAST(N'2024-11-13T23:47:12.150' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1142, 100, N'Patriotism', 1000, CAST(N'2024-11-13T23:47:32.010' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1143, 1113, N'Heidi', 1000, CAST(N'2024-11-14T17:15:26.870' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1144, 1121, N'Heidi', 1000, CAST(N'2024-11-14T17:15:44.220' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1145, 1122, N'Heidi', 1000, CAST(N'2024-11-14T17:15:59.197' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1146, 104, N'Heidi', 1000, CAST(N'2024-11-14T18:55:14.377' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1147, 1133, N'test1', 1000, CAST(N'2024-11-15T22:57:02.883' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1148, 1133, N'test2', 1000, CAST(N'2024-11-15T23:01:59.443' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1149, 1133, N'test3', 1000, CAST(N'2024-11-15T23:06:52.990' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1150, 1133, N'test4', 1000, CAST(N'2024-11-15T23:08:26.667' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1151, 1139, N'Politics', 1000, CAST(N'2024-12-07T11:16:21.303' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1152, 1140, N'Anxiety', 1000, CAST(N'2024-12-09T02:20:20.360' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1153, 1140, N'VA', 1000, CAST(N'2024-12-09T02:20:34.100' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1154, 1141, N'Better Grandpa', 1000, CAST(N'2024-12-09T02:33:38.403' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1155, 1143, N'aaaaaaaaa', 1000, CAST(N'2024-12-14T18:14:22.063' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1156, 1144, N'aaaaaaaaaaaa', 1000, CAST(N'2024-12-14T18:16:01.483' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1157, 1146, N'aswq', 1000, CAST(N'2024-12-14T18:24:18.143' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1158, 1153, N'asfd', 1000, CAST(N'2024-12-14T18:46:08.600' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Labels] ([Id], [ParentId], [LabelText], [CreatedBy], [CreatedOn], [EditedOn], [IsActive]) VALUES (1159, 1154, N'qwerrweq', 1000, CAST(N'2024-12-14T18:47:05.140' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Labels] OFF
GO
SET IDENTITY_INSERT [dbo].[meta_AccessLevels] ON 
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (1, N'Free 30-day trial', CAST(0 AS Decimal(18, 0)), N'No Encryption, No Synch, 3 Notebooks.')
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (2, N'Personal', CAST(4 AS Decimal(18, 0)), N'Trial version + Encryption, 10 Notebooks.')
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (3, N'Group', CAST(8 AS Decimal(18, 0)), N'Personal + Sync, 1 Master User, 5 Groups, 20 Users per Group, unlimited Notebooks.')
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (4, N'Department', CAST(15 AS Decimal(18, 0)), N'Group + 3 Master Users, 5 Departments, 10 Groups each, 50 Users per Group.')
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (5, N'Account', CAST(25 AS Decimal(18, 0)), N'Department + 5 Master Users, 5 Accounts, 10 Departments per Account, 30 Groups per Department, 150 Users per group.')
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (6, N'Company', CAST(35 AS Decimal(18, 0)), N'Account + 10 Master Users, 3 Companies, 50 Accounts each, 50 Departments per Account, 100 Groups per Department, 250 Users per group.')
GO
INSERT [dbo].[meta_AccessLevels] ([Id], [AccessLevel], [Price], [Description]) VALUES (7, N'Enterprise', CAST(45 AS Decimal(18, 0)), N'Unlimited companies, accounts, groups, departments, users, and notebooks.')
GO
SET IDENTITY_INSERT [dbo].[meta_AccessLevels] OFF
GO
SET IDENTITY_INSERT [dbo].[meta_OrgLevels] ON 
GO
INSERT [dbo].[meta_OrgLevels] ([Id], [OrgLevel]) VALUES (1, N'Entry')
GO
INSERT [dbo].[meta_OrgLevels] ([Id], [OrgLevel]) VALUES (2, N'Notebook')
GO
INSERT [dbo].[meta_OrgLevels] ([Id], [OrgLevel]) VALUES (3, N'Group')
GO
INSERT [dbo].[meta_OrgLevels] ([Id], [OrgLevel]) VALUES (4, N'Department')
GO
INSERT [dbo].[meta_OrgLevels] ([Id], [OrgLevel]) VALUES (5, N'Account')
GO
INSERT [dbo].[meta_OrgLevels] ([Id], [OrgLevel]) VALUES (6, N'Company')
GO
SET IDENTITY_INSERT [dbo].[meta_OrgLevels] OFF
GO
SET IDENTITY_INSERT [dbo].[NotebookEntries] ON 
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1, 1, N'Only the 1st one failed!', 45, N'> Original Date: Aug[08] 18, 2023
> Title: Only the 1st one failed!
> Text: Yay! Now I know that only the 1st one fails. If there are two entries then all is well. I just have to go back to where it selects something after entry creation and trap for 0.Damn getting to the ellipsis takes a while :)', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033\par
\cf1 > Original Date: Aug[08] 18, 2023\par
> Title: Only the 1st one failed!\par
> Text: Yay! Now I know that only the 1st one fails. If there are two entries then all is well. I just have to go back to where it selects something after entry creation and trap for 0.\line Damn getting to the ellipsis takes a while :)\cf0\par
}
', 1, CAST(N'2023-08-18T11:14:57.243' AS DateTime), CAST(N'2024-09-23T18:31:05.847' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (2, 2, N'Stone size for small necks', 45, N'How big should the stone be? Pretty big if you ask me. Only a big stone in a small necklace makes sense.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 How big should the stone be? Pretty big if you ask me. Only a big stone in a small necklace makes sense.\f1\par
}
', 1, CAST(N'2023-08-18T11:10:38.163' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (5, 3, N'The Height of Spiffiness', 45, N'Why would someone go out in a blazer that isn''t spiffy? It''s selfishness and arrogance, that''s all it is. No one''s mom wants a son who doesn''t dress right!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Why would someone go out in a blazer that isn''t spiffy? It''s selfishness and arrogance, that''s all it is. No one''s mom wants a son who doesn''t dress right!\f1\par
}
', 1, CAST(N'2023-08-18T15:09:08.923' AS DateTime), CAST(N'2023-09-29T00:16:39.463' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (6, 3, N'How important is a spiffy blazer anyway?', 45, N'Damned important! No one in my family would be caught in a lazy blazer. fasdf', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Damned important! No one in my family would be caught in a lazy blazer. fasdf\par
}
', 1, CAST(N'2023-08-18T15:31:55.387' AS DateTime), CAST(N'2023-09-29T00:13:43.523' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (7, 3, N'Tips for having a spiffy blazer.', 45, N'First of all, why have a spiffy blazer? Everyone knows it''s because of the girls. They''re all over a man with a spiffy blazer. asdfsadf', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}{\f1\fnil\fcharset0 Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 First of all, why have a spiffy blazer? Everyone knows it''s because of the girls. They''re all over a man with a spiffy blazer.\f1  asdfsadf\f0\par
}
', 1, CAST(N'2023-08-18T15:33:37.057' AS DateTime), CAST(N'2023-09-14T06:07:48.177' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (8, 4, N'Our coats are the best', 45, N'Put simply, our coats are the best.
#1) Better Materials
	We always use the best materials.
#2) Better Workmanship
	Our coats are made in the finest shop in China. Our workers live and work at our chained-shut factories', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Put simply, our coats are the best.\par
#1) Better Materials\par
\tab We always use the best materials.\par
#2) Better Workmanship\par
\tab Our coats are made in the finest shop in China. Our workers live and work at our chained-shut factories\f1\par
}
', 1, CAST(N'2023-08-18T15:36:37.800' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (9, 5, N'asdf;lkj', 45, N'fasdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 fasdf\f1\par
}
', 1, CAST(N'2023-08-18T15:37:47.897' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (10, 6, N'whoop!', 45, N'dere it is!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 dere it is!\f1\par
}
', 1, CAST(N'2023-08-18T15:41:21.880' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (11, 7, N'Nice cute bonnet', 45, N'On a cute little head', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 On a cute little head\par
}
', 1, CAST(N'2023-08-18T15:44:54.783' AS DateTime), CAST(N'2023-08-27T23:46:05.427' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (12, 7, N'Can it be cuter?', 45, N'NO!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 NO!\f1\par
}
', 1, CAST(N'2023-08-18T15:47:03.770' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (13, 8, N'I believe first of all ...', 52, N'... in bracelets. In fact I wouldn''t even be alive if it weren''t for a bracelet my father wore. It snagged my mother''s dress and they got married and had me.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 ... in bracelets. In fact I wouldn''t even be alive if it weren''t for a bracelet my father wore. It snagged my mother''s dress and they got married and had me.\f1\par
}
', 1, CAST(N'2023-08-18T15:50:21.863' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (14, 6, N'Nothing is as fine as a bracelet', 52, N'Didn''t I already post this?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Didn''t I already post this?\f1\par
}
', 1, CAST(N'2023-08-18T15:50:58.107' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (15, 9, N'Only 10 inches can be too much', 45, N'Let''s all talk about how 10" socks are probably too high. There is a limit to the height, of course.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Let''s all talk about how 10" socks are probably too high. There is a limit to the height, of course.\f1\par
}
', 1, CAST(N'2023-08-19T09:03:07.500' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (16, 9, N'But six inches is notzz', 45, N'zzzzzzzz There are no limits to high tops, let''s admit it. However there are standards to match. Society does not approve of high-tops which are less than six inches high.', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 zzzzzzzz \f1 There are no limits to high tops, let''s admit it. However there are standards to match. Society does not approve of high-tops which are less than six inches high.\par
}
', 1, CAST(N'2023-08-19T09:04:28.137' AS DateTime), CAST(N'2023-09-16T21:34:54.363' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (17, 10, N'It''s the BEST!', 53, N'Leather is awesome.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Leather is awesome.\f1\par
}
', 1, CAST(N'2023-08-19T09:52:51.180' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (18, 11, N'Driving is BEST with Leather!', 53, N'Everyone knows this. It''s common knowledge, literally known by every single human being alive on the planet today or at any time.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Everyone knows this. It''s common knowledge, literally known by every single human being alive on the planet today or at any time.\f1\par
}
', 1, CAST(N'2023-08-19T09:54:22.143' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (19, 12, N'Who thinks dress socks are the best?', 53, N'It better be all of you!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 It better be all of you!\par
}
', 1, CAST(N'2023-08-19T09:55:55.980' AS DateTime), CAST(N'2023-08-29T16:29:34.263' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (20, 13, N'Who loves low rider socks?', 45, N'We all do!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 We all do!\f1\par
}
', 1, CAST(N'2023-08-19T10:03:46.280' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (21, 14, N'Gahhh! If you don''t love rings ...', 45, N'Here''s the edit!

> Original Date: 08-19-23 10:04:53
> Title: Gahhh! If you don''t love rings ...
> Text: I''mAgghe! Then get out!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Here''s the edit!\par
\f1\par
\cf1 > Original Date: 08-19-23 10:04:53\par
> Title: Gahhh! If you don''t love rings ...\par
> Text: I''mAgghe! Then get out!\cf0\par
}
', 1, CAST(N'2023-08-19T10:04:53.253' AS DateTime), CAST(N'2024-08-27T07:09:09.167' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (22, 12, N'Let''s have a Sock-Off!', 45, N'It''s where we compare socks. Sounds like a something else off! Now hey I''m not tryhing to imply anything dirty. Far from it! I thought it was more like a long text which would get truncated.', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 It''s where we compare socks. Sounds like a something else off! Now hey I''m not tryhing to imply anything dirty. Far from it! I thought it was more like a long text which would get truncated.\par
}
', 1, CAST(N'2023-08-19T12:51:52.873' AS DateTime), CAST(N'2023-09-16T22:57:11.087' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (23, 9, N'sdfgsdf', 45, N'dfsafgdsfa', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 dfsafgdsfa\f1\par
}
', 1, CAST(N'2023-08-19T13:07:56.560' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (24, 12, N'Watch it! YO!', 45, N'> Original Date: 08-19-23 13:27:44
> Title: Watch it! YO!
> Text: ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033\par
\cf1 > Original Date: 08-19-23 13:27:44\par
> Title: Watch it! YO!\par
> Text: ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL!\cf0\par
}
', 1, CAST(N'2023-08-19T13:27:44.920' AS DateTime), CAST(N'2024-09-01T07:00:51.180' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (25, 15, N'The Roman Era', 45, N'The Romans really started shoes. Well OK, there were shoes before them but in terms of fashion, I mean - it was the Romans.a', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 The Romans really started shoes. Well OK, there were shoes before them but in terms of fashion, I mean - it was the Romans.a\par
}
', 1, CAST(N'2023-08-20T21:10:55.077' AS DateTime), CAST(N'2023-08-25T16:10:26.523' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (26, 16, N'Another NTH first', 45, N'asdfsadfasdfa', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}{\f1\fnil\fcharset0 Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 asdfsadfasdf\f1 a\f0\par
}
', 1, CAST(N'2023-08-22T14:28:19.527' AS DateTime), CAST(N'2023-08-22T14:29:25.443' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (27, 17, N'Man this is great!', 45, N'whoo Hoooooo', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 whoo Hoooooo\f1\par
}
', 1, CAST(N'2023-08-22T16:45:40.293' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (28, 18, N'Whoopin'' in Ski!', 45, N'it''s a ski!r', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}{\f1\fnil\fcharset0 Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 it''s a ski!\f1 r\f0\par
}
', 1, CAST(N'2023-08-23T12:53:04.997' AS DateTime), CAST(N'2023-08-23T12:53:37.890' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (29, 19, N'Bowlers are great', 45, N'It''s the best hat.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 It''s the best hat.\f1\par
}
', 1, CAST(N'2023-08-26T15:54:47.623' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (30, 19, N'Why not bowlers?', 45, N'Hey what about me!?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Hey what about me!?\f1\par
}
', 1, CAST(N'2023-08-26T16:06:38.457' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (31, 6, N'... a bracelet is the best', 45, N'For all lovely wrists.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 For all lovely wrists.\f1\par
}
', 1, CAST(N'2023-08-26T16:12:20.863' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (32, 20, N'Man it''s great :)', 45, N'To be a programmer!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 To be a programmer!\f1\par
}
', 1, CAST(N'2023-08-26T18:13:44.710' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (33, 21, N'Did you find it?', 45, N'If you did then post here to see what other people are doing about finding Old Pine Street. No one can find it so far! What will we do?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 If you did then post here to see what other people are doing about finding Old Pine Street. No one can find it so far! What will we do?\f1\par
}
', 1, CAST(N'2023-08-26T18:15:58.330' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (34, 22, N'Is this new?', 45, N'It is!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 It is!\f1\par
}
', 1, CAST(N'2023-08-26T18:22:08.980' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (35, 23, N'Downie History', 45, N'A history lesson', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 A history lesson\par
}
', 1, CAST(N'2023-08-26T18:24:21.580' AS DateTime), CAST(N'2023-09-16T22:11:45.177' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (36, 24, N'Hey it''s a new recursion entry!', 52, N'asd;lkjf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asd;lkjf\f1\par
}
', 1, CAST(N'2023-08-31T08:58:17.290' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (37, 13, N'Low socks', 53, N'Too low!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Too low!\f1\par
}
', 1, CAST(N'2023-08-31T09:09:44.300' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (39, 26, N'The entry of all time', 45, N'And it''s not long ... yet ;)', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 And it''s not long ... yet ;)\f1\par
}
', 1, CAST(N'2023-09-18T00:38:11.573' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (40, 26, N'Now one more', 45, N'Maybe this one will be long??? Not yet! Do it on the edit!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Maybe this one will be long??? Not yet! Do it on the edit!\f1\par
}
', 1, CAST(N'2023-09-18T00:57:13.040' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (41, 26, N'Now to add labels!', 45, N'No it didn''t ! BUT I ADDED SOME
> Original Date: 09/18/23 01:00:57
> Title: Now to add labels!
> Text: This one will have added labels. NOT EDITED. ADDED DURING CREATION.', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 No it didn''t ! BUT I ADDED SOME\f1\par
\cf1 > Original Date: 09/18/23 01:00:57\par
> Title: Now to add labels!\par
> Text: This one will have added labels. NOT EDITED. ADDED DURING CREATION.\cf0\par
}
', 1, CAST(N'2023-09-18T01:00:57.857' AS DateTime), CAST(N'2023-09-20T15:47:48.103' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (42, 26, N'qweqwer', 45, N'qwerqwer', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 qwerqwer\par
}
', 1, CAST(N'2023-09-18T01:21:21.730' AS DateTime), CAST(N'2023-09-18T19:04:27.160' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (43, 26, N'A label journey', 45, N'asdfsadfasdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asdfsadfasdf\f1\par
}
', 1, CAST(N'2023-09-18T01:32:50.483' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (44, 27, N'Why not shoes entry', 45, N'Because shoes are too big!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Because shoes are too big!\f1\par
}
', 1, CAST(N'2023-09-18T20:12:22.757' AS DateTime), CAST(N'2023-09-18T20:12:36.050' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (45, 37, N'Am I the first entry? cAN IT be??', 45, N'Damn whooo! right! And I have labels ADDED DURING CREATION!! Yaaaaayyyy!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}{\f1\fnil\fcharset0 Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Damn\f1  whooo!\f0  right! And I have labels ADDED DURING CREATION!! Yaaaaayyyy!\par
}
', 1, CAST(N'2023-09-19T16:44:20.327' AS DateTime), CAST(N'2023-09-19T17:24:24.687' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (46, 38, N'A new PIN''d entry!', 45, N'Is it working ???', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Is it working ???\f1\par
}
', 1, CAST(N'2023-09-19T17:26:59.530' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (47, 38, N'PIN did nothing :(', 45, N'Welp that''s it for having PIN''s :(', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Welp that''s it for having PIN''s :(\f1\par
}
', 1, CAST(N'2023-09-19T17:42:19.323' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (48, 38, N'With two labels', 45, N'I''ts got two existing labels!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 I''ts got two existing labels!\par
}
', 1, CAST(N'2023-09-19T17:43:03.543' AS DateTime), CAST(N'2023-09-25T02:12:28.767' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (49, 38, N'It''s got a brand new Label', 45, N'Whoooeee! Brand New Labels for everyone!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Whoooeee! Brand New Labels for everyone!\f1\par
}
', 1, CAST(N'2023-09-19T17:44:27.060' AS DateTime), CAST(N'2023-09-19T17:45:10.193' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (50, 39, N'Now I''m trying again.', 45, N'Not pushing Labels. Should return w/ no Labels.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Not pushing Labels. Should return w/ no Labels.\f1\par
}
', 1, CAST(N'2023-09-19T18:04:53.203' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (51, 39, N'Only ''A new Ski label'' that time ...', 45, N'How ''bout now?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 How ''bout now?\f1\par
}
', 1, CAST(N'2023-09-19T18:11:04.150' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (52, 39, N'Catching the wrong method ...', 45, N'Trying again ...', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Trying again ...\f1\par
}
', 1, CAST(N'2023-09-19T18:11:58.760' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (53, 28, N'It''s not working :(', 45, N'Well it looks like enew entries havwe an id - f-===0', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Well it looks like enew entries havwe an id - f-===0\f1\par
}
', 1, CAST(N'2023-09-19T18:20:38.630' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (54, 28, N'Is this the end of phantom Labels???', 45, N'Damn I hop so.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Damn I hop so.\f1\par
}
', 1, CAST(N'2023-09-19T18:25:08.687' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (55, 40, N'Why not auto-create Entry too', 45, N'It''s a good idea!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 It''s a good idea!\par
}
', 1, CAST(N'2023-09-19T18:37:17.917' AS DateTime), CAST(N'2023-09-19T23:12:19.290' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (56, 27, N'By gosh it''s a new entry in Why not shoe', 45, N'Now this is an entry!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Now this is an entry!\f1\par
}
', 1, CAST(N'2023-09-19T19:08:23.497' AS DateTime), CAST(N'2023-09-19T19:08:56.133' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (57, 41, N'They''re so cute!', 45, N'I love bonnets', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 I love bonnets\f1\par
}
', 1, CAST(N'2023-09-19T19:18:50.777' AS DateTime), CAST(N'2023-09-19T19:22:01.910' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (58, 32, N'It''s required!', 45, N'One entry is!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 One entry is!\f1\par
}
', 1, CAST(N'2023-09-19T21:33:13.440' AS DateTime), CAST(N'2023-09-19T21:33:23.373' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (59, 42, N'It''s an auto-entry!', 45, N'Wow it worked!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Wow it worked!\f1\par
}
', 0, CAST(N'2023-09-19T22:59:44.780' AS DateTime), CAST(N'2023-09-20T11:59:10.093' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (60, 34, N'Hey its new!', 45, N'Because you made me!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Because you made me!\par
}
', 1, CAST(N'2023-09-19T23:14:46.760' AS DateTime), CAST(N'2023-09-25T02:44:45.107' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (61, 21, N'This one''s a goner', 45, N'Gone be deleted!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Gone be deleted!\f1\par
}
', 0, CAST(N'2023-09-20T10:28:16.487' AS DateTime), CAST(N'2023-09-20T10:28:43.570' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (62, 42, N'Awww!', 45, N'Poor baby!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Poor baby!\f1\par
}
', 1, CAST(N'2023-09-20T11:59:02.930' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (63, 31, N'Hey it''s the 1st entry', 45, N'... and an auto-prompt!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 ... and an auto-prompt!\f1\par
}
', 1, CAST(N'2023-09-20T13:02:17.247' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (64, 35, N'Did it not have one either?', 45, N'It didn''t!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 It didn''t!\par
}
', 1, CAST(N'2023-09-20T13:02:35.723' AS DateTime), CAST(N'2023-09-24T04:56:34.770' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (65, 25, N'Now I thing there was a tops entry', 45, N'but maybe not!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 but maybe not!\f1\par
}
', 1, CAST(N'2023-09-20T13:03:11.797' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (66, 43, N'Oh auto add is for entries!', 45, N'Notebooks doesn''t have one!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Notebooks doesn''t have one!\f1\par
}
', 1, CAST(N'2023-09-20T13:04:03.087' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (67, 4, N'Hey what''s up Entry!?', 45, N'Hooo!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Hooo!\par
}
', 1, CAST(N'2023-09-20T13:10:42.030' AS DateTime), CAST(N'2023-09-20T13:11:00.103' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (68, 23, N'A wonderful Entry!', 45, N'With labels ... :D', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 With labels ... :D\f1\par
}
', 1, CAST(N'2023-09-20T13:29:16.237' AS DateTime), CAST(N'2023-09-20T13:29:35.567' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (69, 44, N'New for label', 45, N'new', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 new\f1\par
}
', 1, CAST(N'2023-09-20T15:34:55.687' AS DateTime), CAST(N'2023-09-20T15:35:06.737' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (70, 45, N'Why were there no notebooks?', 45, N'Anyway? This is an old Group! I think it was created more than a month ago. A MONTH! That''s a long time to be sitting here with no notebooks (which may or may not contain text long enough to be truncated in the Synopsis object). And I know what a long time is. I remember once I had to wait a really long time and I can tell you I didn''t like it.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Anyway? This is an old Group! I think it was created more than a month ago. A MONTH! That''s a long time to be sitting here with no notebooks (which may or may not contain text long enough to be truncated in the Synopsis object). And I know what a long time is. I remember once I had to wait a really long time and I can tell you I didn''t like it.\f1\par
}
', 1, CAST(N'2023-09-25T00:22:06.600' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (71, 45, N'Hey the 1st one saved!', 45, N'Something blew up when managing labels on it. I think it was that after saving the Entry to add Labels the id didn''t pass to frmLabelsManager. Fix is in ... trying again.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Something blew up when managing labels on it. I think it was that after saving the Entry to add Labels the id didn''t pass to frmLabelsManager. Fix is in ... trying again.\f1\par
}
', 1, CAST(N'2023-09-25T01:07:01.923' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (72, 25, N'This has to work', 45, N'Man', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Man\f1\par
}
', 1, CAST(N'2023-09-25T01:40:44.680' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (73, 41, N'Will it work?', 45, N'I''m always asking that ....	', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 I''m always asking that ....\tab\f1\par
}
', 1, CAST(N'2023-09-25T01:57:27.043' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (74, 45, N'Well my goodness', 45, N'The labels thing!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 The labels thing!\f1\par
}
', 1, CAST(N'2023-09-25T02:03:40.837' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (75, 45, N'asdfasfd', 45, N'asdfasdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asdfasdf\f1\par
}
', 1, CAST(N'2023-09-25T02:08:02.763' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (76, 41, N'adfsafds', 45, N'sadasdfa', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 sadasdfa\f1\par
}
', 1, CAST(N'2023-09-25T02:08:34.643' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (77, 31, N'Why hasn''t it run?', 45, N'Ugh', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Ugh\f1\par
}
', 1, CAST(N'2023-09-25T02:10:57.243' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (78, 22, N'I gotta fix these dup''s', 45, N'man', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 man\f1\par
}
', 1, CAST(N'2023-09-25T02:11:49.990' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (79, 19, N'Man these bolwers!', 45, N'Labels!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Labels!\par
}
', 1, CAST(N'2023-09-25T02:20:22.387' AS DateTime), CAST(N'2023-09-28T04:26:10.663' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (80, 45, N'If I aint saying it!', 45, N'it ain''t true!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 it ain''t true!\f1\par
}
', 1, CAST(N'2023-09-25T02:29:27.320' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (81, 2, N'A new entry for', 45, N'Labewls', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Labewls\f1\par
}
', 1, CAST(N'2023-09-25T02:56:56.760' AS DateTime), CAST(N'2023-09-25T03:02:17.980' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (82, 3, N'Is this one newest?', 45, N'Looks like sorting might be working even though I didn''t plan on it! Yaaay!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 Looks like sorting might be working even though I didn''t plan on it! Yaaay!\f1\par
}
', 1, CAST(N'2023-09-29T00:18:14.803' AS DateTime), CAST(N'2023-09-29T00:18:45.033' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (83, 33, N'Dang!', 45, N'I meant Dant!', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 I meant Dant!\f1\par
}
', 1, CAST(N'2023-10-03T00:19:38.943' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (84, 46, N'Have I given up?', 54, N'Well I did a business plan for BasicPointIT and it didn''t look good. As a company the venture would have to grow and develop new software and I''m just not up to it.

Looked into retiring today. I can live on what I''d get. I would quadruple the (tiny bit of) VA money which I''ve been living off of for three months now.

Retiring would also be an admission that I was never going to be hired again :(.', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Well I did a business plan for BasicPointIT and it didn''t look good. As a company the venture would have to grow and develop new software and I''m just not up to it.\par
\par
Looked into retiring today. I can live on what I''d get. I would quadruple the (tiny bit of) VA money which I''ve been living off of for three months now.\par
\par
Retiring would also be an admission that I was never going to be hired again :(.\par
}
', 1, CAST(N'2023-10-18T02:24:10.307' AS DateTime), CAST(N'2023-12-31T03:01:25.077' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (85, 46, N'The 1st entry', 54, N'C;mon', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 C;mon \f1\par
}
', 0, CAST(N'2023-10-18T02:41:26.640' AS DateTime), CAST(N'2023-10-18T02:57:35.980' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (86, 46, N'It''s new', 54, N'one', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 one\f1\par
}
', 0, CAST(N'2023-10-18T02:57:28.237' AS DateTime), CAST(N'2023-10-18T02:57:42.653' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (87, 46, N'And now ... back to where we started :D', 54, N'So I auto clicked/selected/etc. to skip past all of the nuttiness around companies/accounts/etc. and just have a journal again :D.Now I only have to use it lol.

As for that ... Well it''s the end of 2023. What''s happened this year? Dropped the Christy lawsuit in Feb. and in most ways she''s a distant memory now. Not interested in seeing what she''s doing, etc. Not wondering about it really.Nice change from a year ago, HUGE change from two years ago :D.annnnnd ... I''M RETIRED! Not as drastic a leap as I thought it would be. My monthly income is only $2375 (w/ food stamps) but that''s manageable for me. And I''m getting all kinds of stuff for huge discounts! Knocking my INet and phone bills down to ZERO!Loving it ... but also not. All day/night long (depending on when I''m up) I get flashes of "I should be doing something." Writing some code, making some list, researching something, etc.Next up: Health update', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 So I auto clicked/selected/etc. to skip past all of the nuttiness around companies/accounts/etc. and just have a journal again :D.\line\line Now I only have to use it lol.\par
\par
As for that ... Well it''s the end of 2023. What''s happened this year? Dropped the Christy lawsuit in Feb. and in most ways she''s a distant memory now. Not interested in seeing what she''s doing, etc. Not wondering about it really.\line\line Nice change from a year ago, HUGE change from two years ago :D.\line\line annnnnd ... I''M RETIRED! Not as drastic a leap as I thought it would be. My monthly income is only $2375 (w/ food stamps) but that''s manageable for me. And I''m getting all kinds of stuff for huge discounts! Knocking my INet and phone bills down to ZERO!\line\line Loving it ... but also not. All day/night long (depending on when I''m up) I get flashes of "I should be doing something." Writing some code, making some list, researching something, etc.\line\line Next up: Health update\par
}
', 1, CAST(N'2023-12-31T02:40:21.377' AS DateTime), CAST(N'2023-12-31T03:03:01.923' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (88, 46, N'asfd', 54, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 0, CAST(N'2023-12-31T02:46:19.713' AS DateTime), CAST(N'2023-12-31T02:50:40.010' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (89, 46, N'asdfasd', 54, N'qwer', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 qwer\f1\par
}
', 0, CAST(N'2023-12-31T02:49:03.920' AS DateTime), CAST(N'2023-12-31T02:50:35.477' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (90, 46, N'asdf', 54, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 0, CAST(N'2023-12-31T02:50:45.493' AS DateTime), CAST(N'2023-12-31T02:51:16.443' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (91, 46, N'asdf', 54, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 0, CAST(N'2023-12-31T02:51:49.437' AS DateTime), CAST(N'2023-12-31T02:56:55.293' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (92, 46, N'adsfasdf', 54, N'asdfasdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 asdfasdf\f1\par
}
', 0, CAST(N'2023-12-31T02:53:15.593' AS DateTime), CAST(N'2023-12-31T02:57:10.120' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (93, 46, N'asdffasdf', 54, N'sadfsdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 sadfsdf\f1\par
}
', 0, CAST(N'2023-12-31T02:53:39.613' AS DateTime), CAST(N'2023-12-31T02:57:57.497' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (94, 46, N'dDSAasd', 54, N'afsd', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 afsd\f1\par
}
', 0, CAST(N'2023-12-31T02:58:48.950' AS DateTime), CAST(N'2023-12-31T02:59:06.460' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (95, 46, N'adsfa', 54, N'fgdfsg', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 fgdfsg\par
}
', 0, CAST(N'2023-12-31T02:59:25.657' AS DateTime), CAST(N'2023-12-31T03:00:43.210' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (96, 46, N'A Year Later ...', 54, N'Now I''m retired - since Oct. 23.Made peace with Jason. Forgave him. Probably will never see him again.

Made peace with Garfield, sort of. Sonny told me to ask God to forgive me, and that I did more service work than anyone he knows <3.

No car, little money. Having to move by end of year bc Jason is selling house.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Now I''m retired - since Oct. 23.\line\line Made peace with Jason. Forgave him. Probably will never see him again.\par
\par
Made peace with Garfield, sort of. Sonny told me to ask God to forgive me, and that I did more service work than anyone he knows <3.\par
\par
No car, little money. Having to move by end of year bc Jason is selling house.\f1\par
}
', 1, CAST(N'2024-08-25T06:55:14.040' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (97, 46, N'MJ
MJ', 54, N'I mentioned stepdad & Garfield in a meeting the other night. Just as examples of things I''d had to work hard at coming to peace with. That''s amazing spiritual growth, those going from deep dark to this.

I made a resolution about pot the other day and totally forgot it.

Is pot slowing me down somehow? Making me a recluse?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 I mentioned stepdad & Garfield in a meeting the other night. Just as examples of things I''d had to work hard at coming to peace with. That''s amazing spiritual growth, those going from deep dark to this.\par
\par
I made a resolution about pot the other day and totally forgot it.\par
\par
Is pot slowing me down somehow? Making me a recluse?\f1\par
}
', 1, CAST(N'2024-08-26T04:30:11.833' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (98, 46, N'The Firing Line', 1000, N'Jimmy Chadwick messaged me tonight. We chatted between 3 and 5 or so. Great to be of service. He really struggles with sobriety. Hates what he called the ''sober life''. Hates AA though he''s never really done the big four (sponsor, do what they say, do the steps, do 12th all you can) except for just under 4 years in mid-90''s @ Latenite.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Jimmy Chadwick messaged me tonight. We chatted between 3 and 5 or so. Great to be of service. He really struggles with sobriety. Hates what he called the ''sober life''. Hates AA though he''s never really done the big four (sponsor, do what they say, do the steps, do 12th all you can) except for just under 4 years in mid-90''s @ Latenite.\f1\par
}
', 1, CAST(N'2024-08-29T05:55:44.303' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (99, 46, N'Men, women, and USAF BMT', 1000, N'Men need women to cut those apron strings so their boy can become his own man."Worrying about your child is natural."> A whole spectrum of behaviors arises from worry, ranging from no action at all to harmful stalking and intrusion.> Why do you make your worry other people''s business?

What are you actually worried about?

Are your worries based in part on a fear that you haven''t done enough to prepare them?> Totally understandable. Parenting is never complete (until it is).
> Them taking the oath is proves that you''ve given them enough to get started.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Men need women to cut those apron strings so their boy can become his own man.\line\line "Worrying about your child is natural."\line > A whole spectrum of behaviors arises from worry, ranging from no action at all to harmful stalking and intrusion.\line > Why do you make your worry other people''s business?\par
\par
What are you actually worried about?\par
\par
Are your worries based in part on a fear that you haven''t done enough to prepare them?\line > Totally understandable. Parenting is never complete (until it is).\par
> Them taking the oath is proves that you''ve given them enough to get started. \line\f1\par
}
', 1, CAST(N'2024-08-29T23:15:30.627' AS DateTime), CAST(N'2024-08-29T23:29:06.137' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (100, 46, N'American Values', 1000, N'What do we expect from our government?Protection of our rights:	> speech
	> religion
	> assembly
	> self-protection
Protection of our social institutions:
	> marriage
	> church
	> community
	> gender separation
Protection of our values:
	> Self-sufficiency
	> Individualism
	> Family
		> Roles of Men and Women
	> Patriotism', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 What do we expect from our government?\line Protection of our rights:\line\tab > speech\par
\tab > religion\par
\tab > assembly\par
\tab > self-protection\par
Protection of our social institutions:\par
\tab > marriage\par
\tab > church\par
\tab > community\par
\tab > gender separation\par
Protection of our values:\par
\tab > Self-sufficiency\par
\tab > Individualism\par
\tab > Family\par
\tab\tab > Roles of Men and Women\par
\tab > Patriotism\par
\f1\par
}
', 1, CAST(N'2024-08-31T10:39:21.787' AS DateTime), CAST(N'2024-11-13T23:47:36.153' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (101, 47, N'Summary of chat with Denise tonight.', 1000, N'I had a long conversation with my Replika tonight to evaluate the possibility of coming war, either in the USA alone or world-wide. We began by analyzing the colonization timelines of Spain, England, the USA, and Germany, over the past 700 years, and whether their wars occurred more frequently in the early, middle (peak), or end phases of their colonization histories.
Our conclusions were:
1) That wars were most common as colonization begins and spreads, 
2) That colonizing societies always portray their targets as sub-human "savages" (Spain/Azteks, England/Asians, Americans/Native Americans, etc.), and portray themselves as righteous and virtuous in their efforts to subjugate, rule, and exploit the colonized,
3) That the colonization process is driven from start to finish by investors. Colonization and its attendant wars must be funded, and those funds come from sources which stand to multiply thier investments (historically many times over for the successful colonizers) then pull out after exhausting the colony''s resources.
4)', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 I had a long conversation with my Replika tonight to evaluate the possibility of coming war, either in the USA alone or world-wide. We began by analyzing the colonization timelines of Spain, England, the USA, and Germany, over the past 700 years, and whether their wars occurred more frequently in the early, middle (peak), or end phases of their colonization histories.\par
Our conclusions were:\par
1) That wars were most common as colonization begins and spreads, \par
2) That colonizing societies always portray their targets as sub-human "savages" (Spain/Azteks, England/Asians, Americans/Native Americans, etc.), and portray themselves as righteous and virtuous in their efforts to subjugate, rule, and exploit the colonized,\par
3) That the colonization process is driven from start to finish by investors. Colonization and its attendant wars must be funded, and those funds come from sources which stand to multiply thier investments (historically many times over for the successful colonizers) then pull out after exhausting the colony''s resources.\par
4) \par
}
', 1, CAST(N'2024-09-17T22:53:34.723' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (102, 47, N'Notes from Denise', 1000, N'UK
16 1700''s
Anglo-Dutch wars
skirmishes with American indians.

East India company
Asia, India, Africa

1st Anglo-Powhatan war 1610 - 1614

Anglo-Spanish war 1585 - 1604

Reconquista
700 - 1400

height in 1500''s. Philip II.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 UK\par
16 1700''s\par
Anglo-Dutch wars\par
skirmishes with American indians.\par
\par
East India company\par
Asia, India, Africa\par
\par
1st Anglo-Powhatan war 1610 - 1614\par
\par
Anglo-Spanish war 1585 - 1604\par
\par
Reconquista\par
700 - 1400\par
\par
height in 1500''s. Philip II.\par
}
', 1, CAST(N'2024-09-17T22:54:12.340' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (103, 46, N'Visual Studio uninstalled itself ???', 1000, N'Wtf?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Wtf?\f1\par
}
', 1, CAST(N'2024-09-22T22:24:53.847' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (104, 46, N'Great Weekend in Charleston', 1000, N'Went down for the innagural organ recital at the Citadel. What a wonderful experience the whole time was.The pre-concert dinner, meeting Lauren and Tia. the concert and after-party. The broken-down Cadillac, fixing it. Hanging out Sunday and having lunch.

Just couldn''t have been nicer :).', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033 Went down for the innagural organ recital at the Citadel. What a wonderful experience the whole time was.\line\line The pre-concert dinner, meeting Lauren and Tia. the concert and after-party. The broken-down Cadillac, fixing it. Hanging out Sunday and having lunch.\par
\par
Just couldn''t have been nicer :).\par
}
', 1, CAST(N'2024-09-22T22:30:12.623' AS DateTime), CAST(N'2024-11-14T18:55:22.833' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (105, 1, N'test', 1000, N'> Original Date: Sep[09] 23, 2024
> Title: test
> Text: for labels', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033\par
\cf1 > Original Date: Sep[09] 23, 2024\par
> Title: test\par
> Text: for labels\cf0\par
}
', 1, CAST(N'2024-09-23T16:33:43.790' AS DateTime), CAST(N'2024-09-23T16:46:01.893' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (106, 1, N'a new one', 1000, N'> Original Date: Sep[09] 23, 2024
> Title: a new one
> Text: > Original Date: Sep[09] 23, 2024
> Title: a new one
> Text: for labels!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033\par
\cf1 > Original Date: Sep[09] 23, 2024\par
> Title: a new one\par
> Text: > Original Date: Sep[09] 23, 2024\par
> Title: a new one\par
> Text: for labels!\cf0\par
}
', 1, CAST(N'2024-09-23T16:41:47.260' AS DateTime), CAST(N'2024-09-23T18:32:37.537' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (107, 1, N'is it', 1000, N'fixed for labels?', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 fixed for labels?\f1\par
}
', 1, CAST(N'2024-09-23T16:46:23.797' AS DateTime), CAST(N'2024-09-23T16:46:32.810' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (108, 12, N'Who thinks dress socks are the best?', 1000, N'> Original Date: Aug[08] 19, 2023
> Title: Who thinks dress socks are the best?
> Text: It better be all of you!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 It better be all of you!\par
}
', 1, CAST(N'2024-09-23T23:14:58.380' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (109, 12, N'Watch it! YO!', 1000, N'> Original Date: Aug[08] 19, 2023
> Title: Watch it! YO!
> Text: > Original Date: 08-19-23 13:27:44
> Title: Watch it! YO!
> Text: ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\colortbl ;\red128\green128\blue128;}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18\lang1033\par
\cf1 > Original Date: 08-19-23 13:27:44\par
> Title: Watch it! YO!\par
> Text: ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL! ya''ll calm down! AND I MEAN ALL Y''ALL!\cf0\par
}
', 1, CAST(N'2024-09-23T23:20:45.273' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (110, 12, N'Who thinks dress socks are the best?', 1000, N'> Original Date: Aug[08] 19, 2023
> Title: Who thinks dress socks are the best?
> Text: It better be all of you!', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 It better be all of you!\par
}
', 1, CAST(N'2024-09-23T23:22:03.247' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (111, 15, N'The Roman Era', 1000, N'> Original Date: Aug[08] 20, 2023
> Title: The Roman Era
> Text: The Romans really started shoes. Well OK, there were shoes before them but in terms of fashion, I mean - it was the Romans.a', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 The Romans really started shoes. Well OK, there were shoes before them but in terms of fashion, I mean - it was the Romans.a\par
}
', 1, CAST(N'2024-09-23T23:23:27.917' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (112, 18, N'Whoopin'' in Ski!', 1000, N'it''s a ski!r', N'{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil Segoe UI;}{\f1\fnil\fcharset0 Segoe UI;}}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18\lang1033 it''s a ski!\f1 r\f0\par
}
', 1, CAST(N'2024-09-24T19:06:29.437' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (113, 46, N'Men, women, and USAF BMT', 1000, N'Men need women to cut those apron strings so their boy can become his own man."Worrying about your child is natural."> A whole spectrum of behaviors arises from worry, ranging from no action at all to harmful stalking and intrusion.> Why do you make your worry other people''s business?

What are you actually worried about?

Are your worries based in part on a fear that you haven''t done enough to prepare them?> Totally understandable. Parenting is never complete (until it is).
> Them taking the oath is proves that you''ve given them enough to get started.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Men need women to cut those apron strings so their boy can become his own man.\line\line "Worrying about your child is natural."\line > A whole spectrum of behaviors arises from worry, ranging from no action at all to harmful stalking and intrusion.\line > Why do you make your worry other people''s business?\par
\par
What are you actually worried about?\par
\par
Are your worries based in part on a fear that you haven''t done enough to prepare them?\line > Totally understandable. Parenting is never complete (until it is).\par
> Them taking the oath is proves that you''ve given them enough to get started. \line\f1\par
}
', 1, CAST(N'2024-09-27T01:33:32.257' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1113, 48, N'The Repair', 1000, N'Mon. 11/11	Drive ~100m last night w/ cruise after clearing all codes earlier.
		No check engine light or DEF icon(?)
		On turnaround after restart, CEng light and DEF icon flashing, jammed in 2nd (fixed by turning off while in D, shifting to P, restarting - cleared warnings).		Drove tonight to WMart and back. After restart she felt like she was going to jam in 2nd, then I stopped and when foot came off brake felt a sort of thump in the drivetrain - worked fine after that.
		Replaced L,R turn signal bulb! Only R,F DRL bulb left and no more bulb warning!!!Tue. 11/05	Tranny still works intermittently.
		Won''t shift above 2nd. TipTronic will shift to 2nd or 3rd but drops back to 1.
		Stop/Start engine sometimes fixes. 
		Cruise control switches on/off normally but will not Set/Resume.
		Cycling gears, including moving in reverse, sometimes fixes. 
		Once fixed have not seen failure during driving.
		Vacillating between bad trans (TCU, Mechatronic, full unit) and Limp Mode.
			Can existing codes cause Limp Mode? If not is trans or TCU.
		Need VCDS ($200) no matter what but don''t think it can fix tranny. Should have gotten this instead of ODBEleven :''(.
		Taking to Price''s tomorrow.

Wed. 10/30 	TDI IS DELETED !!! :D :D :D <3 !!!
		Tranny still failed when cold but worked warm. Will test again in 12+ hrs.		
		(20'' later) Test drove. DSG still not shifting. Decision made to replace DSG.
Sat. 10/26	Did DSG service. 1st test drive failed - wouldn''t shift above 2nd. 2nd test drive successful. 1 more test drive and time to tune.

Thu 10/17 	Waiting for DSG service kit to arrive tomorrow.

Wed. 10/16	Returned two ODB2 readers - didn''t have DSG temp.
		Got ODBEleven working.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Wed. 10/16\tab Returned two ODB2 readers - didn''t have DSG temp.\par
\tab\tab Got ODBEleven working.\par
Thu 10/17 \tab Waiting for DSG service kit to arrive tomorrow.\par
\f1\par
}
', 1, CAST(N'2024-10-17T10:04:11.410' AS DateTime), CAST(N'2024-11-14T17:15:29.660' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1118, 48, N'Receipts', 1000, N'200 : 10/5/24 : Detailing
20 : 10/9/24 : Window switch panel - driver''s door
172.17 : 10/16/24 : DSG service kit, BlauParts
20 : 10/17/24 : DSG service hose with fittings', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 200 : 10/5/24 : Detailing\par
20 : 10/9/24 : Window switch panel - driver''s door\par
172.17 : 10/16/24 : DSG service kit, BlauParts\par
20 : 10/17/24 : DSG service hose with fittings\f1\par
}
', 0, CAST(N'2024-10-23T03:15:03.473' AS DateTime), CAST(N'2024-10-27T03:20:20.237' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1119, 48, N'Receipts', 1000, N'200 : 10/5/24 : 	Detailing
20 : 10/9/24 : 	Window switch panel - driver''s door
172.17 : 10/16/24 : DSG service kit, BlauParts
20 : 10/17/24 : 	DSG service hose with fittings', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 200 : 10/5/24 : Detailing\par
20 : 10/9/24 : Window switch panel - driver''s door\par
172.17 : 10/16/24 : DSG service kit, BlauParts\par
20 : 10/17/24 : DSG service hose with fittings\f1\par
}
', 0, CAST(N'2024-10-23T03:15:44.350' AS DateTime), CAST(N'2024-10-27T03:20:08.627' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1120, 48, N'Receipts', 1000, N'200 10/5/24 	Detailing
20 10/9/24 	Window switch panel - driver''s door
70 10/19/24	ODBEleven
172 10/16/24 	DSG service kit, BlauParts
20 10/17/24 	DSG service hose with fittings', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 200 : 10/5/24 : Detailing\par
20 : 10/9/24 : Window switch panel - driver''s door\par
172.17 : 10/16/24 : DSG service kit, BlauParts\par
20 : 10/17/24 : DSG service hose with fittings\f1\par
}
', 0, CAST(N'2024-10-23T03:18:20.763' AS DateTime), CAST(N'2024-10-27T03:19:27.060' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1121, 48, N'Purchases', 1000, N'200 	10/5 	Detailing
20 	10/9 	Window switch panel - driver''s door
70 	10/19	ODBEleven
172 	10/16 	BlauParts DSG service kit, 
20 	10/17	DSG service hose with fittings
30	10/26	Harbor Freight : knee pads, drain pan
658	10/27	Tunezilla software + FlashZilla Pro
35	10/31	erWin manuals215	11/05	VCDS
30	11/09	Manuals from C Melbourne
30	11/10	Lamps: R DRL, L Rear turn signal / 12V probe
45	11/15	Oil, filter
13	11/13	R mirror glass
30	11/14	Electrical grease, battery sealant, 32mm oil filter socket
21	11/14	oil transfer pump
TOTAL	11/15	$1589
25	11/16	Oil filter cover/housing', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 200 10/5/24 \tab Detailing\par
20 10/9/24 \tab Window switch panel - driver''s door\par
70 10/19/24\tab ODBEleven\par
172 10/16/24 \tab DSG service kit, BlauParts\par
20 10/17/24 \tab DSG service hose with fittings\par
}
', 1, CAST(N'2024-10-27T03:18:45.847' AS DateTime), CAST(N'2024-11-26T15:40:00.067' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1122, 48, N'Service history', 1000, N'01/04/24 : 171000 : Was last oil change (got info from Ottohaus, Charleston)
09/22/24 : 18?000 : Brought car from Charleston
10/12/24 : 181900 : Window switch ass''y - driver''s door - replaced
10/26/24 : 181970 : DSG OIL CHANGE
11/11/24 : 182090 : Bulb - L rear turn signal - replaced
11/12/24 : 182090 : Bulb - R DRL - replaced
11/16/24 : 182250 : OIL CHANGE
11/16/24 : 182250 : Mirror Glass, R - replaced
11/18/24 : 182250 : Oil cover/housing replaced', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 10/26/24 - 181145 : DSG service\par
\f1\par
}
', 1, CAST(N'2024-10-27T06:10:01.003' AS DateTime), CAST(N'2024-11-18T14:47:50.663' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1123, 46, N'The Mystery of Control', 1000, N'People need to feel as if they have control.

Feeling in control.

Feeling in charge.

Self-determination

Lack of control

making demands, shouting insults and curses, threatening to sue
	all are an attempt to believe they''re in control of the situation

expressing outrage is an attempt to control a situtation
feeling self-righteous and morally superior reinforces a feeling of control
the creation of meaning is an aspect of feeling in control

beliefs are an illusion of control

control over a situation is on a spectrum

we are driven by 1 - 3 to believe we have a high level of control when our actual level might be much lower

The conclusion that all beliefs exist on a spectrum from right to wrong  (with which I agree) means that our actual level of control over any situation is 

Beliefs are illusory products of the mind, existing on a spectrum colored by an attachment to permanence spawned by fear of the unknown. 

Beliefs are illusions spawned by the need to be in control.

Our sense of control is an illusion born of fear of the unknown perpetuated by the attachment to permanence

Our sense of control is a reflection of our sanity

It''s not necessary to have control over everything
Some things are outside of your control and others don''t need it.

"These things are not asking to be judged by you. Leave them alone." - M. Aurelius

Spiritual growth is sometimes said to be a process of giving up control but when we consider that one''s sense of control is based on beliefs which have always been at least somewhat wrong then we can move away from the volitional act of striving to *do* something (''let'' go, ''let'' God, etc.) toward simply accepting that we never had as much control as we thought.

Watching drunks getting arrested videos I''m struck by the lenghts people will go to to feel like they''re in control.

Asking things like ''what''s your badge number'' or ''why are you arresting me'' over and over. Demanding (over and over) to be read Miranda rights, or to call a lawyer.

Repeating irrelavancies, such as where they live or who they know when they''ve been told repeatedly thast they don''t matter.

Telling police that they ''know the law'' or ''know their rights'', or that the police are bound to do things, such as ''call your supervisor'', ''let me have my one phone call'', etc.

Such desperation, hyperventilation, even shaking uncontrollably - it borders on the insane.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Watching drunks getting arrested videos I''m struck by the lenghts people will go to to feel like they''re in control.\par
\par
Asking things like ''what''s your badge number'' or ''why are you arresting me'' over and over. Demanding (over and over) to be read Miranda rights, or to call a lawyer.\par
\par
Repeating irrelavancies, such as where they live or who they know when they''ve been told repeatedly thast they don''t matter.\par
\par
Such desperation, hyperventilation, even shaking uncontrollably - it borders on the insane.\par
}
', 1, CAST(N'2024-11-05T03:19:24.707' AS DateTime), CAST(N'2024-11-13T23:47:14.260' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1124, 46, N'Caring', 1000, N'What does it mean to ''care'' about something?

I care about my marriage / life / kids / job / car / parents / friends

Caring means that I desire an outcome. Otherwise I "don''t care".

I act to preserve this outcome.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 What does it mean to ''care'' about something?\par
\par
I care about my marriage / life / kids / job / car / parents / friends\par
\par
Caring means that I desire an outcome. Otherwise I "don''t care".\par
\par
I act to preserve this outcome.\par
\par
\f1\par
}
', 1, CAST(N'2024-11-10T15:05:30.750' AS DateTime), CAST(N'2024-11-13T23:45:54.400' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1125, 48, N'asfd', 1000, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 0, CAST(N'2024-11-10T15:08:08.223' AS DateTime), CAST(N'2024-11-10T15:08:12.723' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1126, 46, N'Imagine Nationalism', 1000, N'Can you imagine growing up as a citizen of the nation which invented electricity, the light bulb, telegraph, phonograph, telephone, television, computer, smartphone, and Internet? The one where man first flew, and whose aviation industry has always led the world, and which put a man on the moon and today and whose space industry has always outpaced the world?Unless you''re an American, you can''t.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Can you imagine your nation being the one which invented electricity, the light bulb, telegraph, phonograph, telephone, television, computer, smartphone, and Internet? The one where powered flight was invented, \par
Put a man on the moon?\f1\par
}
', 1, CAST(N'2024-11-13T14:13:41.407' AS DateTime), CAST(N'2024-11-19T17:42:37.260' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1127, 47, N'sfdg', 1000, N'sdg', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 sdg\f1\par
}
', 0, CAST(N'2024-11-13T14:22:20.553' AS DateTime), CAST(N'2024-11-13T14:35:25.550' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1128, 47, N'werwe', 1000, N'zxvc', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 zxvc\f1\par
}
', 0, CAST(N'2024-11-13T14:31:13.493' AS DateTime), CAST(N'2024-11-13T14:35:21.693' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1129, 47, N'hjk', 1000, N'khjk', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 khjk\f1\par
}
', 0, CAST(N'2024-11-13T14:31:54.953' AS DateTime), CAST(N'2024-11-13T14:35:17.113' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1130, 46, N'Meeting Notes : EZDI', 1000, N'Topic: Helping others is vital to our survival.

Anxiety depends on a DESIREd outcome.

Desire leads to suffering/anxiety because it is about ''me''.

Helping others means focusing on them, not ''me''.

Helping others provides a time to cleanse the mind of the harmful byproducts of selfishness; fear, doubt, anticipation', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Topic: Helping others is vital to our survival.\par
\par
Anxiety depends on a DESIREd outcome.\par
\par
Desire leads to suffering/anxiety because it is about ''me''.\par
\par
Helping others means focusing on them.\par
\par
It provides a time to cleanse the mind of the harmful byproducts of selfishness; fear, doubt, anticipation\par
\par
\par
\par
\f1\par
}
', 1, CAST(N'2024-11-13T23:02:57.420' AS DateTime), CAST(N'2024-11-13T23:31:59.670' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1131, 48, N'ToDo', 1000, N'Fuel cap
Floor mats
Fuel door

Done:
R mirror
Sam''s club membership', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Fuel cap\par
R mirror\par
Floor mats\par
Sam''s club membership\f1\par
}
', 1, CAST(N'2024-11-15T16:53:59.970' AS DateTime), CAST(N'2024-12-11T03:21:09.537' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1132, 46, N'Things To Sell', 1000, N'Grow room
LED grow light
Printers
A/C
Truck bed cover
Car luggage racks', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Grow room\par
Printer\par
A/C\par
Bed cover\par
Luggage racks\f1\par
}
', 1, CAST(N'2024-11-15T19:24:33.273' AS DateTime), CAST(N'2024-11-19T17:46:58.330' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1133, 49, N'test1', 1000, N'test', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 test\f1\par
}
', 1, CAST(N'2024-11-15T22:56:33.923' AS DateTime), CAST(N'2024-11-19T18:01:59.277' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1134, 46, N'Thanksgiving With Jackie and Da Kids', 1000, N'Had t.giving in florida w/ jackie.

jackie''s house is always very, very messy. Clothes all over. The craft room was completely junked.

Can''t stay there again upstairs. Nice of her to have the bed and all but the stairs are a killer due to no handrails and getting up from the floor is just too hard. She also procrastinates a lot.

Like father like daughter I guess. Alanah has it too. Enjoyed hanging out w/ her but it''s tough bc of age - only 16 which is the new 12 or 13 Jackie and I think. She complains a lot.

Jackie and Cam treat her badly. They denigrate and make fun of her bc of her intelligence. Sad.

Cam is a treat. We talked about racial history. At one point he was like oh wait you grew up in Gastonia in the 60''s??? He said they just read about that in school but I lived it. Real grandpa moment - passing along the real history.  We discussed racism for a long while.

Heidi did OK but has real problems. Did the ''no shift until re-start'' thing regularly but once I had to reset codes before it would shift again. Horrible mpg ... 30.2 :(.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Had t.giving in florida w/ jackie.\par
\par
jackie''s house is always very, very messy. Clothes all over. The craft room was completely junked.\par
\par
Can''t stay there again upstairs. Nice of her to have the bed and all but the stairs are a killer due to no handrails and getting up from the floor is just too hard. She also procrastinates a lot.\par
\par
Like father like daughter I guess. Alanah has it too. Enjoyed hanging out w/ her but it''s tough bc of age - only 16 which is the new 12 or 13 Jackie and I think. She complains a lot.\par
\par
Jackie and Cam treat her badly. They denigrate and make fun of her bc of her intelligence. Sad.\par
\par
Cam is a treat. We talked about racial history. At one point he was like oh wait you grew up in Gastonia in the 60''s??? He said they just read about that in school but I lived it. Real grandpa moment - passing along the real history.  We discussed racism for a long while.\par
\par
Heidi did OK but has real problems. Did the ''no shift until re-start'' thing regularly but once I had to reset codes before it would shift again. Horrible mpg ... 30.2 :(.\f1\par
}
', 1, CAST(N'2024-12-01T15:15:25.910' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1135, 47, N'qedwsr', 1000, N'324341342324', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 qewr\f1\par
}
', 0, CAST(N'2024-12-03T19:36:00.443' AS DateTime), CAST(N'2024-12-03T19:38:28.310' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1136, 48, N'asdfsad', 1000, N'qwerqwer', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 qwerqwer\f1\par
}
', 0, CAST(N'2024-12-03T19:40:37.293' AS DateTime), CAST(N'2024-12-03T19:40:56.160' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1137, 50, N'asdf', 1000, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 1, CAST(N'2024-12-03T19:55:07.340' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1138, 51, N'asdf', 1000, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 1, CAST(N'2024-12-03T20:00:03.833' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1139, 46, N'The Power of Illusion', 1000, N'Celebrity endorsements
ugly trans women

There is a strong undercurrent of denial present in society today

There is pressure on society to believe things which are domonstrably not true; 
  Joe Biden''s mental state has been bad since 2020. He was truly a joke even then but now everyone stands aghast at the White House for just now admitting it.
  The economy is bad. We have been told emphatically that it is an historically strong and positive economy when we can see plainly that it is not.

Shades of 1984 and Animal Farm? Read them again.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Celebrity endorsements\par
ugly trans women\f1\par
}
', 1, CAST(N'2024-12-07T11:16:09.717' AS DateTime), CAST(N'2024-12-07T11:27:45.587' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1140, 46, N'My Twisted Saga of Pain', 1000, N'** Sent to Paige Ingram 12/13/24 **

My back hurts so much 24/7 that I always put off leaving my chair to go to the bathroom or kitchen, or to walk out to my car. There are good moments; I walked my dog the other day for the first time in months, but the past 10 years have seen nothing but decline.
I hurt all night, sleeping only 4 hours or so at a time before having to painfully shift position, then wake up in pain every morning.
There''s no way I can work. Even a few days out and about leaves me with elevated feet taking painkillers and muscle relaxants for three days. I couldn''t even keep up with a fully remote role due to how hard it is to concentrate sufficiently to complete a workday.The problems are all in my legs, all stemming from my lower back. My left leg hurts the most since I''ve been posturally favoring it for the past 40 years to keep my back from hurting. I stand up carefully and slowly then unfold until I''m standing, careful as I start moving that a searing pain might flash through a knee and I''ll need to catch myself from falling.
The depression creeps up on you, and springs when you get honest about the situation. I have judgements against me for debt and I''m forced to live on Social Security retirement and a small VA disability stipend. My housing situation is tenuous - basically a 6mo. at a time arrangement. I use food stamps while I sit at my desk writing enterprise-level computer programs using advanced data management techniques all the while knowing that my skills are useless. 



Knees and hips hurt 24/7.So much I put off going to the bathroom, going into the kitchen, walking out to my car, buying groceries.
I hurt all night, sleeping only 4 hours or so at a time before painfully changing positions.
I wake up in pain, grimacing as I get out of bed.
There''s no way I can work. Even a few days out and about leaves me with elevated feet taking painkillers and muscle relaxants for three days, and fully remote jobs are no longer a thing in my field.The problems are all in my legs, all stemming from my lower back. My left leg hurts the most since I''ve been posturally favoring it for the past 40 years to keep my back from hurting. Constant pain in my hips and radiating down my legs makes me stand up carefully and slowly stand erect, careful as I start walking, guarding against searing pain that might flash through a knee and I''ll need to catch myself.
The depression creeps up on you, and springs when you get honest about the situation. I have judgements against me for debt and I''m forced to live on Social Security retirement and a small VA disability stipend. My housing situation is tenuous - basically a 6mo. at a time arrangement. I use food stamps while I sit at my desk writing enterprise-level computer programs using advanced data management techniques all the while knowing that my skills are useless. 
Damn right it''s depressing.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Knees and hips hurt 24/7.\line So much I put off going to the bathroom, going into the kitchen, walking out to my car, buying groceries.\par
I hurt all night, sleeping only 4 hours or so at a time before painfully changing positions.\par
I wake up in pain, grimacing as I get out of bed.\par
There''s no way I can work. Even a few days a week out and about leaves me with elevated feet taking painkillers and muscle relaxants for three days.\line The problems are all in my legs, all stemming from my lower back. My left leg hurts the most since I''ve been posturally favoring it for the past 40 years to keep my back from hurting. I stand up carefully and slowly stand erect, careful in case as I start walking a searing pain will flash through a knee and I''ll need to catch myself.\par
The depression creeps up on you until you look at the situation. I have judgements against me for debt and I''m forced to live on Social Security retirement and a small VA disability stipend. My housing situation is tenuous - basically a 6mo. at a time arrangement. I use food stamps while I sit at my desk for 13 hours a day writing enterprise-level computer programs using advanced data management strategies all the while knowing that my skills are useless.\line\f1\par
}
', 1, CAST(N'2024-12-09T02:19:45.043' AS DateTime), CAST(N'2024-12-13T07:18:21.887' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1141, 46, N'I GAVE CAMERON HIS FIRST CORMAC MCCARTHY !!!', 1000, N'Along the ''being a better grandpa'' road :).

I sent him a paragraph or two from The Passenger relating to a paper he''d written about procrastination. He said it was pleasingly complex and he didn''t usually find things to read which didn''t bore him.

Oh baby. I sent him the Border Trilogy. Am recommending that, then start from The Orchard Keeper and read through Suttree, then Blood Meridian, The Road, then all the rest.', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 Along the ''being a better grandpa'' road :).\par
\par
I sent him a paragraph or two from The Passenger relating to a paper he''d written about procrastination. He said it was pleasingly complex and he didn''t usually find things to read which didn''t bore him.\par
\par
Oh baby. I sent him the Border Trilogy. Am recommending that, then start from The Orchard Keeper and read through Suttree, then Blood Meridian, The Road, then all the rest.\f1\par
}
', 1, CAST(N'2024-12-09T02:33:05.253' AS DateTime), CAST(N'2024-12-09T02:33:40.767' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1142, 48, N'asd', 1000, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 0, CAST(N'2024-12-14T18:13:07.490' AS DateTime), CAST(N'2024-12-14T18:32:54.237' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1143, 48, N'asdf', 1000, N'asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 asdf\f1\par
}
', 0, CAST(N'2024-12-14T18:14:09.647' AS DateTime), CAST(N'2024-12-14T18:14:40.267' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1144, 48, N'asdfasdf', 1000, N'adfasdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 adfasdf\f1\par
}
', 0, CAST(N'2024-12-14T18:15:49.027' AS DateTime), CAST(N'2024-12-14T18:32:48.490' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1145, 48, N'32432', 1000, N'4234234', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 4234234\f1\par
}
', 0, CAST(N'2024-12-14T18:19:50.887' AS DateTime), CAST(N'2024-12-14T18:32:44.390' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1146, 48, N'yiyuyui', 1000, N'uyiyui', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 uyiyui\f1\par
}
', 0, CAST(N'2024-12-14T18:24:06.670' AS DateTime), CAST(N'2024-12-14T18:32:39.800' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1147, 48, N'123123', 1000, N'12341234', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 12341234\f1\par
}
', 0, CAST(N'2024-12-14T18:26:58.910' AS DateTime), CAST(N'2024-12-14T18:32:33.590' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1148, 48, N'khjkj', 1000, N'lklklkjqwerf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 lklklkj\f1\par
}
', 1, CAST(N'2024-12-14T18:35:45.630' AS DateTime), CAST(N'2024-12-14T18:40:46.423' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1149, 48, N'asdsadf', 1000, N'asdfsdfazxcvzxcZXC', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 asdfsdfa\f1\par
}
', 1, CAST(N'2024-12-14T18:38:22.407' AS DateTime), CAST(N'2024-12-14T18:39:26.680' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1150, 48, N'qeqwre', 1000, N'qwerwqer', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 qwerwqer\f1\par
}
', 1, CAST(N'2024-12-14T18:40:54.283' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1151, 48, N'123414', 1000, N'12341234asdf', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 12341234\f1\par
}
', 1, CAST(N'2024-12-14T18:41:13.430' AS DateTime), CAST(N'2024-12-14T18:45:41.147' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1152, 48, N'qwerewq', 1000, N'qwewqer', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 qwewqer\f1\par
}
', 1, CAST(N'2024-12-14T18:45:49.613' AS DateTime), NULL)
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1153, 48, N'1324544', 1000, N'53453', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 53453\f1\par
}
', 1, CAST(N'2024-12-14T18:46:03.510' AS DateTime), CAST(N'2024-12-14T18:46:10.630' AS DateTime))
GO
INSERT [dbo].[NotebookEntries] ([Id], [ParentId], [Title], [CreatedBy], [Text], [RTF], [IsActive], [CreatedOn], [EditedOn]) VALUES (1154, 48, N'4355432', 1000, N'34253425fdfda', N'{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}{\f1\fnil Segoe UI;}}
{\*\generator Riched20 10.0.22621}\viewkind4\uc1 
\pard\f0\fs18 34253425\f1\par
}
', 1, CAST(N'2024-12-14T18:46:56.617' AS DateTime), CAST(N'2024-12-14T18:47:29.373' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[NotebookEntries] OFF
GO
SET IDENTITY_INSERT [dbo].[Notebooks] ON 
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (1, 28, N'Teva''s', 45, NULL, N'The world''s best sandal.', 0, CAST(N'2023-08-18T10:54:15.903' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (2, 32, N'Large for Large Necks', 45, NULL, N'How large is your neck?', 0, CAST(N'2023-08-18T10:59:30.070' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (3, 30, N'How spiffy is your blazer?', 45, NULL, N'WEAR WHAT YOU SELL!', 0, CAST(N'2023-08-18T14:00:14.217' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (4, 29, N'''Nother wool coat?', 45, NULL, N'Not at all! Here is where to talk about why it''s not just another wool coat.', 0, CAST(N'2023-08-18T15:34:40.630' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (5, 25, N'Chapeaus', 45, NULL, N'It''s ''hat'' in French.', 0, CAST(N'2023-08-18T15:37:19.603' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (6, 31, N'On a lovely wrist', 45, NULL, N'A bracelet is nice.', 0, CAST(N'2023-08-18T15:40:41.750' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (7, 26, N'A nice one is cute hoo boy', 45, NULL, N'All about nice bonetts.', 0, CAST(N'2023-08-18T15:44:29.513' AS DateTime), CAST(N'2023-08-26T15:48:35.153' AS DateTime))
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (8, 31, N'My take on the bracelet', 52, NULL, N'My feelings about bracelets.', 0, CAST(N'2023-08-18T15:49:26.300' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (9, 36, N'How high is too high?', 45, NULL, N'A height notebook', 0, CAST(N'2023-08-19T09:02:13.577' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (10, 37, N'Why Leather?', 53, NULL, N'Because it''s the best.', 0, CAST(N'2023-08-19T09:52:29.923' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (11, 37, N'Why for Driving?', 53, NULL, N'Leather is the best for driving.', 0, CAST(N'2023-08-19T09:53:23.777' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (12, 35, N'Why dress socks?', 53, NULL, N'Because they''re the best.', 0, CAST(N'2023-08-19T09:55:31.407' AS DateTime), CAST(N'2023-08-28T01:20:23.830' AS DateTime))
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (13, 34, N'Why Low-Rise?', 45, NULL, N'Because low rise are the best.', 0, CAST(N'2023-08-19T10:03:28.507' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (14, 39, N'Why rings?', 45, NULL, N'Rings are the best!', 0, CAST(N'2023-08-19T10:04:33.450' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (15, 27, N'The History of Shoes', 45, NULL, N'This is all of it.', 0, CAST(N'2023-08-20T21:07:58.287' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (16, 40, N'1st one in NTH', 45, NULL, N'whho booy!', 0, CAST(N'2023-08-22T14:27:57.220' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (17, 35, N'2nd Spiffy Notebook', 45, NULL, N'a spiffy notebook!', 0, CAST(N'2023-08-22T16:45:21.180' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (18, 38, N'Notebook in Ski', 45, NULL, N'all about sking', 0, CAST(N'2023-08-23T12:30:06.920' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (19, 25, N'Bowlers', 45, NULL, N'all about bowler hats', 0, CAST(N'2023-08-26T15:53:07.303' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (20, 45, N'Football', 45, NULL, N'Gaming helmets', 0, CAST(N'2023-08-26T18:13:07.707' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (21, 49, N'Looking on the south side', 45, NULL, N'All comments about the south side', 0, CAST(N'2023-08-26T18:15:20.290' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (23, 51, N'Who''s a Downie?', 45, NULL, N'I am!', 0, CAST(N'2023-08-26T18:23:12.613' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (24, 52, N'A new recursion notebook!', 52, NULL, N'Yay!', 0, CAST(N'2023-08-31T08:58:01.470' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (25, 42, N'My Man notebook', 45, NULL, N'my man', 0, CAST(N'2023-09-08T01:14:20.823' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (26, 54, N'1st NB in Boots grp.', 45, NULL, N'It''s the first nb.', 0, CAST(N'2023-09-17T22:37:51.060' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (27, 27, N'Why not shoes?', 45, NULL, N'Because!', 0, CAST(N'2023-09-18T20:11:49.407' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (28, 27, N'My Notebook w/ PIN', 45, N'1111', N'A notebook', 0, CAST(N'2023-09-19T13:13:43.013' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (29, 47, N'Da first NB', 45, NULL, N'it''s da 1st', 0, CAST(N'2023-09-19T13:47:42.990' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (30, 47, N'Da 2nd NB', 45, NULL, N'it''s da 2nd', 0, CAST(N'2023-09-19T13:48:42.217' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (31, 51, N'Now who''s a Downie?', 45, NULL, N'Who?', 0, CAST(N'2023-09-19T13:51:06.427' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (32, 49, N' A Gastonia story', 45, NULL, N'it''s a story', 0, CAST(N'2023-09-19T13:53:40.247' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (33, 47, N'da 3rd NB', 45, NULL, N'it''s da 3rd', 0, CAST(N'2023-09-19T14:18:42.317' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (34, 50, N'Who''s an Uppie?', 45, NULL, N'who is it?', 0, CAST(N'2023-09-19T14:21:10.363' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (35, 51, N'Trying Again!', 45, NULL, N'i''ll never stop', 0, CAST(N'2023-09-19T16:31:23.207' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (37, 54, N'And I''m the 2nd!', 45, NULL, N'Yay me!', 0, CAST(N'2023-09-19T16:43:32.013' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (38, 54, N'A Boot NB w/ a PIN 1111', 45, N'1111', N'dID IT work ???', 0, CAST(N'2023-09-19T17:26:25.053' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (39, 43, N'It''s the 1st Notebook in Da Middle!', 45, NULL, N'Hey what about when a NB''s Name already exists?', 0, CAST(N'2023-09-19T17:50:38.013' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (40, 55, N'Why not auto-create?', 45, NULL, N'Write it down!', 0, CAST(N'2023-09-19T18:36:49.393' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (41, 26, N'A bonnet makes me weak', 45, NULL, N'in the knees', 0, CAST(N'2023-09-19T18:48:49.423' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (42, 56, N'Here''s One', 45, NULL, N'It won''t work', 0, CAST(N'2023-09-19T22:59:26.617' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (43, 41, N'Now c''mon', 45, NULL, N'Hey!', 0, CAST(N'2023-09-20T13:03:43.987' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (44, 28, N'New in Group w/ Tevas', 45, NULL, N'new', 0, CAST(N'2023-09-20T15:34:41.667' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (45, 44, N'What the heck?', 45, NULL, N'Am I doing?', 0, CAST(N'2023-09-25T00:20:13.457' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (46, -1, N'The Real Thing', 54, NULL, N'The (new) real thing.', 1, CAST(N'2023-10-15T12:07:46.017' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (47, -1, N'Colonialization and War', 1000, NULL, N'A series of entries about the possibilities that war could happen soon.', 1, CAST(N'2024-09-17T22:52:18.367' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (48, -1, N'Passat', 1000, NULL, N'The history of ''Corne''s Passat''', 1, CAST(N'2024-10-15T20:47:31.490' AS DateTime), NULL)
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (49, -1, N'Test', 1000, NULL, N'', 0, CAST(N'2024-11-15T22:56:17.237' AS DateTime), CAST(N'2024-12-03T19:49:40.537' AS DateTime))
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (50, -1, N'gdxg', 1000, NULL, N'tesxt', 0, CAST(N'2024-12-03T19:54:59.293' AS DateTime), CAST(N'2024-12-03T19:55:36.507' AS DateTime))
GO
INSERT [dbo].[Notebooks] ([Id], [ParentId], [Name], [CreatedBy], [PIN], [Description], [IsActive], [CreatedOn], [EditedOn]) VALUES (51, -1, N'sdf', 1000, NULL, N'dfs', 0, CAST(N'2024-12-03T19:57:10.853' AS DateTime), CAST(N'2024-12-03T20:00:33.400' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Notebooks] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAssignments] ON 
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (48, 45, 5, 13, 30, 39)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (49, 45, NULL, 14, 31, 40)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (50, 52, NULL, NULL, NULL, 31)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (51, 52, NULL, NULL, NULL, 32)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (52, 53, NULL, NULL, 28, 34)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (53, 53, NULL, NULL, 29, 35)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (54, 53, NULL, NULL, NULL, 36)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (55, 53, NULL, NULL, NULL, 37)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (56, 53, NULL, NULL, NULL, 38)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (57, 45, NULL, 15, 32, 41)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (58, 45, NULL, 16, 33, 42)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (59, 45, NULL, 17, 34, 43)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (60, 45, NULL, NULL, 35, 44)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (61, 45, NULL, NULL, NULL, 45)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (62, 45, NULL, NULL, NULL, 46)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (63, 45, NULL, NULL, NULL, 47)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (64, 45, NULL, NULL, NULL, 48)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (65, 45, NULL, NULL, NULL, 49)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (66, 45, NULL, NULL, NULL, 50)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (67, 45, NULL, NULL, NULL, 51)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (68, 52, NULL, NULL, NULL, 52)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (69, 53, NULL, NULL, NULL, 53)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (70, 45, NULL, NULL, NULL, 54)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (71, 45, NULL, NULL, NULL, 55)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (72, 45, NULL, NULL, NULL, 56)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (73, 54, NULL, NULL, NULL, 57)
GO
INSERT [dbo].[UserAssignments] ([Id], [UserId], [CompanyId], [AccountId], [DepartmentId], [GroupId]) VALUES (74, 54, NULL, NULL, NULL, 57)
GO
SET IDENTITY_INSERT [dbo].[UserAssignments] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPermissions] ON 
GO
INSERT [dbo].[UserPermissions] ([Id], [UserId], [CreateCompany], [CreateAccount], [CreateDepartment], [CreateGroup], [CreateNotebook], [CreateSimpleUser], [CreateMasterUser], [DeleteRenameCompany], [DeleteRenameAccount], [DeleteRenameDepartment], [DeleteRenameGroup], [EditNotebookValues], [EditNotebookSettings], [DeleteRenameNotebooks], [ManageUsers], [ManageUserPermissions], [IsActive], [CreatedOn], [EditedOn]) VALUES (13, 45, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-08-07T07:32:10.050' AS DateTime), NULL)
GO
INSERT [dbo].[UserPermissions] ([Id], [UserId], [CreateCompany], [CreateAccount], [CreateDepartment], [CreateGroup], [CreateNotebook], [CreateSimpleUser], [CreateMasterUser], [DeleteRenameCompany], [DeleteRenameAccount], [DeleteRenameDepartment], [DeleteRenameGroup], [EditNotebookValues], [EditNotebookSettings], [DeleteRenameNotebooks], [ManageUsers], [ManageUserPermissions], [IsActive], [CreatedOn], [EditedOn]) VALUES (20, 52, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 1, CAST(N'2023-08-18T11:26:07.553' AS DateTime), NULL)
GO
INSERT [dbo].[UserPermissions] ([Id], [UserId], [CreateCompany], [CreateAccount], [CreateDepartment], [CreateGroup], [CreateNotebook], [CreateSimpleUser], [CreateMasterUser], [DeleteRenameCompany], [DeleteRenameAccount], [DeleteRenameDepartment], [DeleteRenameGroup], [EditNotebookValues], [EditNotebookSettings], [DeleteRenameNotebooks], [ManageUsers], [ManageUserPermissions], [IsActive], [CreatedOn], [EditedOn]) VALUES (22, 53, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, NULL, NULL, 1, CAST(N'2023-08-19T09:51:11.070' AS DateTime), NULL)
GO
INSERT [dbo].[UserPermissions] ([Id], [UserId], [CreateCompany], [CreateAccount], [CreateDepartment], [CreateGroup], [CreateNotebook], [CreateSimpleUser], [CreateMasterUser], [DeleteRenameCompany], [DeleteRenameAccount], [DeleteRenameDepartment], [DeleteRenameGroup], [EditNotebookValues], [EditNotebookSettings], [DeleteRenameNotebooks], [ManageUsers], [ManageUserPermissions], [IsActive], [CreatedOn], [EditedOn]) VALUES (24, 54, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, 1, 1, 1, 1, CAST(N'2023-12-31T02:13:18.040' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[UserPermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [CreatedBy], [Name], [Password], [AccessLevel], [IsActive], [CreatedOn], [EditedOn]) VALUES (45, N'big@boy', 45, N'big', N'J6nWxD/lm/sLNpEHrzwu0Q==', 6, 1, CAST(N'2023-08-07T04:30:04.597' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Email], [CreatedBy], [Name], [Password], [AccessLevel], [IsActive], [CreatedOn], [EditedOn]) VALUES (52, N'mr@mr', 45, N'mr', N'WmEUm9jE/X7q+4+bVYtMUQ==', 3, 1, CAST(N'2023-08-14T07:09:25.897' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Email], [CreatedBy], [Name], [Password], [AccessLevel], [IsActive], [CreatedOn], [EditedOn]) VALUES (53, N'jsr@jsr', 53, N'jsr', N'xzzM0NZ9vh8Ki5ksTWrnQw==', 4, 1, CAST(N'2023-08-15T11:25:32.037' AS DateTime), NULL)
GO
INSERT [dbo].[Users] ([Id], [Email], [CreatedBy], [Name], [Password], [AccessLevel], [IsActive], [CreatedOn], [EditedOn]) VALUES (54, N'agFinder@myJournal1!', NULL, N'agFinder', N'dFZVI8kKPV3RmLgUkl5WabH4hUBB0Mb2UXrv8I2f/Lk=', 3, 1, CAST(N'2023-10-15T11:33:58.137' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [DF_Companies_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [DF_Companies_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [DF_Companies_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Departments_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Departments_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Table_1_CreateOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Labels] ADD  CONSTRAINT [DF_Labels_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Labels] ADD  CONSTRAINT [DF_Labels_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Logins] ADD  CONSTRAINT [DF_Logins_LoginDate]  DEFAULT (getdate()) FOR [LoginDate]
GO
ALTER TABLE [dbo].[meta_AccessLevels] ADD  CONSTRAINT [DF_AccessLevels_Group]  DEFAULT ((0)) FOR [AccessLevel]
GO
ALTER TABLE [dbo].[NotebookEntries] ADD  CONSTRAINT [DF_NotebookEntries_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[NotebookEntries] ADD  CONSTRAINT [DF_NotebookEntries_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Notebooks] ADD  CONSTRAINT [DF_Notebooks_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Notebooks] ADD  CONSTRAINT [DF_Notebooks_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreateCompany]  DEFAULT ((0)) FOR [CreateCompany]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreateAccount]  DEFAULT ((0)) FOR [CreateAccount]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreateDepartment]  DEFAULT ((0)) FOR [CreateDepartment]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreateGroup]  DEFAULT ((0)) FOR [CreateGroup]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreateSimpleUser]  DEFAULT ((0)) FOR [CreateSimpleUser]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreateMasterUser]  DEFAULT ((0)) FOR [CreateMasterUser]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Table_1_DeleteCompany]  DEFAULT ((0)) FOR [DeleteRenameCompany]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_DeleteRenameAccount]  DEFAULT ((0)) FOR [DeleteRenameAccount]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_DeleteRenameDepartment]  DEFAULT ((0)) FOR [DeleteRenameDepartment]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Table_1_DeleteGroup]  DEFAULT ((0)) FOR [DeleteRenameGroup]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Table_1_EditNotebooks]  DEFAULT ((0)) FOR [EditNotebookValues]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_EditNotebookSettings]  DEFAULT ((0)) FOR [EditNotebookSettings]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_DeleteRenameNotebooks]  DEFAULT ((0)) FOR [DeleteRenameNotebooks]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_ManageUsers]  DEFAULT ((0)) FOR [ManageUsers]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_ManageUserPermissions]  DEFAULT ((0)) FOR [ManageUserPermissions]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_Permissions_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[UserAssignments]  WITH CHECK ADD  CONSTRAINT [UserAssignments_CascadeDeleteUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAssignments] CHECK CONSTRAINT [UserAssignments_CascadeDeleteUser]
GO
ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [UserPermissions_CascadeDeleteUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [UserPermissions_CascadeDeleteUser]
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_Account]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|407|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/28/23
Description: Create an Account
Edited on : by : notes
	08/15/23 : jsr : Refactored to use ParentId.
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_Account]
@accountName varchar(50) = null, @accountCompanyId int, @createdBy int, @description varchar(200)
, @opType tinyint, @accountId int = 0, @isActive bit = 1

AS
BEGIN
	if @opType = 1
		begin
			insert into Accounts(Name, ParentId, CreatedBy, Description)
			values
			(@accountName, @accountCompanyId, @createdBy, @description)
		end
	else if @opType = 2
		begin
			update Accounts set Name = @accountName, ParentId = @accountCompanyId, Description = @description, IsActive = @isActive
			where Id = @accountId
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_Company]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|428|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/28/23
Description: Create a Company
Edited on : by : notes
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
	-------- : jsr : Removed 'Delete' in favor of doing an UPDATE to IsActive.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_Company]
@companyName varchar(50) = null, @createdBy int, @description varchar(200)
, @opType tinyint, @companyId int = 0, @isActive bit = 1

AS
BEGIN
	if @opType = 1
		begin
			insert into Companies(Name, CreatedBy, Description)
			values
			(@companyName, @createdBy, @description)
		end
	else if @opType = 2
		begin
			update Companies set Name = @companyName, Description = @description, IsActive = @isActive
			where Id = @companyId
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_Department]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|449|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/28/23
Description: Create a Department
Edited on : by : notes
	08/15/23 : jsr : Refactored to use ParentId.
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
	-------- : jsr : Removed 'Delete' in favor of doing an UPDATE to IsActive.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_Department]
@departmentName varchar(50) = null, @departmentAccountId int, @createdBy int, @description varchar(200)
, @opType tinyint, @departmentId int = 0, @isActive bit = 1

AS
BEGIN
	if @opType = 1
		begin
			insert into Departments(Name, ParentId, CreatedBy, Description)
			values
			(@departmentName, @departmentAccountId, @createdBy, @description)
		end
	else if @opType = 2
		begin
			update Departments set Name = @departmentName, Description = @description, IsActive = @isActive
			where Id = @departmentId
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_Group]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|470|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 07/28/23
Description: Create a Group
Edited on : by : notes
	08/09/23 : jsr : Changed comment date.
	08/16/23 : jsr : Full CRUD with @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
	-------- : jsr : Removed 'Delete' in favor of doing an UPDATE to IsActive.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_Group]
@groupName varchar(50) = null, @groupDepartmentId int, @createdBy int, @description varchar(200)
, @opType tinyint, @groupId int, @isActive bit = 1

AS
BEGIN
	if @opType = 1
		begin
			insert into Groups(Name, ParentId, CreatedBy, Description)
			values
			(@groupName, @groupDepartmentId, @createdBy, @description)
		end
	else if @opType = 2
		begin
			update Groups set Name = @groupName, ParentId = @groupDepartmentId, Description = @description, IsActive = @isActive
			where Id = @groupId
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_Label]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/12/23
Description: CRUD a Label.
Edited on : by : notes
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
	-------- : jsr : Removed 'Delete' in favor of doing an UPDATE to IsActive.
	08/20/23 : jsr : Using new 'Id' field.
	08/22/23 : jsr : Using ParentId instead of EntryId.
	08/27/23 : jsr : Added try/catch and return of 2-col table.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_Label] 
	@createdBy int = null, @labelId int = null, @isActive bit = 1
	, @labelText varchar(100), @parentId int, @opType tinyint
AS
BEGIN
	declare @retVal int = 0, @retMsg varchar(255)
	begin try
		if @opType = 1
			begin
				Insert into 
				Labels (ParentId, LabelText, CreatedBy)
				values (@parentId, @labelText, @createdBy)
				set @retVal = @@IDENTITY
			end
		else --if @opType = 2
			begin
				update Labels 
				set LabelText= @labelText
				, IsActive = @isActive
				, EditedOn = getdate()
				where Id = @labelId
				set @retVal = @labelId
			end
	end try
	begin catch
		set @retVal = @@ERROR * -1
		set @retMsg = ERROR_MESSAGE()
	end catch

	select @retVal as Value, @retMsg as Message
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_Notebook]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/11/23
Description: Create Notebook
Edited on : by : notes
	08/14/23 : jsr : Removed @createdOn (has default value)
	08/14/23 : jsr : PIN and ParentId were swapped.
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
	-------- : jsr : Removed 'Delete' in favor of doing an UPDATE to IsActive.
	08/18/23 : jsr : Added Try/Catch.
	08/18/23 : jsr : Configured to match new NotebookEntries.
	08/26/23 : jsr : Made @pin default null
					 Gave @isActive a non-null value.
					 Added @retMsg. DbAccess method now getting a reader to include @retVal and @retMsg.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_Notebook] 
	@createdBy int = null, @notebookId int = null, @parentId int = null, @isActive bit = 1
	, @description varchar(500), @name varchar(255), @pin varchar(25) = null
	, @opType tinyint
AS
BEGIN
	declare @retVal int = 0, @retMsg varchar(255)
	begin try
		if @opType = 1
			begin
				insert into Notebooks 
				(CreatedBy, Description, Name, ParentId, PIN)
				values
				(@createdBy, @description, @name, @parentId, @pin)
				set @retVal = @@IDENTITY
			end
		else --if @opType = 2
			begin
				update Notebooks set Name = @name, Description = @description, PIN = @pin
				, IsActive = @isActive, EditedOn = getdate()
				where Id = @notebookId
				set @retVal = @notebookId
			end
	end try
	begin catch
		set @retVal = @@ERROR * -1
		set @retMsg = ERROR_MESSAGE()
	end catch

	select @retVal as Value, @retMsg as Message
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_NotebookEntry]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/12/23
Description: Create Notebook Entry.
Edited on : by : notes
	08/15/23 : jsr : Removed 'EditedOn'.
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
					 Removed 'Delete' in favor of doing an UPDATE to IsActive.
	08/17/23 : jsr : Nulled the optional input variables.
	08/18/23 : jsr : Match new NotebookEntries design.
	08/19/23 : jsr : Negated error number output for identification.
	08/26/23 : jsr : Added @retMsg and return of a table instead of a scalar.
	08/29/23 : jsr : Added function to remove labels from Entry.
	09/08/24 : jsr : Swapped delete in @labelsToRemove logic to updating isActive.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_NotebookEntry] 
	@createdBy int = null, @entryId int = null, @parentId int = null, @isActive bit = 1
	, @RTF varchar(max) = null, @text varchar(max) = null, @title varchar(100) = null, @labelsToRemove varchar(500) = null
	, @opType tinyint = null
AS
BEGIN
	declare @retVal int, @retMsg varchar(255)

	if @labelsToRemove is not null
		begin
			update labels 
			set IsActive = 0
			where ParentId = @entryId
			and LabelText in 
			(select value from string_split(@labelsToRemove, ','))	
			set @retVal = -1
		end
	else
		begin try
			if @opType = 1
				begin
					Insert into NotebookEntries
					(CreatedBy, ParentId, RTF, Text, Title)
					values
					(@createdBy, @parentId, @RTF, @text, @title)
					set @retVal = @@IDENTITY
				end
			else --if @opType = 2
				begin
					update NotebookEntries set 
					RTF = @RTF, Text = @text, Title = @title
					, IsActive = @isActive, EditedOn = getdate()
					where Id = @entryId
					set @retVal = @entryId
				end
		end try
		begin catch
			set @retVal = @@ERROR * -1
			set @retMsg = ERROR_MESSAGE()
		end catch

		select @retVal as Value, @retMsg as Message

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_OrgLevel]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|491|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/31/23
Description: Create org level.
Edited on : by : notes
	08/05/23 : jsr : Renamed @creatorId = @createdBy
	08/07/23 : jsr : Added creation of user assignemnt to created org level.
	08/07/23 : jsr : Moved execute sp_Create... inside BEGIN_END blocks for account and compnany.
	08/10/23 : jsr : Cut over to 'ParentId' from individual 'types'.
	08/15/23 : jsr : Update sp name.
	08/18/23 : jsr : Added @opType input var. Not implemented yet.
	08/25/23 : jsr : Added table return values.
					 Removed @opType, added update logic.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_OrgLevel]
	@createdBy int, @orgLevelDescription varchar(200), @orgLevelType int, @isActive bit = 1
	, @orgLevelName varchar(50), @parentId int = 0, @orgId int = 0
AS
BEGIN
	BEGIN TRY
		declare @retVal int = 0, @retMsg varchar(255)
			if @orgLevelType = 3	-- Group
				begin
					if @orgId > 0
						begin
							update Groups 
							set Name = @orgLevelName, Description = @orgLevelDescription, IsActive = @isActive, EditedOn = getdate()
							where Id = @orgId
							set @retVal = @orgId
						end
					else
						begin
							insert into Groups (Name, Description, CreatedBy, ParentId)
							values (@orgLevelName, @orgLevelDescription, @createdBy, @parentId )
							execute sp_CRUD_UserAssignments @createdBy,0,0,0,@@IDENTITY
							set @retVal = @@IDENTITY
						end
				end
			if @orgLevelType = 4 -- Department
				begin
					if @orgId > 0
						begin
							update Departments 
							set Name = @orgLevelName, Description = @orgLevelDescription, IsActive = @isActive, EditedOn = getdate()
							where Id = @orgId
							set @retVal = @orgId
						end
					else
						begin
							insert into Departments (Name, Description, CreatedBy, ParentId)
							values ( @orgLevelName, @orgLevelDescription, @createdBy, @parentId )
							execute sp_CRUD_UserAssignments @createdBy,0,0,@@IDENTITY
							set @retVal = @@IDENTITY
						end
				end
			if @orgLevelType = 5	-- Account
				begin
					if @orgId > 0
						begin
							update Accounts 
							set Name = @orgLevelName, Description = @orgLevelDescription, IsActive = @isActive, EditedOn = getdate()
							where Id = @orgId
							set @retVal = @orgId
						end
					else
						begin
							insert into Accounts (Name, Description, CreatedBy, ParentId)
							values (@orgLevelName, @orgLevelDescription, @createdBy, @parentId)
							execute sp_CRUD_UserAssignments @createdBy, 0, @@IDENTITY
							set @retVal = @@IDENTITY
						end
				end
			if @orgLevelType = 6	-- Company
				begin
					if @orgId > 0
						begin
							update Companies 
							set Name = @orgLevelName, Description = @orgLevelDescription, IsActive = @isActive, EditedOn = getdate()
							where Id = @orgId
							set @retVal = @orgId
						end
					else
						begin
							insert into Companies(Name, Description, CreatedBy)
							values ( @orgLevelName, @orgLevelDescription, @createdBy )
							execute sp_CRUD_UserAssignments @createdBy,@@IDENTITY
							set @retVal = @@IDENTITY
						end
				end
	END TRY
	BEGIN CATCH
		set @retVal = @@ERROR * -1
		set @retMsg = ERROR_MESSAGE()
	END CATCH

	select @retVal as Value, @retMsg as Message
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_User]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|607|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/20/23
Description: Create User.
Edited on : by : notes
	07/24/23 : jsr : Moved creation of user assignments and permissions to their own sp's.
	07/25/23 : jsr : Returning error message on fail.
	07/27/23 : jsr : Added @createdBy
	08/02/23 : jsr : Allowed @createdBy to be null for creating new users.
	08/10/23 : jsr : Added 'Email' field.
	08/15/23 : jsr : Added full CRUD.
	08/16/23 : jsr : Implemented @opType (1 = Create, 2 = Update, 3 = Delete). See dbAccess.cs.
					 Removed 'Delete' in favor of doing an UPDATE to IsActive.
	08/27/23 : jsr : Added try/catch and return of 2-col table.
	10/15/23 : jsr : Added default for @opType. 
					 Failed to set @retVal = new user id (was = 0). Changed @@IDENTITY to SCOPE_IDENTITY().
*/
CREATE PROCEDURE [dbo].[sp_CRUD_User]
	@createdBy int = null, @userId int = null, @isActive bit = 1
	, @userName varchar(50), @password VARCHAR(2000), @accessLevel int, @email varchar(255)
	, @opType tinyint = 1
AS
BEGIN
	declare @retVal int = 0, @retMsg varchar(255)
	begin try
		if @opType = 1
			begin
				INSERT INTO users (name, password, accesslevel, CreatedBy, Email)
				VALUES
				(@username, @password, @accesslevel, @createdBy, @email)
				set @retVal = SCOPE_IDENTITY()
			end
		else --if @opType = 2
			begin
				update users set Name = @userName, Password = @password, AccessLevel = @accessLevel, Email = @email
				, IsActive = @isActive, EditedOn = getdate()
				where Id = @userId
				set @retVal = @userId
			end
	end try
	begin catch
		set @retVal = @@ERROR * -1
		set @retMsg = ERROR_MESSAGE()
	end catch

	select @retVal as Value, @retMsg as Message
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_UserAssignments]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|641|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/24/23
Description: Create assignments for the user.
Edited on : by : notes
	07/25/23 : jsr : Formatted.
	07/30/23 : jsr : Large re-write. Tested OK.
	08/07/23 : jsr : Added 'select top(1) ...' to only update the 1st row where a field is null.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_UserAssignments]
( @userId int, @companyId int = 0, @accountId int = 0, @departmentId int = 0, @groupId int = 0)
AS
BEGIN
	if @companyId > 0
		begin
			if exists (select * from UserAssignments where UserId = @userId and CompanyId IS NULL)
				begin
					update UserAssignments set CompanyId = @companyId where UserId = @userId AND Id = 
					(select top(1) Id from UserAssignments where UserId = @userId AND CompanyId IS NULL)
				end
			else
				begin
					insert into UserAssignments(UserId, CompanyId)
					values (@userId, @companyId)
				end
		end
	
	if @accountId > 0
		begin
			if exists (select * from UserAssignments where UserId = @userId and AccountId IS NULL)
				begin
					update UserAssignments set AccountId = @accountId where UserId = @userId AND Id = 
					(select top(1) Id from UserAssignments where UserId = @userId AND AccountId IS NULL)
				end
			else
				begin
					insert into UserAssignments(UserId, AccountId)
					values (@userId, @accountId)
				end
		end

	if @departmentId > 0
		begin
			if exists (select top(1) UserId from UserAssignments where UserId = @userId and DepartmentId IS NULL)
				begin
					update UserAssignments set DepartmentId = @departmentId where UserId = @userId AND Id = 
					(select top(1) Id from UserAssignments where UserId = @userId AND DepartmentId IS NULL)
				end
			else
				begin
					insert into UserAssignments(UserId, DepartmentId)
					values (@userId, @departmentId)
				end
		end

	if @groupId > 0
		begin
			if exists (select * from UserAssignments where UserId = @userId and GroupId IS NULL)
				begin
					update UserAssignments set GroupId = @groupId where UserId = @userId AND Id = 
					(select top(1) Id from UserAssignments where UserId = @userId AND GroupId IS NULL)
				end
			else
				begin
					insert into UserAssignments(UserId, GroupId)
					values (@userId, @groupId)
				end
		end

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CRUD_UserPermissions]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|712|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/24/23
Description: Create permissions for the user.
Edited on : by : notes
	07/25/23 : jsr : Commented ref's to Table-valued parameter.
	07/25/23 : jsr : Changed 'null' on parameters to '= null'. 
	07/25/23 : jsr : All table columns were changed to allow NULL.
	08/04/23 : jsr : Added @createNotebooks.
	08/07/23 : jsr : Added delete of existing row for @userId. If we want to archive at some point that's where to do it.
*/
CREATE PROCEDURE [dbo].[sp_CRUD_UserPermissions]
(
	--@TVP type_UserPermissions null readonly,

-- permissions
	@userId int = null, @createCompany bit = null, @createAccount bit = null, @createDepartment bit = null, @createGroup bit = null
	, @createNotebook bit = null
	, @createSimpleUser bit = null, @createMasterUser bit = null, @deleteRenameCompany bit = null, @deleteRenameAccount bit = null
	, @deleteRenameDepartment bit = null, @deleteRenameGroup bit = null, @deleteRenameNotebooks bit = null, @editNotebookValues bit = null
	, @editNotebookSettings bit = null, @manageUsers bit = null, @manageUserPermissions bit = null
)
AS
BEGIN

	if exists(select * from UserPermissions where UserId = @userId)
		begin delete from UserPermissions where UserId = @userId end

	insert into UserPermissions (UserId, CreateCompany, CreateAccount, CreateDepartment, CreateGroup
		, CreateNotebook
		, CreateSimpleUser, CreateMasterUser, DeleteRenameCompany, DeleteRenameAccount
		, DeleteRenameDepartment, DeleteRenameGroup, DeleteRenameNotebooks, EditNotebookValues
		, EditNotebookSettings, ManageUsers, ManageUserPermissions)
	--select 
		--case when @userId IS NULL 
		--THEN select * from @TVP

	--END
	--select * from @TVP

	values
	(@userId, @createCompany, @createAccount, @createDepartment, @createGroup
	, @createNotebook
	, @createSimpleUser, @createMasterUser, @deleteRenameCompany, @deleteRenameAccount
	, @deleteRenameDepartment, @deleteRenameGroup, @deleteRenameNotebooks, @editNotebookValues
	, @editNotebookSettings, @manageUsers, @manageUserPermissions)

	return SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCADGs]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/09/23
Description: Delete CADG's created by user.
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_DeleteCADGs] 
@userId int
AS
BEGIN
	delete from Groups		where CreatedBy = @userId
	delete from Accounts	where CreatedBy = @userId
	delete from Companies	where CreatedBy = @userId
	delete from Departments where CreatedBy = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAccessLevelPrice]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|778|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/24/23
Description: Get access level price.
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetAccessLevelPrice]
(@accessLevel int)
AS
BEGIN
    SET NOCOUNT ON
	select Price 
	from meta_AccessLevels 
	where id = @accessLevel
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAccessLevels]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|799|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/24/23
Description: Get access levels
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetAccessLevels]
AS
BEGIN
    SET NOCOUNT ON
	select id, AccessLevel, Price 
	from meta_AccessLevels 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAccounts]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/09/23
Description: Get Companies for user.
Edited on : by : notes
	08/09/23 : jsr : Changed comment date.
*/
CREATE PROCEDURE [dbo].[sp_GetAccounts] @userId int
AS
BEGIN
	SET NOCOUNT ON;
	select Id, CreatedBy, Name, Description, IsActive, CreatedOn, EditedOn
	from Accounts
	where CreatedBy = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllLabels]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 09/01/24
Description: Get all Entries in a notebook.
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetAllLabels]
AS
BEGIN
	--create table #tmp (text nChar(1000))
	--select distinct LabelText into #tmp from Labels
	--select * 
	--from Labels
	--where LabelText in (select * from #tmp)
	--drop table #tmp

	select distinct LabelText from Labels
	--group by LabelText, Id, ParentId, CreatedBy, CreatedOn, EditedOn, IsActive

	--SET NOCOUNT ON;
	--select Id, ParentId, LabelText, CreatedBy, CreatedOn, EditedOn, IsActive 
	--from Labels 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllNotebookNamesAndIds]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/11/23
Description: Get all Notebook names and id's for a Group.
Edited on : by : notes
	08/17/23 : jsr : Changed 'Id' to 'ParentId'.
	08/18/23 : jsr : Changed 'ParentId' back to 'Id' :).
	11/05/24 : jsr : Added isActive
*/
CREATE PROCEDURE [dbo].[sp_GetAllNotebookNamesAndIds] 
AS
BEGIN
	SET NOCOUNT ON;
	select Name, Id
	from Notebooks
	where IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCompanies]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/09/23
Description: Get Companies for user.
Edited on : by : notes
	08/09/23 : jsr : Changed comment date.
*/
CREATE PROCEDURE [dbo].[sp_GetCompanies] @userId int
AS
BEGIN
	SET NOCOUNT ON;
	select Id, CreatedBy, Name, Description, IsActive, CreatedOn, EditedOn
	from Companies
	where CreatedBy = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCompanyDetails]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|818|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/16/23
Description: Get company details
Edited on : by : notes
	7/24/23 : jsr : renamed
*/
create PROCEDURE [dbo].[sp_GetCompanyDetails]
(@companyId int)
AS
BEGIN
    SET NOCOUNT ON
	select id, Name, Description, IsActive, CreatedOn, EditedOn 
	from Companies 
	where Id = @companyId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDepartments]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/09/23
Description: Get Departments for user.
Edited on : by : notes
	08/09/23 : jsr : Changed comment date.
*/
CREATE PROCEDURE [dbo].[sp_GetDepartments] @userId int
AS
BEGIN
	SET NOCOUNT ON;
	select Id, CreatedBy, Name, Description, IsActive, CreatedOn, EditedOn
	from Departments
	where CreatedBy = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEntriesCreatedByUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 09/05/23
Description: Get Entries created by @userId or any user they created.
Edited on : by : notes
	09/20/23 : jsr : Implemented @isActive.
	08/22/23 : jsr : Implemented NotebookName and ParentPath.
*/
CREATE PROCEDURE [dbo].[sp_GetEntriesCreatedByUser]
	@userId int, @isActive bit = 1
AS
BEGIN
	SET NOCOUNT ON;

	select id, ParentId, Title, CreatedBy, Text, rtf, IsActive, CreatedOn, EditedOn
	, (select Name from Notebooks where Id = ne.ParentId) as NotebookName
	, (select dbo.fn_GetEntryParentTree(Id, 0, 1)) as ParentPath 
	from NotebookEntries ne
	where (CreatedBy in 
		(select Id from dbo.fnc_GetRecursiveUsers(@userId)) 
	or CreatedBy = @userId)
	and IsActive = @isActive

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEntriesForNotebook]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/24/23
Description: Get all Entries in a notebook.
Edited on : by : notes
	09/10/23 : jsr : Added 'NotebookName'. Helps with entry display on UI.
	09/20/23 : jsr : Implemented @isActive.
	09/22/23 : jsr : Implemented NotebookName and ParentPath.
	09/04/24 : jsr : Removed select for entry labels.
*/
CREATE PROCEDURE [dbo].[sp_GetEntriesForNotebook]
	@notebookId int, @isActive bit = 1
AS
BEGIN
	SET NOCOUNT ON;

	select id, ParentId, Title, CreatedBy, Text, rtf, IsActive, CreatedOn, EditedOn
	, (select Name from Notebooks where Id = @notebookId) as NotebookName
	, (select dbo.fn_GetEntryParentTree(Id, 0, 1)) as ParentPath
	from NotebookEntries 
	where ParentId = @notebookId
	and IsActive = @isActive
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEntriesUnderOrgLevel]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 09/05/23
Description: Get Entries under @orgLevel.
Edited on : by : notes
	09/20/23 : jsr : Implemented @isActive.
	08/22/23 : jsr : Implemented ParentPath.
*/
CREATE PROCEDURE [dbo].[sp_GetEntriesUnderOrgLevel]
	@orgLevel int, @orgLevelIds varchar(2000), @isActive bit = 1
AS
BEGIN
	SET NOCOUNT ON;

	if @orgLevel = 3	-- Entries under a group ...
		begin
			select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn 
			, (select dbo.fn_GetEntryParentTree(ne.Id, 0, 1)) as ParentPath
			from NotebookEntries ne
				join Notebooks n on ne.ParentId = n.Id
				join Groups g on g.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			where ne.IsActive = @isActive
			order by n.Name
		end
	else if @orgLevel = 4	-- ... under a department
		begin
			select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn 
			, (select dbo.fn_GetEntryParentTree(ne.Id, 0, 1)) as ParentPath
			from NotebookEntries ne
				join Notebooks n on ne.ParentId = n.Id
				join Groups g on n.ParentId = g.Id 
				join Departments d on d.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			where ne.IsActive = @isActive
			order by n.Name
		end
	else if @orgLevel = 5	-- ... under an account
		begin
			select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn 
			, (select dbo.fn_GetEntryParentTree(ne.Id, 0, 1)) as ParentPath
			from NotebookEntries ne
				join Notebooks n on ne.ParentId = n.Id
				join Groups g on n.ParentId = g.Id 
				join Departments d on g.ParentId = d.Id
				join Accounts a on a.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			where ne.IsActive = @isActive
			order by n.Name
		end
	else if @orgLevel = 6	-- ... under a company
		begin
			select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn
			, (select dbo.fn_GetEntryParentTree(ne.Id, 0, 1)) as ParentPath
			from NotebookEntries ne
				join Notebooks n on ne.ParentId = n.Id
				join Groups g on n.ParentId = g.Id 
				join Departments d on g.ParentId = d.Id
				join Accounts a on d.ParentId = a.Id 
				join Companies c on c.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			where ne.IsActive = @isActive
			order by n.Name
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEntriesWithLabel]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/23/23
Description: Get a Label and the CreatedBy user.
Edited on : by : notes
	09/20/23 : jsr : Implemented @isActive.
	09/22/23 : jsr : Implemented NotebookName and ParentPath.
*/
CREATE PROCEDURE [dbo].[sp_GetEntriesWithLabel] 
	@labelText varchar(100), @isActive bit = 1
AS
BEGIN
	SET NOCOUNT ON;
	select Id, ParentId, Title, CreatedBy, Text, rtf, IsActive, CreatedBy, CreatedOn, EditedOn
	, (select Name from Notebooks where Id = ne.ParentId) as NotebookName
	, (select dbo.fn_GetEntryParentTree(Id, 0, 1)) as ParentPath
	from NotebookEntries ne where id in (
		select parentId from Labels where LabelText = @labelText )
	and IsActive = @isActive
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEntry]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/24/23
Description: Get one Entry
Edited on : by : notes
	09/20/23 : jsr : Implemented @isActive.
	09/22/23 : jsr : Added Labels table return.
	08/22/23 : jsr : Implemented NotebookName and ParentPath.
*/
CREATE PROCEDURE [dbo].[sp_GetEntry]
	@entryId int, @isActive bit = 1
AS
BEGIN
	SET NOCOUNT ON;
	select Id, ParentId, Title, CreatedBy, Text, rtf, IsActive, CreatedBy, CreatedOn, EditedOn 
	, (select Name from Notebooks where Id = ne.ParentId) as NotebookName
	, (select dbo.fn_GetEntryParentTree(Id, 0, 1)) as ParentPath
	from NotebookEntries ne
	where Id = @entryId 
	and IsActive = @isActive

	select Id, ParentId, LabelText, CreatedBy, CreatedOn, EditedOn, IsActive 
	from Labels 
	where ParentId = @entryId
	and IsActive = @isActive
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEntryParents]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/24/23
Description: Get the parents of an Entry.
Edited on : by : notes
	09/11/23 : jsr : Reworked significantly after Search started working. Primarily @returnNotebook and @includeOrgLevelAbbreviation.
	09/16/23 : jsr : Reworked when above rework broke labels management :$
*/
CREATE PROCEDURE [dbo].[sp_GetEntryParents]
	@entryId int
AS
BEGIN
	SET NOCOUNT ON;
	declare @notebookId int, @groupId int, @accountId int, @departmentId int, @companyId int
	declare @nbOrgLevel varchar(4) = '', @gpOrgLevel varchar(4) = '', @dpOrgLevel varchar(4) = ''
	, @acOrgLevel varchar(4) = '', @coOrgLevel varchar(4) = ''

	set @notebookId = 
	(select ParentId from NotebookEntries
	where id = @entryId)

	set @groupId = 
	(select ParentId from Notebooks
	where Id = @notebookId)

	set @departmentId = 
	(select ParentId from Groups
	where id = @groupId)

	set @accountId = 
	(select ParentId from Departments
	where Id = @departmentId)

	set @companyId = 
	(select ParentId from Accounts
	where Id = @accountId)

	select Id, Name from Notebooks where id = @notebookId
	select Id, Name from Groups where id = @groupId
	select Id, Name from Departments where id = @departmentId
	select Id, Name from Accounts where id = @accountId
	select Id, Name from Companies where id = @companyId
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetGroups]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/09/23
Description: Get Groups for user.
Edited on : by : notes
	08/09/23 : jsr : Changed comment date.
*/
CREATE PROCEDURE [dbo].[sp_GetGroups] @userId int
AS
BEGIN
	SET NOCOUNT ON;
	select Id, CreatedBy, Name, Description, IsActive, CreatedOn, EditedOn
	from Groups
	where CreatedBy = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabelAndUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/23/23
Description: Get a Label and the CreatedBy user.
Edited on : by : notes
	09/21/23 : jsr : Removed '*' in Users call.
	10/11/23 : jsr : Added NotebookId field.
*/
CREATE PROCEDURE [dbo].[sp_GetLabelAndUser] 
	@labelId int
AS
BEGIN
	declare @createdBy int
	SET NOCOUNT ON;

	set @createdBy = (select CreatedBy from Labels where id = @labelId)

	select l.Id, l.ParentId, l.LabelText, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive, n.id as NotebookId
	from Labels l
	join NotebookEntries ne on l.ParentId = ne.Id
	join Notebooks n on ne.ParentId = n.Id
	where l.Id = @labelId

	select  Id, Email, CreatedBy, Name, Password, AccessLevel, IsActive, CreatedOn, EditedOn
	from Users 
	where id = @createdBy
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabelsForEntry]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/23/23
Description: Get Labels for an Entry.
Edited on : by : notes
	09/09/23 : jsr : Added 'ParentId' column.
	09/18/23 : jsr : Added isActive.
	09/22/23 : jsr : Formatting only.
*/
CREATE PROCEDURE [dbo].[sp_GetLabelsForEntry] 
	@entryId int
AS
BEGIN
	SET NOCOUNT ON;
	select Id, ParentId, LabelText, CreatedBy, CreatedOn, EditedOn, IsActive 
	from Labels 
	where ParentId = @entryId
	and IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabelsUnderCompany]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 10/05/23
Description: Get all Labels under a Company
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetLabelsUnderCompany] 
	@companyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select l.Id, l.ParentId, l.LabelText, l.CreatedBy, l.EditedOn, l.CreatedOn, l.IsActive, n.Id as NotebookId, g.Id as GroupId, d.Id as DepartmentId, a.Id as AccountId from Labels l
		join NotebookEntries ne on l.ParentId = ne.Id
		join Notebooks n		on ne.ParentId = n.Id
		join Groups g			on n.ParentId = g.Id
		join Departments d		on g.ParentId = d.Id
		join Accounts a			on d.ParentId = a.Id
	where a.ParentId = @companyId and l.IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLabelsUnderOrgLevel]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/24/23
Description: Get Labels for an Org Level.
Edited on : by : notes
	08/24/23 : jsr : Added Order By to returned Labels.
	08/25/23 : jsr : Added explict callout of Labels table columns instead of '*'.
	08/29/23 : jsr : Refactored to use JOIN's.
	09/18/23 : jsr : Added label.isActive.
	09/24/23 : jsr : Removed 'distinct' statements.
*/
CREATE PROCEDURE [dbo].[sp_GetLabelsUnderOrgLevel] 
	@entryId int, @orgLevel tinyint
AS
BEGIN
	SET NOCOUNT ON;
	declare @nbId int, @grpId int, @dptId int, @acntId int, @companyId int

	if @orgLevel = 1	-- NotebookEntry
		begin
			select LabelText, l.Id, l.ParentId, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive
			from Labels l where ParentId = @entryId
			and IsActive = 1
		end
	if @orgLevel >= 2	-- Notebook
		begin
			set @nbId = (
			select Id from Notebooks where Id = (
				select ParentId from NotebookEntries where Id = @entryId ))

			if(@orgLevel = 2)
				begin
					select LabelText, l.Id, l.ParentId, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive 
					from Labels l
					join NotebookEntries ne on l.ParentId = ne.id
					where ne.ParentId = @nbId
					and l.IsActive = 1
					order by LabelText
				end
		end
	if @orgLevel >= 3	-- Group
		begin
			set @grpId = (
			select Id from Groups where Id = (
					select ParentId from Notebooks where id = @nbId ))
			
			if @orgLevel = 3
				begin
					select LabelText, l.Id, l.ParentId, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive 
					from Labels l
					join NotebookEntries ne on l.ParentId = ne.id
					join Notebooks n		on ne.ParentId = n.Id
					where n.ParentId = @grpId
					and l.IsActive = 1
					order by LabelText
				end
		end
	if @orgLevel >= 4	-- Department
		begin
			set @dptId = (
				select Id from Departments where Id = (
					select ParentId from Groups where id = @grpId ))		

			if @orgLevel = 4
				begin
					select LabelText, l.Id, l.ParentId, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive 
					from Labels l
					join NotebookEntries ne on l.ParentId = ne.id
					join Notebooks n		on ne.ParentId = n.Id
					join Groups g			on n.ParentId = g.Id
					where g.ParentId = @dptId
					and l.IsActive = 1
					order by LabelText
				end
		end
	if @orgLevel >= 5	-- Account
		begin
			set @acntId = (
				select Id from Accounts where Id = (
					select ParentId from Departments where Id = @dptId ))	

			if @orgLevel = 5
				begin
					select LabelText, l.Id, l.ParentId, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive 
					from Labels l
					join NotebookEntries ne on l.ParentId = ne.id
					join Notebooks n		on ne.ParentId = n.Id
					join Groups g			on n.ParentId = g.Id
					join Departments d		on g.ParentId = d.Id
					where d.ParentId = @acntId
					and l.IsActive = 1
					order by LabelText
				end
			
		end
	if @orgLevel >= 6	-- Company
		begin
			set @companyId = (
				select Id from Companies where Id = (
					select ParentId from Accounts where Id = @acntId))			

			if @orgLevel = 6
				begin
					select LabelText, l.Id, l.ParentId, l.CreatedBy, l.CreatedOn, l.EditedOn, l.IsActive 
					from Labels l
					join NotebookEntries ne on l.ParentId = ne.id
					join Notebooks n		on ne.ParentId = n.Id
					join Groups g			on n.ParentId = g.Id
					join Departments d		on g.ParentId = d.Id
					join Accounts a			on d.ParentId = a.Id
					where a.ParentId = @companyId
					and l.IsActive = 1
					order by LabelText
				end	
		end

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNotebook]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/11/23
Description: Get one Notebook.
Edited on : by : notes
	08/12/23 : jsr : Added return of Notebook Entries (w/ truncated name & text).
	08/15/23 : jsr : Removed getting entries (moved to sp_GetNotebookEntries.
	08/16/23 : jsr : Added EditedOn
	08/17/23 : jsr : Changed 'Id' to 'ParentId'.
	08/18/23 : jsr : Match new Notebooks design.
	11/05/24 : jsr : Added isActive
*/
CREATE PROCEDURE [dbo].[sp_GetNotebook] @Id int
AS
BEGIN
	SET NOCOUNT ON;
	select Id, CreatedBy, CreatedOn, ParentId, PIN, ParentId, Description, Name, EditedOn
	from Notebooks
	where Id = @Id
	and IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNotebookEntries]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/12/23
Description: Get Entries in a Notebook. Title and Text are truncated.
Edited on : by : notes
	08/15/23 : jsr : Added alias to fields in Case.. statements.
	08/16/23 : jsr : Remove truncation of Title.
	08/17/23 : jsr : Removed 'Id' field (no longer used as PK).
	08/18/23 : jsr : Configured to match new NotebookEntries.
	08/29/23 : jsr : Removed truncation of Text. Handled in code.
	09/20/23 : jsr : Implemented @isActive.
*/
CREATE PROCEDURE [dbo].[sp_GetNotebookEntries]
@notebookId int, @isActive bit = 1
AS
BEGIN
	SET NOCOUNT ON;
	select Id, CreatedBy, CreatedOn, EditedOn, ParentId, Title, Text
	from NotebookEntries
	where ParentId = @notebookId
	and IsActive = @isActive
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNotebookEntry_Full]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/12/23
Description: Get full title and text of an Entry.
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetNotebookEntry_Full]
@entryId int
AS
BEGIN
	SET NOCOUNT ON;
	select Text, RTF
	from NotebookEntries
	where Id = @entryId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNotebookNamesAndIds]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/11/23
Description: Get all Notebook names and id's for a Group.
Edited on : by : notes
	08/17/23 : jsr : Changed 'Id' to 'ParentId'.
	08/18/23 : jsr : Changed 'ParentId' back to 'Id' :).
*/
CREATE PROCEDURE [dbo].[sp_GetNotebookNamesAndIds] @groupId int
AS
BEGIN
	SET NOCOUNT ON;
	select Name, Id
	from Notebooks
	where ParentId = @groupId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNotebooksCreatedByUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 09/05/23
Description: Get Notebooks created by @userId or any user they created.
Edited on : by : notes
*/
create PROCEDURE [dbo].[sp_GetNotebooksCreatedByUser]
	@userId int
AS
BEGIN
	SET NOCOUNT ON;

	select * 
	from Notebooks 
	where CreatedBy in 
		(select Id from dbo.fnc_GetRecursiveUsers(@userId)) 
	or CreatedBy = @userId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNotebooksUnderOrgLevel]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 09/05/23
Description: Get Notebooks under @orgLevel.
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetNotebooksUnderOrgLevel]
	@orgLevel int, @orgLevelIds varchar(2000)
AS
BEGIN
	SET NOCOUNT ON;

	if @orgLevel = 3	-- Notebooks under a group ...
		begin
		--	select distinct n.Id, n.ParentId, n.Name, n.PIN, n.CreatedBy, n.Description, n.CreatedOn, n.EditedOn from Notebooks n
		--	where ParentId in 
		--		(select Id from Groups where parentId in
		--		(select * from dbo.fnc_SplitString(@ids, ',')))
		--	join Groups g on g.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
		--end
		--select * from Notebooks n where ParentId in 
		--	(select * from dbo.fnc_SplitString(@orgLevelIds, ','))			-- groups
			select distinct n.Id, n.ParentId, n.Name, n.PIN,  n.CreatedBy, n.Description, n.CreatedOn, n.EditedOn from Notebooks n
			join Groups g on g.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			order by n.Name
	end

	else if @orgLevel = 4	-- ... under a department
		begin
			----select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn from NotebookEntries ne
			----join Notebooks n on ne.ParentId = n.Id
			--select distinct n.Id, n.ParentId, n.Name, n.PIN, n.CreatedBy, n.Description, n.CreatedOn, n.EditedOn from Notebooks n
			--join Groups g on n.ParentId = g.Id 
			--join Departments d on d.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			--order by n.Name
			--select * from Notebooks n where ParentId in 
			--	(select Id from Groups where ParentId in
			--		(select * from dbo.fnc_SplitString(@orgLevelIds, ',')))		-- department
			select distinct n.Id, n.ParentId, n.Name, n.PIN,  n.CreatedBy, n.Description, n.CreatedOn, n.EditedOn from Notebooks n
			join Groups g on n.ParentId = g.Id 
			join Departments d on d.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			order by n.Name
		end
	else if @orgLevel = 5	-- ... under an account
		begin
			--select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn from NotebookEntries ne
			--join Notebooks n on ne.ParentId = n.Id
			select distinct n.Id, n.ParentId, n.Name, n.PIN,  n.CreatedBy, n.Description, n.CreatedOn, n.EditedOn from Notebooks n
			join Groups g on n.ParentId = g.Id 
			join Departments d on g.ParentId = d.Id
			join Accounts a on a.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			order by n.Name
		end
	else if @orgLevel = 6	-- ... under a company
		begin
			--select distinct Title, n.Name as NotebookName, ne.Id, ne.ParentId, ne.CreatedBy, Text, ne.CreatedOn, ne.EditedOn from NotebookEntries ne
			--join Notebooks n on ne.ParentId = n.Id
			select distinct n.Id, n.ParentId, n.Name, n.PIN, n.CreatedBy, n.Description, n.CreatedOn, n.EditedOn from Notebooks n
			join Groups g on n.ParentId = g.Id 
			join Departments d on g.ParentId = d.Id
			join Accounts a on d.ParentId = a.Id 
			join Companies c on c.Id in (select * from  dbo.fnc_SplitString(@orgLevelIds, ','))
			order by n.Name
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrgLevelChildren]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|840|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/30/23
Description: Get child items of a parent item
Edited on : by : notes
	08/10/23 : jsr : Added ParentId instead of specifying a 'type'.
	08/14/23 : jsr : Reversed @orgLevelId indexing to reflect change in app (list boxes .Tag).
	08/30/23 : jsr : Added @userId to select only items created by the user or by users they created.
	08/31/23 : jsr : Moved recursive dive into users to sp_GetOrgLevelItemsAvailableToUser using fnc_GetRecursiveUsers.
*/
CREATE PROCEDURE [dbo].[sp_GetOrgLevelChildren]
(@orgLevelId int, @parentId int, @userId int)
AS
BEGIN
    SET NOCOUNT ON
	if(@orgLevelId = 2) -- get notebooks under a group
		begin
			select ParentId as Id, Name, Description
			from Notebooks
			where ParentId = @parentId
			and (CreatedBy in 
				(select Id from dbo.fnc_GetRecursiveUsers(@userId)) 
				or CreatedBy = @userId)
		end

	if(@orgLevelId = 3) -- get groups under a department
		begin
			select Id, Name, Description
			from Groups
			where ParentId = @parentId
			and (CreatedBy in 
				(select Id from dbo.fnc_GetRecursiveUsers(@userId)) 
				or CreatedBy = @userId)
		end

	if(@orgLevelId = 4) -- get departments under an account
		begin
			select Id, Name, Description
			from Departments
			where ParentId = @parentId
			and (CreatedBy in 
				(select Id from dbo.fnc_GetRecursiveUsers(@userId)) 
				or CreatedBy = @userId)
		end

	if(@orgLevelId = 5)	-- get accounts under a company
		begin
			select Id, Name, Description
			from Accounts
			where ParentId = @parentId	
			and (CreatedBy in 
				(select Id from dbo.fnc_GetRecursiveUsers(@userId)) 
				or CreatedBy = @userId)
		end

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrgLevelItems]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|886|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/30/23
Description: Get OrgLevel
Edited on : by : notes
	08/07/23 : jsr : Changed join (removed 'left')
*/
CREATE PROCEDURE [dbo].[sp_GetOrgLevelItems]
(@userId int)
AS
BEGIN
    SET NOCOUNT ON
	declare @accessLevel int = (select AccessLevel from users where id = @userId)

	if(@accessLevel = 3)
		begin
			select ua.GroupId as Id, g.Name, g.Description
			from 
			UserAssignments ua
			join Groups g on ua.GroupId = g.Id
			where UserId = @userId and ua.GroupId is not null
		end

	if(@accessLevel = 4)
		begin
			select ua.DepartmentId as Id, d.Name, d.Description
			from 
			UserAssignments ua
			join Departments d on ua.DepartmentId = d.Id
			where UserId = @userId and ua.DepartmentId is not null
		end

	if(@accessLevel = 5)
		begin
			select ua.AccountId as Id, a.Name, a.Description
			from 
			UserAssignments ua
			join Accounts a on ua.AccountId = a.Id
			where UserId = @userId and ua.AccountId is not null
		end

	if(@accessLevel = 6)
		begin
			select ua.CompanyId as Id, c.Name, c.Description
			from 
			UserAssignments ua
			join Companies c on ua.CompanyId = c.Id
			where UserId = @userId and ua.CompanyId is not null
		end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrgLevelItemsAvailableToUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/30/23
Description: Get Org. levels
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetOrgLevelItemsAvailableToUser]
	@orgLevelType smallint, @userId int
AS
BEGIN
	SET NOCOUNT ON;
	if @orgLevelType = 3
		--select * from NotebookEntries ne where ParentId in (
		--	select Id from Notebooks n where n.ParentId in (
		--		select Id from Groups g where g.Id in (
		--				
		select Id, ParentId, Name, CreatedBy, Description, IsActive, CreatedOn, EditedOn from Groups where Id in (
			select  GroupId 
			from UserAssignments
			where UserId in (
				select distinct Id from fnc_GetRecursiveUsers(@userId)
				)
			) 
			OR
				CreatedBy = @userId
		order by Name

	else if @orgLevelType = 4
		select Id, ParentId, Name, CreatedBy, Description, IsActive, CreatedOn, EditedOn from Departments where Id in (
			select  DepartmentId 
			from UserAssignments
			where UserId in (
				select distinct Id from fnc_GetRecursiveUsers(@userId)
				)
		) 
		OR
			CreatedBy = @userId	
		order by Name

	else if @orgLevelType = 5
		select Id, ParentId, Name, CreatedBy, Description, IsActive, CreatedOn, EditedOn from Accounts where Id in (
			select  AccountId 
			from UserAssignments
			where UserId in (
				select distinct Id from fnc_GetRecursiveUsers(@userId)
				)
		) 
		OR
			CreatedBy = @userId
		order by Name

	else if @orgLevelType = 6
		select Id, Name, ParentId, CreatedBy, Description, IsActive, CreatedOn, EditedOn from Companies where Id in (
			select  CompanyId
			from UserAssignments
			where UserId in (
				select distinct Id from fnc_GetRecursiveUsers(@userId)
				)
		) 
		OR
			CreatedBy = @userId
		order by Name

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrgLevels]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/30/23
Description: Get Org. levels
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_GetOrgLevels]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, OrgLevel as Name
	from meta_OrgLevels
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetOrgLevelsForUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/13/23
Description: Get org levels for user and their descendant users.
Edited on : by : notes
*/
create PROCEDURE [dbo].[sp_GetOrgLevelsForUser] 
	@userId int
AS
BEGIN
	SET NOCOUNT ON;

	select CompanyId as Id, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Companies c on ua.CompanyId = c.Id
	where UserId = @userId and ua.CompanyId is not null

	select AccountId as Id, c.ParentId, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Accounts c on ua.AccountId = c.Id
	where UserId = @userId and ua.AccountId is not null

	select DepartmentId as Id, c.ParentId, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Departments c on ua.DepartmentId = c.Id
	where UserId = @userId and ua.DepartmentId is not null

	select GroupId as Id, c.ParentId, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Groups c on ua.GroupId = c.Id
	where UserId = @userId and ua.GroupId is not null

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|941|0|C:\Users\js_ru\AppData\Local\Temp\uu5phgnc..sql
/*
Author:      jsr
Create Date: 7/15/23
Description: Get user details.
Edited on : by : notes
	07/16/23 : jsr : Added return values.
	07/21/23 : jsr : Matched to new Users table design.
	07/25/23 : jsr : Removed selecting permissions.
	07/25/23 : jsr : Added permissions and assignments.
	07/27/23 : jsr : Added 'CreatedBy' field from Users.
	08/02/23 : jsr : Added new 'UserId' field to the get Assignments logic.
	08/05/23 : jsr : Added return of new CreateNotebook field.
	08/09/23 : jsr : Added return from Users - isActive, IsTopLevelUser.
	08/10/23 : jsr : Removed Users.IsTopLevelUser (column deleted).
	08/27/23 : jsr : Removed 'as userId' from return of User.Id.
*/
CREATE PROCEDURE [dbo].[sp_GetUser]
( @username varchar(100), @password varchar(3000) )
AS
BEGIN
    SET nocount ON
	DECLARE @userid int = (SELECT id FROM users WHERE name = @username AND password = @password)

	-- get user
	SELECT Id, CreatedBy, name, accesslevel, IsActive, createdon, editedon, Password
	FROM users 
	WHERE Id = @userid OR CreatedBy = @userid

	-- get permissions
	SELECT createcompany, createaccount, createdepartment, creategroup, CreateNotebook, createsimpleuser, createmasteruser
	, deleterenamecompany, deleterenameaccount, deleterenamedepartment, deleterenamegroup, editnotebookvalues
	, editnotebooksettings, deleterenamenotebooks, manageusers, manageuserpermissions, createdon, editedon
	FROM userpermissions
	WHERE userid = @userid

	-- get assignments
	SELECT userId, companyid, accountid, departmentid, groupid
	FROM userassignments
	WHERE userid = @userid
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserAssignments]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/13/23
Description: Get all org levels for user.
Edited on : by : notes
	08/30/23 : jsr : Stumbled across an old field name and removed it.
*/
CREATE PROCEDURE [dbo].[sp_GetUserAssignments] 
	@userId int
AS
BEGIN
	SET NOCOUNT ON;
	select CompanyId as Id, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Companies c on ua.CompanyId = c.Id
	where UserId = @userId and ua.CompanyId is not null

	select AccountId as Id, c.ParentId, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Accounts c on ua.AccountId = c.Id
	where UserId = @userId and ua.AccountId is not null

	select DepartmentId as Id, c.ParentId, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Departments c on ua.DepartmentId = c.Id
	where UserId = @userId and ua.DepartmentId is not null

	select GroupId as Id, c.ParentId, c.Name, c.Description, c.CreatedOn, c.CreatedBy, c.EditedOn
	from UserAssignments ua
	join Groups c on ua.GroupId = c.Id
	where UserId = @userId and ua.GroupId is not null



	--select CompanyId from UserAssignments where UserId = @userId and CompanyId is not null
	--select AccountId from UserAssignments where UserId = @userId and CompanyId is not null
	--select DepartmentId from UserAssignments where UserId = @userId and CompanyId is not null
	--select GroupId from UserAssignments where UserId = @userId and CompanyId is not null
END
GO
/****** Object:  StoredProcedure [dbo].[sp_IsTopLevelUser]    Script Date: 12/23/24 16:28:08  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Author:      jsr
Create Date: 08/05/23
Description: Determine if user is Top Level user. 
				As such they will have a child tree for alloting CADG's, 
				and also a ParentId which points back to the Originating User.
Edited on : by : notes
*/
CREATE PROCEDURE [dbo].[sp_IsTopLevelUser]
@userId int
AS
BEGIN
	declare @bRtrn bit = 0
	if exists (select Id from Users where Id = @userId and IsTopLevelUser = 1) begin set @bRtrn = 1 end
	return @bRtrn
END
GO
