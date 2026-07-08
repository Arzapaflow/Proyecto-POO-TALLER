using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class TecnicoRepository : ITecnicoRepository
    {
        private int ObtenerIdEspecialidad(Especialidad especialidad)
        {
            switch (especialidad)
            {
                case Especialidad.AppleMoviles:
                case Especialidad.AndroidMoviles:
                    return 1; // Celulares

                case Especialidad.AppleComputadoras:
                case Especialidad.ComputadorasWindows:
                    return 2; // Computadoras

                case Especialidad.PConsolas:
                    return 3; // Consolas

                default:
                    return 4; // Electrónica
            }
        }

        private Especialidad ObtenerEspecialidad(int idEspecialidad)
        {
            switch (idEspecialidad)
            {
                case 1:
                    return Especialidad.AppleMoviles;

                case 2:
                    return Especialidad.ComputadorasWindows;

                case 3:
                    return Especialidad.PConsolas;

                default:
                    return Especialidad.Otros;
            }
        }

        public bool Insertar(Tecnico tecnico)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Tecnicos
                                    (IdEmpleado, IdEspecialidad, PagoPorHora)
                                    VALUES
                                    (@IdEmpleado, @IdEspecialidad, @PagoPorHora)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", tecnico.Id);
                comando.Parameters.AddWithValue("@IdEspecialidad", ObtenerIdEspecialidad(tecnico.Especialidad));
                comando.Parameters.AddWithValue("@PagoPorHora", tecnico.PagoPorHora);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Tecnico tecnico)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE Tecnicos
                                    SET IdEspecialidad = @IdEspecialidad,
                                        PagoPorHora = @PagoPorHora
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", tecnico.Id);
                comando.Parameters.AddWithValue("@IdEspecialidad", ObtenerIdEspecialidad(tecnico.Especialidad));
                comando.Parameters.AddWithValue("@PagoPorHora", tecnico.PagoPorHora);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idEmpleado)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Tecnicos
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Tecnico ObtenerPorId(int idEmpleado)
        {
            Tecnico tecnico = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                                    SELECT
                                    e.IdEmpleado,
                                    e.Nombre,
                                    e.Telefono,
                                    e.Correo,
                                    e.Estado,
                                    e.FechaIngreso,

                                    u.NombreUsuario,

                                    t.IdEspecialidad

                                    FROM Tecnicos t

                                    INNER JOIN Empleados e
                                    ON t.IdEmpleado=e.IdEmpleado

                                    INNER JOIN Usuarios u
                                    ON u.IdEmpleado=e.IdEmpleado

                                    WHERE e.IdEmpleado=@IdEmpleado;";

                SQLiteCommand comando =
                    new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue(
                    "@IdEmpleado",
                    idEmpleado);

                conexion.Open();

                using (SQLiteDataReader reader =
                    comando.ExecuteReader())
                { 
                    if (reader.Read())
                    {
                        tecnico = new Tecnico();

                        tecnico.Id =
                            Convert.ToInt32(reader["IdEmpleado"]);

                        tecnico.Nombre =
                            reader["Nombre"].ToString();

                        tecnico.Telefono =
                            reader["Telefono"].ToString();

                        tecnico.Correo =
                            reader["Correo"].ToString();

                        tecnico.Usuario =
                            reader["NombreUsuario"].ToString();

                        tecnico.Estado =
                            (EstadoEmpleado)Enum.Parse(
                                typeof(EstadoEmpleado),
                                reader["Estado"].ToString());

                        tecnico.FechaIngreso =
                            Convert.ToDateTime(reader["FechaIngreso"]);

                        tecnico.Especialidad =
                            ObtenerEspecialidad(
                                Convert.ToInt32(reader["IdEspecialidad"]));
                    }
                }
                    
            }

            return tecnico;
        }

        public List<Tecnico> ObtenerTodos()
        {
            List<Tecnico> lista = new List<Tecnico>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                                    SELECT
                                    e.IdEmpleado,
                                    e.Nombre,
                                    e.Telefono,
                                    e.Correo,
                                    e.Estado,
                                    e.FechaIngreso,

                                    u.NombreUsuario,

                                    t.IdEspecialidad
    
                                    FROM Tecnicos t

                                    INNER JOIN Empleados e
                                    ON t.IdEmpleado=e.IdEmpleado

                                    INNER JOIN Usuarios u
                                    ON u.IdEmpleado=e.IdEmpleado

                                    ORDER BY e.Nombre;";

                SQLiteCommand comando =
                    new SQLiteCommand(consulta, conexion);

                conexion.Open();

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tecnico tecnico = new Tecnico();

                        tecnico.Id =
                            Convert.ToInt32(reader["IdEmpleado"]);

                        tecnico.Nombre =
                            reader["Nombre"].ToString();

                        tecnico.Telefono =
                            reader["Telefono"].ToString();

                        tecnico.Correo =
                            reader["Correo"].ToString();

                        tecnico.Usuario =
                            reader["NombreUsuario"].ToString();

                        tecnico.Estado =
                            (EstadoEmpleado)Enum.Parse(
                                typeof(EstadoEmpleado),
                                reader["Estado"].ToString());

                        tecnico.FechaIngreso =
                            Convert.ToDateTime(reader["FechaIngreso"]);

                        tecnico.Especialidad =
                            ObtenerEspecialidad(
                                Convert.ToInt32(reader["IdEspecialidad"]));

                        lista.Add(tecnico);
                    }
                }
                    
            }

            return lista;
        }
    }
}