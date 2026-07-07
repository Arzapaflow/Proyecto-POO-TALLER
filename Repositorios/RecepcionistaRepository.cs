using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class RecepcionistaRepository : IRecepcionistaRepository
    {
        public bool Insertar(Recepcionista recepcionista)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Recepcionistas
                                    (IdEmpleado)
                                    VALUES
                                    (@IdEmpleado)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", recepcionista.Id);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Recepcionista recepcionista)
        {
            // No hay campos para actualizar
            return true;
        }

        public bool Eliminar(int idEmpleado)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Recepcionistas
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Recepcionista ObtenerPorId(int idEmpleado)
        {
            Recepcionista recepcionista = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdEmpleado
                                    FROM Recepcionistas
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                using (SQLiteDataReader reader = comando.ExecuteReader())

                    if (reader.Read())
                    {
                        recepcionista = new Recepcionista();

                        recepcionista.Id = Convert.ToInt32(reader["IdEmpleado"]);
                    }
            }

            return recepcionista;
        }

        public List<Recepcionista> ObtenerTodos()
        {
            List<Recepcionista> lista = new List<Recepcionista>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdEmpleado
                                    FROM Recepcionistas";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Recepcionista recepcionista = new Recepcionista();

                    recepcionista.Id = Convert.ToInt32(reader["IdEmpleado"]);

                    lista.Add(recepcionista);
                }
            }

            return lista;
        }
    }
}