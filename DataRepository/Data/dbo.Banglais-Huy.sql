USE [GTVT]
GO
/****** Object:  Table [dbo].[Banglais]    Script Date: 1/10/2021 11:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banglais](
	[BanglaiId] [int] IDENTITY(1,1) NOT NULL,
	[LoaiBang] [nvarchar](max) NOT NULL,
	[ThongTin] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Banglais] PRIMARY KEY CLUSTERED 
(
	[BanglaiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Banglais] ON 

INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (1, N'A1', N'Cho xe may')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (2, N'A2', N'Cho xe may')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (3, N'A3', N'Cho xe may')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (4, N'B1', N'Cho xe hoi')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (5, N'B2', N'Cho xe hoi')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (6, N'B3', N'Cho xe hoi')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (7, N'C1', N'Cho may bay')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (8, N'C2', N'Cho may bay')
INSERT [dbo].[Banglais] ([BanglaiId], [LoaiBang], [ThongTin]) VALUES (9, N'C3', N'Cho may bay')
SET IDENTITY_INSERT [dbo].[Banglais] OFF
GO
