/****** Object:  Table [dbo].[SysModule]    Script Date: 11/19/2013 22:11:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
--sp_rename 'SysModule.State','Enable','Column'
CREATE TABLE [dbo].[SysModule](
    [Id] [varchar](50) NOT NULL, --id
    [Name] [varchar](200) NOT NULL, --模块名称
    [EnglishName] [varchar](200) NULL, --英文名称（防止将来国际化）
    [ParentId] [varchar](50) NULL,--上级ID这是一个tree
    [Url] [varchar](200) NULL,--链接
    [Iconic] [varchar](200) NULL,--图标，用于链接图标，或tab页图标
    [Sort] [int] NULL,--排序
    [Remark] [varchar](4000) NULL,--说明
    [Enable] [bit] NULL, --状态
    [CreatePerson] [varchar](200) NULL, --创建人
    [CreateTime] [datetime] NULL,--创建事件
    [IsLast] [bit] NOT NULL, --是否是最后一项
    [Version] [timestamp] NULL, --版本
 CONSTRAINT [PK_SysModule] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SysModule]  WITH NOCHECK ADD  CONSTRAINT [FK_SysModule_SysModule] FOREIGN KEY([ParentId])
REFERENCES [dbo].[SysModule] ([Id])
GO

ALTER TABLE [dbo].[SysModule] NOCHECK CONSTRAINT [FK_SysModule_SysModule]
GO



INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('0','顶级菜单','Root','0','','',0,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('BaseSample','模板样例','Sample by Ajax','SampleFile','SysSample','',0,'',1,'Administrator',NULL,1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('Document','我的桌面','Start','PersonDocument','Home/Doc','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('Info','我的资料','Info','PersonDocument','Home/Info','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('InfoHome','主页','Home','Information','MIS/Article','',1,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('Information','信息中心','Information','OA','','',0,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('ManageInfo','管理中心','Manage Article','Information','MIS/ManageArticle','',4,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('ModuleSetting','模块维护','Module Setting','RightManage','SysModule','',100,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('MyInfo','我的信息','My Article','Information','MIS/MyArticle','',2,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('PersonDocument','个人中心','Person Center','0','','',2,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('RightManage','权限管理','Authorities Management','0','','',4,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('RoleAuthorize','角色权限设置','Role Authorize','RightManage','SysRight','',6,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('RoleManage','角色管理','Role Manage','RightManage','SysRole','',2,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SampleFile','开发指南样例','SampleFile','0','SysSample','',1,'',1,'Administrator',NULL,0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemConfig','系统配置','System Config','SystemManage','SysConfig','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemExcepiton','系统异常','System Exception','SystemManage','SysException','',2,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemJobs','系统任务','System Jobs','TaskScheduling','Jobs/Jobs','',0,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemLog','系统日志','System Log','SystemManage','SysLog','',1,'',1,'Administrator','10  1 2012 12:00AM',1,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('SystemManage','系统管理','System Management','0','','',3,'',1,'Administrator','10  1 2012 12:00AM',0,NULL)
INSERT INTO [SysModule] ([Id],[Name],[EnglishName],[ParentId],[Url],[Iconic],[Sort],[Remark],[Enable],[CreatePerson],[CreateTime],[IsLast],[Version]) values ('UserManage','系统管理员','User Manage','RightManage','SysUser',NULL,1,NULL,1,'Administrator','10  1 2012 12:00AM',1,NULL)