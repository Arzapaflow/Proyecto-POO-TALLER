using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Proyecto1.Database
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion = 
            ConfigurationManager.ConnectionStrings["TallerDB"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
