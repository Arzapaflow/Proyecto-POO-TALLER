/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 02_DatosInicialesSQLite.sql
    BASE DE DATOS: SQLite
==========================================================*/

PRAGMA foreign_keys = ON;

BEGIN TRANSACTION;


/*==========================================================
    ROLES
==========================================================*/

INSERT OR IGNORE INTO Roles (Nombre)
VALUES ('Administrador');

INSERT OR IGNORE INTO Roles (Nombre)
VALUES ('Recepcionista');

INSERT OR IGNORE INTO Roles (Nombre)
VALUES ('Técnico');


/*==========================================================
    ESPECIALIDADES
==========================================================*/

INSERT OR IGNORE INTO Especialidades
(
    Nombre,
    Descripcion
)
VALUES
(
    'Celulares',
    'Reparación de teléfonos celulares Android y iPhone'
);

INSERT OR IGNORE INTO Especialidades
(
    Nombre,
    Descripcion
)
VALUES
(
    'Computadoras',
    'Reparación de computadoras de escritorio y laptops'
);

INSERT OR IGNORE INTO Especialidades
(
    Nombre,
    Descripcion
)
VALUES
(
    'Consolas',
    'Reparación de consolas y controles de videojuegos'
);

INSERT OR IGNORE INTO Especialidades
(
    Nombre,
    Descripcion
)
VALUES
(
    'Electrónica',
    'Diagnóstico electrónico y reparación de tarjetas'
);


/*==========================================================
    ESTADOS DEL TICKET
==========================================================*/

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Recibido');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Pendiente de diagnóstico');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('En diagnóstico');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Esperando autorización');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('En reparación');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Esperando refacción');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Reparado');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('No reparable');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Entregado');

INSERT OR IGNORE INTO EstadosTicket (Nombre)
VALUES ('Cancelado');


/*==========================================================
    TIPOS DE EQUIPO
==========================================================*/

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Celular');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Laptop');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Computadora de escritorio');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Consola');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Control');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Tablet');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Impresora');

INSERT OR IGNORE INTO TipoEquipos (Nombre)
VALUES ('Otro');


/*==========================================================
    PROBLEMAS COMUNES
==========================================================*/

INSERT OR IGNORE INTO Problemas
(
    Nombre,
    Descripcion,
    PosiblesCausas,
    CostoEstimado
)
VALUES
(
    'No enciende',
    'El equipo no presenta señales de encendido',
    'Batería dañada, cargador defectuoso, centro de carga o tarjeta electrónica',
    500.00
);

INSERT OR IGNORE INTO Problemas
(
    Nombre,
    Descripcion,
    PosiblesCausas,
    CostoEstimado
)
VALUES
(
    'Pantalla dañada',
    'La pantalla está rota, manchada o no muestra imagen',
    'Golpe, caída, humedad o daño interno del display',
    1000.00
);

INSERT OR IGNORE INTO Problemas
(
    Nombre,
    Descripcion,
    PosiblesCausas,
    CostoEstimado
)
VALUES
(
    'No carga',
    'El equipo no reconoce el cargador o no aumenta el porcentaje de batería',
    'Cargador, cable, centro de carga, batería o circuito de alimentación',
    600.00
);

INSERT OR IGNORE INTO Problemas
(
    Nombre,
    Descripcion,
    PosiblesCausas,
    CostoEstimado
)
VALUES
(
    'Se apaga',
    'El equipo se apaga durante su uso',
    'Sobrecalentamiento, batería, fuente de alimentación o daño electrónico',
    700.00
);

INSERT OR IGNORE INTO Problemas
(
    Nombre,
    Descripcion,
    PosiblesCausas,
    CostoEstimado
)
VALUES
(
    'Falla de software',
    'El sistema operativo presenta errores o no inicia correctamente',
    'Archivos dañados, actualización fallida, virus o almacenamiento defectuoso',
    500.00
);

INSERT OR IGNORE INTO Problemas
(
    Nombre,
    Descripcion,
    PosiblesCausas,
    CostoEstimado
)
VALUES
(
    'Revisión general',
    'El cliente solicita diagnóstico general del equipo',
    'Problema pendiente de identificar',
    200.00
);


/*==========================================================
    ADMINISTRADOR INICIAL
==========================================================*/

/* Crear el empleado administrador si todavía no existe */

INSERT INTO Empleados
(
    Nombre,
    Telefono,
    Correo,
    Estado
)
SELECT
    'Administrador principal',
    '0000000000',
    'admin@taller.local',
    'Activo'
WHERE NOT EXISTS
(
    SELECT 1
    FROM Empleados
    WHERE Correo = 'admin@taller.local'
);


/* Registrar al empleado como administrador */

INSERT OR IGNORE INTO Administradores
(
    IdEmpleado
)
SELECT IdEmpleado
FROM Empleados
WHERE Correo = 'admin@taller.local';


/* Crear el usuario administrador */

INSERT OR IGNORE INTO Usuarios
(
    IdEmpleado,
    IdRol,
    NombreUsuario,
    Contrasena,
    Activo
)
SELECT
    Empleados.IdEmpleado,
    Roles.IdRol,
    'admin',
    'Admin123!',
    1
FROM Empleados
INNER JOIN Roles
    ON Roles.Nombre = 'Administrador'
WHERE Empleados.Correo = 'admin@taller.local';


COMMIT;
