using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;
using System.Data;
using System.Data.SqlClient;


namespace Proyecto1.Repositorios
{
    public class MaterialRepository : IMaterialRepository
    {
        public bool Insertar(Material material)
        {
            using (SqlConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Materiales
                            (Codigo, Nombre, Descripcion, Stock, StockMinimo, CostoUnitario, Activo)
                            VALUES
                            (@Codigo, @Nombre, @Descripcion, @Stock, @StockMinimo, @CostoUnitario, @Activo)";

                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@Codigo", material.Codigo);
                comando.Parameters.AddWithValue("@Nombre", material.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                comando.Parameters.AddWithValue("@Stock", material.Stock);
                comando.Parameters.AddWithValue("@StockMinimo", material.StockMinimo);
                comando.Parameters.AddWithValue("@CostoUnitario", material.CostoUnitario);
                comando.Parameters.AddWithValue("@Activo", material.Activo);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Material material)
        {
            throw new System.NotImplementedException();
        }

        public bool Eliminar(int idMaterial)
        {
            throw new System.NotImplementedException();
        }

        public Material ObtenerPorId(int idMaterial)
        {
            throw new System.NotImplementedException();
        }

        public List<Material> ObtenerTodos()
        {
            List<Material> listaMateriales = new List<Material>();

            using (SqlConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdMaterial,
                                   Codigo,
                                   Nombre,
                                   Descripcion,
                                   Stock,
                                   StockMinimo,
                                   CostoUnitario,
                                   Activo
                            FROM Materiales";

                SqlCommand comando = new SqlCommand(consulta, conexion);

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Material material = new Material();

                    material.IdMaterial = Convert.ToInt32(reader["IdMaterial"]);
                    material.Codigo = reader["Codigo"].ToString();
                    material.Nombre = reader["Nombre"].ToString();
                    material.Descripcion = reader["Descripcion"].ToString();
                    material.Stock = Convert.ToDecimal(reader["Stock"]);
                    material.StockMinimo = Convert.ToDecimal(reader["StockMinimo"]);
                    material.CostoUnitario = Convert.ToDecimal(reader["CostoUnitario"]);
                    material.Activo = Convert.ToBoolean(reader["Activo"]);

                    listaMateriales.Add(material);
                }
            }

            return listaMateriales;
        }
    }
}
