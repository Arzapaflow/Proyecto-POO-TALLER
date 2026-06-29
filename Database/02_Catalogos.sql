/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 02_Catalogos.sql
==========================================================*/

USE TallerReparaciones;
GO

/*==========================================================
    TABLA: Roles de empleados
==========================================================*/

CREATE TABLE Roles
(
    IdRol INT IDENTITY(1,1) PRIMARY KEY,

    Nombre NVARCHAR(30) NOT NULL UNIQUE
);
GO

/*==========================================================
    TABLA: Especialidades
==========================================================*/

CREATE TABLE Especialidades
(
    IdEspecialidad INT IDENTITY(1,1) PRIMARY KEY,

    Nombre NVARCHAR(60) NOT NULL UNIQUE,

    Descripcion NVARCHAR(200)
);
GO

/*==========================================================
    TABLA: EstadosTicket
==========================================================*/

CREATE TABLE EstadosTicket
(
    IdEstado INT IDENTITY(1,1) PRIMARY KEY,

    Nombre NVARCHAR(40) NOT NULL UNIQUE
);
GO

/*==========================================================
    TABLA: TipoEquipos
==========================================================*/

CREATE TABLE TipoEquipos
(
    IdTipoEquipo INT IDENTITY(1,1) PRIMARY KEY,

    Nombre NVARCHAR(50) NOT NULL UNIQUE
);
GO