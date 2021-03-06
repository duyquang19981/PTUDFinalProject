USE [GTVT]
GO
/****** Object:  Table [dbo].[Chuxes]    Script Date: 1/10/2021 11:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuxes](
	[ChuxeId] [int] IDENTITY(1,1) NOT NULL,
	[CMND] [int] NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](max) NULL,
	[NamSinh] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Chuxes] PRIMARY KEY CLUSTERED 
(
	[ChuxeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Chuxes] ON 

INSERT [dbo].[Chuxes] ([ChuxeId], [CMND], [HoTen], [DiaChi], [GioiTinh], [NamSinh]) VALUES (1, 123456789, N'Quang Huy', N'Bien Hoa', N'Nam', 1999)
INSERT [dbo].[Chuxes] ([ChuxeId], [CMND], [HoTen], [DiaChi], [GioiTinh], [NamSinh]) VALUES (2, 987654321, N'Tuan Khang', N'Nha Trang', N'Nam', 1999)
INSERT [dbo].[Chuxes] ([ChuxeId], [CMND], [HoTen], [DiaChi], [GioiTinh], [NamSinh]) VALUES (3, 987664521, N'Hai Yen', N'Ha Noi', N'Nu', 1999)
INSERT [dbo].[Chuxes] ([ChuxeId], [CMND], [HoTen], [DiaChi], [GioiTinh], [NamSinh]) VALUES (4, 987627461, N'Pham Kinh Kha', N'Ho Chi Minh', N'Nam', 1999)
INSERT [dbo].[Chuxes] ([ChuxeId], [CMND], [HoTen], [DiaChi], [GioiTinh], [NamSinh]) VALUES (5, 157395786, N'Quang Vu', N'Da Nang', N'Nam', 1960)
SET IDENTITY_INSERT [dbo].[Chuxes] OFF
GO
