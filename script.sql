USE [master]
GO
/****** Object:  Database [Diplom_arendacar]    Script Date: 15.05.2024 17:50:35 ******/
CREATE DATABASE [Diplom_arendacar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Diplom_arendacar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Diplom_arendacar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Diplom_arendacar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Diplom_arendacar_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Diplom_arendacar] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Diplom_arendacar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Diplom_arendacar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET ARITHABORT OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Diplom_arendacar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Diplom_arendacar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Diplom_arendacar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Diplom_arendacar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET RECOVERY FULL 
GO
ALTER DATABASE [Diplom_arendacar] SET  MULTI_USER 
GO
ALTER DATABASE [Diplom_arendacar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Diplom_arendacar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Diplom_arendacar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Diplom_arendacar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Diplom_arendacar] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Diplom_arendacar] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Diplom_arendacar] SET QUERY_STORE = OFF
GO
USE [Diplom_arendacar]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [varchar](50) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NULL,
	[Brand] [varchar](50) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Care]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Care](
	[CareID] [int] IDENTITY(1,1) NOT NULL,
	[StatusCarID] [int] NULL,
	[BrandID] [int] NULL,
	[BodyID] [int] NULL,
	[ColorID] [int] NULL,
	[Name] [varchar](90) NULL,
	[YearID] [int] NOT NULL,
	[TypeengineID] [int] NOT NULL,
	[EngineCapacityID] [int] NULL,
	[Powe] [int] NULL,
	[Mileage] [int] NULL,
	[TransmissioneID] [int] NULL,
	[Cost] [int] NOT NULL,
	[PowerReserve] [int] NULL,
	[NumberUses] [int] NULL,
	[Image] [varchar](250) NULL,
	[TO] [int] NULL,
	[VIN] [varchar](150) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Care] PRIMARY KEY CLUSTERED 
