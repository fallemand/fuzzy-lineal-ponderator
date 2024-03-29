GO
USE [FuzzyLP3]
GO
/****** Object:  Table [dbo].[Alternativas]    Script Date: 24/07/2014 13:55:25 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Alternativas] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Alternativas_1] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[abreviacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Criterios]    Script Date: 24/07/2014 13:55:25 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Criterios] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Criterios_1] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[abreviacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetallesAlternativa]    Script Date: 24/07/2014 13:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesAlternativa](
	[idAlternativa] [int] NOT NULL,
	[idCriterio] [int] NOT NULL,
	[idVariable] [int] NOT NULL,
 CONSTRAINT [IX_Valoraciones] UNIQUE NONCLUSTERED 
(
	[idAlternativa] ASC,
	[idCriterio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proyectos]    Script Date: 24/07/2014 13:55:25 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Proyectos] UNIQUE NONCLUSTERED 
(
	[nombre] ASC,
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposUsuario]    Script Date: 24/07/2014 13:55:25 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/07/2014 13:55:25 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Variables]    Script Date: 24/07/2014 13:55:25 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Variables_2] UNIQUE NONCLUSTERED 
(
	[idProyecto] ASC,
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Variables_3] UNIQUE NONCLUSTERED 
(
	[abreviacion] ASC,
	[idProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
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
ALTER DATABASE [FuzzyLP3] SET  READ_WRITE 
GO
