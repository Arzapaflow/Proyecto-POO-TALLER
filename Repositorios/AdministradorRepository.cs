using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class AdministradorRepository : IAdministradorRepository
    {
        public bool Insertar(Administrador administrador)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Administradores
                                    (IdEmpleado)
                                    VALUES
                                    (@IdEmpleado)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", administrador.Id);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Administrador administrador)
        {
            // La tabla no tiene campos para actualizar.
            return true;
        }

        public bool Eliminar(int idEmpleado)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Administradores
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Administrador ObtenerPorId(int idEmpleado)
        {
            Administrador administrador = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdEmpleado
                                    FROM Administradores
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    administrador = new Administrador();

                    administrador.Id = Convert.ToInt32(reader["IdEmpleado"]);
                }
            }

            return administrador;
        }

        public List<Administrador> ObtenerTodos()
        {
            List<Administrador> lista = new List<Administrador>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdEmpleado
                                    FROM Administradores";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Administrador administrador = new Administrador();

                    administrador.Id = Convert.ToInt32(reader["IdEmpleado"]);

                    lista.Add(administrador);
                }
            }

            return lista;
        }
    }
}