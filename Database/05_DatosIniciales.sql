/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 05_DatosIniciales.sql
==========================================================*/

USE TallerReparaciones;
GO


/*==========================================================
    ROLES DE DATOS INICIALES
==========================================================*/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Roles
    WHERE Nombre = N'Administrador'
)
BEGIN
    INSERT INTO dbo.Roles (Nombre)
    VALUES (N'Administrador');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Roles
    WHERE Nombre = N'Recepcionista'
)
BEGIN
    INSERT INTO dbo.Roles (Nombre)
    VALUES (N'Recepcionista');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Roles
    WHERE Nombre = N'Técnico'
)
BEGIN
    INSERT INTO dbo.Roles (Nombre)
    VALUES (N'Técnico');
END;
GO


/*==========================================================
    ESPECIALIDADES
==========================================================*/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Especialidades
    WHERE Nombre = N'Celulares'
)
BEGIN
    INSERT INTO dbo.Especialidades
    (
        Nombre,
        Descripcion
    )
    VALUES
    (
        N'Celulares',
        N'Reparación de teléfonos celulares Android y iPhone'
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Especialidades
    WHERE Nombre = N'Computadoras'
)
BEGIN
    INSERT INTO dbo.Especialidades
    (
        Nombre,
        Descripcion
    )
    VALUES
    (
        N'Computadoras',
        N'Reparación de computadoras de escritorio y laptops'
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Especialidades
    WHERE Nombre = N'Consolas'
)
BEGIN
    INSERT INTO dbo.Especialidades
    (
        Nombre,
        Descripcion
    )
    VALUES
    (
        N'Consolas',
        N'Reparación de consolas y controles de videojuegos'
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Especialidades
    WHERE Nombre = N'Electrónica'
)
BEGIN
    INSERT INTO dbo.Especialidades
    (
        Nombre,
        Descripcion
    )
    VALUES
    (
        N'Electrónica',
        N'Diagnóstico electrónico y reparación de tarjetas'
    );
END;
GO


/*==========================================================
    ESTADOS DEL TICKET
==========================================================*/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Recibido'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Recibido');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Pendiente de diagnóstico'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Pendiente de diagnóstico');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'En diagnóstico'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'En diagnóstico');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Esperando autorización'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Esperando autorización');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'En reparación'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'En reparación');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Esperando refacción'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Esperando refacción');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Reparado'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Reparado');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'No reparable'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'No reparable');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Entregado'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Entregado');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.EstadosTicket
    WHERE Nombre = N'Cancelado'
)
BEGIN
    INSERT INTO dbo.EstadosTicket (Nombre)
    VALUES (N'Cancelado');
END;
GO


/*==========================================================
    TIPOS DE EQUIPO
==========================================================*/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Celular'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Celular');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Laptop'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Laptop');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Computadora de escritorio'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Computadora de escritorio');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Consola'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Consola');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Control'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Control');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Tablet'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Tablet');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Impresora'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Impresora');
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.TipoEquipos
    WHERE Nombre = N'Otro'
)
BEGIN
    INSERT INTO dbo.TipoEquipos (Nombre)
    VALUES (N'Otro');
END;
GO


/*==========================================================
    PROBLEMAS COMUNES
==========================================================*/

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Problemas
    WHERE Nombre = N'No enciende'
)
BEGIN
    INSERT INTO dbo.Problemas
    (
        Nombre,
        Descripcion,
        PosiblesCausas,
        CostoEstimado
    )
    VALUES
    (
        N'No enciende',
        N'El equipo no presenta señales de encendido',
        N'Batería dañada, cargador defectuoso, centro de carga o tarjeta electrónica',
        500.00
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Problemas
    WHERE Nombre = N'Pantalla dañada'
)
BEGIN
    INSERT INTO dbo.Problemas
    (
        Nombre,
        Descripcion,
        PosiblesCausas,
        CostoEstimado
    )
    VALUES
    (
        N'Pantalla dañada',
        N'La pantalla está rota, manchada o no muestra imagen',
        N'Golpe, caída, humedad o daño interno del display',
        1000.00
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Problemas
    WHERE Nombre = N'No carga'
)
BEGIN
    INSERT INTO dbo.Problemas
    (
        Nombre,
        Descripcion,
        PosiblesCausas,
        CostoEstimado
    )
    VALUES
    (
        N'No carga',
        N'El equipo no reconoce el cargador o no aumenta el porcentaje de batería',
        N'Cargador, cable, centro de carga, batería o circuito de alimentación',
        600.00
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Problemas
    WHERE Nombre = N'Se apaga'
)
BEGIN
    INSERT INTO dbo.Problemas
    (
        Nombre,
        Descripcion,
        PosiblesCausas,
        CostoEstimado
    )
    VALUES
    (
        N'Se apaga',
        N'El equipo se apaga durante su uso',
        N'Sobrecalentamiento, batería, fuente de alimentación o daño electrónico',
        700.00
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Problemas
    WHERE Nombre = N'Falla de software'
)
BEGIN
    INSERT INTO dbo.Problemas
    (
        Nombre,
        Descripcion,
        PosiblesCausas,
        CostoEstimado
    )
    VALUES
    (
        N'Falla de software',
        N'El sistema operativo presenta errores o no inicia correctamente',
        N'Archivos dañados, actualización fallida, virus o almacenamiento defectuoso',
        500.00
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Problemas
    WHERE Nombre = N'Revisión general'
)
BEGIN
    INSERT INTO dbo.Problemas
    (
        Nombre,
        Descripcion,
        PosiblesCausas,
        CostoEstimado
    )
    VALUES
    (
        N'Revisión general',
        N'El cliente solicita diagnóstico general del equipo',
        N'Problema pendiente de identificar',
        200.00
    );
END;
GO


/*==========================================================
    ADMINISTRADOR INICIAL
==========================================================*/

DECLARE @IdEmpleadoAdministrador INT;
DECLARE @IdRolAdministrador INT;

SELECT @IdRolAdministrador = IdRol
FROM dbo.Roles
WHERE Nombre = N'Administrador';

SELECT @IdEmpleadoAdministrador = IdEmpleado
FROM dbo.Empleados
WHERE Correo = N'admin@taller.local';

IF @IdEmpleadoAdministrador IS NULL
BEGIN
    INSERT INTO dbo.Empleados
    (
        Nombre,
        Telefono,
        Correo,
        Estado
    )
    VALUES
    (
        N'Administrador principal',
        N'0000000000',
        N'admin@taller.local',
        N'Activo'
    );

    SET @IdEmpleadoAdministrador = SCOPE_IDENTITY();
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Administradores
    WHERE IdEmpleado = @IdEmpleadoAdministrador
)
BEGIN
    INSERT INTO dbo.Administradores
    (
        IdEmpleado
    )
    VALUES
    (
        @IdEmpleadoAdministrador
    );
END;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.Usuarios
    WHERE NombreUsuario = N'admin'
)
BEGIN
    INSERT INTO dbo.Usuarios
    (
        IdEmpleado,
        IdRol,
        NombreUsuario,
        Contrasena,
        Activo
    )
    VALUES
    (
        @IdEmpleadoAdministrador,
        @IdRolAdministrador,
        N'admin',
        N'Admin123!',
        1
    );
END;
GO