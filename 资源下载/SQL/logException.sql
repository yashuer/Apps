/****** Object:  Table [dbo].[SysLog]    Script Date: 11/20/2013 21:13:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SysLog](
    [Id] [varchar](50) NOT NULL, --GUID
    [Operator] [varchar](50) NULL,--������
    [Message] [varchar](500) NULL,--������Ϣ
    [Result] [varchar](20) NULL,--���
    [Type] [varchar](20) NULL,--��������
    [Module] [varchar](20) NULL,--����ģ��
    [CreateTime] [datetime] NULL,--�����¼�
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
    [HelpLink] [varchar](500) NULL,--��������
    [Message] [varchar](500) NULL,--�쳣��Ϣ
    [Source] [varchar](500) NULL,--��Դ
    [StackTrace] [text] NULL,--��ջ
    [TargetSite] [varchar](500) NULL,--Ŀ��ҳ
    [Data] [varchar](500) NULL,--����
    [CreateTime] [datetime] NULL,--����ʱ��
 CONSTRAINT [PK_SysException] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF