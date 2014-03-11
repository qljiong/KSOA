CREATE TABLE [dbo].[Admin_Role] (
	[ID] int NOT NULL IDENTITY PRIMARY KEY, 
	[RoleName] nvarchar(50) NOT NULL, 
	[IsDelete] bit NOT NULL DEFAULT ((0)), 
	[AddTime] datetime NOT NULL DEFAULT (getdate()), 
	[RoleNote] nvarchar(MAX)
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'角色表ID',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'ID';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'角色名称',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'RoleName';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'是否已删除；0：未删除，1：已删除',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'IsDelete';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'条目添加时间',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'AddTime';
EXEC sp_addextendedproperty @name=N'MS_Description',@value=N'角色描述',@level0type=N'Schema',@level0name=N'dbo',@level1type=N'Table',@level1name=N'Admin_Role',@level2type=N'Column',@level2name=N'RoleNote';
GO