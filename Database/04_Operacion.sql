/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 04_Operacion.sql
==========================================================*/

USE TallerReparaciones;
GO


/*==========================================================
    TABLA: Problemas

    Catálogo de problemas comunes reportados por los
    clientes o identificados durante la recepción.
==========================================================*/

CREATE TABLE dbo.Problemas
(
    IdProblema INT IDENTITY(1,1) NOT NULL,

    Nombre NVARCHAR(100) NOT NULL,

    Descripcion NVARCHAR(300) NULL,

    PosiblesCausas NVARCHAR(500) NULL,

    CostoEstimado DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Problemas_CostoEstimado
        DEFAULT 0,

    Activo BIT NOT NULL
        CONSTRAINT DF_Problemas_Activo
        DEFAULT 1,

    CONSTRAINT PK_Problemas
        PRIMARY KEY (IdProblema),

    CONSTRAINT UQ_Problemas_Nombre
        UNIQUE (Nombre),

    CONSTRAINT CK_Problemas_CostoEstimado
        CHECK (CostoEstimado >= 0)
);
GO


/*==========================================================
    TABLA: Equipos

    Cada equipo pertenece a:
    - Un cliente.
    - Un tipo de equipo.
==========================================================*/

CREATE TABLE dbo.Equipos
(
    IdEquipo INT IDENTITY(1,1) NOT NULL,

    IdCliente INT NOT NULL,

    IdTipoEquipo INT NOT NULL,

    Marca NVARCHAR(60) NOT NULL,

    Modelo NVARCHAR(80) NOT NULL,

    NumeroSerie NVARCHAR(100) NULL,

    Color NVARCHAR(40) NULL,

    Accesorios NVARCHAR(250) NULL,

    Observaciones NVARCHAR(500) NULL,

    CONSTRAINT PK_Equipos
        PRIMARY KEY (IdEquipo),

    CONSTRAINT FK_Equipos_Clientes
        FOREIGN KEY (IdCliente)
        REFERENCES dbo.Clientes(IdCliente),

    CONSTRAINT FK_Equipos_TipoEquipos
        FOREIGN KEY (IdTipoEquipo)
        REFERENCES dbo.TipoEquipos(IdTipoEquipo)
);
GO


/*==========================================================
    TABLA: Materiales

    Representa las piezas, componentes y consumibles
    disponibles en el inventario del taller.
==========================================================*/

CREATE TABLE dbo.Materiales
(
    IdMaterial INT IDENTITY(1,1) NOT NULL,

    Codigo NVARCHAR(30) NOT NULL,

    Nombre NVARCHAR(100) NOT NULL,

    Descripcion NVARCHAR(300) NULL,

    Stock DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Materiales_Stock
        DEFAULT 0,

    StockMinimo DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Materiales_StockMinimo
        DEFAULT 0,

    CostoUnitario DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Materiales_CostoUnitario
        DEFAULT 0,

    Activo BIT NOT NULL
        CONSTRAINT DF_Materiales_Activo
        DEFAULT 1,

    CONSTRAINT PK_Materiales
        PRIMARY KEY (IdMaterial),

    CONSTRAINT UQ_Materiales_Codigo
        UNIQUE (Codigo),

    CONSTRAINT CK_Materiales_Stock
        CHECK (Stock >= 0),

    CONSTRAINT CK_Materiales_StockMinimo
        CHECK (StockMinimo >= 0),

    CONSTRAINT CK_Materiales_CostoUnitario
        CHECK (CostoUnitario >= 0)
);
GO


/*==========================================================
    TABLA: Tickets

    Cada ticket se relaciona con:
    - Un equipo.
    - Un problema.
    - Un estado.
    - Un recepcionista.
    - Opcionalmente, un técnico.
==========================================================*/

