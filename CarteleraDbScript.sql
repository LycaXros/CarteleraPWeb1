
CREATE TABLE [dbo].[ActorPeliculas](
	[ActorId] [int] NOT NULL,
	[PeliculaId] [int] NOT NULL,
 CONSTRAINT [PK_ActorPeliculas] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC,
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 11/27/2019 2:51:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellidos] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cines]    Script Date: 11/27/2019 2:51:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cines](
	[CineId] [uniqueidentifier] NOT NULL,
	[Telefono] [nvarchar](255) NULL,
	[Nombre] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cines] PRIMARY KEY CLUSTERED 
(
	[CineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DireccionCines]    Script Date: 11/27/2019 2:51:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DireccionCines](
	[CineId] [uniqueidentifier] NOT NULL,
	[Calle] [nvarchar](250) NOT NULL,
	[Numero] [nvarchar](250) NOT NULL,
	[Ciudad] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_DireccionCines] PRIMARY KEY CLUSTERED 
(
	[CineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generoes]    Script Date: 11/27/2019 2:51:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generoes](
	[GeneroId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Generoes] PRIMARY KEY CLUSTERED 
(
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasas]    Script Date: 11/27/2019 2:51:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasas](
	[CineId] [uniqueidentifier] NOT NULL,
	[PeliculaId] [int] NOT NULL,
	[TandaId] [int] NOT NULL,
 CONSTRAINT [PK_Pasas] PRIMARY KEY CLUSTERED 
(
	[CineId] ASC,
	[PeliculaId] ASC,
	[TandaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 11/27/2019 2:52:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[PeliculaId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
	[Director] [nvarchar](max) NOT NULL,
	[GeneroId] [int] NOT NULL,
	[Clasificacion] [int] NOT NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tandas]    Script Date: 11/27/2019 2:55:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tandas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hora] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tandas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarifas]    Script Date: 11/27/2019 2:56:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarifas](
	[TarifaId] [int] IDENTITY(1,1) NOT NULL,
	[CineId] [uniqueidentifier] NOT NULL,
	[Dia] [int] NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Tarifas] PRIMARY KEY CLUSTERED 
