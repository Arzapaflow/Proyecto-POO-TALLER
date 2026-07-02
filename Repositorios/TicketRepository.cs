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
    public class TicketRepository : ITicketRepository
    {
        #region Mapeo Estado

        private int ObtenerIdEstado(EstadoTicket estado)
        {
            switch (estado)
            {
                case EstadoTicket.EnEspera:
                    return 1;

                case EstadoTicket.EnProgreso:
                    return 5;

                case EstadoTicket.Terminado:
                    return 7;

                case EstadoTicket.Entregado:
                    return 9;

                case EstadoTicket.Cancelado:
                    return 10;

                default:
                    return 1;
            }
        }

        private EstadoTicket ObtenerEstado(int idEstado)
        {
            switch (idEstado)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    return EstadoTicket.EnEspera;

                case 5:
                case 6:
                    return EstadoTicket.EnProgreso;

                case 7:
                case 8:
                    return EstadoTicket.Terminado;

                case 9:
                    return EstadoTicket.Entregado;

                case 10:
                    return EstadoTicket.Cancelado;

                default:
                    return EstadoTicket.EnEspera;
            }
        }

        #endregion

        public bool Insertar(Ticket ticket)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                INSERT INTO Tickets
                (
                    IdEquipo,
                    IdProblema,
                    IdEstado,
                    IdRecepcionista,
                    IdTecnico,
                    DescripcionFalla,
                    Diagnostico,
                    SolucionAplicada,
                    Prioridad,
                    FechaIngreso,
                    FechaAsignacionTecnico,
                    FechaEntrega,
                    CostoEstimado,
                    CostoFinal,
                    GarantiaDias,
                    Observaciones
                )
                VALUES
                (
                    @IdEquipo,
                    @IdProblema,
                    @IdEstado,
                    @IdRecepcionista,
                    @IdTecnico,
                    @DescripcionFalla,
                    @Diagnostico,
                    @SolucionAplicada,
                    @Prioridad,
                    @FechaIngreso,
                    @FechaAsignacionTecnico,
                    @FechaEntrega,
                    @CostoEstimado,
                    @CostoFinal,
                    @GarantiaDias,
                    @Observaciones
                );";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdEquipo", ticket.Equipo.Id);
                comando.Parameters.AddWithValue("@IdProblema", ticket.Problema.Id);
                comando.Parameters.AddWithValue("@IdEstado", ObtenerIdEstado(ticket.Estado));
                comando.Parameters.AddWithValue("@IdRecepcionista", ticket.Recepcionista.Id);

                if (ticket.TecnicoAsignado == null)
                    comando.Parameters.AddWithValue("@IdTecnico", DBNull.Value);
                else
                    comando.Parameters.AddWithValue("@IdTecnico", ticket.TecnicoAsignado.Id);

                comando.Parameters.AddWithValue("@DescripcionFalla", ticket.DescripcionFalla);
                comando.Parameters.AddWithValue("@Diagnostico", ticket.Diagnostico);
                comando.Parameters.AddWithValue("@SolucionAplicada", ticket.SolucionAplicada);
                comando.Parameters.AddWithValue("@Prioridad", ticket.Prioridad);

                comando.Parameters.AddWithValue("@FechaIngreso", ticket.FechaIngreso);

                if (ticket.FechaAsignacionTecnico.HasValue)
                    comando.Parameters.AddWithValue("@FechaAsignacionTecnico", ticket.FechaAsignacionTecnico.Value);
                else
                    comando.Parameters.AddWithValue("@FechaAsignacionTecnico", DBNull.Value);

                if (ticket.FechaEntrega.HasValue)
                    comando.Parameters.AddWithValue("@FechaEntrega", ticket.FechaEntrega.Value);
                else
                    comando.Parameters.AddWithValue("@FechaEntrega", DBNull.Value);

                comando.Parameters.AddWithValue("@CostoEstimado", ticket.CostoEstimado);

                if (ticket.CostoFinal.HasValue)
                    comando.Parameters.AddWithValue("@CostoFinal", ticket.CostoFinal.Value);
                else
                    comando.Parameters.AddWithValue("@CostoFinal", DBNull.Value);

                comando.Parameters.AddWithValue("@GarantiaDias", ticket.GarantiaDias);
                comando.Parameters.AddWithValue("@Observaciones", ticket.Observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public bool Actualizar(Ticket ticket)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"
                UPDATE Tickets
                SET
                    IdEquipo=@IdEquipo,
                    IdProblema=@IdProblema,
                    IdEstado=@IdEstado,
                    IdRecepcionista=@IdRecepcionista,
                    IdTecnico=@IdTecnico,
                    DescripcionFalla=@DescripcionFalla,
                    Diagnostico=@Diagnostico,
                    SolucionAplicada=@SolucionAplicada,
                    Prioridad=@Prioridad,
                    FechaIngreso=@FechaIngreso,
                    FechaAsignacionTecnico=@FechaAsignacionTecnico,
                    FechaEntrega=@FechaEntrega,
                    CostoEstimado=@CostoEstimado,
                    CostoFinal=@CostoFinal,
                    GarantiaDias=@GarantiaDias,
                    Observaciones=@Observaciones
                WHERE IdTicket=@IdTicket;";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdTicket", ticket.Id);
                comando.Parameters.AddWithValue("@IdEquipo", ticket.Equipo.Id);
                comando.Parameters.AddWithValue("@IdProblema", ticket.Problema.Id);
                comando.Parameters.AddWithValue("@IdEstado", ObtenerIdEstado(ticket.Estado));
                comando.Parameters.AddWithValue("@IdRecepcionista", ticket.Recepcionista.Id);

                if (ticket.TecnicoAsignado == null)
                    comando.Parameters.AddWithValue("@IdTecnico", DBNull.Value);
                else
                    comando.Parameters.AddWithValue("@IdTecnico", ticket.TecnicoAsignado.Id);

                comando.Parameters.AddWithValue("@DescripcionFalla", ticket.DescripcionFalla);
                comando.Parameters.AddWithValue("@Diagnostico", ticket.Diagnostico);
                comando.Parameters.AddWithValue("@SolucionAplicada", ticket.SolucionAplicada);
                comando.Parameters.AddWithValue("@Prioridad", ticket.Prioridad);

                comando.Parameters.AddWithValue("@FechaIngreso", ticket.FechaIngreso);

                if (ticket.FechaAsignacionTecnico.HasValue)
                    comando.Parameters.AddWithValue("@FechaAsignacionTecnico", ticket.FechaAsignacionTecnico.Value);
                else
                    comando.Parameters.AddWithValue("@FechaAsignacionTecnico", DBNull.Value);

                if (ticket.FechaEntrega.HasValue)
                    comando.Parameters.AddWithValue("@FechaEntrega", ticket.FechaEntrega.Value);
                else
                    comando.Parameters.AddWithValue("@FechaEntrega", DBNull.Value);

                comando.Parameters.AddWithValue("@CostoEstimado", ticket.CostoEstimado);

                if (ticket.CostoFinal.HasValue)
                    comando.Parameters.AddWithValue("@CostoFinal", ticket.CostoFinal.Value);
                else
                    comando.Parameters.AddWithValue("@CostoFinal", DBNull.Value);

                comando.Parameters.AddWithValue("@GarantiaDias", ticket.GarantiaDias);
                comando.Parameters.AddWithValue("@Observaciones", ticket.Observaciones);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }
        public bool Eliminar(int idTicket)
        {
            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"DELETE FROM Tickets
                                    WHERE IdTicket = @IdTicket";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdTicket", idTicket);

                conexion.Open();

                return comando.ExecuteNonQuery() > 0;
            }
        }

        public Ticket ObtenerPorId(int idTicket)
        {
            Ticket ticket = null;

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Tickets
                                    WHERE IdTicket = @IdTicket";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdTicket", idTicket);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    ticket = new Ticket();

                    ticket.Id = Convert.ToInt32(reader["IdTicket"]);

                    ticket.Equipo = new Equipo();
                    ticket.Equipo.Id = Convert.ToInt32(reader["IdEquipo"]);

                    ticket.Problema = new Problema();
                    ticket.Problema.Id = Convert.ToInt32(reader["IdProblema"]);

                    ticket.Recepcionista = new Recepcionista();
                    ticket.Recepcionista.Id = Convert.ToInt32(reader["IdRecepcionista"]);

                    if (reader["IdTecnico"] != DBNull.Value)
                    {
                        ticket.TecnicoAsignado = new Tecnico();
                        ticket.TecnicoAsignado.Id = Convert.ToInt32(reader["IdTecnico"]);
                    }

                    ticket.Estado = ObtenerEstado(Convert.ToInt32(reader["IdEstado"]));

                    ticket.DescripcionFalla = reader["DescripcionFalla"].ToString();
                    ticket.Diagnostico = reader["Diagnostico"].ToString();
                    ticket.SolucionAplicada = reader["SolucionAplicada"].ToString();
                    ticket.Prioridad = reader["Prioridad"].ToString();
                    ticket.Observaciones = reader["Observaciones"].ToString();

                    ticket.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);

                    if (reader["FechaAsignacionTecnico"] != DBNull.Value)
                        ticket.FechaAsignacionTecnico =
                            Convert.ToDateTime(reader["FechaAsignacionTecnico"]);

                    if (reader["FechaEntrega"] != DBNull.Value)
                        ticket.FechaEntrega =
                            Convert.ToDateTime(reader["FechaEntrega"]);

                    ticket.CostoEstimado =
                        Convert.ToDecimal(reader["CostoEstimado"]);

                    if (reader["CostoFinal"] != DBNull.Value)
                        ticket.CostoFinal =
                            Convert.ToDecimal(reader["CostoFinal"]);

                    ticket.GarantiaDias =
                        Convert.ToInt32(reader["GarantiaDias"]);
                }
            }

            return ticket;
        }

        public List<Ticket> ObtenerTodos()
        {
            List<Ticket> lista = new List<Ticket>();

            using (SQLiteConnection conexion = ConexionBD.CrearConexion())
            {
                string consulta = @"SELECT *
                                    FROM Tickets";

                SQLiteCommand comando = new SQLiteCommand(consulta, conexion);

                conexion.Open();

                SQLiteDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Ticket ticket = new Ticket();

                    ticket.Id = Convert.ToInt32(reader["IdTicket"]);

                    ticket.Equipo = new Equipo();
                    ticket.Equipo.Id = Convert.ToInt32(reader["IdEquipo"]);

                    ticket.Problema = new Problema();
                    ticket.Problema.Id = Convert.ToInt32(reader["IdProblema"]);

                    ticket.Recepcionista = new Recepcionista();
                    ticket.Recepcionista.Id = Convert.ToInt32(reader["IdRecepcionista"]);

                    if (reader["IdTecnico"] != DBNull.Value)
                    {
                        ticket.TecnicoAsignado = new Tecnico();
                        ticket.TecnicoAsignado.Id = Convert.ToInt32(reader["IdTecnico"]);
                    }

                    ticket.Estado = ObtenerEstado(Convert.ToInt32(reader["IdEstado"]));

                    ticket.DescripcionFalla = reader["DescripcionFalla"].ToString();
                    ticket.Diagnostico = reader["Diagnostico"].ToString();
                    ticket.SolucionAplicada = reader["SolucionAplicada"].ToString();
                    ticket.Prioridad = reader["Prioridad"].ToString();
                    ticket.Observaciones = reader["Observaciones"].ToString();

                    ticket.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);

                    if (reader["FechaAsignacionTecnico"] != DBNull.Value)
                        ticket.FechaAsignacionTecnico =
                            Convert.ToDateTime(reader["FechaAsignacionTecnico"]);

                    if (reader["FechaEntrega"] != DBNull.Value)
                        ticket.FechaEntrega =
                            Convert.ToDateTime(reader["FechaEntrega"]);

                    ticket.CostoEstimado =
                        Convert.ToDecimal(reader["CostoEstimado"]);

                    if (reader["CostoFinal"] != DBNull.Value)
                        ticket.CostoFinal =
                            Convert.ToDecimal(reader["CostoFinal"]);

                    ticket.GarantiaDias =
                        Convert.ToInt32(reader["GarantiaDias"]);

                    lista.Add(ticket);
                }
            }

            return lista;
        }
    }
}
