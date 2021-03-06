/****** Object:  Table [dbo].[SysLog]    Script Date: 11/20/2013 21:13:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SysLog](
    [Id] [varchar](50) NOT NULL, --GUID
    [Operator] [varchar](50) NULL,--操作人
    [Message] [varchar](500) NULL,--操作信息
    [Result] [varchar](20) NULL,--结果
    [Type] [varchar](20) NULL,--操作类型
    [Module] [varchar](20) NULL,--操作模块
    [CreateTime] [datetime] NULL,--操作事件
 CONSTRAINT [PK_SysLog] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




/****** Object:  Table [dbo].[SysException]    Script Date: 11/20/2013 21:17:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SysException](
    [Id] [varchar](50) NOT NULL, --GUID
    [HelpLink] [varchar](500) NULL,--帮助链接
    [Message] [varchar](500) NULL,--异常信息
    [Source] [varchar](500) NULL,--来源
    [StackTrace] [text] NULL,--堆栈
    [TargetSite] [varchar](500) NULL,--目标页
    [Data] [varchar](500) NULL,--程序集
    [CreateTime] [datetime] NULL,--发生时间
 CONSTRAINT [PK_SysException] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF