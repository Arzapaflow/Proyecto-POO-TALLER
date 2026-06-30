using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto1.Database
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion =
            ConfigurationManager
                .ConnectionStrings["TallerReparaciones"]
                .ConnectionString;

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }

        public static bool ProbarConexion(out string mensajeError)
        {
            try
            {
                using (SqlConnection conexion = CrearConexion())
                {
                    conexion.Open();
                    mensajeError = string.Empty;
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }
    }
}