CREATE TABLE dbo.Tickets
(
    IdTicket INT IDENTITY(1,1) NOT NULL,

    IdEquipo INT NOT NULL,

    IdProblema INT NOT NULL,

    IdEstado INT NOT NULL,

    IdRecepcionista INT NOT NULL,

    IdTecnico INT NULL,

    DescripcionFalla NVARCHAR(500) NOT NULL,

    Diagnostico NVARCHAR(1000) NULL,

    SolucionAplicada NVARCHAR(1000) NULL,

    Prioridad NVARCHAR(15) NOT NULL
        CONSTRAINT DF_Tickets_Prioridad
        DEFAULT N'Normal',

    FechaIngreso DATETIME2 NOT NULL
        CONSTRAINT DF_Tickets_FechaIngreso
        DEFAULT SYSDATETIME(),

    FechaAsignacionTecnico DATETIME2 NULL,

    FechaEntrega DATETIME2 NULL,

    CostoEstimado DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Tickets_CostoEstimado
        DEFAULT 0,

    CostoFinal DECIMAL(10,2) NULL,

    GarantiaDias INT NOT NULL
        CONSTRAINT DF_Tickets_GarantiaDias
        DEFAULT 0,

    Observaciones NVARCHAR(1000) NULL,

    CONSTRAINT PK_Tickets
        PRIMARY KEY (IdTicket),

    CONSTRAINT FK_Tickets_Equipos
        FOREIGN KEY (IdEquipo)
        REFERENCES dbo.Equipos(IdEquipo),

    CONSTRAINT FK_Tickets_Problemas
        FOREIGN KEY (IdProblema)
        REFERENCES dbo.Problemas(IdProblema),

    CONSTRAINT FK_Tickets_EstadosTicket
        FOREIGN KEY (IdEstado)
        REFERENCES dbo.EstadosTicket(IdEstado),

    CONSTRAINT FK_Tickets_Recepcionistas
        FOREIGN KEY (IdRecepcionista)
        REFERENCES dbo.Recepcionistas(IdEmpleado),

    CONSTRAINT FK_Tickets_Tecnicos
        FOREIGN KEY (IdTecnico)
        REFERENCES dbo.Tecnicos(IdEmpleado),

    CONSTRAINT CK_Tickets_Prioridad
        CHECK
        (
            Prioridad IN
            (
                N'Baja',
                N'Normal',
                N'Alta',
                N'Urgente'
            )
        ),

    CONSTRAINT CK_Tickets_CostoEstimado
        CHECK (CostoEstimado >= 0),

    CONSTRAINT CK_Tickets_CostoFinal
        CHECK (CostoFinal IS NULL OR CostoFinal >= 0),

    CONSTRAINT CK_Tickets_GarantiaDias
        CHECK (GarantiaDias >= 0),

    CONSTRAINT CK_Tickets_FechaAsignacion
        CHECK
        (
            FechaAsignacionTecnico IS NULL
            OR FechaAsignacionTecnico >= FechaIngreso
        ),

    CONSTRAINT CK_Tickets_FechaEntrega
        CHECK
        (
            FechaEntrega IS NULL
            OR FechaEntrega >= FechaIngreso
        )
);
GO


/*==========================================================
    TABLA: MovimientosInventario

    En una salida por reparación se puede identificar:
    - El material utilizado.
    - El ticket correspondiente.
    - El técnico que utilizó el material.
==========================================================*/

CREATE TABLE dbo.MovimientosInventario
(
    IdMovimiento INT IDENTITY(1,1) NOT NULL,

    IdMaterial INT NOT NULL,

    IdTicket INT NULL,

    IdTecnico INT NULL,

    TipoMovimiento NVARCHAR(15) NOT NULL,

    Cantidad DECIMAL(10,2) NOT NULL,

    CostoUnitario DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_MovimientosInventario_CostoUnitario
        DEFAULT 0,

    FechaMovimiento DATETIME2 NOT NULL
        CONSTRAINT DF_MovimientosInventario_Fecha
        DEFAULT SYSDATETIME(),

    Observaciones NVARCHAR(500) NULL,

    CONSTRAINT PK_MovimientosInventario
        PRIMARY KEY (IdMovimiento),

    CONSTRAINT FK_MovimientosInventario_Materiales
        FOREIGN KEY (IdMaterial)
        REFERENCES dbo.Materiales(IdMaterial),

    CONSTRAINT FK_MovimientosInventario_Tickets
        FOREIGN KEY (IdTicket)
        REFERENCES dbo.Tickets(IdTicket),

    CONSTRAINT FK_MovimientosInventario_Tecnicos
        FOREIGN KEY (IdTecnico)
        REFERENCES dbo.Tecnicos(IdEmpleado),

    CONSTRAINT CK_MovimientosInventario_Tipo
        CHECK
        (
            TipoMovimiento IN
            (
                N'Entrada',
                N'Salida',
                N'Ajuste'
            )
        ),

    CONSTRAINT CK_MovimientosInventario_Cantidad
        CHECK (Cantidad > 0),

    CONSTRAINT CK_MovimientosInventario_Costo
        CHECK (CostoUnitario >= 0),

    CONSTRAINT CK_MovimientosInventario_Salida
        CHECK
        (
            TipoMovimiento <> N'Salida'
            OR
            (
                IdTicket IS NOT NULL
                AND IdTecnico IS NOT NULL
            )
        )
);
GO


/*==========================================================
    ÍNDICES

    Facilitan las búsquedas por cliente, técnico, estado,
    ticket y material.
==========================================================*/

CREATE INDEX IX_Equipos_IdCliente
    ON dbo.Equipos(IdCliente);
GO

CREATE INDEX IX_Tickets_IdEquipo
    ON dbo.Tickets(IdEquipo);
GO

CREATE INDEX IX_Tickets_IdTecnico
    ON dbo.Tickets(IdTecnico);
GO

CREATE INDEX IX_Tickets_IdEstado
    ON dbo.Tickets(IdEstado);
GO

CREATE INDEX IX_MovimientosInventario_IdMaterial
    ON dbo.MovimientosInventario(IdMaterial);
GO

CREATE INDEX IX_MovimientosInventario_IdTicket
    ON dbo.MovimientosInventario(IdTicket);
GO