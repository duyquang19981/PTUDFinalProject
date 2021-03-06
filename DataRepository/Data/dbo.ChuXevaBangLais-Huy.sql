USE [GTVT]
GO
/****** Object:  Table [dbo].[ChuXevaBangLais]    Script Date: 1/10/2021 11:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuXevaBangLais](
	[ChuxeId] [int] NOT NULL,
	[BanglaiId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ChuXevaBangLais] PRIMARY KEY CLUSTERED 
(
	[ChuxeId] ASC,
	[BanglaiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChuXevaBangLais] ([ChuxeId], [BanglaiId]) VALUES (1, 1)
INSERT [dbo].[ChuXevaBangLais] ([ChuxeId], [BanglaiId]) VALUES (4, 1)
INSERT [dbo].[ChuXevaBangLais] ([ChuxeId], [BanglaiId]) VALUES (1, 2)
INSERT [dbo].[ChuXevaBangLais] ([ChuxeId], [BanglaiId]) VALUES (2, 2)
INSERT [dbo].[ChuXevaBangLais] ([ChuxeId], [BanglaiId]) VALUES (1, 3)
GO
ALTER TABLE [dbo].[ChuXevaBangLais]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ChuXevaBangLais_dbo.Banglais_BanglaiId] FOREIGN KEY([BanglaiId])
REFERENCES [dbo].[Banglais] ([BanglaiId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChuXevaBangLais] CHECK CONSTRAINT [FK_dbo.ChuXevaBangLais_dbo.Banglais_BanglaiId]
GO
ALTER TABLE [dbo].[ChuXevaBangLais]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ChuXevaBangLais_dbo.Chuxes_ChuxeId] FOREIGN KEY([ChuxeId])
REFERENCES [dbo].[Chuxes] ([ChuxeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChuXevaBangLais] CHECK CONSTRAINT [FK_dbo.ChuXevaBangLais_dbo.Chuxes_ChuxeId]
GO
