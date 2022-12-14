USE [task]
GO
/****** Object:  Table [dbo].[checkout_cart]    Script Date: 04-Jan-21 6:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[checkout_cart](
	[product_id] [varchar](20) NOT NULL,
	[product_name] [varchar](50) NULL,
	[purchase_unit] [float] NULL,
	[per_unit_price] [float] NULL,
	[total_cost] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movie]    Script Date: 04-Jan-21 6:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie](
	[id] [varchar](20) NULL,
	[title] [varchar](50) NULL,
	[imdbrating] [float] NULL,
	[income] [int] NULL,
	[releasedate] [date] NULL,
	[genre] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_roster]    Script Date: 04-Jan-21 6:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_roster](
	[product_id] [varchar](15) NOT NULL,
	[product_name] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[measurement_unit] [varchar](15) NOT NULL,
	[supplier] [varchar](50) NOT NULL,
	[per_unit_price] [float] NOT NULL,
 CONSTRAINT [PK_inventory] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userlogin]    Script Date: 04-Jan-21 6:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userlogin](
	[id] [varchar](10) NOT NULL,
	[username] [varchar](60) NULL,
	[password] [varchar](30) NULL,
	[usertype] [varchar](30) NULL,
 CONSTRAINT [PK_userlogin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[movie] ([id], [title], [imdbrating], [income], [releasedate], [genre]) VALUES (N'm001', N'thor', 9.7, 666, CAST(N'1979-12-15' AS Date), N'action')
INSERT [dbo].[movie] ([id], [title], [imdbrating], [income], [releasedate], [genre]) VALUES (N'm002', N'Jhonny English', 9.7, 234, CAST(N'2001-01-01' AS Date), N'comedy')
INSERT [dbo].[movie] ([id], [title], [imdbrating], [income], [releasedate], [genre]) VALUES (N'm003', N'3 Idiots', 10, 991, CAST(N'2020-12-15' AS Date), N'drama')
GO
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p101', N'Cocacola 1 liter', 110, N'liter', N'Cocacola', 60)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p102', N'Lays chips 25 gm', 99, N'packet', N'Cocacola', 25)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p103', N'Matador pencil p6', 160, N'piece', N'Matador', 5)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p104', N'Potato', 95, N'kg', N'local kachabazar', 40)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p105', N'Surf excel 1 kg', 30, N'kg', N'Fresh', 150)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p106', N'Lifebouy handwash 250 ml', 60, N'packet', N'Lifebouy', 90)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p107', N'Wheel power 1 kg', 10, N'kg', N'Wheel', 60)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p108', N'H110 motherboard', 10, N'piece', N'Gigabyte', 6300)
INSERT [dbo].[product_roster] ([product_id], [product_name], [quantity], [measurement_unit], [supplier], [per_unit_price]) VALUES (N'p109', N'Green tea (tea bag)', 100, N'packet', N'Ispahani', 90)
GO
INSERT [dbo].[userlogin] ([id], [username], [password], [usertype]) VALUES (N'u101', N'master', N'master', N'manager')
INSERT [dbo].[userlogin] ([id], [username], [password], [usertype]) VALUES (N'u102', N'kobeer', N'123', N'manager')
INSERT [dbo].[userlogin] ([id], [username], [password], [usertype]) VALUES (N'u103', N'tamanna', N'123', N'salesman')
INSERT [dbo].[userlogin] ([id], [username], [password], [usertype]) VALUES (N'u104', N'pavel', N'123', N'manager')
INSERT [dbo].[userlogin] ([id], [username], [password], [usertype]) VALUES (N'u105', N'steve', N'123', N'salesman')
INSERT [dbo].[userlogin] ([id], [username], [password], [usertype]) VALUES (N'u106', N'tommy', N'123', N'manager')
GO
