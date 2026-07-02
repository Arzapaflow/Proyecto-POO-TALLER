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
    public class MovimientoInventarioRepository : IMovimientoInventarioRepository
    {
        public bool Insertar(MovimientoInventario movimiento)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"INSERT INTO MovimientosInventario
                (
                    IdMaterial,
                    IdTicket,
                    IdTecnico,
                    TipoMovimiento,
                    Cantidad,
                    CostoUnitario,
                    FechaMovimiento,
                    Observaciones
                )
                VALUES
                (
                    @IdMaterial,
                    @IdTicket,
                    @IdTecnico,
                    @TipoMovimiento,
                    @Cantidad,
                    @CostoUnitario,
                    @FechaMovimiento,
                    @Observaciones
                );";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdMaterial", movimiento.Material.IdMaterial);

                if (movimiento.Ticket == null)
                    comando.Parameters.AddWithValue("@IdTicket", DBNull.Value);
                else
                    comando.Parameters.AddWithValue("@IdTicket", movimiento.Ticket.Id);

                if (movimiento.Tecnico == null)
                    comando.Parameters.AddWithValue("@IdTecnico", DBNull.Value);
                else
                    comando.Parameters.AddWithValue("@IdTecnico", movimiento.Tecnico.Id);

                comando.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                comando.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                comando.Parameters.AddWithValue("@CostoUnitario", movimiento.CostoUnitario);
                comando.Parameters.AddWithValue("@FechaMovimiento", movimiento.Fecha);
                comando.Parameters.AddWithValue("@Observaciones", movimiento.Observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(MovimientoInventario movimiento)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"UPDATE MovimientosInventario
                SET
                    IdMaterial=@IdMaterial,
                    IdTicket=@IdTicket,
                    IdTecnico=@IdTecnico,
                    TipoMovimiento=@TipoMovimiento,
                    Cantidad=@Cantidad,
                    CostoUnitario=@CostoUnitario,
                    FechaMovimiento=@FechaMovimiento,
                    Observaciones=@Observaciones
                WHERE IdMovimiento=@IdMovimiento;";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdMovimiento", movimiento.Id);
                comando.Parameters.AddWithValue("@IdMaterial", movimiento.Material.IdMaterial);

                if (movimiento.Ticket == null)
                    comando.Parameters.AddWithValue("@IdTicket", DBNull.Value);
                else
                    comando.Parameters.AddWithValue("@IdTicket", movimiento.Ticket.Id);

                if (movimiento.Tecnico == null)
                    comando.Parameters.AddWithValue("@IdTecnico", DBNull.Value);
                else
                    comando.Parameters.AddWithValue("@IdTecnico", movimiento.Tecnico.Id);

                comando.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                comando.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                comando.Parameters.AddWithValue("@CostoUnitario", movimiento.CostoUnitario);
                comando.Parameters.AddWithValue("@FechaMovimiento", movimiento.Fecha);
                comando.Parameters.AddWithValue("@Observaciones", movimiento.Observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idMovimiento)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM MovimientosInventario
                                    WHERE IdMovimiento=@IdMovimiento";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdMovimiento", idMovimiento);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public MovimientoInventario ObtenerPorId(int idMovimiento)
        {
            MovimientoInventario movimiento = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM MovimientosInventario
                                    WHERE IdMovimiento=@IdMovimiento";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdMovimiento", idMovimiento);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    movimiento = new MovimientoInventario();

                    movimiento.Id = Convert.ToInt32(reader["IdMovimiento"]);

                    movimiento.Material = new Material();
                    movimiento.Material.IdMaterial = Convert.ToInt32(reader["IdMaterial"]);

                    if (reader["IdTicket"] != DBNull.Value)
                    {
                        movimiento.Ticket = new Ticket();
                        movimiento.Ticket.Id = Convert.ToInt32(reader["IdTicket"]);
                    }

                    if (reader["IdTecnico"] != DBNull.Value)
                    {
                        movimiento.Tecnico = new Tecnico();
                        movimiento.Tecnico.Id = Convert.ToInt32(reader["IdTecnico"]);
                    }

                    movimiento.TipoMovimiento = reader["TipoMovimiento"].ToString();
                    movimiento.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    movimiento.CostoUnitario = Convert.ToDecimal(reader["CostoUnitario"]);
                    movimiento.Fecha = Convert.ToDateTime(reader["FechaMovimiento"]);
                    movimiento.Observaciones = reader["Observaciones"].ToString();
                }
            }

            return movimiento;
        }

        public List<MovimientoInventario> ObtenerTodos()
        {
            List<MovimientoInventario> lista = new List<MovimientoInventario>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM MovimientosInventario";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    MovimientoInventario movimiento = new MovimientoInventario();

                    movimiento.Id = Convert.ToInt32(reader["IdMovimiento"]);

                    movimiento.Material = new Material();
                    movimiento.Material.IdMaterial = Convert.ToInt32(reader["IdMaterial"]);

                    if (reader["IdTicket"] != DBNull.Value)
                    {
                        movimiento.Ticket = new Ticket();
                        movimiento.Ticket.Id = Convert.ToInt32(reader["IdTicket"]);
                    }

                    if (reader["IdTecnico"] != DBNull.Value)
                    {
                        movimiento.Tecnico = new Tecnico();
                        movimiento.Tecnico.Id = Convert.ToInt32(reader["IdTecnico"]);
                    }

                    movimiento.TipoMovimiento = reader["TipoMovimiento"].ToString();
                    movimiento.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                    movimiento.CostoUnitario = Convert.ToDecimal(reader["CostoUnitario"]);
                    movimiento.Fecha = Convert.ToDateTime(reader["FechaMovimiento"]);
                    movimiento.Observaciones = reader["Observaciones"].ToString();

                    lista.Add(movimiento);
                }
            }

            return lista;
        }
    }
}
