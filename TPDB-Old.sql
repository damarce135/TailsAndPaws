/****** Object:  Database [TP_old]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE DATABASE [TP_old]  (EDITION = 'Standard', SERVICE_OBJECTIVE = 'S0', MAXSIZE = 20 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS;
GO
ALTER DATABASE [TP_old] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [TP_old] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP_old] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP_old] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP_old] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP_old] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP_old] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP_old] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP_old] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP_old] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP_old] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP_old] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP_old] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP_old] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP_old] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [TP_old] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP_old] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TP_old] SET  MULTI_USER 
GO
ALTER DATABASE [TP_old] SET ENCRYPTION ON
GO
ALTER DATABASE [TP_old] SET QUERY_STORE = ON
GO
ALTER DATABASE [TP_old] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO

/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[adopcion]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adopcion](
	[idAdopcion] [int] NOT NULL IDENTITY,
	[idAnimal] [int] NULL,
	[idAdoptante] [int] NULL,
	[fechaAdopcion] [datetime] NULL,
	[fechaSeguimiento] [datetime] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAdopcion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[adoptante]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adoptante](
	[idAdoptante] [int] NOT NULL IDENTITY,
	[cedula] [varchar](45) NULL,
	[nombre] [varchar](45) NULL,
	[apellido1] [varchar](45) NULL,
	[apellido2] [varchar](45) NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[idProvincia] [int] NULL,
	[idCanton] [int] NULL,
	[idDistrito] [int] NULL,
	[detalleDireccion] [varchar](300) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAdoptante] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[animal]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[animal](
	[idAnimal] [int] NOT NULL IDENTITY,
	[nombre] [varchar](45) NULL,
	[sexo] [varchar](45) NULL,
	[raza] [varchar](45) NULL,
	[castrado] [varchar](45) NULL,
	[edad] [varchar](45) NULL,
	[fechaIngreso] [datetime] NULL,
	[idGSanguineo] [int] NULL,
	[idOrganizacion] [int] NULL,
	[habilitado] [bit] NULL,
	[especie] [varchar](45) NOT NULL,
	[adoptado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAnimal] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[canton]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[canton](
	[idCanton] [int] NOT NULL IDENTITY,
	[nombreCanton] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCanton] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idCategoria] [int] NOT NULL IDENTITY,
	[nombreCategoria] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cita]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cita](
	[idCita] [int] NOT NULL IDENTITY,
	[nombre] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[fecha] [datetime] NULL,
	[hora] [time](7) NULL,
	[motivo] [varchar](300) NULL,
	[idUsuario] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCita] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[distrito]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[distrito](
	[idDistrito] [int] NOT NULL IDENTITY,
	[nombreDistrito] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idDistrito] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donante]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donante](
	[idDonante] [int] NOT NULL IDENTITY,
	[nombre] [varchar](45) NULL,
	[apellido1] [varchar](45) NULL,
	[apellido2] [varchar](45) NULL,
	[telefono] [varchar](45) NULL,
	[email] [varchar](100) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDonante] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupoSanguineo]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupoSanguineo](
	[idGSanguineo] [int] NOT NULL IDENTITY,
	[nombreGSanguineo] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idGSanguineo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[organizacion]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizacion](
	[idOrganizacion] [int] NOT NULL IDENTITY,
	[tipo] [varchar](45) NULL,
	[nombre] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[email] [varchar](45) NULL,
	[descripcion] [varchar](300) NULL,
	[idProvincia] [int] NULL,
	[idCanton] [int] NULL,
	[idDistrito] [int] NULL,
	[detalleDireccion] [varchar](300) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrganizacion] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orgProveedor]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orgProveedor](
	[idOrgProveedor] [int] NOT NULL IDENTITY,
	[idOrganizacion] [int] NULL,
	[idProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrgProveedor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodCategoria]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodCategoria](
	[idProdCategoria] [int] NOT NULL IDENTITY,
	[idProducto] [int] NULL,
	[idCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProdCategoria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodProveedor]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodProveedor](
	[idProdProveedor] [int] NOT NULL IDENTITY,
	[idProducto] [int] NULL,
	[idProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProdProveedor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[idProducto] [int] NOT NULL IDENTITY,
	[nombre] [varchar](45) NULL,
	[descripcion] [varchar](300) NULL,
	[fechaIngreso] [datetime] NULL,
	[cantidad] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idProveedor] [int] NOT NULL IDENTITY,
	[nombreProveedor] [varchar](45) NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[idProvincia] [int] NULL,
	[idCanton] [int] NULL,
	[idDistrito] [int] NULL,
	[detalleDireccion] [varchar](300) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[idProvincia] [int] NOT NULL IDENTITY,
	[nombreProvincia] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recordatorio]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recordatorio](
	[idRecordatorio] [int] NOT NULL IDENTITY,
	[creado] [datetime] NOT NULL,
	[titulo] [varchar](100) NULL,
	[descripcion] [varchar](300) NULL,
	[urgencia] [varchar](45) NULL,
	[alertaEstado] [int] NULL,
	[idUsuario] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idRecordatorio] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idRol] [int] NOT NULL IDENTITY,
	[nombreRol] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seguimiento]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seguimiento](
	[idSeguimiento] [int] NOT NULL IDENTITY,
	[idAnimal] [int] NULL,
	[idAdoptante] [int] NULL,
	[idUsuario] [int] NULL,
	[estado] [varchar](45) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idSeguimiento] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] NOT NULL IDENTITY,
	[cedula] [varchar](45) NULL,
	[nombre] [varchar](45) NULL,
	[apellido1] [varchar](45) NULL,
	[apellido2] [varchar](45) NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[contrasena] [varbinary](1) NULL,
	[idOrganizacion] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarioRol]    Script Date: 10/15/2020 4:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarioRol](
	[idUsuarioRol] [int] NOT NULL IDENTITY,
	[idRol] [int] NULL,
	[idUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuarioRol] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 10/15/2020 4:17:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[adopcion]  WITH CHECK ADD FOREIGN KEY([idAdoptante])
REFERENCES [dbo].[adoptante] ([idAdoptante])
GO
ALTER TABLE [dbo].[adopcion]  WITH CHECK ADD FOREIGN KEY([idAnimal])
REFERENCES [dbo].[animal] ([idAnimal])
GO
ALTER TABLE [dbo].[adoptante]  WITH CHECK ADD FOREIGN KEY([idCanton])
REFERENCES [dbo].[canton] ([idCanton])
GO
ALTER TABLE [dbo].[adoptante]  WITH CHECK ADD FOREIGN KEY([idDistrito])
REFERENCES [dbo].[distrito] ([idDistrito])
GO
ALTER TABLE [dbo].[adoptante]  WITH CHECK ADD FOREIGN KEY([idProvincia])
REFERENCES [dbo].[provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[animal]  WITH CHECK ADD FOREIGN KEY([idGSanguineo])
REFERENCES [dbo].[grupoSanguineo] ([idGSanguineo])
GO
ALTER TABLE [dbo].[animal]  WITH CHECK ADD FOREIGN KEY([idOrganizacion])
REFERENCES [dbo].[organizacion] ([idOrganizacion])
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[organizacion]  WITH CHECK ADD FOREIGN KEY([idCanton])
REFERENCES [dbo].[canton] ([idCanton])
GO
ALTER TABLE [dbo].[organizacion]  WITH CHECK ADD FOREIGN KEY([idDistrito])
REFERENCES [dbo].[distrito] ([idDistrito])
GO
ALTER TABLE [dbo].[organizacion]  WITH CHECK ADD FOREIGN KEY([idProvincia])
REFERENCES [dbo].[provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[orgProveedor]  WITH CHECK ADD FOREIGN KEY([idOrganizacion])
REFERENCES [dbo].[organizacion] ([idOrganizacion])
GO
ALTER TABLE [dbo].[orgProveedor]  WITH CHECK ADD FOREIGN KEY([idProveedor])
REFERENCES [dbo].[proveedor] ([idProveedor])
GO
ALTER TABLE [dbo].[prodCategoria]  WITH CHECK ADD FOREIGN KEY([idCategoria])
REFERENCES [dbo].[categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[prodCategoria]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[prodProveedor]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[producto] ([idProducto])
GO
ALTER TABLE [dbo].[prodProveedor]  WITH CHECK ADD FOREIGN KEY([idProveedor])
REFERENCES [dbo].[proveedor] ([idProveedor])
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([idCanton])
REFERENCES [dbo].[canton] ([idCanton])
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([idDistrito])
REFERENCES [dbo].[distrito] ([idDistrito])
GO
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([idProvincia])
REFERENCES [dbo].[provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[recordatorio]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[seguimiento]  WITH CHECK ADD FOREIGN KEY([idAdoptante])
REFERENCES [dbo].[adoptante] ([idAdoptante])
GO
ALTER TABLE [dbo].[seguimiento]  WITH CHECK ADD FOREIGN KEY([idAnimal])
REFERENCES [dbo].[animal] ([idAnimal])
GO
ALTER TABLE [dbo].[seguimiento]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[usuarioRol]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[usuarioRol]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO

ALTER DATABASE [TP_old] SET  READ_WRITE 
GO
