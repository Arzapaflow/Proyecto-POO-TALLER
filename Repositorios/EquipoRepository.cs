using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class EquipoRepository : IEquipoRepository
    {
        public bool Insertar(Equipo equipo)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
            INSERT INTO Equipos
            (
                IdCliente,
                IdTipoEquipo,
                Marca,
                Modelo,
                Color,
                NumeroSerie,
                Accesorios,
                Observaciones
            )
            VALUES
            (
                @IdCliente,
                @IdTipoEquipo,
                @Marca,
                @Modelo,
                @Color,
                @NumeroSerie,
                @Accesorios,
                @Observaciones
            );

            SELECT last_insert_rowid();";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue(
                    "@IdCliente",
                    equipo.Cliente.Id
                );

                comando.Parameters.AddWithValue(
                    "@IdTipoEquipo",
                    equipo.TipoEquipo.Id
                );

                comando.Parameters.AddWithValue(
                    "@Marca",
                    equipo.Marca
                );

                comando.Parameters.AddWithValue(
                    "@Modelo",
                    equipo.Modelo
                );

                comando.Parameters.AddWithValue(
                    "@Color",
                    equipo.Color
                );

                comando.Parameters.AddWithValue(
                    "@NumeroSerie",
                    string.IsNullOrWhiteSpace(equipo.NumeroSerie)
                        ? (object)DBNull.Value
                        : equipo.NumeroSerie
                );

                comando.Parameters.AddWithValue(
                    "@Accesorios",
                    string.IsNullOrWhiteSpace(equipo.Accesorios)
                        ? (object)DBNull.Value
                        : equipo.Accesorios
                );

                comando.Parameters.AddWithValue(
                    "@Observaciones",
                    string.IsNullOrWhiteSpace(equipo.Observaciones)
                        ? (object)DBNull.Value
                        : equipo.Observaciones
                );

                conexion.Open();

                object resultado = comando.ExecuteScalar();

                if (resultado == null || resultado == DBNull.Value)
                    return false;

                equipo.Id = Convert.ToInt32(resultado);

                return equipo.Id > 0;
            }
        }

        public bool Actualizar(Equipo equipo)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE Equipos
                                    SET IdCliente = @IdCliente,
                                        IdTipoEquipo = @IdTipoEquipo,
                                        Marca = @Marca,
                                        Modelo = @Modelo,
                                        NumeroSerie = @NumeroSerie,
                                        Color = @Color,
                                        Accesorios = @Accesorios,
                                        Observaciones = @Observaciones
                                    WHERE IdEquipo = @IdEquipo";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEquipo", equipo.Id);
                comando.Parameters.AddWithValue("@IdCliente", equipo.Cliente.Id);
                comando.Parameters.AddWithValue("@IdTipoEquipo", equipo.TipoEquipo.Id);
                comando.Parameters.AddWithValue("@Marca", equipo.Marca);
                comando.Parameters.AddWithValue("@Modelo", equipo.Modelo);
                comando.Parameters.AddWithValue("@NumeroSerie", equipo.NumeroSerie);
                comando.Parameters.AddWithValue("@Color", equipo.Color);
                comando.Parameters.AddWithValue("@Accesorios", equipo.Accesorios);
                comando.Parameters.AddWithValue("@Observaciones", equipo.Observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idEquipo)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Equipos
                                    WHERE IdEquipo = @IdEquipo";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEquipo", idEquipo);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Equipo ObtenerPorId(int idEquipo)
        {
            Equipo equipo = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Equipos
                                    WHERE IdEquipo = @IdEquipo";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEquipo", idEquipo);

                conexion.Open();

                using (SQLiteDataReader reader = comando.ExecuteReader()) 

                if (reader.Read())
                {
                    equipo = new Equipo();

                    equipo.Id = Convert.ToInt32(reader["IdEquipo"]);

                    equipo.Cliente = new Cliente();
                    equipo.Cliente.Id = Convert.ToInt32(reader["IdCliente"]);

                    equipo.TipoEquipo = new TipoEquipo();
                    equipo.TipoEquipo.Id = Convert.ToInt32(reader["IdTipoEquipo"]);

                    equipo.Marca = reader["Marca"].ToString();
                    equipo.Modelo = reader["Modelo"].ToString();
                    equipo.NumeroSerie = reader["NumeroSerie"].ToString();
                    equipo.Color = reader["Color"].ToString();
                    equipo.Accesorios = reader["Accesorios"].ToString();
                    equipo.Observaciones = reader["Observaciones"].ToString();
                }
            }

            return equipo;
        }

        public List<Equipo> ObtenerTodos()
        {
            List<Equipo> lista = new List<Equipo>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Equipos";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Equipo equipo = new Equipo();

                    equipo.Id = Convert.ToInt32(reader["IdEquipo"]);

                    equipo.Cliente = new Cliente();
                    equipo.Cliente.Id = Convert.ToInt32(reader["IdCliente"]);

                    equipo.TipoEquipo = new TipoEquipo();
                    equipo.TipoEquipo.Id = Convert.ToInt32(reader["IdTipoEquipo"]);

                    equipo.Marca = reader["Marca"].ToString();
                    equipo.Modelo = reader["Modelo"].ToString();
                    equipo.NumeroSerie = reader["NumeroSerie"].ToString();
                    equipo.Color = reader["Color"].ToString();
                    equipo.Accesorios = reader["Accesorios"].ToString();
                    equipo.Observaciones = reader["Observaciones"].ToString();

                    lista.Add(equipo);
                }
            }

            return lista;
        }
    }
}