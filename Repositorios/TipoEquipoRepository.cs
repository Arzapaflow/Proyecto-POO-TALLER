using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class TipoEquipoRepository : ITipoEquipoRepository
    {
        public bool Insertar(TipoEquipo tipoEquipo)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO TipoEquipos
                                    (Nombre)
                                    VALUES
                                    (@Nombre)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@Nombre", tipoEquipo.Nombre);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(TipoEquipo tipoEquipo)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE TipoEquipos
                                    SET Nombre = @Nombre
                                    WHERE IdTipoEquipo = @IdTipoEquipo";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdTipoEquipo", tipoEquipo.Id);
                comando.Parameters.AddWithValue("@Nombre", tipoEquipo.Nombre);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idTipoEquipo)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM TipoEquipos
                                    WHERE IdTipoEquipo = @IdTipoEquipo";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdTipoEquipo", idTipoEquipo);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public TipoEquipo ObtenerPorId(int idTipoEquipo)
        {
            TipoEquipo tipoEquipo = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdTipoEquipo,
                                           Nombre
                                    FROM TipoEquipos
                                    WHERE IdTipoEquipo = @IdTipoEquipo";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdTipoEquipo", idTipoEquipo);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    tipoEquipo = new TipoEquipo();

                    tipoEquipo.Id = Convert.ToInt32(reader["IdTipoEquipo"]);
                    tipoEquipo.Nombre = reader["Nombre"].ToString();
                }
            }

            return tipoEquipo;
        }

        public List<TipoEquipo> ObtenerTodos()
        {
            List<TipoEquipo> lista = new List<TipoEquipo>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdTipoEquipo,
                                           Nombre
                                    FROM TipoEquipos";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    TipoEquipo tipoEquipo = new TipoEquipo();

                    tipoEquipo.Id = Convert.ToInt32(reader["IdTipoEquipo"]);
                    tipoEquipo.Nombre = reader["Nombre"].ToString();

                    lista.Add(tipoEquipo);
                }
            }

            return lista;
        }
    }
}
