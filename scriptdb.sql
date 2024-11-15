USE [master]
GO
/****** Object:  Database [proyecto_taller2]    Script Date: 12/11/2024 21:14:56 ******/
CREATE DATABASE [proyecto_taller2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'proyecto_taller2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyecto_taller2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'proyecto_taller2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyecto_taller2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [proyecto_taller2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [proyecto_taller2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [proyecto_taller2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [proyecto_taller2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [proyecto_taller2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [proyecto_taller2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [proyecto_taller2] SET ARITHABORT OFF 
GO
ALTER DATABASE [proyecto_taller2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [proyecto_taller2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [proyecto_taller2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto_taller2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [proyecto_taller2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [proyecto_taller2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [proyecto_taller2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [proyecto_taller2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [proyecto_taller2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [proyecto_taller2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [proyecto_taller2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [proyecto_taller2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [proyecto_taller2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [proyecto_taller2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [proyecto_taller2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [proyecto_taller2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [proyecto_taller2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [proyecto_taller2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [proyecto_taller2] SET  MULTI_USER 
GO
ALTER DATABASE [proyecto_taller2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [proyecto_taller2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [proyecto_taller2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [proyecto_taller2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [proyecto_taller2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [proyecto_taller2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [proyecto_taller2] SET QUERY_STORE = ON
GO
ALTER DATABASE [proyecto_taller2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [proyecto_taller2]
GO
/****** Object:  UserDefinedTableType [dbo].[EDetalle_Venta]    Script Date: 12/11/2024 21:14:56 ******/
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	[IdProducto] [int] NULL,
	[Precio] [decimal](18, 2) NULL,
	[Cantidad] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Efactura_detalle]    Script Date: 12/11/2024 21:14:56 ******/
CREATE TYPE [dbo].[Efactura_detalle] AS TABLE(
	[IdProducto] [int] NULL,
	[Precio] [decimal](18, 2) NULL,
	[Cantidad] [int] NULL,
	[SubTotal] [decimal](18, 2) NULL
)
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_categoria] [varchar](30) NOT NULL,
	[estado_categoria] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre_cliente] [varchar](20) NULL,
	[apellido_cliente] [varchar](20) NULL,
	[DNI_cliente] [int] NOT NULL,
	[telefono_cliente] [varchar](30) NOT NULL,
	[direccion_cliente] [varchar](50) NULL,
	[email_cliente] [varchar](50) NULL,
	[estado_cliente] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[tipo_documento] [varchar](50) NULL,
	[numero_documento] [varchar](50) NULL,
	[dni_cliente] [varchar](50) NULL,
	[nombre_cliente] [varchar](100) NULL,
	[monto_total] [float] NULL,
	[fecha_registro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura_detalle]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura_detalle](
	[id_venta_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NOT NULL,
	[id_factura] [int] NOT NULL,
	[precioVenta] [float] NULL,
	[cantidad] [int] NULL,
	[subTotal] [float] NULL,
	[fecha_registro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_venta_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_marca] [varchar](30) NOT NULL,
	[estado_marca] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](20) NOT NULL,
	[id_marca] [int] NOT NULL,
	[stock] [int] NOT NULL,
	[precio] [float] NULL,
	[descripcion] [varchar](20) NOT NULL,
	[id_categoria] [int] NOT NULL,
	[estado_producto] [varchar](10) NOT NULL,
	[codigo_producto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_usuario]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_usuario](
	[id_tipo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_tipo_usuario] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](20) NOT NULL,
	[apellido_usuario] [varchar](20) NOT NULL,
	[telefono_usuario] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[contraseña] [varchar](20) NOT NULL,
	[id_tipo_usuario] [int] NOT NULL,
	[estado_usuario] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([id_categoria], [descripcion_categoria], [estado_categoria]) VALUES (1, N'Comestible', N'Activo')
INSERT [dbo].[categoria] ([id_categoria], [descripcion_categoria], [estado_categoria]) VALUES (2, N'Bebida', N'Activo')
INSERT [dbo].[categoria] ([id_categoria], [descripcion_categoria], [estado_categoria]) VALUES (3, N'Medicamento', N'Activo')
INSERT [dbo].[categoria] ([id_categoria], [descripcion_categoria], [estado_categoria]) VALUES (4, N'Belleza e higiene', N'Activo')
INSERT [dbo].[categoria] ([id_categoria], [descripcion_categoria], [estado_categoria]) VALUES (6, N'Electronica', N'Inactivo')
SET IDENTITY_INSERT [dbo].[categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([id_cliente], [nombre_cliente], [apellido_cliente], [DNI_cliente], [telefono_cliente], [direccion_cliente], [email_cliente], [estado_cliente]) VALUES (4, N'Checo', N'Perez', 13133133, N'1111111111', N'asdadad1', N'asd@asd.as', N'Activo')
INSERT [dbo].[clientes] ([id_cliente], [nombre_cliente], [apellido_cliente], [DNI_cliente], [telefono_cliente], [direccion_cliente], [email_cliente], [estado_cliente]) VALUES (7, N'Ramon', N'Garcia', 11111111, N'123123132', N'1231231', N'qweqe@gmail.com', N'Activo')
INSERT [dbo].[clientes] ([id_cliente], [nombre_cliente], [apellido_cliente], [DNI_cliente], [telefono_cliente], [direccion_cliente], [email_cliente], [estado_cliente]) VALUES (8, N'Jose', N'Collar', 21319392, N'3794519016', N'Paul Groussac 2011', N'josecollar@hotmail.com', N'Activo')
INSERT [dbo].[clientes] ([id_cliente], [nombre_cliente], [apellido_cliente], [DNI_cliente], [telefono_cliente], [direccion_cliente], [email_cliente], [estado_cliente]) VALUES (10, N'Tomas', N'Collar', 41612231, N'3794868139', N'Paul Groussac 2010', N'tomascollar@gmail.com', N'Inactivo')
INSERT [dbo].[clientes] ([id_cliente], [nombre_cliente], [apellido_cliente], [DNI_cliente], [telefono_cliente], [direccion_cliente], [email_cliente], [estado_cliente]) VALUES (11, N'Denisse', N'Alvarez', 41508407, N'3795031765', N'Darragueira 1159', N'denissealvarez@hotmail.com', N'Activo')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[factura] ON 

INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (4, 9, N'Boleta', N'0001', N'13133133', N'sadasdd', 4100, CAST(N'2024-11-05T20:12:12.923' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (5, 9, N'Boleta', N'0002', N'21319392', N'Joselo', 10003, CAST(N'2024-11-06T01:42:25.833' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (6, 9, N'Boleta', N'0003', N'21319392', N'Joselo', 4000, CAST(N'2024-11-06T22:00:50.540' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (8, 9, N'Factura', N'F-12345', N'12345678', N'Cliente de Prueba', 100, CAST(N'2024-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (9, 9, N'Factura', N'F-12345', N'12345678', N'Cliente de Prueba', 100, CAST(N'2024-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (10, 8, N'Factura', N'0006', N'21319392', N'Joselo', 10003, CAST(N'2024-11-09T00:17:56.457' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (11, 9, N'Factura', N'0007', N'11111111', N'Ramon', 7000, CAST(N'2024-11-09T04:12:33.350' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (12, 9, N'Boleta', N'0008', N'11111111', N'Ramon', 15800, CAST(N'2024-11-11T03:18:10.900' AS DateTime))
INSERT [dbo].[factura] ([id_factura], [id_usuario], [tipo_documento], [numero_documento], [dni_cliente], [nombre_cliente], [monto_total], [fecha_registro]) VALUES (13, 9, N'Boleta', N'0009', N'13133133', N'Checo', 25600, CAST(N'2024-11-11T04:25:57.017' AS DateTime))
SET IDENTITY_INSERT [dbo].[factura] OFF
GO
SET IDENTITY_INSERT [dbo].[factura_detalle] ON 

INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (1, 3, 4, 100, 1, 100, CAST(N'2024-11-05T20:12:12.923' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (2, 1004, 4, 2000, 2, 4000, CAST(N'2024-11-05T20:12:12.923' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (3, 1004, 5, 2000, 5, 10000, CAST(N'2024-11-06T01:42:25.833' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (4, 1003, 5, 1, 3, 3, CAST(N'2024-11-06T01:42:25.833' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (5, 1004, 6, 2000, 2, 4000, CAST(N'2024-11-06T22:00:50.540' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (7, 1003, 8, 50, 1, 50, CAST(N'2024-11-08T05:06:39.410' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (8, 1004, 8, 25, 2, 50, CAST(N'2024-11-08T05:06:39.410' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (9, 1003, 9, 50, 1, 50, CAST(N'2024-11-08T05:07:06.010' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (10, 1004, 9, 25, 2, 50, CAST(N'2024-11-08T05:07:06.010' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (11, 1004, 10, 2000, 5, 10000, CAST(N'2024-11-09T00:17:56.457' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (12, 1003, 10, 1, 3, 3, CAST(N'2024-11-09T00:17:56.457' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (13, 1009, 11, 4000, 1, 4000, CAST(N'2024-11-09T04:12:33.350' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (14, 1003, 11, 1500, 2, 3000, CAST(N'2024-11-09T04:12:33.350' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (15, 1008, 12, 3900, 2, 7800, CAST(N'2024-11-11T03:18:10.900' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (16, 1006, 12, 3500, 1, 3500, CAST(N'2024-11-11T03:18:10.900' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (17, 1003, 12, 1500, 3, 4500, CAST(N'2024-11-11T03:18:10.900' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (18, 1004, 13, 2000, 5, 10000, CAST(N'2024-11-11T04:25:57.017' AS DateTime))
INSERT [dbo].[factura_detalle] ([id_venta_detalle], [id_producto], [id_factura], [precioVenta], [cantidad], [subTotal], [fecha_registro]) VALUES (19, 1008, 13, 3900, 4, 15600, CAST(N'2024-11-11T04:25:57.017' AS DateTime))
SET IDENTITY_INSERT [dbo].[factura_detalle] OFF
GO
SET IDENTITY_INSERT [dbo].[marca] ON 

INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (1, N'Arcor', N'Activo')
INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (2, N'Milka', N'Activo')
INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (3, N'Coca Cola', N'Activo')
INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (4, N'Pepsi', N'Inactivo')
INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (5, N'Bayer', N'Activo')
INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (6, N'Dove', N'Activo')
INSERT [dbo].[marca] ([id_marca], [descripcion_marca], [estado_marca]) VALUES (1002, N'Rosamonte', N'Activo')
SET IDENTITY_INSERT [dbo].[marca] OFF
GO
SET IDENTITY_INSERT [dbo].[productos] ON 

INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (3, N'Clight naranja', 1, 25, 100, N'Jugo en sobre', 2, N'Inactivo', 3)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1003, N'Pure de Tomate', 1, 26, 1500, N'200 ml', 1, N'Activo', 1003)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1004, N'Chocolate blanco ', 2, 227, 2000, N'290 gr', 1, N'Activo', 1004)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1005, N'Milka oreo', 2, 0, 100, N'500 gr', 1, N'Activo', 1010)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1006, N'Yerba', 1002, 49, 3500, N'1 kg', 1, N'Activo', 1011)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1008, N'Gaseosa', 3, 54, 3900, N'1.5 litros', 2, N'Activo', 1012)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1009, N'Bayaspirina Forte', 5, 14, 4000, N'10 unidades', 3, N'Activo', 1013)
INSERT [dbo].[productos] ([id_producto], [nombre_producto], [id_marca], [stock], [precio], [descripcion], [id_categoria], [estado_producto], [codigo_producto]) VALUES (1010, N'Jabon de tocador', 6, 20, 800, N'100gr', 4, N'Inactivo', 1014)
SET IDENTITY_INSERT [dbo].[productos] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_usuario] ON 

INSERT [dbo].[tipo_usuario] ([id_tipo_usuario], [descripcion_tipo_usuario]) VALUES (1, N'superadmin')
INSERT [dbo].[tipo_usuario] ([id_tipo_usuario], [descripcion_tipo_usuario]) VALUES (2, N'admin')
INSERT [dbo].[tipo_usuario] ([id_tipo_usuario], [descripcion_tipo_usuario]) VALUES (3, N'vendedor')
SET IDENTITY_INSERT [dbo].[tipo_usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (6, N'Tomas', N'Collar', N'3794868139', N'tomascollar', N'1234', 1, N'Activo')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (7, N'Admin', N'Admin', N'111111', N'admin', N'1234', 2, N'Activo')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (8, N'Toni', N'Collar', N'1111', N'toni_vendedor', N'1234', 3, N'Activo')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (9, N'asda', N'asd', N'123', N'vendedor', N'1234', 3, N'Activo')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (10, N'denisse', N'denisse', N'123', N'VendedoraDenisse', N'12345', 3, N'Inactivo')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (11, N'Super', N'Admin', N'333344445555', N'superadmin', N'1234', 1, N'Activo')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [apellido_usuario], [telefono_usuario], [usuario], [contraseña], [id_tipo_usuario], [estado_usuario]) VALUES (12, N'Jose', N'Collar', N'3794519016', N'jose_administrador', N'12345', 2, N'Inactivo')
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
/****** Object:  Index [UQ_codigo_producto]    Script Date: 12/11/2024 21:14:56 ******/
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [UQ_codigo_producto] UNIQUE NONCLUSTERED 
(
	[codigo_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[categoria] ADD  DEFAULT ('Activo') FOR [estado_categoria]
GO
ALTER TABLE [dbo].[factura] ADD  DEFAULT (getdate()) FOR [fecha_registro]
GO
ALTER TABLE [dbo].[factura_detalle] ADD  DEFAULT (getdate()) FOR [fecha_registro]
GO
ALTER TABLE [dbo].[marca] ADD  DEFAULT ('Activo') FOR [estado_marca]
GO
ALTER TABLE [dbo].[productos] ADD  DEFAULT ('Activo') FOR [estado_producto]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT ('Activo') FOR [estado_usuario]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_id_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_id_usuario]
GO
ALTER TABLE [dbo].[factura_detalle]  WITH CHECK ADD  CONSTRAINT [FK_id_producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[productos] ([id_producto])
GO
ALTER TABLE [dbo].[factura_detalle] CHECK CONSTRAINT [FK_id_producto]
GO
ALTER TABLE [dbo].[factura_detalle]  WITH CHECK ADD  CONSTRAINT [FK_id_venta] FOREIGN KEY([id_factura])
REFERENCES [dbo].[factura] ([id_factura])
GO
ALTER TABLE [dbo].[factura_detalle] CHECK CONSTRAINT [FK_id_venta]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_id_categoria] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_id_categoria]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_id_marca] FOREIGN KEY([id_marca])
REFERENCES [dbo].[marca] ([id_marca])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_id_marca]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD CHECK  ((len([DNI_cliente])>=(6) AND len([DNI_cliente])<=(8)))
GO
ALTER TABLE [dbo].[tipo_usuario]  WITH CHECK ADD CHECK  (([descripcion_tipo_usuario]='vendedor' OR [descripcion_tipo_usuario]='superadmin' OR [descripcion_tipo_usuario]='admin'))
GO
/****** Object:  StoredProcedure [dbo].[sp_BajaLogicaCliente]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BajaLogicaCliente]
    @id_cliente INT
AS
BEGIN
    UPDATE clientes
    SET estado_cliente = 'Inactivo'
    WHERE id_cliente = @id_cliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_BajaLogicaUsuario]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BajaLogicaUsuario]
    @id_usuario INT
AS
BEGIN
    UPDATE usuario
    SET estado_usuario = 'Inactivo'
    WHERE id_usuario = @id_usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CategoriasMasVendidas]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CategoriasMasVendidas]
AS
BEGIN
    SELECT TOP 5
        c.descripcion_categoria AS Categoria,
        SUM(dv.cantidad) AS TotalVendidos
    FROM 
        factura_detalle dv
    INNER JOIN
        productos p ON p.id_producto = dv.id_producto
    INNER JOIN
        categoria c ON c.id_categoria = p.id_categoria
    GROUP BY
        c.descripcion_categoria
    ORDER BY
        TotalVendidos DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ClientesMasVentas]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ClientesMasVentas]
AS
BEGIN
    SELECT TOP 5
        c.nombre_cliente AS NombreCliente,
        SUM(f.monto_total) AS TotalGastado
    FROM 
        factura f
    INNER JOIN
        clientes c ON c.dni_cliente = f.dni_cliente -- Relacionamos por dni_cliente
    GROUP BY
        c.nombre_cliente
    ORDER BY
        TotalGastado DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----procedimiento para modificar categoria
create proc [dbo].[sp_EditarCategoria](
@IdCategoria int,
@Descripcion varchar(50),
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (select * from categoria where descripcion_categoria = @Descripcion and id_categoria != @IdCategoria)
		update categoria set
		descripcion_categoria = @Descripcion
		where id_categoria = @IdCategoria
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'

	end

end

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_EliminarCategoria](
@IdCategoria int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (
		select * from categoria c
		inner join productos p on p.id_categoria = c.id_categoria
		where c.id_categoria = @IdCategoria
		)
		begin
			update categoria set estado_categoria = 'Inactivo' where id_categoria = @IdCategoria
		end
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'Esta categoria esta relacionada a un producto y no puede ser eliminada'
	end
end

GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarMarca]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EliminarMarca](
@IdMarca int,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Resultado = 1
	if not exists (
		select * from marca m
		inner join productos p on p.id_marca = m.id_marca
		where m.id_marca = @IdMarca
		)
		begin
			update marca set estado_marca = 'Inactivo' where id_marca = @IdMarca
		end
	else
	begin
		set @Resultado = 0
		set @Mensaje = 'Esta marca esta relacionada a un producto y no puede ser eliminada'
	end
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ProductosMasVendidos]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProductosMasVendidos]
AS
BEGIN
    SELECT TOP 5
        p.nombre_producto AS NombreProducto,
        SUM(dv.cantidad) AS TotalVendidos
    FROM
        factura_detalle dv
    INNER JOIN
        productos p ON p.id_producto = dv.id_producto
    GROUP BY
        p.nombre_producto
    ORDER BY
        TotalVendidos DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarCategoria]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_RegistrarCategoria](
@Descripcion varchar(50),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	if not exists (select * from categoria where descripcion_categoria = @Descripcion)
	begin
		insert into categoria(descripcion_categoria, estado_categoria)
		values (@Descripcion,'Activo')
		set @Resultado =  SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir la descripcion de una categoria'
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RegistrarMarca]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_RegistrarMarca](
@Descripcion varchar(50),
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	if not exists (select * from marca where descripcion_marca = @Descripcion)
	begin
		insert into marca(descripcion_marca, estado_marca)
		values (@Descripcion,'Activo')
		set @Resultado =  SCOPE_IDENTITY()
	end
	else
		set @Mensaje = 'No se puede repetir la descripcion de una marca'
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteVentas]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ReporteVentas](
@fechainicio varchar(10),
@fechafin varchar(10)
)
as
begin
SET DATEFORMAT dmy;
    SELECT 
        convert(char(10), v.fecha_registro, 103) AS [FechaRegistro],
        v.tipo_documento,
        v.numero_documento,
        v.monto_total,
        u.nombre_usuario AS [NombreUsuario],
        v.dni_cliente, 
        v.nombre_cliente
    FROM factura v
    INNER JOIN usuario u ON u.id_usuario = v.id_usuario
    WHERE CONVERT(date, v.fecha_registro) BETWEEN @fechainicio AND @fechafin
    GROUP BY 
        v.fecha_registro, v.tipo_documento, v.numero_documento, v.monto_total, 
        u.nombre_usuario, v.dni_cliente, v.nombre_cliente
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteVentasMensuales]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ReporteVentasMensuales]
AS
BEGIN
    SET DATEFORMAT dmy;
    SELECT 
        DATENAME(month, v.fecha_registro) AS Mes,
        COUNT(*) AS TotalVentas,
        SUM(v.monto_total) AS MontoTotal
    FROM 
        factura v
    GROUP BY 
        DATENAME(month, v.fecha_registro), MONTH(v.fecha_registro)
    ORDER BY 
        MONTH(v.fecha_registro);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteVentasPorVendedor]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ReporteVentasPorVendedor]
    @id_usuario INT
AS
BEGIN
    SELECT
        CONVERT(CHAR(10), v.fecha_registro, 103) AS [FechaRegistro],
        v.tipo_documento,
        v.numero_documento,
        v.monto_total,
        u.nombre_usuario AS [NombreUsuario],
        v.dni_cliente,
        v.nombre_cliente
    FROM factura v
    INNER JOIN usuario u ON u.id_usuario = v.id_usuario
    WHERE v.id_usuario = @id_usuario
    GROUP BY 
        v.fecha_registro,
        v.tipo_documento,
        v.numero_documento,
        v.monto_total,
        u.nombre_usuario,
        v.dni_cliente,
        v.nombre_cliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_RegistrarVenta]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[usp_RegistrarVenta](
@id_usuario int,
@tipo_documento varchar(500),
@numero_documento varchar(500),
@dni_cliente varchar(500),
@nombre_cliente varchar(500),
@monto_total decimal(18,2),
@DetalleVenta [EDetalle_Venta] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	begin try
		
		declare @idventa int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro

		insert into factura(id_usuario,tipo_documento,numero_documento,dni_cliente,nombre_cliente,monto_total)
		values(@id_usuario,@tipo_documento,@numero_documento,@dni_cliente,@nombre_cliente,@monto_total)

		set @idventa = SCOPE_IDENTITY()

		insert into factura_detalle(id_factura,id_producto,precioVenta,cantidad,subTotal)
		select @idventa,IdProducto,Precio,Cantidad,SubTotal from @DetalleVenta

		commit transaction registro

	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch

end
GO
/****** Object:  StoredProcedure [dbo].[usp_RegistrarVentaConFecha]    Script Date: 12/11/2024 21:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RegistrarVentaConFecha]
(
    @id_usuario INT,
    @tipo_documento VARCHAR(500),
    @numero_documento VARCHAR(500),
    @dni_cliente VARCHAR(500),
    @nombre_cliente VARCHAR(500),
    @monto_total DECIMAL(18, 2),
    @fecha_registro DATETIME,  -- Parámetro adicional para la fecha de registro
    @DetalleVenta [EDetalle_Venta] READONLY,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        DECLARE @idventa INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION registro;

        -- Inserta en factura con la fecha especificada
        INSERT INTO factura(id_usuario, tipo_documento, numero_documento, dni_cliente, nombre_cliente, monto_total, fecha_registro)
        VALUES(@id_usuario, @tipo_documento, @numero_documento, @dni_cliente, @nombre_cliente, @monto_total, @fecha_registro);

        SET @idventa = SCOPE_IDENTITY();

        -- Inserta en factura_detalle
        INSERT INTO factura_detalle(id_factura, id_producto, precioVenta, cantidad, subTotal)
        SELECT @idventa, IdProducto, Precio, Cantidad, SubTotal FROM @DetalleVenta;

        COMMIT TRANSACTION registro;

    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        ROLLBACK TRANSACTION registro;
    END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [proyecto_taller2] SET  READ_WRITE 
GO
