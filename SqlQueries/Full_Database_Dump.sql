USE [master]
GO
/****** Object:  Database [ProjectDataBase]    Script Date: 07.01.2021 14:57:56 ******/
CREATE DATABASE [ProjectDataBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectDataBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectDataBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectDataBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectDataBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectDataBase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectDataBase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectDataBase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectDataBase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectDataBase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectDataBase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectDataBase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectDataBase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectDataBase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectDataBase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectDataBase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectDataBase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectDataBase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectDataBase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectDataBase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectDataBase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectDataBase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectDataBase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectDataBase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectDataBase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectDataBase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectDataBase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectDataBase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectDataBase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectDataBase] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectDataBase] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectDataBase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectDataBase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectDataBase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectDataBase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectDataBase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectDataBase', N'ON'
GO
ALTER DATABASE [ProjectDataBase] SET QUERY_STORE = OFF
GO
USE [ProjectDataBase]
GO
/****** Object:  Table [dbo].[Auditories]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auditories](
	[AuditoriumID] [int] IDENTITY(1,1) NOT NULL,
	[ResponsibleID] [int] NOT NULL,
	[AuditoryType] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AuditoriumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocumentID] [int] IDENTITY(1,1) NOT NULL,
	[InventoryName] [char](10) NOT NULL,
	[DurationOfUse] [int] NOT NULL,
	[DateUsedFrom] [date] NOT NULL,
	[DateUsedTo] [date] NULL,
	[Reason] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventarizations]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarizations](
	[InventarizationID] [int] IDENTITY(1,1) NOT NULL,
	[InventarizationDate] [date] NOT NULL,
	[VerifierID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InventarizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[InventoryID] [int] IDENTITY(1,1) NOT NULL,
	[AuditoriumID] [int] NOT NULL,
	[DocumentID] [int] NOT NULL,
	[CurrentState] [char](10) NOT NULL,
	[Availability] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InventoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lists]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lists](
	[ListID] [int] IDENTITY(1,1) NOT NULL,
	[AuditoriumID] [int] NOT NULL,
	[InventarizationID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repairs]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repairs](
	[RepairID] [int] IDENTITY(1,1) NOT NULL,
	[InventoryID] [int] NOT NULL,
	[DateStart] [date] NOT NULL,
	[DateEnd] [date] NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[RepairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responsibles]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responsibles](
	[ResponsibleID] [int] IDENTITY(1,1) NOT NULL,
	[ResponsibleName] [char](30) NOT NULL,
	[Password] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ResponsibleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verifiers]    Script Date: 07.01.2021 14:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verifiers](
	[VerifierID] [int] IDENTITY(1,1) NOT NULL,
	[VefifierName] [char](30) NOT NULL,
	[Password] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VerifierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Auditories]  WITH CHECK ADD FOREIGN KEY([ResponsibleID])
REFERENCES [dbo].[Responsibles] ([ResponsibleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventarizations]  WITH CHECK ADD FOREIGN KEY([VerifierID])
REFERENCES [dbo].[Verifiers] ([VerifierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventories]  WITH CHECK ADD FOREIGN KEY([AuditoriumID])
REFERENCES [dbo].[Auditories] ([AuditoriumID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inventories]  WITH CHECK ADD FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Documents] ([DocumentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lists]  WITH CHECK ADD FOREIGN KEY([AuditoriumID])
REFERENCES [dbo].[Auditories] ([AuditoriumID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lists]  WITH CHECK ADD FOREIGN KEY([InventarizationID])
REFERENCES [dbo].[Inventarizations] ([InventarizationID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Repairs]  WITH CHECK ADD FOREIGN KEY([InventoryID])
REFERENCES [dbo].[Inventories] ([InventoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [ProjectDataBase] SET  READ_WRITE 
GO
