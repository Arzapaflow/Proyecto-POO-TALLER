using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Repositorios.Interfaces;

namespace Proyecto1.Repositorios
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public bool Insertar(Empleado empleado)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Empleados
                                    (Nombre, Telefono, Correo, Estado, FechaIngreso)
                                    VALUES
                                    (@Nombre, @Telefono, @Correo, @Estado, @FechaIngreso)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                comando.Parameters.AddWithValue("@Correo", empleado.Correo);
                comando.Parameters.AddWithValue("@Estado", empleado.Estado.ToString());
                comando.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Empleado empleado)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE Empleados
                                    SET Nombre = @Nombre,
                                        Telefono = @Telefono,
                                        Correo = @Correo,
                                        Estado = @Estado,
                                        FechaIngreso = @FechaIngreso
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", empleado.Id);
                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                comando.Parameters.AddWithValue("@Correo", empleado.Correo);
                comando.Parameters.AddWithValue("@Estado", empleado.Estado.ToString());
                comando.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idEmpleado)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Empleados
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Empleado ObtenerPorId(int idEmpleado)
        {
            Empleado empleado = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdEmpleado,
                                           Nombre,
                                           Telefono,
                                           Correo,
                                           Estado,
                                           FechaIngreso
                                    FROM Empleados
                                    WHERE IdEmpleado = @IdEmpleado";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    empleado = new Empleado();

                    empleado.Id = Convert.ToInt32(reader["IdEmpleado"]);
                    empleado.Nombre = reader["Nombre"].ToString();
                    empleado.Telefono = reader["Telefono"].ToString();
                    empleado.Correo = reader["Correo"].ToString();
                    empleado.Estado = (EstadoEmpleado)Enum.Parse(typeof(EstadoEmpleado), reader["Estado"].ToString());
                    empleado.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                }
            }

            return empleado;
        }

        public List<Empleado> ObtenerTodos()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdEmpleado,
                                           Nombre,
                                           Telefono,
                                           Correo,
                                           Estado,
                                           FechaIngreso
                                    FROM Empleados";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();

                    empleado.Id = Convert.ToInt32(reader["IdEmpleado"]);
                    empleado.Nombre = reader["Nombre"].ToString();
                    empleado.Telefono = reader["Telefono"].ToString();
                    empleado.Correo = reader["Correo"].ToString();
                    empleado.Estado = (EstadoEmpleado)Enum.Parse(typeof(EstadoEmpleado), reader["Estado"].ToString());
                    empleado.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);

                    lista.Add(empleado);
                }
            }

            return lista;
        }
    }
}
