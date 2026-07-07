using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Models;

namespace Proyecto1.Repositorios.Interfaces
{
    public interface ITicketRepository
    {
        bool Insertar(Ticket ticket);

        bool Actualizar(Ticket ticket);

        bool Eliminar(int idTicket);

        Ticket ObtenerPorId(int idTicket);

        List<Ticket> ObtenerTodos();

        List<Ticket> ObtenerPorTecnico(int idTecnico);
    }
}
