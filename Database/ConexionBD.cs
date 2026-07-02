using System;
using System.Configuration;
using System.Data.SQLite;
using System.IO;

namespace Proyecto1.Database
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion =
            ConstruirCadenaConexion();

        private static string ConstruirCadenaConexion()
        {
            ConnectionStringSettings configuracion =
                ConfigurationManager.ConnectionStrings["TallerReparaciones"];

            if (configuracion == null)
            {
                throw new ConfigurationErrorsException(
                    "No se encontró la conexión TallerReparaciones en App.config."
                );
            }

            SQLiteConnectionStringBuilder constructor =
                new SQLiteConnectionStringBuilder(
                    configuracion.ConnectionString
                );

            string nombreBase = string.IsNullOrWhiteSpace(constructor.DataSource)
                ? "TallerReparaciones.db"
                : constructor.DataSource;

            constructor.DataSource = BuscarBaseDeDatos(nombreBase);

            return constructor.ConnectionString;
        }

        private static string BuscarBaseDeDatos(string nombreBase)
        {
           
            string rutaEjecutable = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                Path.GetFileName(nombreBase)
            );

            
            DirectoryInfo carpetaActual =
                new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (carpetaActual != null)
            {
                string rutaProyecto = Path.Combine(
                    carpetaActual.FullName,
                    "Proyecto1.csproj"
                );

                string rutaBase = Path.Combine(
                    carpetaActual.FullName,
                    Path.GetFileName(nombreBase)
                );

                if (File.Exists(rutaProyecto) && File.Exists(rutaBase))
                {
                    return rutaBase;
                }

                carpetaActual = carpetaActual.Parent;
            }

            
            if (File.Exists(rutaEjecutable))
            {
                return rutaEjecutable;
            }

            throw new FileNotFoundException(
                "No se encontró TallerReparaciones.db. " +
                "Debe estar junto a Proyecto1.csproj o junto al ejecutable.",
                rutaEjecutable
            );
        }

        public static SQLiteConnection CrearConexion()
        {
            return new SQLiteConnection(cadenaConexion);
        }

        public static SQLiteConnection ObtenerConexion()
        {
            return CrearConexion();
        }

        public static bool ProbarConexion(out string mensajeError)
        {
            try
            {
                using (SQLiteConnection conexion = CrearConexion())
                {
                    conexion.Open();

                    using (SQLiteCommand comando =
                        new SQLiteCommand(
                            "PRAGMA foreign_keys = ON;",
                            conexion
                        ))
                    {
                        comando.ExecuteNonQuery();
                    }

                    mensajeError = string.Empty;
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }
    }
}