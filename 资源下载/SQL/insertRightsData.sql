--操作码
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleCreate','创建','Create','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleDelete','删除','Delete','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleDetails','详细','Details','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleEdit','编辑','Edit','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleExport','导出','Export','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleQuery','查询','Query','BaseSample',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('BaseSampleSave','保存','Save','BaseSample',0,0)

INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingCreate','创建','Create','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingDelete','删除','Delete','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingDetails','详细','Details','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingEdit','编辑','Edit','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingExport','导出','Export','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingQuery','查询','Query','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingSave','保存','Save','ModuleSetting',0,0)
--角色
INSERT INTO [SysRole] ([Id],[Name],[Description],[CreateTime],[CreatePerson]) values ('administrator','超级管理员','全部授权','10  1 2012 12:00AM','Administrator')

--模块授权
INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorSampleFile','SampleFile','administrator',1)
INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorBaseSample','BaseSample','administrator',1)

INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorModuleSetting','ModuleSetting','administrator',1)

--权限
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleCreate','administratorBaseSample','Create',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleDelete','administratorBaseSample','Delete',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleDetails','administratorBaseSample','Details',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleEdit','administratorBaseSample','Edit',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleExport','administratorBaseSample','Export',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleQuery','administratorBaseSample','Query',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorBaseSampleSave','administratorBaseSample','Save',1)

INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingCreate','ModuleSetting','Create',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingDelete','ModuleSetting','Delete',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingDetails','ModuleSetting','Details',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingEdit','ModuleSetting','Edit',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingExport','ModuleSetting','Export',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingQuery','ModuleSetting','Query',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('ModuleSettingSave','ModuleSetting','Save',1)
--管理员
INSERT INTO [SysUser] ([Id],[UserName],[Password],[TrueName],[Card],[MobileNumber],[PhoneNumber],[QQ],[EmailAddress],[OtherContact],[Province],[City],[Village],[Address],[State],[CreateTime],[CreatePerson],[Sex],[Birthday],[JoinDate],[Marital],[Political],[Nationality],[Native],[School],[Professional],[Degree],[DepId],[PosId],[Expertise],[JobState],[Photo],[Attach]) 
values ('admin','admin','01-92-02-3A-7B-BD-73-25-05-16-F0-69-DF-18-B5-00','系统管理员',NULL,NULL,'06638888888','324345345','ymnets@sina.com','MSN：ymnets','440000','440100','440101','小小村落',1,'11 18 2012  3:40PM','admin','男','05 18 1900 12:00AM','01  1 2013 12:00AM','未婚','中国','中国','广东揭阳','美国哈佛大学','计算机工程','硕士','20000','20001','勤劳向学,为人友善,乐于助人','在职',NULL,NULL)

--赋予用户角色
INSERT INTO [SysRoleSysUser] ([SysUserId],[SysRoleId]) values ('admin','administrator')