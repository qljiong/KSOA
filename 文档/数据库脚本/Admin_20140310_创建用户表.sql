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
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'用户表ID',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'ID';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'用户名',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusName';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'用户密码（需MD5混淆过的）',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusPwd';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'外键关联Admin_Role表的ID',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'RoleID';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'用户邮箱（可做登陆用），设置唯一约束',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusEmail';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'用户手机（可做登陆用），设置唯一约束',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'CusPhoneNum';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'是否已删除；0：未删除，1：已删除',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'IsDelete';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'条目添加时间',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'KSCustomer',@level2type=N'Column',@level2name=N'AddTime';
GO