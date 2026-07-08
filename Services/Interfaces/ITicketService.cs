using System.Collections.Generic;
using Proyecto1.Models;
using Proyecto1.Models.Enums;

namespace Proyecto1.Services.Interfaces
{
    public interface ITicketService
    {
        bool Registrar(Ticket ticket);

        bool Actualizar(Ticket ticket);

        bool Eliminar(int idTicket);

        bool AsignarTecnico(int idTicket, Tecnico tecnico);

        bool CambiarEstado(
            int idTicket,
            EstadoTicket nuevoEstado
        );

        Ticket ObtenerPorId(int idTicket);

        List<Ticket> ObtenerTodos();
        List<Ticket> ObtenerPorTecnico(int idTecnico);
    }
}