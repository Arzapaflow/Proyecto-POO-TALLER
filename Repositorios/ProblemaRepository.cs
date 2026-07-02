using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class ProblemaRepository : IProblemaRepository
    {
        public bool Insertar(Problema problema)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Problemas
                                    (Nombre, Descripcion, PosiblesCausas, CostoEstimado, Activo)
                                    VALUES
                                    (@Nombre, @Descripcion, @PosiblesCausas, @CostoEstimado, @Activo)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@Nombre", problema.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", problema.Descripcion);
                comando.Parameters.AddWithValue("@PosiblesCausas", problema.PosiblesCausas);
                comando.Parameters.AddWithValue("@CostoEstimado", problema.CostoEstimado);
                comando.Parameters.AddWithValue("@Activo", problema.Activo ? 1 : 0);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Problema problema)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE Problemas
                                    SET Nombre = @Nombre,
                                        Descripcion = @Descripcion,
                                        PosiblesCausas = @PosiblesCausas,
                                        CostoEstimado = @CostoEstimado,
                                        Activo = @Activo
                                    WHERE IdProblema = @IdProblema";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdProblema", problema.Id);
                comando.Parameters.AddWithValue("@Nombre", problema.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", problema.Descripcion);
                comando.Parameters.AddWithValue("@PosiblesCausas", problema.PosiblesCausas);
                comando.Parameters.AddWithValue("@CostoEstimado", problema.CostoEstimado);
                comando.Parameters.AddWithValue("@Activo", problema.Activo ? 1 : 0);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idProblema)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Problemas
                                    WHERE IdProblema = @IdProblema";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdProblema", idProblema);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Problema ObtenerPorId(int idProblema)
        {
            Problema problema = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Problemas
                                    WHERE IdProblema = @IdProblema";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdProblema", idProblema);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    problema = new Problema();

                    problema.Id = Convert.ToInt32(reader["IdProblema"]);
                    problema.Nombre = reader["Nombre"].ToString();
                    problema.Descripcion = reader["Descripcion"].ToString();
                    problema.PosiblesCausas = reader["PosiblesCausas"].ToString();
                    problema.CostoEstimado = Convert.ToDecimal(reader["CostoEstimado"]);
                    problema.Activo = Convert.ToInt32(reader["Activo"]) == 1;
                }
            }

            return problema;
        }

        public List<Problema> ObtenerTodos()
        {
            List<Problema> lista = new List<Problema>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Problemas";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Problema problema = new Problema();

                    problema.Id = Convert.ToInt32(reader["IdProblema"]);
                    problema.Nombre = reader["Nombre"].ToString();
                    problema.Descripcion = reader["Descripcion"].ToString();
                    problema.PosiblesCausas = reader["PosiblesCausas"].ToString();
                    problema.CostoEstimado = Convert.ToDecimal(reader["CostoEstimado"]);
                    problema.Activo = Convert.ToInt32(reader["Activo"]) == 1;

                    lista.Add(problema);
                }
            }

            return lista;
        }
    }
}