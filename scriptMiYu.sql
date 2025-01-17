USE [master]
GO
/****** Object:  Database [MiYu]    Script Date: 7/18/2024 6:29:17 PM ******/
CREATE DATABASE [MiYu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MiYu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MiYu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiYu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MiYu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MiYu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiYu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiYu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiYu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiYu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiYu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiYu] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiYu] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MiYu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiYu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiYu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiYu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiYu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiYu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiYu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiYu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiYu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MiYu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiYu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiYu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiYu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiYu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiYu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiYu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiYu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MiYu] SET  MULTI_USER 
GO
ALTER DATABASE [MiYu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiYu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MiYu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MiYu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MiYu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MiYu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MiYu] SET QUERY_STORE = ON
GO
ALTER DATABASE [MiYu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MiYu]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [nvarchar](50) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[dob] [date] NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[gender] [bit] NULL,
	[mail] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[status_id] [int] NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendence]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendence](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[status_id] [int] NOT NULL,
	[description] [nvarchar](50) NULL,
	[employee_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_Attendence] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[id] [int] NOT NULL,
	[name] [nvarchar](200) NULL,
	[time] [datetime] NULL,
	[employee_id] [nvarchar](50) NULL,
	[number] [int] NULL,
	[status_id] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_type_id] [int] NOT NULL,
	[customer_id] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customerType]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customerType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_customerType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [nvarchar](50) NOT NULL,
	[employee_type_id] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmployeeType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[weight] [int] NULL,
	[unit] [nvarchar](10) NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[weight] [int] NULL,
	[unit] [nvarchar](20) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [numeric](12, 2) NOT NULL,
	[description] [nvarchar](200) NULL,
	[ingredient_id] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time_start] [datetime] NULL,
	[order_menu_id] [int] NULL,
	[status_id] [int] NOT NULL,
	[table_id] [int] NULL,
	[time_end] [datetime] NULL,
	[custormer_id] [nvarchar](50) NULL,
	[employee_id] [nvarchar](50) NULL,
	[price] [numeric](12, 2) NULL,
	[voucher_id] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderMenu]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMenu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[menu_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [nvarchar](50) NOT NULL,
	[time] [datetime] NULL,
	[status_id] [int] NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StorageItems]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[storage_id] [int] NULL,
	[item_id] [int] NULL,
 CONSTRAINT [PK_StorageItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[floor] [int] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/18/2024 6:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NULL,
	[quantity] [int] NULL,
	[code] [nvarchar](10) NULL,
	[discount] [numeric](3, 0) NOT NULL,
	[remaining] [int] NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([id], [username], [password], [name], [dob], [phone], [gender], [mail], [address], [status_id], [role_id]) VALUES (N'CU001', N'huy', N'123456789', N'unknown', CAST(N'2003-04-05' AS Date), N'0124253534', 1, N'huy@fpt.edu.vn', N'Viet Nam', 1, 2)
INSERT [dbo].[Account] ([id], [username], [password], [name], [dob], [phone], [gender], [mail], [address], [status_id], [role_id]) VALUES (N'EM001', N'gioidm', N'123456789', N'Đoàn Mạnh Giỏi', CAST(N'2003-04-16' AS Date), N'0354063266', 1, N'gioidm@fpt.edu.vn', N'Hai Phong', 1, 3)
INSERT [dbo].[Account] ([id], [username], [password], [name], [dob], [phone], [gender], [mail], [address], [status_id], [role_id]) VALUES (N'EM002', N'hieu', N'123456789', N'Đoàn Nguyễn Minh Hiếu', CAST(N'2003-04-04' AS Date), N'0354063265', 1, N'hieu@fpt.edu.vn', N'Hai Phong', 1, 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [dob], [phone], [gender], [mail], [address], [status_id], [role_id]) VALUES (N'EM003', N'thinh', N'123456789', N'Nguyễn Thịnh', CAST(N'2003-01-01' AS Date), N'0123456785', 1, N'thinh@fpt.edu.vn', N'Viet Nam', 1, 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [dob], [phone], [gender], [mail], [address], [status_id], [role_id]) VALUES (N'EM004', N'anhkt', N'123456789', N'Kiều Anh Thế Anh', CAST(N'2003-04-09' AS Date), N'0124354646', 0, N'anh@fpt.edu.v', N'Nghe An', 1, 1)
INSERT [dbo].[Account] ([id], [username], [password], [name], [dob], [phone], [gender], [mail], [address], [status_id], [role_id]) VALUES (N'EM005', N'hai', N'123456789', N'Lê Duy Hải', CAST(N'2003-05-01' AS Date), N'0124345544', 1, N'hai@fpt.edu.vn', N'Hung Yen', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Attendence] ON 

INSERT [dbo].[Attendence] ([id], [date], [status_id], [description], [employee_id]) VALUES (1, CAST(N'2024-07-18T17:57:24.197' AS DateTime), 7, N'Present successfully', N'EM004')
SET IDENTITY_INSERT [dbo].[Attendence] OFF
GO
INSERT [dbo].[Customer] ([customer_type_id], [customer_id]) VALUES (1, N'CU001')
GO
SET IDENTITY_INSERT [dbo].[customerType] ON 

INSERT [dbo].[customerType] ([id], [name]) VALUES (1, N'dine in')
INSERT [dbo].[customerType] ([id], [name]) VALUES (2, N'take away')
SET IDENTITY_INSERT [dbo].[customerType] OFF
GO
INSERT [dbo].[Employee] ([employee_id], [employee_type_id]) VALUES (N'EM002', 1)
INSERT [dbo].[Employee] ([employee_id], [employee_type_id]) VALUES (N'EM003', 1)
INSERT [dbo].[Employee] ([employee_id], [employee_type_id]) VALUES (N'EM004', 2)
INSERT [dbo].[Employee] ([employee_id], [employee_type_id]) VALUES (N'EM005', 1)
GO
SET IDENTITY_INSERT [dbo].[EmployeeType] ON 

INSERT [dbo].[EmployeeType] ([id], [name]) VALUES (1, N'Waiter')
INSERT [dbo].[EmployeeType] ([id], [name]) VALUES (2, N'cashier')
SET IDENTITY_INSERT [dbo].[EmployeeType] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (1, N'Cua Hoàng Đế Xào Tỏi', CAST(1000000.00 AS Numeric(12, 2)), N'Cua hoàng đế , tỏi , dầu oliu , bánh mì', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (4, N'Mực Chiên Bơ', CAST(200000.00 AS Numeric(12, 2)), N'Mực khô cát bà , bơ thượng hạng , đường , tương ớt', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (5, N'Cá Song Hấp Dầu Hào', CAST(300000.00 AS Numeric(12, 2)), N'Cá Song , Nấm , Cà Rốt , Xì Dầu , Hành', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (6, N'Bề Bề Hấp', CAST(200000.00 AS Numeric(12, 2)), N'Bề Bề , Dầu , Hành', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (9, N'Mực Hấp', CAST(200000.00 AS Numeric(12, 2)), N'Mực Tươi Cát bà', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (10, N'Cơm rang Hải Sản', CAST(100000.00 AS Numeric(12, 2)), N'Cơm , Trứng , Tôm , Mực', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (11, N'Mì Xào Hải Sản', CAST(100000.00 AS Numeric(12, 2)), N'Mì,Tôm,Mực', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (12, N'Coca', CAST(20000.00 AS Numeric(12, 2)), NULL, NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (13, N'Pesi', CAST(20000.00 AS Numeric(12, 2)), NULL, NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (14, N'Nước ép Táo', CAST(40000.00 AS Numeric(12, 2)), NULL, NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (15, N'Rau Muống Xào', CAST(50000.00 AS Numeric(12, 2)), N'Rau Muông sạch', NULL)
INSERT [dbo].[Menu] ([id], [name], [price], [description], [ingredient_id]) VALUES (16, N'Nước Suối', CAST(10000.00 AS Numeric(12, 2)), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1, CAST(N'2024-07-17T11:36:03.220' AS DateTime), NULL, 5, 5, CAST(N'2024-07-17T11:36:03.220' AS DateTime), NULL, N'EM004', CAST(50000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (2, CAST(N'2024-07-18T00:26:25.140' AS DateTime), NULL, 5, 3, CAST(N'2024-07-18T00:26:25.140' AS DateTime), NULL, N'EM004', CAST(1720000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (3, CAST(N'2024-07-18T11:54:57.850' AS DateTime), NULL, 5, 12, CAST(N'2024-07-18T11:54:57.850' AS DateTime), NULL, N'EM004', CAST(1100000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1003, CAST(N'2024-07-18T14:44:48.023' AS DateTime), NULL, 5, 3, CAST(N'2024-07-18T14:44:48.023' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1004, CAST(N'2024-07-18T15:03:01.723' AS DateTime), NULL, 5, 13, CAST(N'2024-07-18T15:03:01.723' AS DateTime), NULL, N'EM004', CAST(350000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1005, CAST(N'2024-07-18T15:06:39.527' AS DateTime), NULL, 4, 8, CAST(N'2024-07-18T15:06:39.527' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1006, CAST(N'2024-07-18T15:07:33.237' AS DateTime), NULL, 5, 5, CAST(N'2024-07-18T15:07:33.237' AS DateTime), NULL, N'EM004', CAST(520000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1007, CAST(N'2024-07-18T15:15:29.207' AS DateTime), NULL, 5, 4, CAST(N'2024-07-18T15:15:29.207' AS DateTime), NULL, N'EM004', CAST(220000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1008, CAST(N'2024-07-18T15:36:34.023' AS DateTime), NULL, 3, 14, CAST(N'2024-07-18T15:36:54.850' AS DateTime), NULL, N'EM004', CAST(2500000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1009, CAST(N'2024-07-18T15:39:42.230' AS DateTime), NULL, 3, 5, CAST(N'2024-07-18T15:40:07.520' AS DateTime), NULL, N'EM004', CAST(620000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1010, CAST(N'2024-07-18T15:40:51.903' AS DateTime), NULL, 3, 5, CAST(N'2024-07-18T15:41:02.130' AS DateTime), NULL, N'EM004', CAST(570000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1011, CAST(N'2024-07-18T15:43:11.380' AS DateTime), NULL, 3, 4, CAST(N'2024-07-18T15:43:21.203' AS DateTime), NULL, N'EM004', CAST(270000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1012, CAST(N'2024-07-18T15:44:20.023' AS DateTime), NULL, 3, 5, CAST(N'2024-07-18T15:45:04.867' AS DateTime), NULL, N'EM004', CAST(1020000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1013, CAST(N'2024-07-18T15:48:08.860' AS DateTime), NULL, 3, 5, CAST(N'2024-07-18T15:48:17.033' AS DateTime), NULL, N'EM004', CAST(320000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1014, CAST(N'2024-07-18T15:50:31.153' AS DateTime), NULL, 3, 3, CAST(N'2024-07-18T15:50:43.273' AS DateTime), NULL, N'EM004', CAST(600000.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1015, CAST(N'2024-07-18T16:25:43.577' AS DateTime), NULL, 4, 5, CAST(N'2024-07-18T16:25:43.577' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1016, CAST(N'2024-07-18T16:25:45.083' AS DateTime), NULL, 4, 6, CAST(N'2024-07-18T16:25:45.083' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1017, CAST(N'2024-07-18T16:25:46.760' AS DateTime), NULL, 4, 4, CAST(N'2024-07-18T16:25:46.760' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1018, CAST(N'2024-07-18T16:27:49.253' AS DateTime), NULL, 4, 13, CAST(N'2024-07-18T16:27:49.253' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
INSERT [dbo].[Order] ([id], [time_start], [order_menu_id], [status_id], [table_id], [time_end], [custormer_id], [employee_id], [price], [voucher_id]) VALUES (1019, CAST(N'2024-07-18T16:27:51.950' AS DateTime), NULL, 4, 12, CAST(N'2024-07-18T16:27:51.950' AS DateTime), NULL, N'EM004', CAST(0.00 AS Numeric(12, 2)), NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderMenu] ON 

INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1012, 2, 1, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1013, 2, 10, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1016, 2, 6, 2)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1017, 2, 12, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1018, 2, 4, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1019, 3, 6, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1020, 3, 11, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1021, 3, 9, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1022, 3, 5, 2)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1023, 1004, 4, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1024, 1004, 11, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1025, 1004, 15, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1026, 1, 15, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1027, 1006, 9, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1028, 1006, 12, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1029, 1006, 5, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1030, 1007, 9, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1031, 1007, 13, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1032, 1008, 6, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1033, 1008, 11, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1034, 1008, 4, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1035, 1008, 1, 2)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1036, 1009, 6, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1037, 1009, 11, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1038, 1009, 12, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1039, 1009, 10, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1040, 1009, 4, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1041, 1010, 6, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1042, 1010, 15, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1043, 1010, 12, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1044, 1010, 5, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1045, 1011, 9, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1046, 1011, 13, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1047, 1011, 15, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1048, 1012, 9, 2)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1050, 1012, 5, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1051, 1012, 10, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1052, 1012, 4, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1053, 1012, 16, 2)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1054, 1013, 11, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1055, 1013, 9, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1056, 1013, 12, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1057, 1014, 6, 1)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1058, 1014, 11, 2)
INSERT [dbo].[OrderMenu] ([id], [order_id], [menu_id], [quantity]) VALUES (1059, 1014, 4, 1)
SET IDENTITY_INSERT [dbo].[OrderMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Employee  ')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'Customer  ')
INSERT [dbo].[Role] ([id], [name]) VALUES (3, N'Manager   ')
INSERT [dbo].[Role] ([id], [name]) VALUES (4, N'Admin     ')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([id], [name]) VALUES (1, N'Active')
INSERT [dbo].[Status] ([id], [name]) VALUES (2, N'Ban')
INSERT [dbo].[Status] ([id], [name]) VALUES (3, N'Done')
INSERT [dbo].[Status] ([id], [name]) VALUES (4, N'Process')
INSERT [dbo].[Status] ([id], [name]) VALUES (5, N'Cancel')
INSERT [dbo].[Status] ([id], [name]) VALUES (6, N'Paid')
INSERT [dbo].[Status] ([id], [name]) VALUES (7, N'present')
INSERT [dbo].[Status] ([id], [name]) VALUES (8, N'absent')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (1, N'Table1', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (2, N'Table2', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (3, N'Table3', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (4, N'Table4', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (5, N'Table5', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (6, N'Table6', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (7, N'Table7', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (8, N'Table8', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (9, N'Table9', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (10, N'Table10', 1)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (11, N'Table1', 2)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (12, N'Table2', 2)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (13, N'Table3', 2)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (14, N'Table4', 2)
INSERT [dbo].[Table] ([id], [name], [floor]) VALUES (15, N'Table5', 2)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET IDENTITY_INSERT [dbo].[Voucher] ON 

INSERT [dbo].[Voucher] ([id], [name], [description], [quantity], [code], [discount], [remaining]) VALUES (2, N'Tung Bung Khai Truong', N'Sieu Khuyen Mai', 100, N'KM001', CAST(10 AS Numeric(3, 0)), 100)
SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Status]
GO
ALTER TABLE [dbo].[Attendence]  WITH CHECK ADD  CONSTRAINT [FK_Attendence_Employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
GO
ALTER TABLE [dbo].[Attendence] CHECK CONSTRAINT [FK_Attendence_Employee]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Status]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Account] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Account]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_customerType] FOREIGN KEY([customer_type_id])
REFERENCES [dbo].[customerType] ([id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_customerType]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Account] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Account]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeType] FOREIGN KEY([employee_type_id])
REFERENCES [dbo].[EmployeeType] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeType]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Ingredient] FOREIGN KEY([ingredient_id])
REFERENCES [dbo].[Ingredient] ([id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Ingredient]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([custormer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table] FOREIGN KEY([table_id])
REFERENCES [dbo].[Table] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Voucher] FOREIGN KEY([voucher_id])
REFERENCES [dbo].[Voucher] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Voucher]
GO
ALTER TABLE [dbo].[OrderMenu]  WITH CHECK ADD  CONSTRAINT [FK_OrderMenu_Menu] FOREIGN KEY([menu_id])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[OrderMenu] CHECK CONSTRAINT [FK_OrderMenu_Menu]
GO
ALTER TABLE [dbo].[OrderMenu]  WITH CHECK ADD  CONSTRAINT [FK_OrderMenu_Order1] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderMenu] CHECK CONSTRAINT [FK_OrderMenu_Order1]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Storage_Status] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Storage_Status]
GO
ALTER TABLE [dbo].[StorageItems]  WITH CHECK ADD  CONSTRAINT [FK_StorageItems_Items] FOREIGN KEY([item_id])
REFERENCES [dbo].[Items] ([id])
GO
ALTER TABLE [dbo].[StorageItems] CHECK CONSTRAINT [FK_StorageItems_Items]
GO
ALTER TABLE [dbo].[StorageItems]  WITH CHECK ADD  CONSTRAINT [FK_StorageItems_Storage] FOREIGN KEY([storage_id])
REFERENCES [dbo].[Storage] ([id])
GO
ALTER TABLE [dbo].[StorageItems] CHECK CONSTRAINT [FK_StorageItems_Storage]
GO
USE [master]
GO
ALTER DATABASE [MiYu] SET  READ_WRITE 
GO
