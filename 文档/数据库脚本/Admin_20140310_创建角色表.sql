CREATE TABLE [dbo].[Admin_Role] (
	[ID] int NOT NULL IDENTITY PRIMARY KEY, 
	[RoleName] nvarchar(50) NOT NULL, 
	[IsDelete] bit NOT NULL DEFAULT ((0)), 
	[AddTime] datetime NOT NULL DEFAULT (getdate()), 
	[RoleNote] nvarchar(MAX)
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'��ɫ��ID',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'ID';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'��ɫ����',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'RoleName';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'�Ƿ���ɾ����0��δɾ����1����ɾ��',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'IsDelete';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'��Ŀ���ʱ��',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'AddTime';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'��ɫ����',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'RoleNote';
GO