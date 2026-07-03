using System;
using System.Collections.Generic;
using Proyecto1.Models;
using Proyecto1.Models.Enums;
using Proyecto1.Repositorios;
using Proyecto1.Repositorios.Interfaces;
using Proyecto1.Services.Interfaces;

namespace Proyecto1.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEquipoRepository _equipoRepository;
        private readonly IProblemaRepository _problemaRepository;
        private readonly IRecepcionistaRepository _recepcionistaRepository;
        private readonly ITecnicoRepository _tecnicoRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
            _equipoRepository = new EquipoRepository();
            _problemaRepository = new ProblemaRepository();
            _recepcionistaRepository = new RecepcionistaRepository();
            _tecnicoRepository = new TecnicoRepository();
        }

        public TicketService(
            ITicketRepository ticketRepository,
            IEquipoRepository equipoRepository,
            IProblemaRepository problemaRepository,
            IRecepcionistaRepository recepcionistaRepository,
            ITecnicoRepository tecnicoRepository)
        {
            if (ticketRepository == null)
                throw new ArgumentNullException(nameof(ticketRepository));

            if (equipoRepository == null)
                throw new ArgumentNullException(nameof(equipoRepository));

            if (problemaRepository == null)
                throw new ArgumentNullException(nameof(problemaRepository));

            if (recepcionistaRepository == null)
            {
                throw new ArgumentNullException(
                    nameof(recepcionistaRepository)
                );
            }

            if (tecnicoRepository == null)
                throw new ArgumentNullException(nameof(tecnicoRepository));

            _ticketRepository = ticketRepository;
            _equipoRepository = equipoRepository;
            _problemaRepository = problemaRepository;
            _recepcionistaRepository = recepcionistaRepository;
            _tecnicoRepository = tecnicoRepository;
        }

        public bool Registrar(Ticket ticket)
        {
            ValidarTicket(ticket);
            CargarReferencias(ticket);

            if (ticket.FechaIngreso == DateTime.MinValue)
            {
                ticket.FechaIngreso = DateTime.Now;
            }

            if (ticket.CostoEstimado == 0 &&
                ticket.Problema != null)
            {
                ticket.CostoEstimado =
                    ticket.Problema.CostoEstimado;
            }

            if (ticket.TecnicoAsignado != null &&
                !ticket.FechaAsignacionTecnico.HasValue)
            {
                ticket.FechaAsignacionTecnico = DateTime.Now;
            }

            if (ticket.Estado == EstadoTicket.Entregado &&
                !ticket.FechaEntrega.HasValue)
            {
                ticket.FechaEntrega = DateTime.Now;
            }

            return _ticketRepository.Insertar(ticket);
        }

        public bool Actualizar(Ticket ticket)
        {
            ValidarTicket(ticket);

            if (ticket.Id <= 0)
            {
                throw new ArgumentException(
                    "El identificador del ticket no es válido."
                );
            }

            Ticket ticketExistente =
                _ticketRepository.ObtenerPorId(ticket.Id);

            if (ticketExistente == null)
                return false;

            CargarReferencias(ticket);

            if (ticket.TecnicoAsignado != null &&
                !ticket.FechaAsignacionTecnico.HasValue)
            {
                ticket.FechaAsignacionTecnico = DateTime.Now;
            }

            if (ticket.Estado == EstadoTicket.Entregado)
            {
                if (!ticket.FechaEntrega.HasValue)
                {
                    ticket.FechaEntrega = DateTime.Now;
                }
            }
            else
            {
                ticket.FechaEntrega = null;
            }

            return _ticketRepository.Actualizar(ticket);
        }

        public bool Eliminar(int idTicket)
        {
            if (idTicket <= 0)
            {
                throw new ArgumentException(
                    "El identificador del ticket no es válido."
                );
            }

            Ticket ticket =
                _ticketRepository.ObtenerPorId(idTicket);

            if (ticket == null)
                return false;

            return _ticketRepository.Eliminar(idTicket);
        }

        public bool AsignarTecnico(
            int idTicket,
            Tecnico tecnico)
        {
            if (idTicket <= 0)
            {
                throw new ArgumentException(
                    "El identificador del ticket no es válido."
                );
            }

            if (tecnico == null || tecnico.Id <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionarse un técnico válido."
                );
            }

            Ticket ticket =
                _ticketRepository.ObtenerPorId(idTicket);

            if (ticket == null)
            {
                throw new InvalidOperationException(
                    "El ticket seleccionado no existe."
                );
            }

            if (ticket.Estado == EstadoTicket.Cancelado)
            {
                throw new InvalidOperationException(
                    "No se puede asignar un técnico a un ticket cancelado."
                );
            }

            if (ticket.Estado == EstadoTicket.Entregado)
            {
                throw new InvalidOperationException(
                    "No se puede asignar un técnico a un ticket entregado."
                );
            }

            Tecnico tecnicoExistente =
                _tecnicoRepository.ObtenerPorId(tecnico.Id);

            if (tecnicoExistente == null)
            {
                throw new InvalidOperationException(
                    "El técnico seleccionado no existe."
                );
            }

            ticket.TecnicoAsignado = tecnicoExistente;
            ticket.FechaAsignacionTecnico = DateTime.Now;

            if (ticket.Estado == EstadoTicket.EnEspera)
            {
                ticket.Estado = EstadoTicket.EnProgreso;
            }

            return _ticketRepository.Actualizar(ticket);
        }

        public bool CambiarEstado(
            int idTicket,
            EstadoTicket nuevoEstado)
        {
            if (idTicket <= 0)
            {
                throw new ArgumentException(
                    "El identificador del ticket no es válido."
                );
            }

            Ticket ticket =
                _ticketRepository.ObtenerPorId(idTicket);

            if (ticket == null)
            {
                throw new InvalidOperationException(
                    "El ticket seleccionado no existe."
                );
            }

            if (ticket.Estado == EstadoTicket.Cancelado &&
                nuevoEstado != EstadoTicket.Cancelado)
            {
                throw new InvalidOperationException(
                    "Un ticket cancelado no puede cambiar de estado."
                );
            }

            if (ticket.Estado == EstadoTicket.Entregado &&
                nuevoEstado != EstadoTicket.Entregado)
            {
                throw new InvalidOperationException(
                    "Un ticket entregado no puede cambiar de estado."
                );
            }

            if (nuevoEstado == EstadoTicket.EnProgreso &&
                ticket.TecnicoAsignado == null)
            {
                throw new InvalidOperationException(
                    "Debe asignarse un técnico antes de iniciar el trabajo."
                );
            }

            if (nuevoEstado == EstadoTicket.Entregado &&
                ticket.Estado != EstadoTicket.Terminado)
            {
                throw new InvalidOperationException(
                    "El ticket debe estar terminado antes de entregarse."
                );
            }

            ticket.Estado = nuevoEstado;

            if (nuevoEstado == EstadoTicket.Entregado)
            {
                ticket.FechaEntrega = DateTime.Now;
            }

            return _ticketRepository.Actualizar(ticket);
        }

        public Ticket ObtenerPorId(int idTicket)
        {
            if (idTicket <= 0)
            {
                throw new ArgumentException(
                    "El identificador del ticket no es válido."
                );
            }

            return _ticketRepository.ObtenerPorId(idTicket);
        }

        public List<Ticket> ObtenerTodos()
        {
            return _ticketRepository.ObtenerTodos();
        }

        private void ValidarTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            if (ticket.Equipo == null ||
                ticket.Equipo.Id <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionarse un equipo válido."
                );
            }

            if (ticket.Problema == null ||
                ticket.Problema.Id <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionarse un problema válido."
                );
            }

            if (ticket.Recepcionista == null ||
                ticket.Recepcionista.Id <= 0)
            {
                throw new ArgumentException(
                    "Debe asignarse un recepcionista válido."
                );
            }

            if (ticket.TecnicoAsignado != null &&
                ticket.TecnicoAsignado.Id <= 0)
            {
                throw new ArgumentException(
                    "El técnico asignado no es válido."
                );
            }

            if (string.IsNullOrWhiteSpace(
                ticket.DescripcionFalla))
            {
                throw new ArgumentException(
                    "Debe describirse la falla del equipo."
                );
            }

            if (string.IsNullOrWhiteSpace(ticket.Prioridad))
            {
                throw new ArgumentException(
                    "Debe indicarse la prioridad del ticket."
                );
            }

            if (ticket.CostoEstimado < 0)
            {
                throw new ArgumentException(
                    "El costo estimado no puede ser negativo."
                );
            }

            if (ticket.CostoFinal.HasValue &&
                ticket.CostoFinal.Value < 0)
            {
                throw new ArgumentException(
                    "El costo final no puede ser negativo."
                );
            }

            if (ticket.GarantiaDias < 0)
            {
                throw new ArgumentException(
                    "Los días de garantía no pueden ser negativos."
                );
            }

            ticket.DescripcionFalla =
                ticket.DescripcionFalla.Trim();

            if (ticket.Diagnostico != null)
                ticket.Diagnostico = ticket.Diagnostico.Trim();

            if (ticket.SolucionAplicada != null)
            {
                ticket.SolucionAplicada =
                    ticket.SolucionAplicada.Trim();
            }

            if (ticket.Observaciones != null)
            {
                ticket.Observaciones =
                    ticket.Observaciones.Trim();
            }
        }

        private void CargarReferencias(Ticket ticket)
        {
            Equipo equipo =
                _equipoRepository.ObtenerPorId(
                    ticket.Equipo.Id
                );

            if (equipo == null)
            {
                throw new InvalidOperationException(
                    "El equipo seleccionado no existe."
                );
            }

            Problema problema =
                _problemaRepository.ObtenerPorId(
                    ticket.Problema.Id
                );

            if (problema == null)
            {
                throw new InvalidOperationException(
                    "El problema seleccionado no existe."
                );
            }

            Recepcionista recepcionista =
                _recepcionistaRepository.ObtenerPorId(
                    ticket.Recepcionista.Id
                );

            if (recepcionista == null)
            {
                throw new InvalidOperationException(
                    "El recepcionista seleccionado no existe."
                );
            }

            ticket.Equipo = equipo;
            ticket.Problema = problema;
            ticket.Recepcionista = recepcionista;

            if (ticket.TecnicoAsignado != null)
            {
                Tecnico tecnico =
                    _tecnicoRepository.ObtenerPorId(
                        ticket.TecnicoAsignado.Id
                    );

                if (tecnico == null)
                {
                    throw new InvalidOperationException(
                        "El técnico seleccionado no existe."
                    );
                }

                ticket.TecnicoAsignado = tecnico;
            }
        }
    }
}