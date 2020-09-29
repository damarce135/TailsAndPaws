USE [master]
GO
/****** Object:  Database [TP]    Script Date: 29/9/2020 14:57:32 ******/
CREATE DATABASE [TP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP] SET RECOVERY FULL 
GO
ALTER DATABASE [TP] SET  MULTI_USER 
GO
ALTER DATABASE [TP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP', N'ON'
GO
ALTER DATABASE [TP] SET QUERY_STORE = OFF
GO
USE [TP]
GO
/****** Object:  Table [dbo].[adopcion]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adopcion](
	[idAdopcion] [int] NOT NULL,
	[idAnimal] [int] NULL,
	[idAdoptante] [int] NULL,
	[fechaAdopcion] [datetime] NULL,
	[fechaSeguimiento] [datetime] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAdopcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[adoptante]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adoptante](
	[idAdoptante] [int] NOT NULL,
	[cedula] [varchar](45) NULL,
	[nombre] [varchar](45) NULL,
	[apellido1] [varchar](45) NULL,
	[apellido2] [varchar](45) NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[idDireccion] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAdoptante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[animal]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[animal](
	[idAnimal] [int] NOT NULL,
	[nombre] [varchar](45) NULL,
	[sexo] [varchar](45) NULL,
	[raza] [varchar](45) NULL,
	[castrado] [varchar](45) NULL,
	[edad] [varchar](45) NULL,
	[fechaIngreso] [datetime] NULL,
	[idGSanguineo] [int] NULL,
	[idOrganizacion] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[canton]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[canton](
	[idCanton] [int] NOT NULL,
	[nombreCanton] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCanton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idCategoria] [int] NOT NULL,
	[nombreCategoria] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cita]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cita](
	[idCita] [int] NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[direccion]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[direccion](
	[idDireccion] [int] NOT NULL,
	[idProvincia] [int] NULL,
	[idCanton] [int] NULL,
	[idDistrito] [int] NULL,
	[detalle] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[idDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[distrito]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[distrito](
	[idDistrito] [int] NOT NULL,
	[nombreDistrito] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donante]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donante](
	[idDonante] [int] NOT NULL,
	[nombre] [varchar](45) NULL,
	[apellido1] [varchar](45) NULL,
	[apellido2] [varchar](45) NULL,
	[telefono] [varchar](45) NULL,
	[email] [varchar](100) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDonante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupoSanguineo]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupoSanguineo](
	[idGSanguineo] [int] NOT NULL,
	[nombreGSanguineo] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idGSanguineo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[organizacion]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[organizacion](
	[idOrganizacion] [int] NOT NULL,
	[tipo] [varchar](45) NULL,
	[nombre] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[email] [varchar](45) NULL,
	[idDireccion] [int] NULL,
	[descripcion] [varchar](300) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrganizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orgProveedor]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orgProveedor](
	[idOrgProveedor] [int] NOT NULL,
	[idOrganizacion] [int] NULL,
	[idProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrgProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodCategoria]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodCategoria](
	[idProdCategoria] [int] NOT NULL,
	[idProducto] [int] NULL,
	[idCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prodProveedor]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prodProveedor](
	[idProdProveedor] [int] NOT NULL,
	[idProducto] [int] NULL,
	[idProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[idProducto] [int] NOT NULL,
	[nombre] [varchar](45) NULL,
	[descripcion] [varchar](300) NULL,
	[fechaIngreso] [datetime] NULL,
	[cantidad] [int] NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idProveedor] [int] NOT NULL,
	[nombreProveedor] [varchar](45) NULL,
	[idDireccion] [int] NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](45) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[idProvincia] [int] NOT NULL,
	[nombreProvincia] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recordatorio]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recordatorio](
	[idRecordatorio] [int] NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idRol] [int] NOT NULL,
	[nombreRol] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seguimiento]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seguimiento](
	[idSeguimiento] [int] NOT NULL,
	[idAnimal] [int] NULL,
	[idAdoptante] [int] NULL,
	[idUsuario] [int] NULL,
	[estado] [varchar](45) NULL,
	[habilitado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idSeguimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idUsuario] [int] NOT NULL,
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarioRol]    Script Date: 29/9/2020 14:57:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarioRol](
	[idUsuarioRol] [int] NOT NULL,
	[idRol] [int] NULL,
	[idUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuarioRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[adopcion]  WITH CHECK ADD FOREIGN KEY([idAdoptante])
REFERENCES [dbo].[adoptante] ([idAdoptante])
GO
ALTER TABLE [dbo].[adopcion]  WITH CHECK ADD FOREIGN KEY([idAnimal])
REFERENCES [dbo].[animal] ([idAnimal])
GO
ALTER TABLE [dbo].[adoptante]  WITH CHECK ADD FOREIGN KEY([idDireccion])
REFERENCES [dbo].[direccion] ([idDireccion])
GO
ALTER TABLE [dbo].[animal]  WITH CHECK ADD FOREIGN KEY([idGSanguineo])
REFERENCES [dbo].[grupoSanguineo] ([idGSanguineo])
GO
ALTER TABLE [dbo].[animal]  WITH CHECK ADD FOREIGN KEY([idOrganizacion])
REFERENCES [dbo].[organizacion] ([idOrganizacion])
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[direccion]  WITH CHECK ADD FOREIGN KEY([idCanton])
REFERENCES [dbo].[canton] ([idCanton])
GO
ALTER TABLE [dbo].[direccion]  WITH CHECK ADD FOREIGN KEY([idDistrito])
REFERENCES [dbo].[distrito] ([idDistrito])
GO
ALTER TABLE [dbo].[direccion]  WITH CHECK ADD FOREIGN KEY([idProvincia])
REFERENCES [dbo].[provincia] ([idProvincia])
GO
ALTER TABLE [dbo].[organizacion]  WITH CHECK ADD FOREIGN KEY([idDireccion])
REFERENCES [dbo].[direccion] ([idDireccion])
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
ALTER TABLE [dbo].[proveedor]  WITH CHECK ADD FOREIGN KEY([idDireccion])
REFERENCES [dbo].[direccion] ([idDireccion])
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
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([idOrganizacion])
REFERENCES [dbo].[organizacion] ([idOrganizacion])
GO
ALTER TABLE [dbo].[usuarioRol]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[rol] ([idRol])
GO
ALTER TABLE [dbo].[usuarioRol]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuario] ([idUsuario])
GO
USE [master]
GO
ALTER DATABASE [TP] SET  READ_WRITE 
GO
