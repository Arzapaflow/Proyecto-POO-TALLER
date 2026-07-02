

 /*BASE DE DATOS: SQLite*/



PRAGMA foreign_keys = ON;

CREATE TABLE Materiales
(
    IdMaterial INTEGER PRIMARY KEY AUTOINCREMENT,

    Codigo TEXT NOT NULL UNIQUE,

    Nombre TEXT NOT NULL,

    Descripcion TEXT,

    Stock NUMERIC NOT NULL DEFAULT 0,

    StockMinimo NUMERIC NOT NULL DEFAULT 0,

    CostoUnitario NUMERIC NOT NULL DEFAULT 0,

    Activo INTEGER NOT NULL DEFAULT 1,

    CHECK (Stock >= 0),

    CHECK (StockMinimo >= 0),

    CHECK (CostoUnitario >= 0)
);

/*02_Catalogos*/



/*TABLA: Roles*/

CREATE TABLE Roles
(
    IdRol INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL UNIQUE
);


/*TABLA: Especialidades*/

CREATE TABLE Especialidades
(
    IdEspecialidad INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL UNIQUE,

    Descripcion TEXT
);


/*TABLA: EstadosTicket*/

CREATE TABLE EstadosTicket
(
    IdEstado INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL UNIQUE
);


/*TABLA: TipoEquipos*/

CREATE TABLE TipoEquipos
(
    IdTipoEquipo INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL UNIQUE
);

/*03 PERSONAS*/

/*TABLA: Clientes*/

CREATE TABLE Clientes
(
    IdCliente INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL,

    Telefono TEXT NOT NULL,

    Correo TEXT NOT NULL
);


/*TABLA: Empleados*/

CREATE TABLE Empleados
(
    IdEmpleado INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL,

    Telefono TEXT NOT NULL,

    Correo TEXT NOT NULL,

    Estado TEXT NOT NULL DEFAULT 'Activo',

    FechaIngreso TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CHECK (Estado IN ('Activo', 'Inactivo'))
);


/*TABLA: Tecnicos*/

CREATE TABLE Tecnicos
(
    IdEmpleado INTEGER NOT NULL,

    IdEspecialidad INTEGER NOT NULL,

    PagoPorHora NUMERIC NOT NULL DEFAULT 0,

    PRIMARY KEY (IdEmpleado),

    FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado),

    FOREIGN KEY (IdEspecialidad)
        REFERENCES Especialidades(IdEspecialidad),

    CHECK (PagoPorHora >= 0)
);


/*TABLA: Recepcionistas*/

CREATE TABLE Recepcionistas
(
    IdEmpleado INTEGER PRIMARY KEY,

    FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado)
);


/*TABLA: Administradores*/

CREATE TABLE Administradores
(
    IdEmpleado INTEGER PRIMARY KEY,

    FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado)
);


/*TABLA: Usuarios*/

CREATE TABLE Usuarios
(
    IdUsuario INTEGER PRIMARY KEY AUTOINCREMENT,

    IdEmpleado INTEGER NOT NULL UNIQUE,

    IdRol INTEGER NOT NULL,

    NombreUsuario TEXT NOT NULL UNIQUE,

    Contrasena TEXT NOT NULL,

    Activo INTEGER NOT NULL DEFAULT 1,

    FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado),

    FOREIGN KEY (IdRol)
        REFERENCES Roles(IdRol)
);

/*04 OPERACION*/

/*TABLA: Problemas*/

CREATE TABLE Problemas
(
    IdProblema INTEGER PRIMARY KEY AUTOINCREMENT,

    Nombre TEXT NOT NULL UNIQUE,

    Descripcion TEXT,

    PosiblesCausas TEXT,

    CostoEstimado NUMERIC NOT NULL DEFAULT 0,

    Activo INTEGER NOT NULL DEFAULT 1,

    CHECK (CostoEstimado >= 0)
);

/*TABLA: Equipos*/

