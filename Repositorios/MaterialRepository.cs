using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class MaterialRepository : IMaterialRepository
    {
        public bool Insertar(Material material)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                    INSERT INTO Materiales
                    (
                        Codigo,
                        Nombre,
                        Descripcion,
                        Stock,
                        StockMinimo,
                        CostoUnitario,
                        Activo
                    )
                    VALUES
                    (
                        @Codigo,
                        @Nombre,
                        @Descripcion,
                        @Stock,
                        @StockMinimo,
                        @CostoUnitario,
                        @Activo
                    );";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", material.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", material.Nombre);
                    comando.Parameters.AddWithValue(
                        "@Descripcion",
                        string.IsNullOrWhiteSpace(material.Descripcion)
                            ? (object)DBNull.Value
                            : material.Descripcion
                    );
                    comando.Parameters.AddWithValue("@Stock", material.Stock);
                    comando.Parameters.AddWithValue("@StockMinimo", material.StockMinimo);
                    comando.Parameters.AddWithValue("@CostoUnitario", material.CostoUnitario);
                    comando.Parameters.AddWithValue("@Activo", material.Activo ? 1 : 0);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Actualizar(Material material)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                    UPDATE Materiales
                    SET Codigo = @Codigo,
                        Nombre = @Nombre,
                        Descripcion = @Descripcion,
                        Stock = @Stock,
                        StockMinimo = @StockMinimo,
                        CostoUnitario = @CostoUnitario,
                        Activo = @Activo
                    WHERE IdMaterial = @IdMaterial;";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@IdMaterial", material.IdMaterial);
                    comando.Parameters.AddWithValue("@Codigo", material.Codigo);
                    comando.Parameters.AddWithValue("@Nombre", material.Nombre);
                    comando.Parameters.AddWithValue(
                        "@Descripcion",
                        string.IsNullOrWhiteSpace(material.Descripcion)
                            ? (object)DBNull.Value
                            : material.Descripcion
                    );
                    comando.Parameters.AddWithValue("@Stock", material.Stock);
                    comando.Parameters.AddWithValue("@StockMinimo", material.StockMinimo);
                    comando.Parameters.AddWithValue("@CostoUnitario", material.CostoUnitario);
                    comando.Parameters.AddWithValue("@Activo", material.Activo ? 1 : 0);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Eliminar(int idMaterial)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                    DELETE FROM Materiales
                    WHERE IdMaterial = @IdMaterial;";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@IdMaterial", idMaterial);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public Material ObtenerPorId(int idMaterial)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                    SELECT
                        IdMaterial,
                        Codigo,
                        Nombre,
                        Descripcion,
                        Stock,
                        StockMinimo,
                        CostoUnitario,
                        Activo
                    FROM Materiales
                    WHERE IdMaterial = @IdMaterial;";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@IdMaterial", idMaterial);

                    conexion.Open();

                    using (SQLiteDataReader reader = comando.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        return MapearMaterial(reader);
                    }
                }
            }
        }

        public List<Material> ObtenerTodos()
        {
            List<Material> listaMateriales = new List<Material>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                    SELECT
                        IdMaterial,
                        Codigo,
                        Nombre,
                        Descripcion,
                        Stock,
                        StockMinimo,
                        CostoUnitario,
                        Activo
                    FROM Materiales
                    ORDER BY Nombre;";

                using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                {
                    conexion.Open();

                    using (SQLiteDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaMateriales.Add(MapearMaterial(reader));
                        }
                    }
                }
            }

            return listaMateriales;
        }

        private Material MapearMaterial(SQLiteDataReader reader)
        {
            return new Material
            {
                IdMaterial = Convert.ToInt32(reader["IdMaterial"]),
                Codigo = reader["Codigo"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Descripcion = reader["Descripcion"] == DBNull.Value
                    ? string.Empty
                    : reader["Descripcion"].ToString(),
                Stock = Convert.ToDecimal(reader["Stock"]),
                StockMinimo = Convert.ToDecimal(reader["StockMinimo"]),
                CostoUnitario = Convert.ToDecimal(reader["CostoUnitario"]),
                Activo = Convert.ToInt32(reader["Activo"]) == 1
            };
        }
    }
}
