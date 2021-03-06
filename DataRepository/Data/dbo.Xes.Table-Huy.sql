USE [GTVT]
GO
/****** Object:  Table [dbo].[Xes]    Script Date: 1/10/2021 11:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xes](
	[XeId] [int] IDENTITY(1,1) NOT NULL,
	[BienSoXe] [nvarchar](max) NULL,
	[Hang] [nvarchar](max) NULL,
	[Loai] [nvarchar](max) NULL,
	[MauSac] [nvarchar](max) NULL,
	[Nam] [int] NOT NULL,
	[TrangThai] [nvarchar](max) NULL,
	[ChuxeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Xes] PRIMARY KEY CLUSTERED 
(
	[XeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Xes] ON 

INSERT [dbo].[Xes] ([XeId], [BienSoXe], [Hang], [Loai], [MauSac], [Nam], [TrangThai], [ChuxeId]) VALUES (2, N'12345', N'Honda', N'Vison', N'Den', 2020, N'Hoan tat', 1)
INSERT [dbo].[Xes] ([XeId], [BienSoXe], [Hang], [Loai], [MauSac], [Nam], [TrangThai], [ChuxeId]) VALUES (3, N'23451', N'Yamaha', N'Exciter', N'Den', 2020, N'Hoan tat', 1)
SET IDENTITY_INSERT [dbo].[Xes] OFF
GO
ALTER TABLE [dbo].[Xes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Xes_dbo.Chuxes_ChuxeId] FOREIGN KEY([ChuxeId])
REFERENCES [dbo].[Chuxes] ([ChuxeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Xes] CHECK CONSTRAINT [FK_dbo.Xes_dbo.Chuxes_ChuxeId]
GO