(
	[CareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Year]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Year](
	[YearID] [int] IDENTITY(0,1) NOT NULL,
	[Year] [varchar](50) NULL,
 CONSTRAINT [PK_Year] PRIMARY KEY CLUSTERED 
(
	[YearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        b.Brand AS Бренд, dbo.Care.Name AS Модель, dbo.Care.Powe AS [Мощьность двигателя], dbo.Year.Year AS Год, dbo.Color.Color AS цвет, dbo.Care.Cost AS Цена
FROM            dbo.Care INNER JOIN
                         dbo.Brand AS b ON dbo.Care.BrandID = b.BrandID INNER JOIN
                         dbo.Color ON dbo.Care.ColorID = dbo.Color.ColorID INNER JOIN
                         dbo.Year ON dbo.Care.YearID = dbo.Year.YearID
WHERE        (dbo.Care.Status = 1)
GO
/****** Object:  Table [dbo].[Body]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Body](
	[BodyID] [int] IDENTITY(1,1) NOT NULL,
	[Body] [varchar](50) NULL,
 CONSTRAINT [PK_Body] PRIMARY KEY CLUSTERED 
(
	[BodyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detali]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detali](
	[DetaliID] [int] IDENTITY(1,1) NOT NULL,
	[Detali] [varchar](150) NULL,
 CONSTRAINT [PK_Detali] PRIMARY KEY CLUSTERED 
(
	[DetaliID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EngineCapacity]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngineCapacity](
	[EngineCapacityID] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [varchar](50) NULL,
 CONSTRAINT [PK_EngineCapacity] PRIMARY KEY CLUSTERED 
(
	[EngineCapacityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CareID] [int] NULL,
	[DateStartUses] [date] NULL,
	[DateEndUse] [date] NULL,
	[DateCreationOrder] [datetime] NULL,
	[OrderNumber] [nchar](10) NULL,
	[StatusID] [int] NULL,
	[CostRental] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] NOT NULL,
	[RoleName] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Work] [varchar](50) NULL,
	[Cost] [int] NULL,
	[DateStart] [datetime] NULL,
	[CareID] [int] NULL,
	[DateEnd] [datetime] NULL,
	[CodeService] [varchar](90) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceDetale]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceDetale](
	[ServiceID] [int] NOT NULL,
	[DetaliID] [int] NOT NULL,
	[Count] [int] NULL,
	[CodeService] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceHistoryUser]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceHistoryUser](
	[UserID] [int] NULL,
	[ServiceID] [int] NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusCar]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCar](
	[StatusCarID] [int] NOT NULL,
	[StatusCar] [varchar](90) NULL,
 CONSTRAINT [PK_StatusCar] PRIMARY KEY CLUSTERED 
(
	[StatusCarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transmissione]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transmissione](
	[TransmissioneID] [int] NOT NULL,
	[Trans] [varchar](90) NULL,
 CONSTRAINT [PK_Transmissione] PRIMARY KEY CLUSTERED 
(
	[TransmissioneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeEngine]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeEngine](
	[TypeengineID] [int] NOT NULL,
	[Typeengine] [varchar](75) NULL,
 CONSTRAINT [PK_TypeEngine] PRIMARY KEY CLUSTERED 
(
	[TypeengineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Patronymic] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[CodeService] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Body] ON 

INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (0, N'Все типы кузовов')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (1, N'Седан')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (2, N'Лифтбек')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (3, N'Универсал')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (4, N'Кроссовер')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (5, N'Хетчбэк')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (6, N'Купе')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (7, N'Внедорожник')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (8, N'Пикап')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (9, N'Кабриолет')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (10, N'Минивен')
INSERT [dbo].[Body] ([BodyID], [Body]) VALUES (23, N'WPL')
SET IDENTITY_INSERT [dbo].[Body] OFF
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (0, 12, N'Все производители')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (1, 1, N'Touota')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (2, 1, N'Subaru')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (3, 1, N'Honda')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (4, 1, N'Infiniti')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (5, 1, N'Lexsus')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (6, 1, N'Mazda')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (7, 1, N'Nissan')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (8, 1, N'Mitsubishi')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (9, 2, N'Ford')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (10, 2, N'Tesla')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (11, 2, N'Jeep')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (12, 2, N'Chevrole')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (13, 2, N'Dodge')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (14, 2, N'Cadillac')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (15, 3, N'Audi')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (16, 6, N'BMW')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (17, 3, N'Merscedes')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (18, 3, N'Opel')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (19, 3, N'Porsche')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (20, 3, N'Volkswagen')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (21, 4, N'Mini')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (22, 4, N'Bentley')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (23, 4, N'Land Rover')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (24, 4, N'Jaguar')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (25, 4, N'Aston Martin')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (26, 5, N'LADA')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (27, 6, N'Haval')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (28, 6, N'JAC')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (29, 6, N'Zeekr')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (30, 6, N'Geely')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (31, 6, N'Changan')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (32, 7, N'Hyndai')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (33, 7, N'Kia')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (34, 8, N'Maserati')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (35, 8, N'Lamborghini')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (36, 8, N'Fiat')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (37, 8, N'ferrari')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (38, 8, N'Alfa Romeo')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (39, 9, N'Renault')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (40, 9, N'Bugatti')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (41, 9, N'Citroen')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (42, 10, N'Volvo')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (43, 11, N'Skoda')
INSERT [dbo].[Brand] ([BrandID], [CountryID], [Brand]) VALUES (61, NULL, N'WPL')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Care] ON 

INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (1, 1, 33, 2, 12, N'Stinger', 7, 3, 0, 247, 60000, 1, 14000, 550, 37, N'1_Stinger.jpg', 6, N'JH4DA9340MS002938', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (2, 1, 10, 5, 2, N'Model X', 4, 3, 0, 525, 42000, 1, 11000, 550, 12, N'2_Model-X.jpg', 1, N'2FMZA51665BA05533', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (3, 4, 29, 1, 1, N'0011', 6, 1, 22, 200, 500, 1, 15000, 0, 1, NULL, 0, N'1225', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (4, 5, 17, 7, 2, N'G-Класс', 5, 1, 20, 422, 50000, 1, 25000, 0, 59, N'4_G-Class.jpg', 4, N'JH4DA9350LS003644', 4)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (5, 1, 15, 3, 3, N'RS-6', 8, 1, 20, 600, 22000, 1, 20000, 0, 11, N'5_RS-6.jpg', 1, N'2FDJF37G2BCA83848', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (6, 1, 15, 2, 5, N'RS-7', 8, 1, 20, 600, 35000, 1, 27000, 0, 19, N'6_RS-7.jpg', 3, N'YV1AH852071023377', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (7, 4, 19, 9, 1, N'911 Turbo S', 2, 3, 0, 650, 7000, 1, 40000, 300, 7, N'7_911 Turbo S.jpg', 0, N'22', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (8, 4, 16, 1, 2, N'7 Серия', 10, 3, 0, 286, 1000, 2, 30000, 800, 3, N'8_7 Серия.jpg', 0, N'55555', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (9, 1, 23, 4, 3, N'Rang Rover D350 Long', 10, 2, 16, 350, 3000, 1, 35000, 0, 11, N'9_RangRover.jpg', 0, N'JH4DA9460NS007560', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (10, 1, 35, 6, 9, N'Aventador', 3, 1, 22, 740, 9600, 1, 65000, 0, 5, N'10_Aventador.jpg', 0, N'3GYFK62817G278819', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (11, 5, 26, 1, 1, N'Priora', 4, 1, 7, 106, 30000, 2, 6000, 0, 45, N'Priora11.jpg', 3, N'2HKRM4H51CH631687', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (12, 2, 17, 7, 1, N'G-Класс', 5, 1, 20, 422, 85000, 1, 25000, 0, 56, NULL, 8, N'1C4BJWDG8DL559834', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (19, 1, 3, 8, 2, N'проверкаЭлектро', 3, 1, 5, 244, 1000, 1, 10000, 0, 0, N'213.jpg', 1, N'1G1YY26W285119002', NULL)
INSERT [dbo].[Care] ([CareID], [StatusCarID], [BrandID], [BodyID], [ColorID], [Name], [YearID], [TypeengineID], [EngineCapacityID], [Powe], [Mileage], [TransmissioneID], [Cost], [PowerReserve], [NumberUses], [Image], [TO], [VIN], [UserID]) VALUES (20, 2, 26, 4, 14, N'Vesta', 5, 3, 0, 234, 23444, 1, 23444, 123321, 0, NULL, 2, N'456', NULL)
SET IDENTITY_INSERT [dbo].[Care] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (0, N'Все цвета')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (1, N'Белый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (2, N'Чёрный')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (3, N'Красный')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (4, N'Синий')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (5, N'Серый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (6, N'Жёлтый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (7, N'Зелёный')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (8, N'Ораньжевый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (9, N'Голубой')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (10, N'Бордовый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (11, N'Коричнеый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (12, N'Хаки')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (13, N'Розовый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (14, N'Золотой')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (15, N'Хромированый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (16, N'Бирюзовый')
INSERT [dbo].[Color] ([ColorID], [Color]) VALUES (27, N'WPL')
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (0, N' ')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (1, N'Япония')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (2, N'США')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (3, N'Германия')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (4, N'Англия')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (5, N'Россия')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (6, N'Китай')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (7, N'Корея')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (8, N'Италия')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (9, N'Франции')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (10, N'Швеция')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (11, N'Чехия')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (12, N' ')
INSERT [dbo].[Country] ([CountryID], [Country]) VALUES (42, N'WPL')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Detali] ON 

INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (1, N'Свечи зажигания')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (2, N'Фильтр Масляный')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (3, N'Колодки')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (4, N'Масло Моторное')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (5, N'Масло Трансимисионное')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (6, N'Фильр Воздушный')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (7, N'Тормозные Диски')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (8, N'Шины')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (9, N'Антифриз')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (1010, N'Проверка')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (1011, N'Проверка')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (1012, N'Проверка')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (1013, N'GHJDTHRF')
INSERT [dbo].[Detali] ([DetaliID], [Detali]) VALUES (1014, N'wpl')
SET IDENTITY_INSERT [dbo].[Detali] OFF
GO
SET IDENTITY_INSERT [dbo].[EngineCapacity] ON 

INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (0, N'0')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (1, N'0.1')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (2, N'0.8')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (3, N'0.9')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (4, N'1')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (5, N'1.2')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (6, N'1.3')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (7, N'1.5')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (8, N'1.6')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (9, N'1.8')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (10, N'1.9')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (11, N'2')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (12, N'2.3')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (13, N'2.5')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (14, N'2.7')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (15, N'2.8')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (16, N'3')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (17, N'3.2')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (18, N'3.5')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (19, N'3.7')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (20, N'3.8')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (21, N'4')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (22, N'6.5')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (25, N'')
INSERT [dbo].[EngineCapacity] ([EngineCapacityID], [Capacity]) VALUES (27, N'1')
SET IDENTITY_INSERT [dbo].[EngineCapacity] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (1, 6, 11, CAST(N'2024-04-11' AS Date), CAST(N'2024-04-14' AS Date), CAST(N'2024-04-11T16:23:45.060' AS DateTime), N'7BAF770   ', 4, 12000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (3, 6, 4, CAST(N'2024-04-15' AS Date), CAST(N'2024-04-20' AS Date), CAST(N'2024-04-14T15:55:56.940' AS DateTime), N'DF30D3A   ', 4, 125000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (4, 6, 2, CAST(N'2024-04-25' AS Date), CAST(N'2024-04-30' AS Date), CAST(N'2024-04-25T16:36:29.120' AS DateTime), N'6575C9C   ', 5, 44000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (5, 6, 20, CAST(N'2024-05-09' AS Date), CAST(N'2024-05-26' AS Date), CAST(N'2024-05-09T12:44:43.213' AS DateTime), N'D254CCE   ', 2, 398548)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (6, 6, 8, CAST(N'2024-05-09' AS Date), CAST(N'2024-05-10' AS Date), CAST(N'2024-05-09T12:50:51.237' AS DateTime), N'92A2741   ', 3, 30000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (7, 6, 7, CAST(N'2024-05-21' AS Date), CAST(N'2024-05-26' AS Date), CAST(N'2024-05-11T23:12:52.693' AS DateTime), N'E49A044   ', 3, 240000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (8, 6, 3, CAST(N'2024-05-13' AS Date), CAST(N'2024-05-14' AS Date), CAST(N'2024-05-13T12:31:09.363' AS DateTime), N'522C9E4   ', 3, 15000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (9, 6, 10, CAST(N'2024-05-13' AS Date), CAST(N'2024-05-15' AS Date), CAST(N'2024-05-13T12:40:29.827' AS DateTime), N'FBA7700   ', 1, 130000)
INSERT [dbo].[Order] ([OrderID], [UserID], [CareID], [DateStartUses], [DateEndUse], [DateCreationOrder], [OrderNumber], [StatusID], [CostRental]) VALUES (10, 6, 5, CAST(N'2024-05-13' AS Date), CAST(N'2024-05-16' AS Date), CAST(N'2024-05-13T12:47:52.540' AS DateTime), N'ADF57D5   ', 1, 60000)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Пользователь')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Менеджер')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Авотмеханик')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (4, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (5, N'Заблокированый')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (6, N'Гость')
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ServiceID], [UserID], [Work], [Cost], [DateStart], [CareID], [DateEnd], [CodeService]) VALUES (37, 4, N'Техническое обслуживание', NULL, CAST(N'2024-05-15T17:46:51.440' AS DateTime), 4, NULL, N'2C15C96')
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
INSERT [dbo].[ServiceDetale] ([ServiceID], [DetaliID], [Count], [CodeService]) VALUES (37, 4, 1, NULL)
INSERT [dbo].[ServiceDetale] ([ServiceID], [DetaliID], [Count], [CodeService]) VALUES (37, 5, 1, NULL)
INSERT [dbo].[ServiceDetale] ([ServiceID], [DetaliID], [Count], [CodeService]) VALUES (37, 6, 1, NULL)
GO
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (1, N'Обрабатываеться')
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (2, N'Готов к выдаче')
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (3, N'Выданно')
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (4, N'Закрыта')
INSERT [dbo].[Status] ([StatusID], [Status]) VALUES (5, N'Отказано')
GO
INSERT [dbo].[StatusCar] ([StatusCarID], [StatusCar]) VALUES (1, N'Активна')
INSERT [dbo].[StatusCar] ([StatusCarID], [StatusCar]) VALUES (2, N'Забронированна')
INSERT [dbo].[StatusCar] ([StatusCarID], [StatusCar]) VALUES (4, N'В аренде')
INSERT [dbo].[StatusCar] ([StatusCarID], [StatusCar]) VALUES (5, N'Обслуживаеться')
INSERT [dbo].[StatusCar] ([StatusCarID], [StatusCar]) VALUES (6, N'Продана')
INSERT [dbo].[StatusCar] ([StatusCarID], [StatusCar]) VALUES (7, N'Не активна')
GO
INSERT [dbo].[Transmissione] ([TransmissioneID], [Trans]) VALUES (0, N' ')
INSERT [dbo].[Transmissione] ([TransmissioneID], [Trans]) VALUES (1, N'Автомат')
INSERT [dbo].[Transmissione] ([TransmissioneID], [Trans]) VALUES (2, N'Механика')
INSERT [dbo].[Transmissione] ([TransmissioneID], [Trans]) VALUES (3, N'Робот')
INSERT [dbo].[Transmissione] ([TransmissioneID], [Trans]) VALUES (4, N'Вариатор')
GO
INSERT [dbo].[TypeEngine] ([TypeengineID], [Typeengine]) VALUES (0, N'Все типы двигателей')
INSERT [dbo].[TypeEngine] ([TypeengineID], [Typeengine]) VALUES (1, N'Бензин')
INSERT [dbo].[TypeEngine] ([TypeengineID], [Typeengine]) VALUES (2, N'Дизель')
INSERT [dbo].[TypeEngine] ([TypeengineID], [Typeengine]) VALUES (3, N'Электро')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (1, 4, N'Алексей', N'Белый', N'Владимирович', N'4', N'4', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (2, 1, N'Саша', N'Белый', N'Владимиович', N'123', N'89501736225', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (3, 5, N'Антон', N'Горлов', N'Николаевич', N'123', N'465654', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (4, 3, N'Павел', N'Петров', N'Дмитриевич', N'3', N'3', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (5, 1, N'wpl', N'wpl', N'wpl', N'wpl', N'wpl', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (6, 1, N'prince', N'abigor', N'libra', N'1', N'1', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (7, 1, N'1', N'1', N'1', N'1', N'12', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (8, 5, N'12', N'12', N'12', N'12', N'456654', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (10, 2, N'Alexey', N'Beluy', N'Vladimirovich', N'2', N'2', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (11, 2, N'p', N'p', N'p', N'9', N'9', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (1012, 1, N'123', N'123', N'', N'', N'123', NULL)
INSERT [dbo].[User] ([UserID], [RoleID], [Name], [Surname], [Patronymic], [Password], [Number], [CodeService]) VALUES (1013, 1, N'Александр', N'Белый', N'Владимирович', N'5', N'89018511045', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Year] ON 

INSERT [dbo].[Year] ([YearID], [Year]) VALUES (0, N'Все года')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (1, N'2015')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (2, N'2016')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (3, N'2017')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (4, N'2018')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (5, N'2019')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (6, N'2020')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (7, N'2021')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (8, N'2022')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (9, N'2023')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (10, N'2024')
INSERT [dbo].[Year] ([YearID], [Year]) VALUES (19, N'777')
SET IDENTITY_INSERT [dbo].[Year] OFF
GO
ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [FK_Brand_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [FK_Brand_Country]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_Body] FOREIGN KEY([BodyID])
REFERENCES [dbo].[Body] ([BodyID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_Body]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_Brand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_Brand]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_Color] FOREIGN KEY([ColorID])
REFERENCES [dbo].[Color] ([ColorID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_Color]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_EngineCapacity] FOREIGN KEY([EngineCapacityID])
REFERENCES [dbo].[EngineCapacity] ([EngineCapacityID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_EngineCapacity]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_StatusCar] FOREIGN KEY([StatusCarID])
REFERENCES [dbo].[StatusCar] ([StatusCarID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_StatusCar]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_Transmissione] FOREIGN KEY([TransmissioneID])
REFERENCES [dbo].[Transmissione] ([TransmissioneID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_Transmissione]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_TypeEngine] FOREIGN KEY([TypeengineID])
REFERENCES [dbo].[TypeEngine] ([TypeengineID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_TypeEngine]
GO
ALTER TABLE [dbo].[Care]  WITH CHECK ADD  CONSTRAINT [FK_Care_Year] FOREIGN KEY([YearID])
REFERENCES [dbo].[Year] ([YearID])
GO
ALTER TABLE [dbo].[Care] CHECK CONSTRAINT [FK_Care_Year]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Care1] FOREIGN KEY([CareID])
REFERENCES [dbo].[Care] ([CareID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Care1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Care] FOREIGN KEY([CareID])
REFERENCES [dbo].[Care] ([CareID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Care]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_User]
GO
ALTER TABLE [dbo].[ServiceDetale]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetale_Detali] FOREIGN KEY([DetaliID])
REFERENCES [dbo].[Detali] ([DetaliID])
GO
ALTER TABLE [dbo].[ServiceDetale] CHECK CONSTRAINT [FK_ServiceDetale_Detali]
GO
ALTER TABLE [dbo].[ServiceDetale]  WITH CHECK ADD  CONSTRAINT [FK_ServiceDetale_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[ServiceDetale] CHECK CONSTRAINT [FK_ServiceDetale_Service]
GO
ALTER TABLE [dbo].[ServiceHistoryUser]  WITH CHECK ADD  CONSTRAINT [FK_ServiceHistoryUser_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ServiceID])
GO
ALTER TABLE [dbo].[ServiceHistoryUser] CHECK CONSTRAINT [FK_ServiceHistoryUser_Service]
GO
ALTER TABLE [dbo].[ServiceHistoryUser]  WITH CHECK ADD  CONSTRAINT [FK_ServiceHistoryUser_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ServiceHistoryUser] CHECK CONSTRAINT [FK_ServiceHistoryUser_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  StoredProcedure [dbo].[add_detali]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_detali]
	@name_detali varchar(90)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Detali](Detali) VALUES(@name_detali)
END
GO
/****** Object:  StoredProcedure [dbo].[add_new_car_electro]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_new_car_electro]

	(@status_car_id int,
	@brand_id int,
	@body_id int, 
	@color_id int, 
	@car_name varchar(50),
	@year_id int,
	@type_engent_id int,
	@engine_capacity_id int,
	@powe int,
	@mileage int,
	@transmissione_id int,
	@cost int,
	@power_reserve int,
	@number_uses int,
	@to int,
	@VIN varchar(90)
	--IMG = NULL
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Care](StatusCarID, BrandID, BodyID, ColorID, [Name], YearID, TypeengineID, EngineCapacityID, Powe, Mileage, TransmissioneID, Cost, PowerReserve, NumberUses, [TO], VIN)
	VALUES(1,@brand_id, @body_id, @color_id, @car_name, @year_id, @type_engent_id, @engine_capacity_id, @powe, @mileage, @transmissione_id, @cost, @power_reserve, @number_uses, @to, @VIN)
END
GO
/****** Object:  StoredProcedure [dbo].[add_worker]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[add_worker]
		@name varchar(50),
		@surname varchar(50),
		@patronymic varchar(50),
		@number varchar(20),
		@password varchar(50),
		@role_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[User]([Name], Surname, Patronymic, Number, [Password], RoleID)
	VALUES
	(@name, @surname, @patronymic, @number, @password, @role_id)
END
GO
/****** Object:  StoredProcedure [dbo].[AddClient]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddClient]

@name varchar(50),
@surname varchar(50),
@patronymic varchar(50),
@number varchar(20),
@password varchar(50)

AS
BEGIN
	INSERT INTO [dbo].[User]([Name], Surname, Patronymic, Number, Password, RoleID)
	VALUES
	(@name, @surname, @patronymic, @number, @password, 1)

END
GO
/****** Object:  StoredProcedure [dbo].[Assigning_Car_Master]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Assigning_Car_Master]
	@car_id int,
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Care
	SET UserID = @user_id
	WHERE CareID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[blok]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[blok]
	@user_id int,
	@car_id int,
	@service_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Work
	FROM [Service] s
	WHERE s.UserID = @user_id AND s.CarID = @car_id AND ServiceID = @service_id
END
GO
/****** Object:  StoredProcedure [dbo].[blok_detail]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[blok_detail]
	@user_id int,
	@car_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(ServiceID)
	FROM [Service] s
	WHERE s.UserID = @user_id AND s.CarID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[car_info_cuntry]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[car_info_cuntry] 
	@car_id int
AS
BEGIN
	SELECT Country.[Country], e.Capacity, t.Trans, Care.PowerReserve, Typeengine
	from Care
	JOIN [Brand] b ON Care.BrandID = b.BrandID
	JOIN [Country] ON b.CountryID = Country.CountryID
	JOIN [EngineCapacity] e ON Care.EngineCapacityID = e.EngineCapacityID
	JOIN [Transmissione] t ON Care.TransmissioneID =t.TransmissioneID
	JOIN [TypeEngine] ON Care.TypeengineID = TypeEngine.TypeengineID
	WHERE CareID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[carinfo]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[carinfo]
	@car_id int
AS
BEGIN

	SELECT CareID, Country.[Country]
	from Care
	JOIN [Brand] b ON Care.BrandID = b.BrandID
	JOIN [Country] ON b.CountryID = Country.CountryID
	WHERE CareID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[change_car_electro_false]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[change_car_electro_false]
	(@care_id int,
	@model_name varchar(90),
	@brend_id int,
	@country_id int,
	@color_id int,

	@Engine_Type int,
	@Engine_Capacity int,

	@vin varchar(90),

	@body_id int,
	@Year_id int,
	@Transmission_Type int,
	@power_reserve int, 
	@horsepower int, 
	@mileage int,
	@to int,
	@cost int)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @vin = 0
	BEGIN 
		UPDATE [Care]
		Set [Name] = @model_name,
		BrandID = @brend_id,
		ColorID = @color_id,
		BodyID = @body_id,
		YearID = @Year_id,
		TransmissioneID = @Transmission_Type,
		PowerReserve = @power_reserve,
		Powe = @horsepower,
		Mileage = @mileage,
		[TO] = @to,
		Cost = @cost, 

		EngineCapacityID = @Engine_Capacity,
		TypeengineID = @Engine_Type

		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
	ELSE
	BEGIN 
		UPDATE [Care]
		Set [Name] = @model_name,
		BrandID = @brend_id,
		ColorID = @color_id,
		BodyID = @body_id,
		YearID = @Year_id,
		TransmissioneID = @Transmission_Type,
		PowerReserve = @power_reserve,
		Powe = @horsepower,
		Mileage = @mileage,
		[TO] = @to,
		Cost = @cost, 
		EngineCapacityID = @Engine_Capacity,
		TypeengineID = @Engine_Type,
		VIN = @vin
		

		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[change_car_electro_true]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[change_car_electro_true]
	(@care_id int,
	@model_name varchar(90),
	@brend_id int,
	@country_id int,
	@color_id int,
	@body_id int,
	@Year_id int,
	@Transmission_Type int,
	@power_reserve int, 
	@horsepower int, 
	@mileage int,
	@to int,
	@cost int,

	@Engine_Capacity int,


	@vin varchar(90))


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @vin = 0
	BEGIN
		UPDATE [Care]
		Set [Name] = @model_name,
		BrandID = @brend_id,
		ColorID = @color_id,
		BodyID = @body_id,
		YearID = @Year_id,
		TransmissioneID = @Transmission_Type,
		PowerReserve = @power_reserve,
		Powe = @horsepower,
		Mileage = @mileage,
		[TO] = @to,
		Cost = @cost,
		EngineCapacityID = @Engine_Capacity

		

		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
	ELSE
	BEGIN
		UPDATE [Care]
		Set [Name] = @model_name,
		BrandID = @brend_id,
		ColorID = @color_id,
		BodyID = @body_id,
		YearID = @Year_id,
		TransmissioneID = @Transmission_Type,
		PowerReserve = @power_reserve,
		Powe = @horsepower,
		Mileage = @mileage,
		[TO] = @to, Cost = @cost,
		VIN = @vin,
		EngineCapacityID = @Engine_Capacity


		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[change_car_false]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[change_car_false]
	(@care_id int,
	@model_name varchar(90),
	@brend_id int,
	@country_id int,
	@color_id int,

	@Engine_Type int,
	@Engine_Capacity int,

	@vin varchar(90),

	@body_id int,
	@Year_id int,
	@Transmission_Type int,
	@power_reserve int, 
	@horsepower int, 
	@mileage int,
	@to int,
	@cost int)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @vin = 0
	BEGIN
		UPDATE [Care]
		Set [Name] = @model_name,
		BrandID = @brend_id,
		ColorID = @color_id,
		BodyID = @body_id,
		YearID = @Year_id,
		TransmissioneID = @Transmission_Type,
		PowerReserve = @power_reserve,
		Powe = @horsepower,
		Mileage = @mileage,
		[TO] = @to,
		Cost = @cost, 
		EngineCapacityID = @Engine_Capacity,
		TypeengineID = @Engine_Type

		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
	ELSE
	BEGIN
		UPDATE [Care]
		Set [Name] = @model_name,
		BrandID = @brend_id,
		ColorID = @color_id,
		BodyID = @body_id,
		YearID = @Year_id,
		TransmissioneID = @Transmission_Type,
		PowerReserve = @power_reserve,
		Powe = @horsepower,
		Mileage = @mileage,
		[TO] = @to,
		Cost = @cost, 
		EngineCapacityID = @Engine_Capacity,
		TypeengineID = @Engine_Type,
		VIN = @vin

		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[change_car_name]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[change_car_name]
	@care_id int,
	@new_name varchar(90)

	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Care 
	Set [Name] = @new_name
	WHERE CareID = @care_id


END
GO
/****** Object:  StoredProcedure [dbo].[change_car_true]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
CREATE PROCEDURE [dbo].[change_car_true]
	(@care_id int,
	@model_name varchar(90),
	@brend_id int,
	@country_id int,
	@color_id int,
	@body_id int,

	@Engine_Capacity int,

	@vin varchar(90),

	@Year_id int,
	@Transmission_Type int, 
	@horsepower int, 
	@mileage int,
	@to int,
	@cost int)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @vin = 0
	BEGIN
		UPDATE [Care]
		Set [Name] = @model_name, BrandID = @brend_id, ColorID = @color_id, BodyID = @body_id, YearID = @Year_id, TransmissioneID = @Transmission_Type, Powe = @horsepower, Mileage = @mileage, [TO] = @to, Cost = @cost, EngineCapacityID = @Engine_Capacity
		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
	ELSE
	BEGIN
		UPDATE [Care]
		Set [Name] = @model_name, BrandID = @brend_id, ColorID = @color_id, BodyID = @body_id, YearID = @Year_id, TransmissioneID = @Transmission_Type, Powe = @horsepower, Mileage = @mileage, [TO] = @to, Cost = @cost, EngineCapacityID = @Engine_Capacity, VIN = @vin
		WHERE CareID = @care_id

		UPDATE [Brand]
		Set CountryID = @country_id
		where BrandID = @brend_id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Contract_PDF]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Contract_PDF]
	@car_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.Brand, c.[Name], o.DateStartUses, o.DateEndUse, o.CostRental
	FROM [Order] o
	JOIN Care c ON o.CareID=c.CareID
	JOIN Brand b ON c.BrandID=b.BrandID
	WHERE c.CareID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[costfoltr1]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[costfoltr1]
	@costmin varchar(50),
	@costmax varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.[Brand] as [Бренд], Care.[Name] as [Модель], Care.[Powe] as [Мощьность двигателя], [Year].[Year] as [Год], Color.[Color] as [цвет], Care.[Cost] as [Цена], Care.NumberUses

FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] ON Care.YearID = [Year].YearID
WHERE Care.[Cost] BETWEEN @costmin AND @costmax 
	AND
	Care.Status = 1

END
GO
/****** Object:  StoredProcedure [dbo].[CreatOrderUser]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreatOrderUser]
(@user_id int,
@car_id int,
@date_start date,
@date_end date,
@cost_renal int
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [Order] (UserID, CareID, DateStartUses, DateEndUse, DateCreationOrder, OrderNumber, StatusID, CostRental) VALUES (@user_id, @car_id, @date_start, @date_end, GETDATE(), RIGHT(NEWID(),7), 1, @cost_renal)

END
GO
/****** Object:  StoredProcedure [dbo].[Detali_PDF]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Detali_PDF]
	@service_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.Detali, sd.[Count]
	FROM ServiceDetale sd
	JOIN Detali d ON sd.DetaliID = d.DetaliID
	WHERE ServiceID = @service_id
END
GO
/****** Object:  StoredProcedure [dbo].[detaling_servic_end]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[detaling_servic_end]
		@service_id int,
		@cost int,
		@detailing varchar(50)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Service](Work, Cost, DateEnd) VALUES(@detailing, @cost ,GETDATE())

END
GO
/****** Object:  StoredProcedure [dbo].[detaling_servic_start]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[detaling_servic_start]
		@user_id int,
		@care_id int


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Service](CarID, UserID, DateStart) VALUES(@care_id, @user_id, GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[End_Service_Detail]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[End_Service_Detail]
	@cost int,
	@date_end datetime,
	@CodeService varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here	
	UPDATE [dbo].[Service]
	Set DateEnd = @date_end, Cost = @cost
	WHERE CodeService = @CodeService
END
GO
/****** Object:  StoredProcedure [dbo].[End_Service_TO]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[End_Service_TO]
	@cost int,
	@date_end datetime,
	@CodeService varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Service]
	Set DateEnd = @date_end, Cost = @cost
	WHERE CodeService = @CodeService
END
GO
/****** Object:  StoredProcedure [dbo].[Entrance]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Entrance]
	(@number varchar(30), @password varchar(30))
AS
BEGIN
	SELECT * from [User] WHERE [Number]=@number and [Password]=@password
 
END
GO
/****** Object:  StoredProcedure [dbo].[foto]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[foto]
	@car_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Image]
	FROM Care
	WHERE CareID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[fullfiltr]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[fullfiltr]
	


	@brand varchar(75),
	@year varchar(75),
	@color varchar(75),
	@powermin varchar(75),
	@powermax varchar(75),
	@costmin varchar(75),
	@costmax varchar(75)

AS
BEGIN
	SET NOCOUNT ON;

	SELECT Care.[CareID], b.[Brand] as [Бренд], Care.[Name] as [Модель], Care.[Powe] as [Мощьность двигателя], [Year].[Year] as [Год], Color.[Color] as [цвет], Care.[Cost] as [Цена], Care.NumberUses

FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] ON Care.YearID = [Year].YearID
WHERE Care.Status = 1
	AND
	b.BrandID = @brand
	OR 
	(Care.[Powe] BETWEEN @powermin AND @powermax)
	OR
	(Care.[Cost] BETWEEN @costmin AND @costmax)
	OR
	Color.ColorID = @color
	OR
	[Year].YearID = @year

END
GO
/****** Object:  StoredProcedure [dbo].[Greeting]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Greeting]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Surname, [Name], Patronymic
	FROM [User]
	WHERE UserID = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[histori_klient]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[histori_klient]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.Brand AS [Марка], c.[Name] AS [Модель], o.DateStartUses AS [Дата начала], o.DateEndUse AS [Дата конца], o.CostRental AS [Цена]
	FROM [Order] o
	JOIN Care c ON o.CareID = c.CareID
	JOIN Brand b ON c.BrandID = b.BrandID
	WHERE UserID = @user_id AND StatusID = 4
END
GO
/****** Object:  StoredProcedure [dbo].[history_order_user]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[history_order_user]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.Brand, c.[Name], c.VIN, o.CostRental, o.DateStartUses, o.DateEndUse 
	FROM [Order] o
	JOIN Care c ON o.CareID = c.CareID
	JOIN Brand b ON c.BrandID = b.BrandID
	WHERE o.UserID = @user_id AND o.StatusID = 4
END
GO
/****** Object:  StoredProcedure [dbo].[inicialu]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[inicialu]
	@user_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Name], [Surname], [Patronymic], [Number]
	FROM [User]
	WHERE UserID = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[List_All_Services]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[List_All_Services]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT c.CareID, c.Mileage, c.[TO], b.Brand AS [Бренд], c.[Name] AS [Модель], c.VIN
	FROM Care c 
	JOIN Brand b ON c.BrandID = b.BrandID
	WHERE c.StatusCarID = 5 AND c.UserID IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[list_car_master]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_car_master]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.CareID, c.[TO], c.Mileage, b.Brand, c.[Name], c.VIN
	FROM Care c
	JOIN Brand b ON c.BrandID = b.BrandID
	WHERE c.StatusCarID = 5
END
GO
/****** Object:  StoredProcedure [dbo].[list_care_change]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_care_change]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Care.[CareID], te.TypeengineID, c.CountryID, b.BrandID, Care.[Name] as [Модель], b.[Brand] as [Бренд],c.Country AS[Страна], bb.Body AS [Кузов], Color.[Color] as [цвет], [Year].[Year] as [Год], te.Typeengine AS[Тип двигателя], ec.Capacity AS [Объём двигателя], Care.[Powe] as [Мощьность],Care.Mileage AS [Пробег], t.Trans AS [КПП], Care.[Cost] as [Цена], Care.PowerReserve AS [Запас хода], Care.VIN as [VIN]

FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] ON Care.YearID = [Year].YearID
JOIN [Body] bb ON Care.BodyID = bb.BodyID
JOIN [TypeEngine] te ON Care.TypeengineID = te.TypeengineID
JOIN [EngineCapacity] ec ON Care.EngineCapacityID = ec.EngineCapacityID
JOIN [Transmissione] t ON Care.TransmissioneID = t.TransmissioneID
JOIN [Country] c ON b.CountryID = c.CountryID
WHERE Care.StatusCarID = 1
END
GO
/****** Object:  StoredProcedure [dbo].[list_care_change1]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_care_change1]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Care.CareID AS [CareID 0],
	b.BrandID AS [BrandID 1],
	b.CountryID AS [CountryID 2],
	bb.BodyID AS [BodyID 3],
	Color.ColorID AS [ColorID 4],
	y.YearID AS [YearID 5],
	te.TypeengineID AS [TypeengineID 6],
	ec.EngineCapacityID AS [EngineCapacityID 7],
	t.TransmissioneID AS [TransmissioneID 8],
	Care.PowerReserve AS [PowerReserve 9],
	b.Brand,
	Care.[Name],
	Care.VIN,
	Care.Powe,
	Care.Mileage,
	Care.[TO],
	Care.Cost


FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Body] bb ON Care.BodyID = bb.BodyID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] y ON Care.YearID = y.YearID
JOIN [TypeEngine] te ON Care.TypeengineID = te.TypeengineID
JOIN [EngineCapacity] ec ON Care.EngineCapacityID = ec.EngineCapacityID
JOIN [Transmissione] t ON Care.TransmissioneID = t.TransmissioneID
JOIN [Country] co ON b.CountryID = co.CountryID
WHERE Care.StatusCarID = 1
END
GO
/****** Object:  StoredProcedure [dbo].[list_detali]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_detali]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.DetaliID, d.Detali AS [Детали]
	FROM [Detali] d
END
GO
/****** Object:  StoredProcedure [dbo].[List_My_Services]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[List_My_Services]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.CareID, c.Mileage, c.[TO], b.Brand AS [Бренд], c.[Name] AS [Модель], c.VIN
	FROM Care c 
	JOIN Brand b ON c.BrandID = b.BrandID
	WHERE c.StatusCarID = 5 AND c.UserID = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[list_Order]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_Order]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Order].OrderID, [Order].[UserID], [Order].CareID, OrderNumber as [Номер заявки], c.[Name] as [Модель], [Order].DateStartUses as [Начало аренды], [Order].DateEndUse as [Конец аренды], [Order].DateCreationOrder as [Дата создания заяки], [Order].CostRental as [Цена аренды], s.[Status] as [Статус заявки]
	FROM [Order]
	JOIN [Care] c ON [Order].CareID = c.CareID
	JOIN [Status] s ON [Order].StatusID = s.StatusID
	WHERE [Order].StatusID = 1
	OR [Order].StatusID = 2


END
GO
/****** Object:  StoredProcedure [dbo].[list_order2]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_order2]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT [Order].OrderID, [Order].[UserID], [Order].CareID, OrderNumber as [Номер заявки], c.[Name] as [Модель], [Order].DateStartUses as [Начало аренды], [Order].DateEndUse as [Конец аренды], [Order].CostRental as [Цена аренды], s.[Status] as [Статус заявки], c.VIN AS [VIN-номер машины]
	FROM [Order]
	JOIN [Care] c ON [Order].CareID = c.CareID
	JOIN [Status] s ON [Order].StatusID = s.StatusID
	WHERE [Order].StatusID = 3

END
GO
/****** Object:  StoredProcedure [dbo].[list_users]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[list_users]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.UserID, u.[Name] as [Имя], u.[Surname] as [Фамилия], u.[Patronymic] as [отчество], u.[Number] as [Номер], r.[RoleName] as [Должность]
	FROM [User] u 
	JOIN [Role] r ON u.RoleID = r.RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[listcar]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[listcar]

AS
BEGIN
	SELECT Care.[CareID], b.[Brand] as [Бренд], Care.[Name] as [Модель], Care.[Powe] as [Мощьность двигателя4], [Year].[Year] as [Год], Color.[Color] as [цвет], Care.[Cost] as [Цена], Care.NumberUses, Care.TypeengineID

FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] ON Care.YearID = [Year].YearID
WHERE Care.StatusCarID = 1
ORDER BY Care.NumberUses DESC
	SET NOCOUNT ON;

END
GO
/****** Object:  StoredProcedure [dbo].[listcar1]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[listcar1]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT Care.[CareID], b.[Brand] as [Бренд], Care.[Name] as [Модель],te.TypeengineID, Care.[Powe] as [Мощьность двигателя], [Year].[Year] as [Год], Color.[Color] as [цвет], Care.[Cost] as [Цена], Care.NumberUses,  bb.Body AS [Кузов], Care.[Image], Care.PowerReserve, te.Typeengine

FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] ON Care.YearID = [Year].YearID
JOIN [Body] bb ON Care.BodyID = bb.BodyID
JOIN [TypeEngine] te ON Care.TypeengineID = te.TypeengineID

WHERE Care.StatusCarID = 1
ORDER BY Care.NumberUses DESC
 
END
GO
/****** Object:  StoredProcedure [dbo].[new_data]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[new_data]
	@country varchar(90),
	@brand varchar(90),
	@body varchar(90),
	@color varchar(90),
	@year varchar(90),
	@EngineCapacity varchar(90)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@country != '1' AND @brand = '1' AND @body = '1' AND @color = '1' AND @year = '1' AND @EngineCapacity = '1')
	BEGIN
	INSERT INTO [Country](Country)VALUES(@country)
	END

	ELSE IF (@country != '1' AND @brand != '1' AND @body = '1' AND @color = '1' AND @year = '1' AND @EngineCapacity = '1')
	BEGIN
	INSERT INTO [Country](Country)VALUES(@country)
	INSERT INTO [Brand](Brand)VALUES(@brand)
	END

	ELSE IF (@country != '1' AND @brand != '1' AND @body != '1' AND @color = '1' AND @year = '1' AND @EngineCapacity = '1')
	BEGIN
	INSERT INTO [Country](Country)VALUES(@country)
	INSERT INTO [Brand](Brand)VALUES(@brand)
	INSERT INTO [Body](Body)VALUES(@brand)
	END

	ELSE IF (@country != '1' AND @brand != '1' AND @body != '1' AND @color != '1' AND @year = '1' AND @EngineCapacity = '1')
	BEGIN
	INSERT INTO [Country](Country)VALUES(@country)
	INSERT INTO [Brand](Brand)VALUES(@brand)
	INSERT INTO [Body](Body)VALUES(@body)
	INSERT INTO [Color](Color)VALUES(@color)
	END

	ELSE IF (@country != '1' AND @brand != '1' AND @body != '1' AND @color != '1' AND @year != '1' AND @EngineCapacity = '1')
	BEGIN
	INSERT INTO [Country](Country)VALUES(@country)
	INSERT INTO [Brand](Brand)VALUES(@brand)
	INSERT INTO [Body](Body)VALUES(@body)
	INSERT INTO [Color](Color)VALUES(@color)
	INSERT INTO [Year]([Year])VALUES(@year)
	END

	ELSE IF (@country = '1' AND @brand = '1' AND @body = '1' AND @color = '1' AND @year = '1' AND @EngineCapacity = '1')
	BEGIN
	INSERT INTO [Country](Country)VALUES(@country)
	INSERT INTO [Brand](Brand)VALUES(@brand)
	INSERT INTO [Body](Body)VALUES(@body)
	INSERT INTO [Color](Color)VALUES(@color)
	INSERT INTO [Year]([Year])VALUES(@year)
	INSERT INTO [EngineCapacity]([Capacity])VALUES(@EngineCapacity)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Ordercar1]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Ordercar1]
	@car_id int

AS
BEGIN
	SELECT Care.[CareID], b.[Brand], Care.[Name], Care.[Powe], [Year].[Year], Color.[Color], Care.[Cost], Care.NumberUses

FROM Care 
JOIN [Brand] b ON Care.BrandID = b.BrandID
JOIN [Color] ON Care.ColorID = Color.ColorID
JOIN [Year] ON Care.YearID = [Year].YearID
WHERE Care.CareID = @car_id
END
GO
/****** Object:  StoredProcedure [dbo].[OrderCarUserHistori]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[OrderCarUserHistori]
	@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  [Order].UserID, [Order].[CareID], [Order].OrderNumber as [Номер заказа], [Care].[Name] as [Модель], [Order].DateStartUses as [Начало аренды], [Order].DateEndUse as [Конец аренды], [Order].DateCreationOrder as [Дата создание заявки], [Order].CostRental as [Цена], s.[Status] as[Статус заяввки]

	FROM [Order]
	JOIN [Care] ON [Order].CareID = Care.CareID
	JOIN [Status] s ON [Order].StatusID = s.StatusID
	WHERE UserID = @user_id AND ([Order].StatusID = 1 OR [Order].StatusID = 2 OR [Order].StatusID = 3)

END
GO
/****** Object:  StoredProcedure [dbo].[Ordering_parts]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Ordering_parts]
	@service_id int,
	@detali_id int,
	@detali_count int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[ServiceDetale] (ServiceID, DetaliID, [Count]) VALUES (@service_id, @detali_id, @detali_count)
END
GO
/****** Object:  StoredProcedure [dbo].[prinytie]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[prinytie]
	(@order_id int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Order].OrderID, c.CareID, [Order].OrderNumber, c.Mileage, c.VIN
	FROM [Order]
	JOIN Care c ON [Order].CareID = c.CareID
	WHERE OrderID = @order_id


END
GO
/****** Object:  StoredProcedure [dbo].[proverka_vin]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[proverka_vin]
	@vin_cod varchar(90)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM Care
	WHERE VIN = @vin_cod
END
GO
/****** Object:  StoredProcedure [dbo].[report]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[report] 
	@date_start date,
	@date_end date

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT u.Surname AS [Фамилия], u.[Name] AS [Имя], u.Patronymic AS [Отчество], b.Brand AS [Марка], c.[Name] AS [Модель], c.VIN, o.CostRental AS [Цена], o.DateStartUses AS [Дата начала], o.DateEndUse AS [Дата конца]
	FROM [Order] o
	JOIN [User] u ON o.UserID = u.UserID
	JOIN [Care] c ON o.CareID = c.CareID
	JOIN [Brand] b ON c.BrandID = b.BrandID
	WHERE DateStartUses >=  @date_start AND DateEndUse <=  @date_end AND StatusID = 4
END
GO
/****** Object:  StoredProcedure [dbo].[restoring_access]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[restoring_access]
	@user_id int,
	@role_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [User]
	Set RoleID = @role_id
	WHERE UserID = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[Start_Service_Detail]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Start_Service_Detail]
	@user_id int,
	@car_id int,
	@date_start datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Service] (UserID, CareID, DateStart, Work, CodeService) VALUES (@user_id, @car_id, @date_start, 'Детейлинг', RIGHT(NEWID(),7))

	UPDATE [dbo].[ServiceHistoryUser]
	SET UserID = @user_id, [Status] = 'В работе', ServiceID = (SELECT MAX(ServiceID) FROM [Service] WHERE UserID = @user_id AND CareID = @car_id)

END
GO
/****** Object:  StoredProcedure [dbo].[Start_Service_TO]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Start_Service_TO]
	@user_id int,
	@car_id int,
	@date_start datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Service](UserID, CareID, DateStart, Work, CodeService) VALUES(@user_id, @car_id, @date_start, 'Техническое обслуживание', RIGHT(NEWID(),7))

	UPDATE [dbo].[ServiceHistoryUser]
	SET UserID = @user_id, [Status] = 'В работе', ServiceID = (SELECT MAX(ServiceID) FROM [Service] WHERE UserID = @user_id AND CareID = @car_id)
END
GO
/****** Object:  StoredProcedure [dbo].[update_brend_car]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_brend_car]
	@care_id int,
	@care_new_brend int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		UPDATE [Care]
	Set [BrandID] = @care_new_brend
	WHERE CareID = @care_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_color_car]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_color_car]
	@care_id int,
	@care_new_color int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Care]
	Set ColorID = @care_new_color 
	WHERE CareID = @care_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_country_car]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_country_car]
	@brend_id int,
	@care_new_country int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Brand]
	Set CountryID = @care_new_country
	WHERE BrandID = @brend_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_detailing_end]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_detailing_end]
		@service_id int,
		@cost int,
		@detailing varchar(50),
		@user_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [Service] 
	Set Cost = @cost, Work = @detailing, DateEnd = GETDATE()
	WHERE ServiceID = @service_id AND UserID = @user_id;
    -- Insert statements for procedure here
	
END
GO
/****** Object:  StoredProcedure [dbo].[update_engine_capacity]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_engine_capacity]
	@care_id int,
	@new_engine_capacity int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Care]
	Set [EngineCapacityID] = @new_engine_capacity
	WHERE CareID = @care_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_foto_car]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_foto_car]
	@care_id int,
	@foto varchar(90)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Care]
	Set [Image] = @foto
	WHERE CareID = @care_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_name_car]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_name_car]
	@care_id int,
	@care_new_name varchar(90)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Care]
	Set [Name] = @care_new_name
	WHERE CareID = @care_id
END
GO
/****** Object:  StoredProcedure [dbo].[update_number]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_number]
	@user_id int,
	@number varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		UPDATE [User] 
		Set Number = @number
		WHERE UserID = @user_id;
END
GO
/****** Object:  StoredProcedure [dbo].[update_role_id]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_role_id]
	@user_id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		UPDATE [User] 
		Set RoleID = 5
		WHERE UserID = @user_id;
END
GO
/****** Object:  StoredProcedure [dbo].[update_status_car]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[update_status_car]
	@car_id int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Care] 
	Set StatusCarID = 1
	WHERE CareID = @car_id;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Status_Order]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Status_Order]
	@order_ID int,
	@care_ID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [Order] 
	Set StatusID = 5
	WHERE OrderID = @order_ID;

	UPDATE [Care] 
	Set [StatusCarID] = 1
	WHERE CareID = @care_ID;

END
GO
/****** Object:  StoredProcedure [dbo].[Update_Status_Order2]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Status_Order2]
	@order_ID int,
	@care_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET NOCOUNT ON;
	UPDATE [Order] 
	Set StatusID = 3
	WHERE OrderID = @order_ID;

	UPDATE [Care] 
	Set [StatusCarID] = 4
	WHERE CareID = @care_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Status_Order3]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Update_Status_Order3]
	@order_ID int,
	@care_ID int,
	@milleg int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET NOCOUNT ON;
	UPDATE [Order] 
	Set StatusID = 4
	WHERE OrderID = @order_ID;

	UPDATE [Care] 
	Set [StatusCarID] = 5
	WHERE CareID = @care_ID;

	UPDATE [Care] 
	Set [Mileage] = @milleg
	WHERE CareID = @care_ID;
END
GO
/****** Object:  StoredProcedure [dbo].[user_for_pdf]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[user_for_pdf]
	@order_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  u.Surname, u.[Name], u.[Patronymic]
	FROM [Order] o
	JOIN [User] u ON o.UserID = u.UserID
	WHERE o.OrderID = @order_id
END
GO
/****** Object:  StoredProcedure [dbo].[xxx]    Script Date: 15.05.2024 17:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[xxx]
		@car int,
		@user int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(ServiceID) AS [max_id]
	FROM [Service] s
	WHERE s.UserID = @user AND s.CarID = @car AND ServiceID IS NOT NULL
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Care"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 258
               Bottom = 119
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Color"
            Begin Extent = 
               Top = 6
               Left = 470
               Bottom = 102
               Right = 644
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Year"
            Begin Extent = 
               Top = 6
               Left = 682
               Bottom = 102
               Right = 856
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 13
         Column = 1440
         Alias = 2760
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
         Or = 1350
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [Diplom_arendacar] SET  READ_WRITE 
GO
