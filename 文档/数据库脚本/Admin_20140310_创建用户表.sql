USE [KSOA]
GO

/****** Object:  Table [dbo].[KSCustomer]    Script Date: 2014/3/11 16:40:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

if object_id(N'[KSCustomer]',N'U') is not null
begin 
	drop table [KSCustomer]
end

CREATE TABLE [dbo].[KSCustomer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [nvarchar](50) NOT NULL,
	[CusName] [nvarchar](50) NOT NULL,
	[CusPwd] [nvarchar](50) NOT NULL,
	[CusEmail] [nvarchar](50) NOT NULL unique,
	[CusPhoneNum] [nvarchar](50) NOT NULL unique,
	[IsDelete] [bit] NOT NULL,
	[AddTime] [datetime] NULL,
 CONSTRAINT [PK__KSCustom__3214EC27A292F0D2] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[KSCustomer] ADD  CONSTRAINT [DF__KSCustome__IsDel__239E4DCF]  DEFAULT ((0)) FOR [IsDelete]
GO

ALTER TABLE [dbo].[KSCustomer] ADD  CONSTRAINT [DF__KSCustome__AddTi__24927208]  DEFAULT (getdate()) FOR [AddTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������Admin_Role���ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'RoleID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'CusName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����루��MD5�������ģ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'CusPwd'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����䣨������½�ã�������ΨһԼ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'CusEmail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û��ֻ���������½�ã�������ΨһԼ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'CusPhoneNum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ���ɾ����0��δɾ����1����ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ŀ���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KSCustomer', @level2type=N'COLUMN',@level2name=N'AddTime'
GO


