USE [master]
GO
/****** Object:  Database [FuzzyLP]    Script Date: 21/07/2014 12:12:38 ******/
CREATE DATABASE [FuzzyLP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FLP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FLP.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FLP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FLP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FuzzyLP] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FuzzyLP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FuzzyLP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FuzzyLP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FuzzyLP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FuzzyLP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FuzzyLP] SET ARITHABORT OFF 
GO
ALTER DATABASE [FuzzyLP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FuzzyLP] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FuzzyLP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FuzzyLP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FuzzyLP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FuzzyLP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FuzzyLP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FuzzyLP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FuzzyLP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FuzzyLP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FuzzyLP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FuzzyLP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FuzzyLP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FuzzyLP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FuzzyLP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FuzzyLP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FuzzyLP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FuzzyLP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FuzzyLP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FuzzyLP] SET  MULTI_USER 
GO
ALTER DATABASE [FuzzyLP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FuzzyLP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FuzzyLP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FuzzyLP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FuzzyLP]
GO
/****** Object:  Table [dbo].[Alternativas]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alternativas](
	[idAlternativa] [int] IDENTITY(1,1) NOT NULL,
	[idProyecto] [int] NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[abreviacion] [varchar](4) NOT NULL,
	[color] [varchar](7) NOT NULL,
 CONSTRAINT [PK_Alternativas] PRIMARY KEY CLUSTERED 
(
	[idAlternativa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Criterios]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Criterios](
	[idCriterio] [int] IDENTITY(1,1) NOT NULL,
	[idProyecto] [int] NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[abreviacion] [varchar](4) NOT NULL,
	[peso] [int] NOT NULL,
	[color] [varchar](7) NOT NULL,
 CONSTRAINT [PK_Criterios] PRIMARY KEY CLUSTERED 
(
	[idCriterio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetallesAlternativa]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesAlternativa](
	[idAlternativa] [int] NOT NULL,
	[idCriterio] [int] NOT NULL,
	[idVariable] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proyectos]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyectos](
	[idProyecto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](60) NULL,
	[fecha] [date] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Proyectos] PRIMARY KEY CLUSTERED 
(
	[idProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposUsuario]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposUsuario](
	[idTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposUsuario] PRIMARY KEY CLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
	[email] [varchar](60) NOT NULL,
	[contrasenia] [varchar](100) NOT NULL,
	[esActivo] [bit] NOT NULL,
	[codigo] [varchar](100) NULL,
	[idTipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Variables]    Script Date: 21/07/2014 12:12:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Variables](
	[idVariable] [int] IDENTITY(1,1) NOT NULL,
	[idProyecto] [int] NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[abreviacion] [varchar](4) NOT NULL,
	[color] [varchar](7) NOT NULL,
	[a] [float] NOT NULL,
	[b] [float] NOT NULL,
	[c] [float] NOT NULL,
 CONSTRAINT [PK_Variables] PRIMARY KEY CLUSTERED 
(
	[idVariable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Alternativas] ON 

INSERT [dbo].[Alternativas] ([idAlternativa], [idProyecto], [nombre], [abreviacion], [color]) VALUES (12, 52, N'Facundo Allemand', N'FA', N'#51b749')
INSERT [dbo].[Alternativas] ([idAlternativa], [idProyecto], [nombre], [abreviacion], [color]) VALUES (13, 52, N'Martin Allemand', N'MA', N'#31859b')
INSERT [dbo].[Alternativas] ([idAlternativa], [idProyecto], [nombre], [abreviacion], [color]) VALUES (14, 52, N'Genio', N'Gen', N'#5484ed')
INSERT [dbo].[Alternativas] ([idAlternativa], [idProyecto], [nombre], [abreviacion], [color]) VALUES (15, 52, N'Muy Mala', N'MM', N'#dc2127')
SET IDENTITY_INSERT [dbo].[Alternativas] OFF
SET IDENTITY_INSERT [dbo].[Criterios] ON 

INSERT [dbo].[Criterios] ([idCriterio], [idProyecto], [nombre], [abreviacion], [peso], [color]) VALUES (73, 52, N'Utilidad', N'Ut', 10, N'#1f497d')
INSERT [dbo].[Criterios] ([idCriterio], [idProyecto], [nombre], [abreviacion], [peso], [color]) VALUES (74, 52, N'Facilidad de Uso', N'FU', 3, N'#fbd75b')
INSERT [dbo].[Criterios] ([idCriterio], [idProyecto], [nombre], [abreviacion], [peso], [color]) VALUES (76, 52, N'Ganancia', N'Gan', 3, N'#a4bdfc')
SET IDENTITY_INSERT [dbo].[Criterios] OFF
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (12, 73, 30)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (12, 74, 33)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (12, 76, 33)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (13, 73, 31)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (13, 74, 33)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (13, 76, 32)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (14, 73, 33)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (14, 74, 30)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (15, 73, 34)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (15, 74, 34)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (15, 76, 34)
INSERT [dbo].[DetallesAlternativa] ([idAlternativa], [idCriterio], [idVariable]) VALUES (14, 76, 33)
SET IDENTITY_INSERT [dbo].[Proyectos] ON 

INSERT [dbo].[Proyectos] ([idProyecto], [nombre], [fecha], [idUsuario]) VALUES (52, N'Selección de Mejor Candidato Para Puesto', CAST(0xC8380B00 AS Date), 1)
INSERT [dbo].[Proyectos] ([idProyecto], [nombre], [fecha], [idUsuario]) VALUES (53, N'Facu', CAST(0xC9380B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[Proyectos] OFF
SET IDENTITY_INSERT [dbo].[TiposUsuario] ON 

INSERT [dbo].[TiposUsuario] ([idTipoUsuario], [nombre]) VALUES (1, N'Usuario')
SET IDENTITY_INSERT [dbo].[TiposUsuario] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [nombre], [email], [contrasenia], [esActivo], [codigo], [idTipoUsuario]) VALUES (1, N'Facundo', N'facualle@hotmail.com', N'YgBvAGQAZQBnAGEAcwA=', 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
SET IDENTITY_INSERT [dbo].[Variables] ON 

INSERT [dbo].[Variables] ([idVariable], [idProyecto], [nombre], [abreviacion], [color], [a], [b], [c]) VALUES (30, 52, N'Excelente', N'E', N'#7bd148', 0.8, 0.9, 1)
INSERT [dbo].[Variables] ([idVariable], [idProyecto], [nombre], [abreviacion], [color], [a], [b], [c]) VALUES (31, 52, N'Muy Bueno', N'MB', N'#7ae7bf', 0.6, 0.7, 0.8)
INSERT [dbo].[Variables] ([idVariable], [idProyecto], [nombre], [abreviacion], [color], [a], [b], [c]) VALUES (32, 52, N'Bueno', N'B', N'#fbd75b', 0.45, 0.6, 0.7)
INSERT [dbo].[Variables] ([idVariable], [idProyecto], [nombre], [abreviacion], [color], [a], [b], [c]) VALUES (33, 52, N'Regular', N'R', N'#ffb878', 0.4, 0.5, 0.6)
INSERT [dbo].[Variables] ([idVariable], [idProyecto], [nombre], [abreviacion], [color], [a], [b], [c]) VALUES (34, 52, N'Desaprobado', N'Des', N'#dc2127', 0, 0.3, 0.4)
SET IDENTITY_INSERT [dbo].[Variables] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Criterios]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[Criterios] ADD  CONSTRAINT [IX_Criterios] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Criterios_1]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[Criterios] ADD  CONSTRAINT [IX_Criterios_1] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[abreviacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Valoraciones]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[DetallesAlternativa] ADD  CONSTRAINT [IX_Valoraciones] UNIQUE NONCLUSTERED 
(
	[idAlternativa] ASC,
	[idCriterio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Proyectos]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[Proyectos] ADD  CONSTRAINT [IX_Proyectos] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Usuarios]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Variables]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[Variables] ADD  CONSTRAINT [IX_Variables] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Variables_1]    Script Date: 21/07/2014 12:12:38 ******/