CREATE TABLE Equipos
(
    IdEquipo INTEGER PRIMARY KEY AUTOINCREMENT,

    IdCliente INTEGER NOT NULL,

    IdTipoEquipo INTEGER NOT NULL,

    Marca TEXT NOT NULL,

    Modelo TEXT NOT NULL,

    NumeroSerie TEXT,

    Color TEXT,

    Accesorios TEXT,

    Observaciones TEXT,

    FOREIGN KEY (IdCliente)
        REFERENCES Clientes(IdCliente),

    FOREIGN KEY (IdTipoEquipo)
        REFERENCES TipoEquipos(IdTipoEquipo)
);

/*TABLA: Tickets*/

CREATE TABLE Tickets
(
    IdTicket INTEGER PRIMARY KEY AUTOINCREMENT,

    IdEquipo INTEGER NOT NULL,

    IdProblema INTEGER NOT NULL,

    IdEstado INTEGER NOT NULL,

    IdRecepcionista INTEGER NOT NULL,

    IdTecnico INTEGER,

    DescripcionFalla TEXT NOT NULL,

    Diagnostico TEXT,

    SolucionAplicada TEXT,

    Prioridad TEXT NOT NULL DEFAULT 'Normal',

    FechaIngreso TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,

    FechaAsignacionTecnico TEXT,

    FechaEntrega TEXT,

    CostoEstimado NUMERIC NOT NULL DEFAULT 0,

    CostoFinal NUMERIC,

    GarantiaDias INTEGER NOT NULL DEFAULT 0,

    Observaciones TEXT,

    FOREIGN KEY (IdEquipo)
        REFERENCES Equipos(IdEquipo),

    FOREIGN KEY (IdProblema)
        REFERENCES Problemas(IdProblema),

    FOREIGN KEY (IdEstado)
        REFERENCES EstadosTicket(IdEstado),

    FOREIGN KEY (IdRecepcionista)
        REFERENCES Recepcionistas(IdEmpleado),

    FOREIGN KEY (IdTecnico)
        REFERENCES Tecnicos(IdEmpleado),

    CHECK (Prioridad IN ('Baja','Normal','Alta','Urgente')),

    CHECK (CostoEstimado >= 0),

    CHECK (CostoFinal IS NULL OR CostoFinal >= 0),

    CHECK (GarantiaDias >= 0),

    CHECK
    (
        FechaAsignacionTecnico IS NULL
        OR FechaAsignacionTecnico >= FechaIngreso
    ),

    CHECK
    (
        FechaEntrega IS NULL
        OR FechaEntrega >= FechaIngreso
    )
);



/*TABLA: MovimientosInventario*/

CREATE TABLE MovimientosInventario
(
    IdMovimiento INTEGER PRIMARY KEY AUTOINCREMENT,

    IdMaterial INTEGER NOT NULL,

    IdTicket INTEGER,

    IdTecnico INTEGER,

    TipoMovimiento TEXT NOT NULL,

    Cantidad NUMERIC NOT NULL,

    CostoUnitario NUMERIC NOT NULL DEFAULT 0,

    FechaMovimiento TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,

    Observaciones TEXT,

    FOREIGN KEY (IdMaterial)
        REFERENCES Materiales(IdMaterial),

    FOREIGN KEY (IdTicket)
        REFERENCES Tickets(IdTicket),

    FOREIGN KEY (IdTecnico)
        REFERENCES Tecnicos(IdEmpleado),

    CHECK (TipoMovimiento IN ('Entrada','Salida','Ajuste')),

    CHECK (Cantidad > 0),

    CHECK (CostoUnitario >= 0),

    CHECK
    (
        TipoMovimiento <> 'Salida'
        OR
        (
            IdTicket IS NOT NULL
            AND IdTecnico IS NOT NULL
        )
    )
);

/*ÍNDICES*/

CREATE INDEX IX_Equipos_IdCliente
ON Equipos(IdCliente);

CREATE INDEX IX_Tickets_IdEquipo
ON Tickets(IdEquipo);

CREATE INDEX IX_Tickets_IdTecnico
ON Tickets(IdTecnico);

CREATE INDEX IX_Tickets_IdEstado
ON Tickets(IdEstado);

CREATE INDEX IX_MovimientosInventario_IdMaterial
ON MovimientosInventario(IdMaterial);

CREATE INDEX IX_MovimientosInventario_IdTicket
ON MovimientosInventario(IdTicket);