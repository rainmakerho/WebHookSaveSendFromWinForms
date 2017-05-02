-- drop table  [WebHooks].[WebHooks]
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [WebHooks].[WebHooks](
	[User] [nvarchar](256) NOT NULL,
	[Id] [nvarchar](64) NOT NULL,
	[ProtectedData] [nvarchar](max) NOT NULL,
	[RowVer] [timestamp] NOT NULL,
 CONSTRAINT [PK_WebHooks.WebHooks] PRIMARY KEY CLUSTERED 
(
	[User] ASC,
	[Id] ASC
)ON [PRIMARY]
) 

GO