(
	[TarifaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ActorPeliculas] ([ActorId], [PeliculaId]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 
GO
INSERT [dbo].[Actors] ([Id], [Nombre], [Apellidos]) VALUES (1, N'Bruce', N'Willis')
GO
INSERT [dbo].[Actors] ([Id], [Nombre], [Apellidos]) VALUES (2, N'Arnold', N'Schwarzenegger')
GO
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
INSERT [dbo].[Cines] ([CineId], [Telefono], [Nombre]) VALUES (N'1d45a390-4455-4f45-a67a-72512809fb69', N'8092101111', N'Palacio Del Cine')
GO
INSERT [dbo].[Cines] ([CineId], [Telefono], [Nombre]) VALUES (N'9b232525-59e7-4d03-83d9-884639f4a911', N'800900000', N'Caribbean Cinemas')
GO
INSERT [dbo].[DireccionCines] ([CineId], [Calle], [Numero], [Ciudad]) VALUES (N'1d45a390-4455-4f45-a67a-72512809fb69', N'Alfa', N'12', N'Betra')
GO
SET IDENTITY_INSERT [dbo].[Generoes] ON 
GO
INSERT [dbo].[Generoes] ([GeneroId], [Nombre]) VALUES (1, N'Accion')
GO
SET IDENTITY_INSERT [dbo].[Generoes] OFF
GO
INSERT [dbo].[Pasas] ([CineId], [PeliculaId], [TandaId]) VALUES (N'1d45a390-4455-4f45-a67a-72512809fb69', 1, 1)
GO
INSERT [dbo].[Pasas] ([CineId], [PeliculaId], [TandaId]) VALUES (N'1d45a390-4455-4f45-a67a-72512809fb69', 1, 2)
GO
INSERT [dbo].[Pasas] ([CineId], [PeliculaId], [TandaId]) VALUES (N'9b232525-59e7-4d03-83d9-884639f4a911', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Peliculas] ON 
GO
INSERT [dbo].[Peliculas] ([PeliculaId], [Titulo], [Director], [GeneroId], [Clasificacion]) VALUES (1, N'Duro de Matar', N'JJJ', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
GO
SET IDENTITY_INSERT [dbo].[Tandas] ON 
GO
INSERT [dbo].[Tandas] ([Id], [Hora]) VALUES (1, N'3:30 PM')
GO
INSERT [dbo].[Tandas] ([Id], [Hora]) VALUES (2, N'6:00 PM')
GO
SET IDENTITY_INSERT [dbo].[Tandas] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarifas] ON 
GO
INSERT [dbo].[Tarifas] ([TarifaId], [CineId], [Dia], [Precio]) VALUES (1, N'1d45a390-4455-4f45-a67a-72512809fb69', 0, CAST(250 AS Decimal(18, 0)))
GO
INSERT [dbo].[Tarifas] ([TarifaId], [CineId], [Dia], [Precio]) VALUES (2, N'1d45a390-4455-4f45-a67a-72512809fb69', 1, CAST(150 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Tarifas] OFF
GO
/****** Object:  Index [IX_FK_PeliculaActorPelicula]    Script Date: 11/27/2019 2:57:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_PeliculaActorPelicula] ON [dbo].[ActorPeliculas]
(
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_PasaPelicula]    Script Date: 11/27/2019 2:57:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_PasaPelicula] ON [dbo].[Pasas]
(
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_GeneroPelicula]    Script Date: 11/27/2019 2:57:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_GeneroPelicula] ON [dbo].[Peliculas]
(
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CineTarifa]    Script Date: 11/27/2019 2:57:48 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_CineTarifa] ON [dbo].[Tarifas]
(
	[CineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cines] ADD  CONSTRAINT [DF__Cines__CineId__5BE2A6F2]  DEFAULT (newid()) FOR [CineId]
GO
ALTER TABLE [dbo].[ActorPeliculas]  WITH CHECK ADD  CONSTRAINT [FK_ActorEntity2] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActorPeliculas] CHECK CONSTRAINT [FK_ActorEntity2]
GO
ALTER TABLE [dbo].[ActorPeliculas]  WITH CHECK ADD  CONSTRAINT [FK_PeliculaActorPelicula] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([PeliculaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActorPeliculas] CHECK CONSTRAINT [FK_PeliculaActorPelicula]
GO
ALTER TABLE [dbo].[DireccionCines]  WITH CHECK ADD  CONSTRAINT [FK_CineDireccionCine] FOREIGN KEY([CineId])
REFERENCES [dbo].[Cines] ([CineId])
GO
ALTER TABLE [dbo].[DireccionCines] CHECK CONSTRAINT [FK_CineDireccionCine]
GO
ALTER TABLE [dbo].[Pasas]  WITH CHECK ADD  CONSTRAINT [FK_PasaPelicula] FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Peliculas] ([PeliculaId])
GO
ALTER TABLE [dbo].[Pasas] CHECK CONSTRAINT [FK_PasaPelicula]
GO
ALTER TABLE [dbo].[Pasas]  WITH CHECK ADD  CONSTRAINT [FK_Pasas_Cines] FOREIGN KEY([CineId])
REFERENCES [dbo].[Cines] ([CineId])
GO
ALTER TABLE [dbo].[Pasas] CHECK CONSTRAINT [FK_Pasas_Cines]
GO
ALTER TABLE [dbo].[Pasas]  WITH CHECK ADD  CONSTRAINT [FK_Pasas_Tandas] FOREIGN KEY([TandaId])
REFERENCES [dbo].[Tandas] ([Id])
GO
ALTER TABLE [dbo].[Pasas] CHECK CONSTRAINT [FK_Pasas_Tandas]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_GeneroPelicula] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Generoes] ([GeneroId])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_GeneroPelicula]
GO
ALTER TABLE [dbo].[Tarifas]  WITH CHECK ADD  CONSTRAINT [FK_CineTarifa] FOREIGN KEY([CineId])
REFERENCES [dbo].[Cines] ([CineId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tarifas] CHECK CONSTRAINT [FK_CineTarifa]
GO
USE [master]
GO
ALTER DATABASE [CARTELERADB] SET  READ_WRITE 
GO
create view [dbo].[ConsultaCartelera]
as
  SELECT
  c.Nombre 'Cinema', p.Titulo 'Pelicula' , t.hora 'Hora Tanda' , gn.Nombre 'Genero',
  CONCAT(dir.Calle,' #', dir.Numero, ', ' , dir.Ciudad) as 'Direccion', c.Telefono,
  c.CineId, p.PeliculaId, t.Id 'TandaId', gn.GeneroId

  FROM Pasas as car
  inner join Cines as c on c.CineId = car.CineId
  left join DireccionCines as dir on dir.CineId = c.CineId
  inner join Peliculas as p on p.PeliculaId = car.PeliculaId
  inner join Tandas as t on t.Id = car.TandaId
  inner join Generoes as gn on gn.GeneroId = p.GeneroId
  