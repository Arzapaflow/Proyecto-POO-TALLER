using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Database;
using Proyecto1.Models;
using Proyecto1.Repositorios.Interfaces;
using System.Data.SQLite;

namespace Proyecto1.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        public bool Insertar(Cliente cliente)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO Clientes
                            (Nombre, Telefono, Correo)
                            VALUES
                            (@Nombre, @Telefono, @Correo)";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Correo", cliente.Correo);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE Clientes
                            SET Nombre = @Nombre,
                                Telefono = @Telefono,
                                Correo = @Correo
                            WHERE IdCliente = @IdCliente";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdCliente", cliente.Id);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Correo", cliente.Correo);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idCliente)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Clientes
                            WHERE IdCliente = @IdCliente";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }


        public Cliente ObtenerPorId(int idCliente)
        {
            Cliente cliente = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdCliente,
                                   Nombre,
                                   Telefono,
                                   Correo
                            FROM Clientes
                            WHERE IdCliente = @IdCliente";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Correo = reader["Correo"].ToString();
                }
            }

            return cliente;
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT IdCliente,
                                   Nombre,
                                   Telefono,
                                   Correo
                            FROM Clientes";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(reader["IdCliente"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    cliente.Correo = reader["Correo"].ToString();

                    listaClientes.Add(cliente);
                }
            }

            return listaClientes;
        }
        }
    }