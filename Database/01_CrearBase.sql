/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 01_CrearBase.sql
    DESCRIPCIÓN:
    Crea la base de datos únicamente si todavía no existe.
==========================================================*/

USE master;
GO

IF DB_ID(N'TallerReparaciones') IS NULL
BEGIN
    CREATE DATABASE TallerReparaciones;
END;
GO

USE TallerReparaciones;
GO