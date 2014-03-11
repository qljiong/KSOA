CREATE TABLE [dbo].[KSCustomer] (
	[ID] int NOT NULL IDENTITY PRIMARY KEY, 
	[CusName] nvarchar(50) NOT NULL, 
	[CusPwd] nvarchar(50) NOT NULL, 
	[RoleID] nvarchar(50) NOT NULL, 
	[CusEmail] nvarchar(50) NOT NULL, 
	[CusPhoneNum] nvarchar(50) NOT NULL, 
	[IsDelete] bit NOT NULL DEFAULT ((0)), 
	[AddTime] datetime DEFAULT getdate()
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�û���ID',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'ID';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�û���',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusName';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�û����루��MD5�������ģ�',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusPwd';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�������Admin_Role���ID',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'RoleID';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�û����䣨������½�ã�������ΨһԼ��',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusEmail';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�û��ֻ���������½�ã�������ΨһԼ��',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusPhoneNum';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�Ƿ���ɾ����0��δɾ����1����ɾ��',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'IsDelete';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'��Ŀ���ʱ��',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'AddTime';
GO