USE [master]
GO
/****** Object:  Database [ChatDb]    Script Date: 11/20/2018 3:19:00 AM ******/
CREATE DATABASE [ChatDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChatDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChatDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChatDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ChatDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ChatDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChatDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChatDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChatDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChatDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChatDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChatDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChatDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChatDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChatDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChatDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChatDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChatDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChatDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChatDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChatDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChatDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChatDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChatDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChatDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChatDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChatDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChatDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChatDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChatDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChatDb] SET  MULTI_USER 
GO
ALTER DATABASE [ChatDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChatDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChatDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChatDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChatDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChatDb] SET QUERY_STORE = OFF
GO
USE [ChatDb]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 11/20/2018 3:19:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[DateOfSubmission] [varchar](50) NOT NULL,
	[Sender] [varchar](50) NOT NULL,
	[Receiver] [varchar](50) NOT NULL,
	[MessageData] [varchar](50) NULL,
 CONSTRAINT [PK_Messages1] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/20/2018 3:19:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_users1] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ChatDb] SET  READ_WRITE 
GO
