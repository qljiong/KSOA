USE [master]
GO
/****** Object:  Database [KSOA]    Script Date: 2014/3/12 16:41:12 ******/
CREATE DATABASE [KSOA] ON  PRIMARY 
( NAME = N'KSOA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\KSOA.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KSOA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\KSOA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KSOA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KSOA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KSOA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KSOA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KSOA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KSOA] SET ARITHABORT OFF 
GO
ALTER DATABASE [KSOA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KSOA] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KSOA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KSOA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KSOA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KSOA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KSOA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KSOA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KSOA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KSOA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KSOA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KSOA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KSOA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KSOA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KSOA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KSOA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KSOA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KSOA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KSOA] SET  MULTI_USER 
GO
ALTER DATABASE [KSOA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KSOA] SET DB_CHAINING OFF 
GO
USE [KSOA]
GO
/****** Object:  Table [dbo].[Admin_Department]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DpName] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Admin_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admin_KSCustomer]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin_KSCustomer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [nvarchar](50) NOT NULL,
	[RealName] [nvarchar](50) NOT NULL,
	[CusName] [nvarchar](50) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Age] [int] NOT NULL,
	[CusPwd] [nvarchar](50) NOT NULL,
	[CusEmail] [nvarchar](50) NOT NULL,
	[CusPhoneNum] [nvarchar](50) NOT NULL,
	[QQ] [varchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK__KSCustom__3214EC27A292F0D2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__KSCustom__60A7203FC8212D4C] UNIQUE NONCLUSTERED 
(
	[CusEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__KSCustom__EA7EE5F091A9445C] UNIQUE NONCLUSTERED 
(
	[CusPhoneNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin_OperatLog]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin_OperatLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OperatorID] [int] NOT NULL,
	[OperatorName] [nvarchar](50) NOT NULL,
	[Module] [nvarchar](50) NOT NULL,
	[OperationContent] [nvarchar](max) NOT NULL,
	[OpIp] [varchar](50) NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Admin_OperatLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin_Platform]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_Platform](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PType] [nvarchar](50) NOT NULL,
	[PName] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Admin_Platform] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admin_Role]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Input] [bit] NOT NULL,
	[See] [bit] NOT NULL,
	[Import] [bit] NOT NULL,
	[Export] [bit] NOT NULL,
	[RoleNote] [nvarchar](max) NULL,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK__Admin_Ro__3214EC27966F96FC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admin_SysErrorLog]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_SysErrorLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageUrl] [nvarchar](200) NOT NULL,
	[ErrorMsg] [nvarchar](max) NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Admin_SysErrorLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Admin_SysMenu]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_SysMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[MenuUrl] [nvarchar](200) NOT NULL,
	[OrderIndex] [int] NOT NULL,
	[AdminRoleID] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SysMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bank_CommercialOpus]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_CommercialOpus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OpusID] [int] NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[CpAddress] [nvarchar](100) NOT NULL,
	[ChannelAddres] [nvarchar](100) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Bank_CommercialOpus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bank_Opus]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank_Opus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OpType] [char](1) NOT NULL,
	[OpTitle] [nvarchar](50) NOT NULL,
	[OpAuthor] [nvarchar](50) NOT NULL,
	[OpBeginTime] [datetime] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Bank_Opus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank_OriginalGroup]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank_OriginalGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OpusCopyright] [nvarchar](300) NOT NULL,
	[CreationInfo] [nvarchar](50) NOT NULL,
	[OpusName] [nvarchar](300) NOT NULL,
	[OpusAuthor] [nvarchar](50) NOT NULL,
	[SalePrice] [decimal](18, 0) NOT NULL,
	[AccreditPlatform] [nvarchar](50) NOT NULL,
	[AccreditCompany] [nvarchar](50) NOT NULL,
	[AccreditTime] [datetime] NOT NULL,
	[AccreditType] [nvarchar](50) NOT NULL,
	[Awards] [nvarchar](max) NULL,
	[OpusMascot] [nvarchar](50) NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Bank_OriginalGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UI_ExcelImportByChannel]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UI_ExcelImportByChannel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ExSpreadType] [char](1) NOT NULL,
	[ExTime] [datetime] NOT NULL,
	[ExOpusName] [nvarchar](200) NOT NULL,
	[ExCollectNum] [int] NOT NULL,
	[ExChargeCollectNum] [int] NOT NULL,
	[ExOpusUnitPrice] [decimal](18, 0) NOT NULL,
	[ExAccountPrice] [decimal](18, 0) NOT NULL,
	[ExAccountCollectNum] [int] NOT NULL,
	[HistoryPercent] [nvarchar](50) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UI_ExcelImportByPlatform]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UI_ExcelImportByPlatform](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ExType] [char](1) NOT NULL,
	[ExTime] [datetime] NOT NULL,
	[ExCpName] [nvarchar](50) NOT NULL,
	[ExOpusName] [nvarchar](200) NOT NULL,
	[ExCooperation] [nvarchar](100) NOT NULL,
	[ExCollectNum] [int] NOT NULL,
	[ExSingleCollectNum] [int] NOT NULL,
	[ExOpusUnitPrice] [decimal](18, 0) NOT NULL,
	[ExAccountPrice] [decimal](18, 0) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Work_Note]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Work_Note](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WType] [char](1) NOT NULL,
	[WriterID] [int] NOT NULL,
	[WriterName] [nvarchar](50) NOT NULL,
	[WTitle] [nvarchar](50) NOT NULL,
	[WConetent] [nvarchar](max) NOT NULL,
	[WTaster] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[WIP] [varchar](50) NULL,
 CONSTRAINT [PK_Work_Note] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Work_Notice]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Work_Notice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NTitle] [nvarchar](50) NOT NULL,
	[NContent] [nvarchar](max) NOT NULL,
	[NCustomerID] [int] NOT NULL,
	[NCustomerName] [nvarchar](50) NOT NULL,
	[Nlevel] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NIP] [varchar](50) NULL,
 CONSTRAINT [PK_Work_Notice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Work_Schedule]    Script Date: 2014/3/12 16:41:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemLaunchTime] [datetime] NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsDelete] [bit] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Admin_Department] ADD  CONSTRAINT [DF_Admin_Department_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Admin_Department] ADD  CONSTRAINT [DF_Admin_Department_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Admin_KSCustomer] ADD  CONSTRAINT [DF_KSCustomer_RealName]  DEFAULT ('') FOR [RealName]
GO
ALTER TABLE [dbo].[Admin_KSCustomer] ADD  CONSTRAINT [DF_KSCustomer_Gender]  DEFAULT ('z') FOR [Gender]
GO
ALTER TABLE [dbo].[Admin_KSCustomer] ADD  CONSTRAINT [DF_KSCustomer_Age]  DEFAULT ((0)) FOR [Age]
GO
ALTER TABLE [dbo].[Admin_KSCustomer] ADD  CONSTRAINT [DF_KSCustomer_QQ]  DEFAULT ('') FOR [QQ]
GO
ALTER TABLE [dbo].[Admin_KSCustomer] ADD  CONSTRAINT [DF__KSCustome__IsDel__239E4DCF]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Admin_KSCustomer] ADD  CONSTRAINT [DF__KSCustome__AddTi__24927208]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Admin_OperatLog] ADD  CONSTRAINT [DF_Admin_OperatLog_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Admin_Platform] ADD  CONSTRAINT [DF_Admin_Platform_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Admin_Platform] ADD  CONSTRAINT [DF_Admin_Platform_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Admin_Role] ADD  CONSTRAINT [DF_Admin_Role_Input]  DEFAULT ((0)) FOR [Input]
GO
ALTER TABLE [dbo].[Admin_Role] ADD  CONSTRAINT [DF_Admin_Role_View]  DEFAULT ((0)) FOR [See]
GO
ALTER TABLE [dbo].[Admin_Role] ADD  CONSTRAINT [DF_Admin_Role_Import]  DEFAULT ((0)) FOR [Import]
GO
ALTER TABLE [dbo].[Admin_Role] ADD  CONSTRAINT [DF_Admin_Role_Export]  DEFAULT ((0)) FOR [Export]
GO
ALTER TABLE [dbo].[Admin_Role] ADD  CONSTRAINT [DF__Admin_Rol__IsDel__276EDEB3]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Admin_Role] ADD  CONSTRAINT [DF__Admin_Rol__AddTi__286302EC]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Admin_SysErrorLog] ADD  CONSTRAINT [DF_Admin_SysErrorLog_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Admin_SysMenu] ADD  CONSTRAINT [DF_SysMenu_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
ALTER TABLE [dbo].[Admin_SysMenu] ADD  CONSTRAINT [DF_Admin_SysMenu_IsEnable]  DEFAULT ((1)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[Admin_SysMenu] ADD  CONSTRAINT [DF_Admin_SysMenu_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Admin_SysMenu] ADD  CONSTRAINT [DF_Admin_SysMenu_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Bank_CommercialOpus] ADD  CONSTRAINT [DF_Bank_CommercialOpus_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Bank_CommercialOpus] ADD  CONSTRAINT [DF_Bank_CommercialOpus_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Bank_Opus] ADD  CONSTRAINT [DF_Bank_Opus_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Bank_Opus] ADD  CONSTRAINT [DF_Bank_Opus_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Bank_OriginalGroup] ADD  CONSTRAINT [DF_Bank_OriginalGroup_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Bank_OriginalGroup] ADD  CONSTRAINT [DF_Bank_OriginalGroup_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UI_ExcelImportByChannel] ADD  CONSTRAINT [DF_UI_ExcelImportByChannel_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[UI_ExcelImportByChannel] ADD  CONSTRAINT [DF_UI_ExcelImportByChannel_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[UI_ExcelImportByPlatform] ADD  CONSTRAINT [DF_UI_CPWAP_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[UI_ExcelImportByPlatform] ADD  CONSTRAINT [DF_UI_CPWAP_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Work_Note] ADD  CONSTRAINT [DF_Work_Note_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Work_Note] ADD  CONSTRAINT [DF_Work_Note_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Work_Notice] ADD  CONSTRAINT [DF_Work_Notice_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Work_Notice] ADD  CONSTRAINT [DF_Work_Notice_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[Work_Schedule] ADD  CONSTRAINT [DF_Work_Schedule_AddTime]  DEFAULT (getdate()) FOR [AddTime]
GO
ALTER TABLE [dbo].[Work_Schedule] ADD  CONSTRAINT [DF_Work_Schedule_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Department', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Department', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Department', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外键关联Admin_Role表的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名(昵称)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'CusName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别;X:女,Y:男,Z:未知' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'Age'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码（需MD5混淆过的）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'CusPwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户邮箱（可做登陆用），设置唯一约束' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'CusEmail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户手机（可做登陆用），设置唯一约束' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'CusPhoneNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户qq' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'QQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_KSCustomer', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人ID,关联用户表的用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_OperatLog', @level2type=N'COLUMN',@level2name=N'OperatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_OperatLog', @level2type=N'COLUMN',@level2name=N'OperatorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作的模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_OperatLog', @level2type=N'COLUMN',@level2name=N'Module'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作详细描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_OperatLog', @level2type=N'COLUMN',@level2name=N'OperationContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人的Ip' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_OperatLog', @level2type=N'COLUMN',@level2name=N'OpIp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台类型;CP,渠道,SDK,合作渠道' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Platform', @level2type=N'COLUMN',@level2name=N'PType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Platform', @level2type=N'COLUMN',@level2name=N'PName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Platform', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Platform', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入的权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'Input'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看的权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'See'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导入的权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'Import'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导出的权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'Export'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'RoleNote'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_Role', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误页面URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysErrorLog', @level2type=N'COLUMN',@level2name=N'PageUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误提示信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysErrorLog', @level2type=N'COLUMN',@level2name=N'ErrorMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysErrorLog', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统菜单表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单级别ID;0:一级菜单,其它自关联当前表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'MenuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'MenuUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单排序ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'OrderIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联AdminRole表的ID,外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'AdminRoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用;0:未启用,1:已启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'IsEnable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin_SysMenu', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品ID,关联Bank_Opus的id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_CommercialOpus', @level2type=N'COLUMN',@level2name=N'OpusID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品使用公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_CommercialOpus', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品CP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_CommercialOpus', @level2type=N'COLUMN',@level2name=N'CpAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品渠道地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_CommercialOpus', @level2type=N'COLUMN',@level2name=N'ChannelAddres'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_CommercialOpus', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_CommercialOpus', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品类型;B:buy(作品购买),S:sell(销售)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_Opus', @level2type=N'COLUMN',@level2name=N'OpType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_Opus', @level2type=N'COLUMN',@level2name=N'OpTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_Opus', @level2type=N'COLUMN',@level2name=N'OpAuthor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布,上架时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_Opus', @level2type=N'COLUMN',@level2name=N'OpBeginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_Opus', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_Opus', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版权信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'OpusCopyright'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创作信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'CreationInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'OpusName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'OpusAuthor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'SalePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权平台' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'AccreditPlatform'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权公司' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'AccreditCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'AccreditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'AccreditType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'获奖情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'Awards'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原创形象相关信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'OpusMascot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank_OriginalGroup', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导入操作人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'CustomerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推广平台;Q:渠道,S:SDK,C:CP(内容提供商)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExSpreadType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期:导入表单里的时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExOpusName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品对应的集数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExCollectNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品对应集数计费条数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExChargeCollectNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExOpusUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExAccountPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算条数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'ExAccountCollectNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'渠道结算金额比例设置调整记录' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'HistoryPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByChannel', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导入操作人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'CustomerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导入类别;W:WAP,S:SDK,Q:渠道' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导入表单里的时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CP(内容提供商)名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExCpName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExOpusName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应合作渠道推广商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExCooperation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品对应集数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExCollectNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单集计费条数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExSingleCollectNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作品单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExOpusUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'ExAccountPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UI_ExcelImportByPlatform', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作报告类型;D:日报,W:周报,M:月报' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WriterID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作报告填写人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WriterName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日报标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作报告内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WConetent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日报审阅人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WTaster'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'填写人IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Note', @level2type=N'COLUMN',@level2name=N'WIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'NTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'NContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'NCustomerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'NCustomerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公告级别,1,2,3,4;1的级别最大' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'Nlevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布人IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Notice', @level2type=N'COLUMN',@level2name=N'NIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Schedule', @level2type=N'COLUMN',@level2name=N'ItemName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目发起时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Schedule', @level2type=N'COLUMN',@level2name=N'ItemLaunchTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条目添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Schedule', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已删除；0：未删除，1：已删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Work_Schedule', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
USE [master]
GO
ALTER DATABASE [KSOA] SET  READ_WRITE 
GO
