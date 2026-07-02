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
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool Insertar(Usuario usuario)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Usuarios
                                    (IdEmpleado, IdRol, NombreUsuario, Contrasena, Activo)
                                    VALUES
                                    (@IdEmpleado, @IdRol, @NombreUsuario, @Contrasena, @Activo)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", usuario.IdEmpleado);
                comando.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                comando.Parameters.AddWithValue("@Activo", usuario.Activo ? 1 : 0);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Usuario usuario)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE Usuarios
                                    SET IdEmpleado = @IdEmpleado,
                                        IdRol = @IdRol,
                                        NombreUsuario = @NombreUsuario,
                                        Contrasena = @Contrasena,
                                        Activo = @Activo
                                    WHERE IdUsuario = @IdUsuario";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                comando.Parameters.AddWithValue("@IdEmpleado", usuario.IdEmpleado);
                comando.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                comando.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                comando.Parameters.AddWithValue("@Activo", usuario.Activo ? 1 : 0);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idUsuario)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Usuarios
                                    WHERE IdUsuario = @IdUsuario";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            Usuario usuario = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Usuarios
                                    WHERE IdUsuario = @IdUsuario";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario();

                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                    usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                    usuario.Contrasena = reader["Contrasena"].ToString();
                    usuario.Activo = Convert.ToInt32(reader["Activo"]) == 1;
                }
            }

            return usuario;
        }

        public Usuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Usuarios
                                    WHERE NombreUsuario = @NombreUsuario";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario();

                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                    usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                    usuario.Contrasena = reader["Contrasena"].ToString();
                    usuario.Activo = Convert.ToInt32(reader["Activo"]) == 1;
                }
            }

            return usuario;
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Usuarios";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    usuario.IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                    usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                    usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                    usuario.Contrasena = reader["Contrasena"].ToString();
                    usuario.Activo = Convert.ToInt32(reader["Activo"]) == 1;

                    lista.Add(usuario);
                }
            }

            return lista;
        }
    }
}
