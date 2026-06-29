/*==========================================================
    PROYECTO: Sistema de Gestión para Taller de Reparaciones
    ARCHIVO: 01_CrearBase.sql
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