ALTER TABLE [dbo].[Variables] ADD  CONSTRAINT [IX_Variables_1] UNIQUE NONCLUSTERED 
(
	[abreviacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alternativas]  WITH CHECK ADD  CONSTRAINT [FK_Alternativas_Proyectos] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[Proyectos] ([idProyecto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alternativas] CHECK CONSTRAINT [FK_Alternativas_Proyectos]
GO
ALTER TABLE [dbo].[Criterios]  WITH CHECK ADD  CONSTRAINT [FK_Criterios_Proyectos] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[Proyectos] ([idProyecto])
GO
ALTER TABLE [dbo].[Criterios] CHECK CONSTRAINT [FK_Criterios_Proyectos]
GO
ALTER TABLE [dbo].[DetallesAlternativa]  WITH CHECK ADD  CONSTRAINT [FK_DetallesAlternativa_Alternativas] FOREIGN KEY([idAlternativa])
REFERENCES [dbo].[Alternativas] ([idAlternativa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallesAlternativa] CHECK CONSTRAINT [FK_DetallesAlternativa_Alternativas]
GO
ALTER TABLE [dbo].[DetallesAlternativa]  WITH CHECK ADD  CONSTRAINT [FK_DetallesAlternativa_Criterios] FOREIGN KEY([idCriterio])
REFERENCES [dbo].[Criterios] ([idCriterio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallesAlternativa] CHECK CONSTRAINT [FK_DetallesAlternativa_Criterios]
GO
ALTER TABLE [dbo].[DetallesAlternativa]  WITH CHECK ADD  CONSTRAINT [FK_DetallesAlternativa_Variables] FOREIGN KEY([idVariable])
REFERENCES [dbo].[Variables] ([idVariable])
GO
ALTER TABLE [dbo].[DetallesAlternativa] CHECK CONSTRAINT [FK_DetallesAlternativa_Variables]
GO
ALTER TABLE [dbo].[Proyectos]  WITH CHECK ADD  CONSTRAINT [FK_Proyectos_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Proyectos] CHECK CONSTRAINT [FK_Proyectos_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TiposUsuario] FOREIGN KEY([idTipoUsuario])
REFERENCES [dbo].[TiposUsuario] ([idTipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_TiposUsuario]
GO
ALTER TABLE [dbo].[Variables]  WITH CHECK ADD  CONSTRAINT [FK_Variables_Proyectos] FOREIGN KEY([idProyecto])
REFERENCES [dbo].[Proyectos] ([idProyecto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Variables] CHECK CONSTRAINT [FK_Variables_Proyectos]
GO
USE [master]
GO
ALTER DATABASE [FuzzyLP] SET  READ_WRITE 
GO
