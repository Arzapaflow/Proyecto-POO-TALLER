/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 03_Personas.sql
    DESCRIPCIÓN:
    Crea las tablas relacionadas con clientes, empleados,
    técnicos, recepcionistas, administradores y usuarios.
==========================================================*/

USE TallerReparaciones;
GO


/*==========================================================
    TABLA: Clientes

    Representa a las personas que llevan equipos al taller.
    Corresponde a la clase Cliente de C#.
==========================================================*/

CREATE TABLE Clientes
(
    IdCliente INT IDENTITY(1,1) NOT NULL,

    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Clientes
        PRIMARY KEY (IdCliente)
);
GO


/*==========================================================
    TABLA: Empleados

    Guarda la información común de todos los trabajadores.

    Los técnicos, recepcionistas y administradores se
    relacionarán con esta tabla mediante IdEmpleado.
==========================================================*/

CREATE TABLE Empleados
(
    IdEmpleado INT IDENTITY(1,1) NOT NULL,

    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,

    Estado NVARCHAR(20) NOT NULL
        CONSTRAINT DF_Empleados_Estado
        DEFAULT N'Activo',

    FechaIngreso DATETIME2 NOT NULL
        CONSTRAINT DF_Empleados_FechaIngreso
        DEFAULT SYSDATETIME(),

    CONSTRAINT PK_Empleados
        PRIMARY KEY (IdEmpleado),

    CONSTRAINT CK_Empleados_Estado
        CHECK (Estado IN (N'Activo', N'Inactivo'))
);
GO


/*==========================================================
    TABLA: Tecnicos

    Representa la especialización de un empleado técnico.

    El IdEmpleado funciona simultáneamente como:
    - Llave primaria de Tecnicos.
    - Llave foránea hacia Empleados.

    Esto representa en SQL la herencia:
    Tecnico : Empleado
==========================================================*/

CREATE TABLE Tecnicos
(
    IdEmpleado INT NOT NULL,

    IdEspecialidad INT NOT NULL,

    PagoPorHora DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Tecnicos_PagoPorHora
        DEFAULT 0,

    CONSTRAINT PK_Tecnicos
        PRIMARY KEY (IdEmpleado),

    CONSTRAINT FK_Tecnicos_Empleados
        FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado),

    CONSTRAINT FK_Tecnicos_Especialidades
        FOREIGN KEY (IdEspecialidad)
        REFERENCES Especialidades(IdEspecialidad),

    CONSTRAINT CK_Tecnicos_PagoPorHora
        CHECK (PagoPorHora >= 0)
);
GO


/*==========================================================
    TABLA: Recepcionistas

    Representa la herencia:
    Recepcionista : Empleado

    Actualmente no tiene atributos específicos, por eso
    solamente contiene el IdEmpleado.
==========================================================*/

CREATE TABLE Recepcionistas
(
    IdEmpleado INT NOT NULL,

    CONSTRAINT PK_Recepcionistas
        PRIMARY KEY (IdEmpleado),

    CONSTRAINT FK_Recepcionistas_Empleados
        FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado)
);
GO


/*==========================================================
    TABLA: Administradores

    Representa la herencia:
    Administrador : Empleado

    Actualmente no tiene atributos específicos, por eso
    solamente contiene el IdEmpleado.
==========================================================*/

CREATE TABLE Administradores
(
    IdEmpleado INT NOT NULL,

    CONSTRAINT PK_Administradores
        PRIMARY KEY (IdEmpleado),

    CONSTRAINT FK_Administradores_Empleados
        FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado)
);
GO


/*==========================================================
    TABLA: Usuarios

    Guarda los datos utilizados para iniciar sesión.

    Cada usuario pertenece a:
    - Un empleado.
    - Un rol.

    El campo IdEmpleado es UNIQUE para garantizar que un
    empleado solamente tenga una cuenta de acceso.
==========================================================*/

CREATE TABLE Usuarios
(
    IdUsuario INT IDENTITY(1,1) NOT NULL,

    IdEmpleado INT NOT NULL,
    IdRol INT NOT NULL,

    NombreUsuario NVARCHAR(50) NOT NULL,
    Contrasena NVARCHAR(100) NOT NULL,

    Activo BIT NOT NULL
        CONSTRAINT DF_Usuarios_Activo
        DEFAULT 1,

    CONSTRAINT PK_Usuarios
        PRIMARY KEY (IdUsuario),

    CONSTRAINT UQ_Usuarios_NombreUsuario
        UNIQUE (NombreUsuario),

    CONSTRAINT UQ_Usuarios_IdEmpleado
        UNIQUE (IdEmpleado),

    CONSTRAINT FK_Usuarios_Empleados
        FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado),

    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (IdRol)
        REFERENCES Roles(IdRol)
);
GO